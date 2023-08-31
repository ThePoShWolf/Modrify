Function Get-MutaWinningOverrides {
    [cmdletbinding()]
    param (
        [Parameter(
            Position = 0
        )]
        [string]$Type,
        [bool]$IncludeDeletedRecords = $false
    )
    $typeName = Switch -Regex ($MutagenGameEnvironment.GameRelease) {
        '^Skyrim' {
            "Mutagen.Bethesda.Skyrim.I$Type`Getter"
        }
    }
    Write-Verbose "Type: $typeName"
    $([Mutagen.Bethesda.OverrideMixIns]::WinningOverrides($MutagenGameEnvironment.LoadOrder.PriorityOrder, $typeName , $IncludeDeletedRecords))
}

$sb = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)
    if (-not (Get-Variable 'MajorRecordTypeNameCompleters' -Scope Script)) {
        # loading all types in Mutagen.Bethesda*
        $allTypes = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes() | Where-Object { $_.Namespace -like 'Mutagen.Bethesda*' }
        # filtering for types that implement the ISkyrimMajorRecordGetter
        # this will need to be Improved to account for other games
        $mrgs = $allTypes | Where-Object { $_.ImplementedInterfaces.FullName -contains 'Mutagen.Bethesda.Skyrim.ISkyrimMajorRecordGetter' }
        # convert to short type name
        # i.e. INpcGetter to Npc
        $script:MajorRecordTypeNameCompleters = $mrgs | Where-Object { $_.name -like '*Getter' } | ForEach-Object {
            $_.Name -replace '^I(.*)Getter', '$1'
        }
    }
    $MajorRecordTypeNameCompleters | Where-Object { $_ -like "$wordToComplete*" } | ForEach-Object {
        $_
    }
}
Register-ArgumentCompleter -CommandName Get-MutaWinningOverrides -ParameterName Type -ScriptBlock $sb