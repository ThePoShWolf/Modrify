$template = @'
namespace Modrify.Skyrim
{
    public static partial class Helpers
    {
        public static Dictionary<string, Type> MajorRecordTypes = new Dictionary<string, Type>()
        {
{types}
        };
    }
}
'@

Get-ChildItem "$PSScriptRoot\..\build\*.dll" | ForEach-Object { Add-Type -Path $_.FullName }
$skyrimTypes = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes() | Where-Object { $_.Namespace -eq 'Mutagen.Bethesda.Skyrim' }
$mrs = $skyrimTypes | Where-Object { $_.BaseType -eq [Mutagen.Bethesda.Skyrim.SkyrimMajorRecord] }
$types = $mrs.Name | ForEach-Object {
    "            { `"$_`", Type.GetType(`"Mutagen.Bethesda.Skyrim.I$_`Getter, Mutagen.Bethesda.Skyrim`") },"
}
$types[$types.Count - 1] = $types[$types.Count - 1].TrimEnd(',')

$template -replace '\{types\}', ($types -join "`n") | Out-File "$PSScriptRoot\MajorRecordTypeHelper.cs" -Force