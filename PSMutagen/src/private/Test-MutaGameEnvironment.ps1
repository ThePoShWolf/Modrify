Function Test-MutaGameEnvironment {
    [OutputType([bool])]
    [cmdletbinding()]
    param (

    )
    if (-not (Get-Variable MutagenGameEnvironment -Scope Global -ErrorAction SilentlyContinue)) {
        Throw 'Please run Set-MutaGameEnvironment first.'
    }
}