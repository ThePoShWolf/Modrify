Function New-FalloutMod {
    [cmdletbinding([Mutagen.Bethesda.Fallout4.Fallout4Mod])]
    [OutputType()]
    param (
        [Mutagen.Bethesda.Plugins.ModKey]$ModKey
    )
    [Mutagen.Bethesda.Fallout4.Fallout4Mod]::new($ModKey)
}