Function Get-MutaModMajorRecords {
    [OutputType([Mutagen.Bethesda.Plugins.Records.MajorRecord[]])]
    [cmdletbinding()]
    param (
        [Parameter(
            Mandatory
        )]
        [Mutagen.Bethesda.Plugins.Records.AMod]$Mod
    )
    switch -regex ($Mod.GameRelease) {
        '^Skyrim' {
            $([Mutagen.Bethesda.Skyrim.SkyrimModMixIn]::EnumerateMajorRecords($mod))
        }
        '^Fallout' {
            $([Mutagen.Bethesda.Fallout4.Fallout4ModMixIn]::EnumerateMajorRecords($mod))
        }
    }
}