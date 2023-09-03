Function New-SkyrimMod {
    [cmdletbinding([Mutagen.Bethesda.Skyrim.SkyrimMod])]
    [OutputType()]
    param (
        [Mutagen.Bethesda.Plugins.ModKey]$ModKey,
        [Mutagen.Bethesda.Skyrim.SkyrimRelease]$GameRelease = $MutagenGameEnvironment.GameRelease
    )
    [Mutagen.Bethesda.Skyrim.SkyrimMod]::new($ModKey, $GameRelease)
}