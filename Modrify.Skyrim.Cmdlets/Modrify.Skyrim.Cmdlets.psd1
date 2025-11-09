@{
    # Script module or binary module file associated with this manifest.
    RootModule             = 'Modrify.Skyrim.dll'

    # Version number of this module.
    ModuleVersion          = '0.43.3'

    # Supported PSEditions
    CompatiblePSEditions   = @('Core')

    # ID used to uniquely identify this module
    GUID                   = 'b8f6d98c-1234-5678-9abc-def123456789'

    # Author of this module
    Author                 = 'Modrify'

    # Company or vendor of this module
    CompanyName            = 'Modrify'

    # Copyright statement for this module
    Copyright              = '(c) Modrify. All rights reserved.'

    # Description of the functionality provided by this module
    Description            = 'PowerShell module for working with Skyrim mods using Mutagen (.NET 8.0). Requires PowerShell 7.4+ for full compatibility.'

    # Minimum version of the PowerShell engine required by this module
    PowerShellVersion      = '7.4'

    # Minimum version of the common language runtime (CLR) required by this module
    CLRVersion             = '2.0'

    # Minimum version of Microsoft .NET Framework required by this module
    DotNetFrameworkVersion = '8.0'

    # Cmdlets to export from this module, for best performance, do not use wildcards and do not delete the entry
    CmdletsToExport        = @(
        'Get-SkyrimMod',
        'New-SkyrimMod', 
        'Write-SkyrimMod',
        'Get-SkyrimMajorRecords',
        'Get-SkyrimWinningOverrides',
        'Set-SkyrimGame',
        'Get-SkyrimGame'
    )

    # Variables to export from this module
    VariablesToExport      = @()

    # Aliases to export from this module, for best performance, do not use wildcards and do not delete the entry
    AliasesToExport        = @()

    # Functions to export from this module, for best performance, do not use wildcards and do not delete the entry
    FunctionsToExport      = @()

    # Private data to pass to the module specified in RootModule/ModuleToProcess
    PrivateData            = @{
        PSData = @{
            # Tags applied to this module. These help with module discovery in online galleries.
            Tags       = @('Skyrim', 'Modding', 'Mutagen', 'PowerShell', 'Gaming')

            # A URL to the license for this module.
            LicenseUri = 'https://github.com/antwon42/Modrify/blob/main/LICENSE'

            # A URL to the main website for this project.
            ProjectUri = 'https://github.com/antwon42/Modrify'

            # A URL to an icon representing this module.
            # IconUri = ''

            # ReleaseNotes of this module
            # ReleaseNotes = ''
        }
    }
}