$template = @'
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using PSMutagen.Core;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Environments;

namespace PSMutagen.Fallout4
{
    public static partial class Helpers
    {
        public static IEnumerable<IModContext<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter>> WinningContextOverrides(string recordType)
        {
            IGameEnvironment<IFallout4Mod, IFallout4ModGetter>fge = GameEnvironment.Typical.Fallout4();
            switch (recordType)
            {
{cases}
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {recordType}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }
}
'@

$switchCaseTemplate = @'
                case "{type}":
                case "{type}BinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.{type}().WinningContextOverrides();
'@

$exceptions = @(
    'Activator'
)

$skip = @(
    'StoryManagerBranchNode', 'StoryManagerQuestNode', 'StoryManagerEventNode'
)

Get-ChildItem "$PSScriptRoot\..\build\*.dll" | ForEach-Object { Add-Type -Path $_.FullName }

$ge = [Mutagen.Bethesda.Environments.GameEnvironment]::Typical.Construct('Fallout4')
$props = $ge.LoadOrder.PriorityOrder.ToArray()[-1].Mod.PSObject.Properties | Where-Object { $_.MemberType -eq 'Property' -and $_.TypeNameOfValue -like 'Mutagen.Bethesda.Fallout4.IFallout4GroupGetter*' }
$regex = '^Mutagen\.Bethesda\.Fallout4\.IFallout4GroupGetter\`1\[\[Mutagen\.Bethesda\.Fallout4\.I(?<type>[^,]+)Getter'

$types = foreach ($prop in $props) {
    if ($prop.TypeNameOfValue -match $regex) {
        if ($skip -notcontains $Matches.type) {
            $strongType = $exceptions -contains $Matches.type ? "Mutagen.Bethesda.Fallout4.$($Matches.type)" : $Matches.type
            $switchCaseTemplate -replace '\{type\}', $Matches.type -replace '\{name\}', $prop.Name -replace '\{strongtype\}', $strongType
        }
    }
}

$template -replace '\{cases\}', ($types -join "`n") | Out-File "$PSScriptRoot\WinningContextOverridesHelper.cs" -Force