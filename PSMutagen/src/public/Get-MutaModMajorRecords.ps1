Function Get-MutaModMajorRecords {
    [OutputType([Mutagen.Bethesda.Plugins.Records.MajorRecord[]])]
    [cmdletbinding()]
    param (
        [Parameter(
            Mandatory,
            ValueFromPipeline
        )]
        [Mutagen.Bethesda.Plugins.Records.IModGetter]$Mod,
        [string]$Type
    )
    Begin {
        Test-MutaGameEnvironment
        if ($PSBoundParameters.Keys -contains 'Type') {
            $typeName = Switch -Regex ($MutagenGameEnvironment.GameRelease) {
                '^Skyrim' {
                    "Mutagen.Bethesda.Skyrim.I$Type`Getter"
                }
                '^Fallout' {
                    "Mutagen.Bethesda.Fallout4.I$Type`Getter"
                }
            }
        }
    }
    Process {
        switch -regex ($Mod.GameRelease) {
            '^Skyrim' {
                if ($PSBoundParameters.Keys -contains 'Type') {
                    $([Mutagen.Bethesda.Skyrim.SkyrimModMixIn]::EnumerateMajorRecords($mod, $typeName))
                } else {
                    $([Mutagen.Bethesda.Skyrim.SkyrimModMixIn]::EnumerateMajorRecords($mod))
                }
            }
            '^Fallout' {
                if ($PSBoundParameters.Keys -contains 'Type') {
                    $([Mutagen.Bethesda.Fallout4.Fallout4ModMixIn]::EnumerateMajorRecords($mod, $typeName))
                } else {
                    $([Mutagen.Bethesda.Fallout4.Fallout4ModMixIn]::EnumerateMajorRecords($mod))
                }
            }
        }
    }
    End {}
}