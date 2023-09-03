Function Get-MutaGameEnvironment {
    [cmdletbinding()]
    param (

    )
    if (Test-MutaGameEnvironment) {
        $MutagenGameEnvironment
    } else {
        Write-Warning "First set your game environment with 'Set-MutaGameEnvironment'"
    }
}