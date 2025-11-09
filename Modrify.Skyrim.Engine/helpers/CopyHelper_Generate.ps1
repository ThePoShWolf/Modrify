$template = @'
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using Modrify.Core;

namespace Modrify.Skyrim
{
    public static partial class Helpers
    {
        public static SkyrimMajorRecord CopyHelper(ISkyrimMod mod, ISkyrimMajorRecordGetter Record, CopyType copyType)
        {
            switch (Record.GetType().Name, copyType)
            {
{cases}
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in Modrify's GitHub repository.");
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

$ge = [Mutagen.Bethesda.Environments.GameEnvironment]::Typical.Construct('SkyrimSE')
$props = $ge.LoadOrder.PriorityOrder.ToArray()[-1].Mod.PSObject.Properties | Where-Object { $_.MemberType -eq 'Property' -and $_.TypeNameOfValue -like 'Mutagen.Bethesda.Skyrim.ISkyrimGroupGetter*' }
$regex = '^Mutagen\.Bethesda\.Skyrim\.ISkyrimGroupGetter\`1\[\[Mutagen\.Bethesda\.Skyrim\.I(?<type>[^,]+)Getter'

$cases = foreach ($prop in $props) {
    if ($prop.TypeNameOfValue -match $regex) {
        $strongType = $exceptions -contains $Matches.type ? "Mutagen.Bethesda.Skyrim.$($Matches.type)" : $Matches.type
        $switchCaseTemplate -replace '\{type\}', $Matches.type -replace '\{name\}', $prop.Name -replace '\{strongtype\}', $strongType
    } else {
        
    }
}

$template -replace '\{cases\}', ($cases + $default -join "`n") | Out-File $PSScriptRoot\CopyHelper.cs -Force