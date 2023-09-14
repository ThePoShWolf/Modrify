$template = @'
namespace Modrify.Fallout4
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
$Fallout4Types = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes() | Where-Object { $_.Namespace -eq 'Mutagen.Bethesda.Fallout4' }
$mrs = $Fallout4Types | Where-Object { $_.BaseType -eq [Mutagen.Bethesda.Fallout4.Fallout4MajorRecord] }
$types = $mrs.Name | ForEach-Object {
    "            { `"$_`", Type.GetType(`"Mutagen.Bethesda.Fallout4.I$_`Getter, Mutagen.Bethesda.Fallout4`") },"
}
$types[$types.Count - 1] = $types[$types.Count - 1].TrimEnd(',')

$template -replace '\{types\}', ($types -join "`n") | Out-File "$PSScriptRoot\MajorRecordTypeHelper.cs" -Force