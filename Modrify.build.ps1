param (
    [version]$Version = '0.0.2',
    [string]$NugetApiKey,
    [ValidateScript({
        (Get-ChildItem "$PSScriptRoot/Modrify*" -Directory).Name -contains $_
        })]
    [string]$Module
)
$modules = [ordered]@{}
$basePath = $PSScriptRoot
Get-ChildItem "$basePath/Modrify*" -Directory | Sort-Object | ForEach-Object {
    $modules[$_.Name] = @{
        basePath    = "$basePath\$($_.Name)"
        docPath     = "$basePath\$($_.Name)\docs"
        testPath    = "$basePath\$($_.Name)\tests"
        moduleName  = $_.Name
        modulePath  = "$basePath\build\$($_.Name)"
        isSubModule = $_.Name -eq 'Modrify' ? $false : $true
    }
}

Write-Host "Version: $($version)"

# Clean out any previous builds
task Clean {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Cleaning $m..."
        if (Get-Module $modules[$m].moduleName) {
            Remove-Module $modules[$m].moduleName
        }
        if (Test-Path $modules[$m].modulePath) {
            Remove-Item $modules[$m].modulePath -Recurse -ErrorAction Ignore | Out-Null
        }
    }
}

# Build the docs, depends on PlatyPS
task DocBuild, Clean, dotnetBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        if (-not (Test-Path $modules[$m].docPath)) {
            New-Item $modules[$m].docPath -ItemType Directory
        }
        Write-Host "Building docs for $m..."
        New-ExternalHelp $modules[$m].docPath -OutputPath "$($modules[$m].modulePath)\EN-US"
    }
}

task dotnetBuild {
    dotnet clean
    dotnet restore
    dotnet publish
    #Set-Location $PSScriptRoot

    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Building $m..."
        if (-not (Test-Path "$($modules[$m].modulePath)\lib" -PathType Container)) {
            New-Item "$($modules[$m].modulePath)\lib" -ItemType Directory | Out-Null
        }
        $filesToSkip = if ($modules[$m].isSubModule) {
            Get-ChildItem "$PSScriptRoot\build\Modrify\lib\*.dll"
        }
        Get-ChildItem "$($modules[$m].basePath)\bin\Debug\net7.0\publish\*.dll" | ForEach-Object {
            if ($filesToSkip.Name -notcontains $_.Name) {
                Copy-Item $_.FullName -Destination "$($modules[$m].modulePath)\lib\" -Force
            }
        }

        Move-Item "$($modules[$m].modulePath)\lib\$m.dll" -Destination $($modules[$m].modulePath) -Force

        if (Test-Path "$($modules[$m].modulePath)\lib\Modrify.dll") {
            Remove-Item "$($modules[$m].modulePath)\lib\Modrify.dll" -Force
        }
    }
}

task GenerateFormats {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Generating formats for $m..."
        # Generate the formats
        & "$($modules[$m].basePath)\$($modules[$m].moduleName).ezout.ps1" -RelativeDestination "../build/$($modules[$m].moduleName)" | Out-Null
    }
}

# Build the module
task ModuleBuild Clean, dotnetBuild, GenerateFormats, DocBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Building the manifest for $m..."
        # Get exported functions
        if ($modules[$m].isSubModule) {
            $commands = & pwsh -NonInteractive -NoProfile -ExecutionPolicy Bypass -Command "`$PSStyle.OutputRendering = [System.Management.Automation.OutputRendering]::PlainText;gci '$basePath\build\Modrify\lib\*.dll' | %{Add-Type -Path `$_.FullName};gci '$($modules[$m].modulePath)\lib\*.dll' | %{Add-Type -Path `$_.FullName};Import-Module '$basePath\Build\Modrify\Modrify.dll';Import-Module '$($modules[$m].modulePath)\$m.dll';(Get-Command -Module $m).Name"
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
                ModuleName = 'Modrify'
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
    <#foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Importing module."
        Import-Module $modules[$m].modulePath -RequiredVersion $version
        Write-Host "Invoking tests."
        Invoke-Pester $modules[$m].testPath -Verbose
    }#>
}

task Publish Test, DocBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Publishing $m..."
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