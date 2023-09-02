Function Set-MutaGameEnvironment {
    [OutputType([Mutagen.Bethesda.Environments.IGameEnvironment], ParameterSetName = 'passthru')]
    [cmdletbinding()]
    param (
        [Parameter(
            Position = 0
        )]
        [Mutagen.Bethesda.GameRelease]$Release,
        [Parameter(
            ParameterSetName = 'passthru'
        )]
        [switch]$Passthru
    )
    $script:MutagenGameEnvironment = [Mutagen.Bethesda.Environments.GameEnvironment]::Typical.Construct($Release)
    if ($Passthru.IsPresent) {
        $MutagenGameEnvironment
    }
}