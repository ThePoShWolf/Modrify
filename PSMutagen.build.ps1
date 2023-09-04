param (
    [version]$Version = '0.0.1',
    [string]$NugetApiKey,
    [ValidateScript({
        (Get-ChildItem "$PSScriptRoot/PSMutagen*" -Directory).Name -contains $_
        })]
    [string]$Module
)
$modules = [ordered]@{}
Get-ChildItem "$PSScriptRoot/PSMutagen*" -Directory | Sort-Object | ForEach-Object {
    $modules[$_.Name] = @{
        basePath    = "$PSScriptRoot\$($_.Name)"
        srcPath     = "$PSScriptRoot\$($_.Name)\src"
        docPath     = "$PSScriptRoot\$($_.Name)\docs"
        testPath    = "$PSScriptRoot\$($_.Name)\tests"
        moduleName  = $_.Name
        modulePath  = "$PSScriptRoot\$($_.Name)\build\$($_.Name)"
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

task UpdateDependencies {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Set-Location $modules[$m].srcPath
        dotnet restore
        dotnet build
        Set-Location $PSScriptRoot

        # Copy the dependency .dlls
        if (-not (Test-Path "$($modules[$m].modulePath)\lib" -PathType Container)) {
            New-Item "$($modules[$m].modulePath)\lib" -ItemType Directory
        }
        $filesToSkip = if ($modules[$m].isSubModule) {
            Get-ChildItem "$PSScriptRoot\PSMutagen\build\PSMutagen\lib\*.dll"
        }
        Get-ChildItem "$($modules[$m].srcPath)\bin\Debug\*.dll" | Where-Object { $_.Name -notlike "$($modules[$m].moduleName).dependencies*" -and $filesToSkip.Name -notcontains $_.Name } | ForEach-Object {
            Move-Item $_.FullName -Destination "$($modules[$m].modulePath)\lib\" -Force
        }
    }
}

task BuildModuleFile {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        $moduleScriptFiles = Get-ChildItem $modules[$m].srcPath -Filter *.ps1 -File -Recurse
        $psm1Path = "$($modules[$m].modulePath)\$($modules[$m].moduleName).psm1"
        if (-not(Test-Path $modules[$m].modulePath)) {
            New-Item $modules[$m].modulePath -ItemType Directory
        }

        # Add using.ps1 to the .psm1 first
        foreach ($file in $moduleScriptFiles | Where-Object { $_.Name -eq 'using.ps1' }) {
            if ($file.fullname) {
                Write-Host "Adding using file: '$($file.Fullname)'"
                Get-Content $file.fullname | Out-File $psm1Path -Append -Encoding utf8
            }
        }

        # Add all .ps1 files to the .psm1, skipping onload.ps1, using.ps1, and any tests
        foreach ($file in $moduleScriptFiles | Where-Object { $_.Name -ne 'onload.ps1' -and $_.Name -ne 'using.ps1' -and $_.FullName -notmatch '(\\|\/)tests(\\|\/)[^\.]+\.tests\.ps1$' }) {
            if ($file.fullname) {
                Write-Host "Adding function file: '$($file.FullName)'"
                Get-Content $file.fullname | Out-File $psm1Path -Append -Encoding utf8
            }
        }
    
        # Add the onload.ps1 files last
        foreach ($file in $moduleScriptFiles | Where-Object { $_.Name -eq 'onload.ps1' }) {
            if ($file.fullname) {
                Write-Host "Adding onload file: '$($file.FullName)'"
                Get-Content $file.fullname | Out-File $psm1Path -Append -Encoding utf8
            }
        }

        # Copy the tests
        foreach ($test in ($moduleScriptFiles | Where-Object { $_.FullName -match '(\\|\/)tests(\\|\/)[^\.]+\.tests\.ps1$' })) {
            Write-Host "Copying test file: '$($test.FullName)'"
            Copy-Item $test.FullName -Destination $modules[$m].modulePath
        }
    }
}

task GenerateFormats {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        # Generate the formats
        & "$($modules[$m].basePath)\$($modules[$m].moduleName).ezout.ps1" -RelativeDestination "build/$($modules[$m].moduleName)"
    }
}

# Build the module
task ModuleBuild Clean, UpdateDependencies, BuildModuleFile, GenerateFormats, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        # Copy the manifest
        Copy-Item "$($modules[$m].srcPath)\$($modules[$m].moduleName).psd1" -Destination $modules[$m].modulePath

        $moduleScriptFiles = Get-ChildItem $modules[$m].srcPath -Filter *.ps1 -File -Recurse

        $moduleManifestData = @{
            Path              = "$($modules[$m].modulePath)\$($modules[$m].moduleName).psd1"
            # Only export the public files
            FunctionsToExport = ($moduleScriptFiles | Where-Object { $_.FullName -match "(\\|\/)public(\\|\/)[^\.]+\.ps1$" }).basename
            ModuleVersion     = $version
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