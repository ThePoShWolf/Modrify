Function New-FalloutMod {
    [OutputType([Mutagen.Bethesda.Fallout4.Fallout4Mod])]
    [cmdletbinding()]
    param (
        [Mutagen.Bethesda.Plugins.ModKey]$ModKey
    )
    Begin {}
    Process {
        [Mutagen.Bethesda.Fallout4.Fallout4Mod]::new($ModKey)
    }
    End {}
}