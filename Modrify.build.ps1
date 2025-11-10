param (
    [version]$Version = '0.1.0',
    [string]$NugetApiKey,
    [ValidateScript({
            (Get-ChildItem "$PSScriptRoot/Modrify*" -Directory).Name -contains "$_.Cmdlets"
        })]
    [string]$Module
)
$modules = [ordered]@{}
$basePath = $PSScriptRoot
$dotnetConfiguration = 'Release'
$dotnetVersion = "net8.0"

# Handle the new ALC architecture where modules have .Cmdlets and .Engine projects
$moduleConfigs = @{
    'Modrify.Skyrim'   = @{
        cmdletsPath = "$basePath\Modrify.Skyrim.Cmdlets"
        enginePath  = "$basePath\Modrify.Skyrim.Engine"
    }
    'Modrify.Fallout4' = @{
        cmdletsPath = "$basePath\Modrify.Fallout4.Cmdlets"
        enginePath  = "$basePath\Modrify.Fallout4.Engine"
    }
}

foreach ($moduleName in $moduleConfigs.Keys) {
    $config = $moduleConfigs[$moduleName]
    
    # Check if the new structure exists (cmdlets + engine) or fall back to legacy
    if (Test-Path $config.cmdletsPath) {
        $modules[$moduleName] = @{
            basePath   = $config.cmdletsPath
            enginePath = $config.enginePath
            docPath    = "$($config.cmdletsPath)\docs"
            testPath   = "$($config.cmdletsPath)\tests"
            moduleName = $moduleName
            modulePath = "$basePath\build\$moduleName"
        }
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
            Remove-Module $modules[$m].moduleName -Force
        }
        if (Test-Path $modules[$m].modulePath) {
            Remove-Item $modules[$m].modulePath -Recurse -ErrorAction Ignore | Out-Null
        }
    }
}

# Build the docs, depends on PlatyPS
task DocBuild Clean, dotnetBuild, {
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
    
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Building $m..."
        # Build the new ALC architecture (cmdlets + engine)
        Write-Host "  Building engine assembly..."
        dotnet build "$($modules[$m].enginePath)" --configuration $dotnetConfiguration
            
        Write-Host "  Building cmdlets assembly..."
        dotnet build "$($modules[$m].basePath)" --configuration $dotnetConfiguration
            
        # Create module structure
        if (-not (Test-Path $modules[$m].modulePath -PathType Container)) {
            New-Item $modules[$m].modulePath -ItemType Directory | Out-Null
        }
            
        # Copy the main cmdlets DLL to the module root
        $cmdletsDll = "$($modules[$m].basePath)\bin\$dotnetConfiguration\$dotnetVersion\$($modules[$m].moduleName).Cmdlets.dll"
        if (Test-Path $cmdletsDll) {
            Copy-Item $cmdletsDll -Destination "$($modules[$m].modulePath)\$($modules[$m].moduleName).dll" -Force
        }
            
        # Copy the lib folder (created by MSBuild target or manual copy)
        $dependenciesSource = "$($modules[$m].basePath)\bin\$dotnetConfiguration\$dotnetVersion"
        $dependenciesTarget = "$($modules[$m].modulePath)\lib"
        if (Test-Path $dependenciesSource) {
            if (Test-Path $dependenciesTarget) {
                Remove-Item $dependenciesTarget -Recurse -Force
            }

            $skip = @(
                'System.Collections.Immutable',
                'System.Text.Encoding.CodePages'
            )
            #Get-ChildItem $dependenciesSource
            Get-ChildItem $dependenciesSource | Where-Object { $skip -notcontains $_.BaseName } | ForEach-Object {
                #Write-Host "$($_.FullName) -> $dependenciesTarget"
                Copy-Item $_.FullName -Destination $dependenciesTarget
            }#>
            #Copy-Item $dependenciesSource -Destination $dependenciesTarget -Recurse -Force
            Write-Host "  Copied lib folder with $(Get-ChildItem $dependenciesTarget | Measure-Object | Select-Object -ExpandProperty Count) files"
        }
    }
}

task GenerateFormats {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Generating formats for $m..."
        
        # Look for .ezout.ps1 files in the appropriate location
        $ezoutScript = $null
        # For ALC modules, try cmdlets path first, then legacy path
        $ezoutScript = "$($modules[$m].basePath)\$($modules[$m].moduleName).Cmdlets.ezout.ps1"
        if ($ezoutScript -and (Test-Path $ezoutScript)) {
            # Generate the formats
            & $ezoutScript -RelativeDestination "../build/$($modules[$m].moduleName)" | Out-Null
        } else {
            Write-Warning "No .ezout.ps1 script found for $m"
        }
    }
}

# Build the module
task ModuleBuild Clean, dotnetBuild, GenerateFormats, DocBuild, {
    foreach ($m in $modules.Keys) {
        if ((-not [string]::IsNullOrEmpty($module)) -and $m -ne $module) {
            continue
        }
        Write-Host "Building the manifest for $m..."
        
        # Find and copy the manifest
        $manifestSource = $null
        # For ALC modules, try cmdlets path first, then legacy path
        $manifestSource = "$($modules[$m].basePath)\$($modules[$m].moduleName).Cmdlets.psd1"
        
        if ($manifestSource -and (Test-Path $manifestSource)) {
            Copy-Item $manifestSource -Destination "$($modules[$m].modulePath)\$($modules[$m].moduleName).psd1" -Force
        } else {
            Write-Error "Could not find manifest file for $m"
            continue
        }
        
        # Get exported functions
        # For ALC modules, import the cmdlets assembly directly
        $commands = & pwsh -NonInteractive -NoProfile -ExecutionPolicy Bypass -Command "`$PSStyle.OutputRendering = [System.Management.Automation.OutputRendering]::PlainText;Import-Module '$($modules[$m].modulePath)\$m.dll' -Force;(Get-Command -Module $m).Name"
        
        # Copy the manifest
        Copy-Item "$($modules[$m].basePath)\$($modules[$m].moduleName).Cmdlets.psd1" -Destination $modules[$m].modulePath -Force

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

task QuickBuild QuickClean, dotnetBuild, GenerateFormats

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