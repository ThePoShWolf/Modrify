$template = @'
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using PSMutagen.Core;

namespace PSMutagen.Fallout4
{
    public static partial class Helpers
    {
        public static Fallout4MajorRecord CopyHelper(IFallout4Mod mod, IFallout4MajorRecordGetter Record, CopyType copyType)
        {
            switch (Record.GetType().Name, copyType)
            {
{cases}
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }
}
'@

$switchCaseTemplate = @'
                case ("{type}", CopyType.AsOverride):
                case ("{type}BinaryOverlay", CopyType.AsOverride):
                    return mod.{name}.GetOrAddAsOverride(Record);
                case ("{type}", CopyType.AsNewRecord):
                case ("{type}BinaryOverlay", CopyType.AsNewRecord):
                    return mod.{name}.DuplicateInAsNewRecord(Record);
                case ("{type}", CopyType.DeepCopy):
                case ("{type}BinaryOverlay", CopyType.DeepCopy):
                    {strongtype} new{type}Record = ({strongtype})Record.DeepCopy();
                    mod.{name}.Add(new{type}Record);
                    return new{type}Record;
'@

$exceptions = @(
    'Activator'
)

Get-ChildItem "$PSScriptRoot\..\build\*.dll" | ForEach-Object { Add-Type -Path $_.FullName }

$ge = [Mutagen.Bethesda.Environments.GameEnvironment]::Typical.Construct('Fallout4')
$props = $ge.LoadOrder.PriorityOrder.ToArray()[-1].Mod.PSObject.Properties | Where-Object { $_.MemberType -eq 'Property' -and $_.TypeNameOfValue -like 'Mutagen.Bethesda.Fallout4.IFallout4GroupGetter*' }
$regex = '^Mutagen\.Bethesda\.Fallout4\.IFallout4GroupGetter\`1\[\[Mutagen\.Bethesda\.Fallout4\.I(?<type>[^,]+)Getter'

$cases = foreach ($prop in $props) {
    if ($prop.TypeNameOfValue -match $regex) {
        $strongType = $exceptions -contains $Matches.type ? "Mutagen.Bethesda.Fallout4.$($Matches.type)" : $Matches.type
        $switchCaseTemplate -replace '\{type\}', $Matches.type -replace '\{name\}', $prop.Name -replace '\{strongtype\}', $strongType
    } else {
        
    }
}

$template -replace '\{cases\}', ($cases + $default -join "`n") | Out-File $PSScriptRoot\CopyHelper.cs -Force