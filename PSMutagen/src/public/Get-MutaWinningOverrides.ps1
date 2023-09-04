Function Get-MutaWinningOverrides {
    [cmdletbinding()]
    param (
        [Parameter(
            Mandatory,
            Position = 0
        )]
        [string]$Type,
        [bool]$IncludeDeletedRecords = $false
    )
    Test-MutaGameEnvironment
    $typeName = Switch -Regex ($MutagenGameEnvironment.GameRelease) {
        '^Skyrim' {
            "Mutagen.Bethesda.Skyrim.I$Type`Getter"
        }
        '^Fallout' {
            "Mutagen.Bethesda.Fallout4.I$Type`Getter"
        }
    }
    Write-Verbose "Type: $typeName"
    $([Mutagen.Bethesda.OverrideMixIns]::WinningOverrides($MutagenGameEnvironment.LoadOrder.PriorityOrder, $typeName , $IncludeDeletedRecords))
}