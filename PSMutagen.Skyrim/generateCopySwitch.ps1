$switchCaseTemplate = @'
            case "{type}":
            case "{type}BinaryOverlay":
                Mod.{name}.GetOrAddAsOverride(Record);
                break;
'@

#Import-Module ".\build\PSMutagen\"
#Import-Module ".\build\PSMutagen.Skyrim"

$ge = Set-MutaGameEnvironment -Game SkyrimSE -PassThru
$props = $ge.LoadOrder.PriorityOrder.ToArray()[-1].Mod.PSObject.Properties | Where-Object { $_.MemberType -eq 'Property' -and $_.TypeNameOfValue -like 'Mutagen.Bethesda.Skyrim.ISkyrimGroupGetter*' }
$regex = '^Mutagen\.Bethesda\.Skyrim\.ISkyrimGroupGetter\`1\[\[Mutagen\.Bethesda\.Skyrim\.I(?<type>[^,]+)Getter'

$switches = foreach ($prop in $props) {
    if ($prop.TypeNameOfValue -match $regex) {
        $switchCaseTemplate -replace '\{type\}', $Matches.type -replace '\{name\}', $prop.Name
    } else {
        
    }
}

$switches -join "`n" | clip