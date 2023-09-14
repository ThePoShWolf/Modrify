$template = @'
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using Modrify.Core;

namespace Modrify.Fallout4
{
    public static partial class Helpers
    {
        public static void AddRecordHelper(IFallout4Mod mod, IFallout4MajorRecordGetter Record)
        {
            switch (Record.GetType().Name)
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
                case "{type}":
                case "{type}BinaryOverlay":
                    mod.{name}.Add(({strongtype})Record);
                    break;
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

$template -replace '\{cases\}', ($cases + $default -join "`n") -replace '\{mrcases\}', ($mrcases + $default -join "`n") | Out-File $PSScriptRoot\AddRecordHelper.cs -Force