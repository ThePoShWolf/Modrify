Function New-SkyrimMod {
    [OutputType([Mutagen.Bethesda.Skyrim.SkyrimMod])]
    [cmdletbinding()]
    param (
        [Mutagen.Bethesda.Plugins.ModKey]$ModKey,
        [Mutagen.Bethesda.Skyrim.SkyrimRelease]$GameRelease = $MutagenGameEnvironment.GameRelease
    )
    Begin {}
    Process {
        [Mutagen.Bethesda.Skyrim.SkyrimMod]::new($ModKey, $GameRelease)
    }
    End {}
}