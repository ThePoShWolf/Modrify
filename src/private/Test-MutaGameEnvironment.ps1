Function Test-MutaGameEnvironment {
    [OutputType([bool])]
    [cmdletbinding()]
    param (

    )
    if (-not (Get-Variable MutagenGameEnvironment -Scope Script -ErrorAction SilentlyContinue)) {
        return $false
    }
    return $true
}