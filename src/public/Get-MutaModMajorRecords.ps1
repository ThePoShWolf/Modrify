Function Get-MutaModMajorRecords {
    [OutputType([Mutagen.Bethesda.Plugins.Records.SkyrimMajorRecord[]])]
    [cmdletbinding()]
    param (
        [Mutagen.Bethesda.Plugins.Records.AMod]$Mod
    )
    $([Mutagen.Bethesda.Skyrim.SkyrimModMixIn]::EnumerateMajorRecords($mod))
}