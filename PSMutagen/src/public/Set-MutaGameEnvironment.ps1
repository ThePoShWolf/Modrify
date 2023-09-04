Function Set-MutaGameEnvironment {
    [OutputType([Mutagen.Bethesda.Environments.IGameEnvironment], ParameterSetName = 'passthru')]
    [cmdletbinding(
        DefaultParameterSetName = 'silent'
    )]
    param (
        [Parameter(
            Mandatory,
            Position = 0
        )]
        [Mutagen.Bethesda.GameRelease]$Release,
        [Parameter(
            Mandatory,
            ParameterSetName = 'passthru'
        )]
        [switch]$Passthru
    )
    $env:MutagenGameEnvironment = [Mutagen.Bethesda.Environments.GameEnvironment]::Typical.Construct($Release)
    if ($Passthru.IsPresent) {
        $MutagenGameEnvironment
    }
}