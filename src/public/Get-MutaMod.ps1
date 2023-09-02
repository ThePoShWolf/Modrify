Function Get-MutaMod {
    [OutputType([Mutagen.Bethesda.Skyrim.SkyrimMod])]
    [cmdletbinding()]
    param (
        [Mutagen.Bethesda.Plugins.ModPath]$Path,
        [Mutagen.Bethesda.GameRelease]$Release = $MutagenGameEnvironment.GameRelease
    )
    [Mutagen.Bethesda.Skyrim.SkyrimMod]::CreateFromBinary($Path, $Release)
}