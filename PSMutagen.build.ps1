param (
    [version]$Version = '0.0.1',
    [string]$NugetApiKey,
    [ValidateScript({
        (Get-ChildItem "$PSScriptRoot/PSMutagen*" -Directory).Name -contains $_
        })]
    [string]$Module
)
$modules = [ordered]@{}
$basePath = $PSScriptRoot
Get-ChildItem "$basePath/PSMutagen*" -Directory | Sort-Object | ForEach-Object {
    $modules[$_.Name] = @{
        basePath    = "$basePath\$($_.Name)"
        docPath     = "$basePath\$($_.Name)\docs"
        testPath    = "$basePath\$($_.Name)\tests"
        moduleName  = $_.Name
        modulePath  = "$basePath\build\$($_.Name)"
        isSubModule = $_.Name -eq 'PSMutagen' ? $false : $true
    }
}

Write-Host "Version: $($version)"

# Clean out any previous builds
task Clean {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        if (Get-Module $modules[$m].moduleName) {
            Remove-Module $modules[$m].moduleName
        }
        if (Test-Path $modules[$m].modulePath) {
            Remove-Item $modules[$m].modulePath -Recurse -ErrorAction Ignore | Out-Null
        }
    }
}

# Build the docs, depends on PlatyPS
task DocBuild ModuleBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        if (-not (Test-Path $modules[$m].docPath)) {
            New-Item $modules[$m].docPath -ItemType Directory
        }
        New-ExternalHelp $modules[$m].docPath -OutputPath "$($modules[$m].modulePath)\EN-US"
    }
}

task dotnetBuild {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Set-Location $modules[$m].basePath
        dotnet restore
        dotnet publish -o build
        Set-Location $PSScriptRoot

        # Copy the dependency .dlls
        if (-not (Test-Path "$($modules[$m].modulePath)\lib" -PathType Container)) {
            New-Item "$($modules[$m].modulePath)\lib" -ItemType Directory
        }
        $filesToSkip = if ($modules[$m].isSubModule) {
            Get-ChildItem "$PSScriptRoot\build\PSMutagen\lib\*.dll"
        }
        Get-ChildItem "$($modules[$m].basePath)\build\*.dll" | ForEach-Object {
            if ($filesToSkip.Name -notcontains $_.Name) {
                Copy-Item $_.FullName -Destination "$($modules[$m].modulePath)\lib\" -Force
            } else {
                Remove-Item $_.FullName -Force
            }
        }

        Move-Item "$($modules[$m].modulePath)\lib\$m.dll" -Destination $($modules[$m].modulePath) -Force

        if (Test-Path "$($modules[$m].modulePath)\lib\PSMutagen.dll") {
            Remove-Item "$($modules[$m].modulePath)\lib\PSMutagen.dll" -Force
        }
    }
}

task GenerateFormats {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        # Generate the formats
        & "$($modules[$m].basePath)\$($modules[$m].moduleName).ezout.ps1" -RelativeDestination "../build/$($modules[$m].moduleName)"
    }
}

# Build the module
task ModuleBuild Clean, dotnetBuild, GenerateFormats, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }

        # Get exported functions
        if ($modules[$m].isSubModule) {
            $commands = & pwsh -NonInteractive -NoProfile -ExecutionPolicy Bypass -Command "`$PSStyle.OutputRendering = [System.Management.Automation.OutputRendering]::PlainText;gci '$basePath\build\PSMutagen\lib\*.dll' | %{Add-Type -Path `$_.FullName};gci '$($modules[$m].modulePath)\lib\*.dll' | %{Add-Type -Path `$_.FullName};Import-Module '$basePath\Build\PSMutagen\PSMutagen.dll';Import-Module '$($modules[$m].modulePath)\$m.dll';(Get-Command -Module $m).Name"
        } else {
            $commands = & pwsh -NonInteractive -NoProfile -ExecutionPolicy Bypass -Command "`$PSStyle.OutputRendering = [System.Management.Automation.OutputRendering]::PlainText;gci '$($modules[$m].modulePath)\lib\*.dll' | %{Add-Type -Path `$_.FullName};Import-Module '$($modules[$m].modulePath)\$m.dll';(Get-Command -Module $m).Name"
        }

        # Copy the manifest
        Copy-Item "$($modules[$m].basePath)\$($modules[$m].moduleName).psd1" -Destination $modules[$m].modulePath -Force

        $moduleManifestData = @{
            Path               = "$($modules[$m].modulePath)\$($modules[$m].moduleName).psd1"
            # Only export the public files
            FunctionsToExport  = $commands
            ModuleVersion      = $version
            RequiredAssemblies = (Get-ChildItem "$($modules[$m].modulePath)\lib\*.dll" | ForEach-Object { "lib/$($_.Name)" })
            <#RequiredModules   = @{
                ModuleName = 'PSMutagen'
                RequiredVersion = [version]'0.0.1'
            }#>
        }
        if ($null -ne $preRelease) {
            $moduleManifestData['Prerelease'] = $preRelease
        }
        if (Test-Path "$($modules[$m].modulePath)\$($modules[$m].moduleName).format.ps1xml") {
            $moduleManifestData['FormatsToProcess'] = "$($modules[$m].moduleName).format.ps1xml"
        }
        Update-ModuleManifest @moduleManifestData
    }
}

task Test ModuleBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Importing module."
        Import-Module $modules[$m].modulePath -RequiredVersion $version
        Write-Host "Invoking tests."
        Invoke-Pester $modules[$m].testPath -Verbose
    }
}

task Publish Test, DocBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        if ($null -ne $NugetApiKey) {
            Publish-Module -Path $modules[$m].modulePath -NuGetApiKey $NugetApiKey -Repository PsGallery
        }
    }
}

task QuickClean {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        if (Get-Module $modules[$m].moduleName) {
            Remove-Module $modules[$m].moduleName
        }
        $psm1Path = "$($modules[$m].modulePath)\$($modules[$m].moduleName).psm1"
        if (Test-Path $psm1Path) {
            Remove-Item $psm1Path -Force -ErrorAction Ignore | Out-Null
        }
    }
}

task QuickBuild QuickClean, BuildModuleFile, GenerateFormats

task QuickReimport QuickBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        if (Test-Path $modules[$m].modulePath) {
            Import-Module $modules[$m].modulePath
        }
    }
}

task All ModuleBuild, Publish