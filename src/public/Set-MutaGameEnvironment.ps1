Function Set-MutaGameEnvironment {
    [OutputType([Mutagen.Bethesda.Environments.GameEnvironmentState], ParameterSetName = 'passthru')]
    [cmdletbinding()]
    param (
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