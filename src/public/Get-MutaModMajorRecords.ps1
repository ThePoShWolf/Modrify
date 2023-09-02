Function Get-MutaModMajorRecords {
    [OutputType([System.Collections.Generic.IEnumerable[Mutagen.Bethesda.Plugins.Records.IMajorRecord]])]
    [cmdletbinding()]
    param (
        [Mutagen.Bethesda.Plugins.Records.AMod]$Mod
    )
    $([Mutagen.Bethesda.Skyrim.SkyrimModMixIn]::EnumerateMajorRecords($mod))
}