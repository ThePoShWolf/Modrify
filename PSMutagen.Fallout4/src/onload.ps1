<#
    Code in this file will be added to the end of the .psm1. For example,
    you should set variables or other environment settings here.
#>

# Load Assemblies
$libPath = Join-Path $PSScriptRoot lib
Get-ChildItem $libPath -Filter *.dll | ForEach-Object {
    Add-Type -Path $_.FullName
}

# Argument Completers
$TypeCompleter = {
    param($commandName, $parameterName, $wordToComplete, $commandAst, $fakeBoundParameters)
    if (-not (Get-Variable 'MajorRecordTypeNameCompleters' -Scope Script)) {
        # loading all types in Mutagen.Bethesda*
        $allTypes = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes() | Where-Object { $_.Namespace -like 'Mutagen.Bethesda*' }
        # filtering for types that implement the ISkyrimMajorRecordGetter
        # this will need to be Improved to account for other games
        $getterSearch = Switch -Regex ($MutagenGameEnvironment.GameRelease) {
            '^Skyrim' {
                'Mutagen.Bethesda.Skyrim.ISkyrimMajorRecordGetter'
            }
            '^Fallout' {
                'Mutagen.Bethesda.Fallout4.IFallout4MajorRecordGetter'
            }
            default {
                'Mutagen.Bethesda.Skyrim.ISkyrimMajorRecordGetter'
            }
        }
        $mrgs = $allTypes | Where-Object { $_.ImplementedInterfaces.FullName -contains $getterSearch }
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
Register-ArgumentCompleter -CommandName Get-MutaWinningOverrides -ParameterName Type -ScriptBlock $TypeCompleter
Register-ArgumentCompleter -CommandName Get-MutaModMajorRecords -ParameterName Type -ScriptBlock $TypeCompleter