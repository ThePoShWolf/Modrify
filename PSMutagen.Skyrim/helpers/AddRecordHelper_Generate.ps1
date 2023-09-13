$template = @'
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using PSMutagen.Core;

namespace PSMutagen.Skyrim
{
    public static partial class Helpers
    {
        public static void AddRecordHelper(ISkyrimMod mod, ISkyrimMajorRecordGetter Record)
        {
            switch (Record.GetType().Name)
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
                case "{type}":
                case "{type}BinaryOverlay":
                    mod.{name}.Add(({strongtype})Record);
                    break;
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

$template -replace '\{cases\}', ($cases + $default -join "`n") -replace '\{mrcases\}', ($mrcases + $default -join "`n") | Out-File $PSScriptRoot\AddRecordHelper.cs -Force