$switchCaseTemplate = @'
                case ("{type}", CopyType.AsOverride):
                case ("{type}BinaryOverlay", CopyType.AsOverride):
                    mod.{name}.GetOrAddAsOverride(Record);
                    break;
                case ("{type}", CopyType.AsNewRecord):
                case ("{type}BinaryOverlay", CopyType.AsNewRecord):
                    mod.{name}.DuplicateInAsNewRecord(Record);
                    break;
                case ("{type}", CopyType.DeepCopy):
                case ("{type}BinaryOverlay", CopyType.DeepCopy):
                    {type} new{type}Record = ({type})Record.DeepCopy();
                    mod.{name}.Add(new{type}Record);
                    break;
'@

$default = @'
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
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

@($switches + $default) -join "`n" | clip