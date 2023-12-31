$template = @'
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Modrify.Core;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Environments;

namespace Modrify.Skyrim
{
    public static partial class Helpers
    {
        public static IEnumerable<IModContext<ISkyrimMod, ISkyrimModGetter, ISkyrimMajorRecord, ISkyrimMajorRecordGetter>> WinningContextOverrides(string recordType)
        {
            IGameEnvironment<ISkyrimMod, ISkyrimModGetter> sge = GameEnvironment.Typical.Skyrim(ModrifyConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease());
            switch (recordType)
            {
{cases}
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {recordType}. Please raise an issue in Modrify's GitHub repository.");
            }
        }
    }
}
'@

$switchCaseTemplate = @'
                case "{type}":
                case "{type}BinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.{type}().WinningContextOverrides();
'@

$exceptions = @(
    'Activator'
)

$skip = @(
    'StoryManagerBranchNode', 'StoryManagerQuestNode', 'StoryManagerEventNode'
)

Get-ChildItem "$PSScriptRoot\..\build\*.dll" | ForEach-Object { Add-Type -Path $_.FullName }

$ge = [Mutagen.Bethesda.Environments.GameEnvironment]::Typical.Construct('SkyrimSE')
$props = $ge.LoadOrder.PriorityOrder.ToArray()[-1].Mod.PSObject.Properties | Where-Object { $_.MemberType -eq 'Property' -and $_.TypeNameOfValue -like 'Mutagen.Bethesda.Skyrim.ISkyrimGroupGetter*' }
$regex = '^Mutagen\.Bethesda\.Skyrim\.ISkyrimGroupGetter\`1\[\[Mutagen\.Bethesda\.Skyrim\.I(?<type>[^,]+)Getter'

$types = foreach ($prop in $props) {
    if ($prop.TypeNameOfValue -match $regex) {
        if ($skip -notcontains $Matches.type) {
            $strongType = $exceptions -contains $Matches.type ? "Mutagen.Bethesda.Skyrim.$($Matches.type)" : $Matches.type
            $switchCaseTemplate -replace '\{type\}', $Matches.type -replace '\{name\}', $prop.Name -replace '\{strongtype\}', $strongType
        }
    }
}

$template -replace '\{cases\}', ($types -join "`n") | Out-File "$PSScriptRoot\WinningContextOverridesHelper.cs" -Force