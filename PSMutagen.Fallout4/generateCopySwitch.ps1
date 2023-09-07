$switchCaseTemplate = @'
            case "{type}":
            case "{type}BinaryOverlay":
                Mod.{name}.GetOrAddAsOverride(Record);
                break;
'@

#Import-Module ".\build\PSMutagen\"
#Import-Module ".\build\PSMutagen.Fallout4"

$ge = Set-MutaGameEnvironment -Game Fallout4 -PassThru
$props = $ge.LoadOrder.PriorityOrder.ToArray()[-1].Mod.PSObject.Properties | Where-Object { $_.MemberType -eq 'Property' -and $_.TypeNameOfValue -like 'Mutagen.Bethesda.Fallout4.IFallout4GroupGetter*' }
$regex = '^Mutagen\.Bethesda\.Fallout4\.IFallout4GroupGetter\`1\[\[Mutagen\.Bethesda\.Fallout4\.I(?<type>[^,]+)Getter'

$switches = foreach ($prop in $props) {
    if ($prop.TypeNameOfValue -match $regex) {
        $switchCaseTemplate -replace '\{type\}', $Matches.type -replace '\{name\}', $prop.Name
    } else {
        
    }
}

$switches -join "`n" | clip