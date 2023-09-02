Function Get-MutaMod {
    [OutputType([Mutagen.Bethesda.Skyrim.SkyrimMod], ParameterSetName = 'forEdit')]
    [OutputType([Mutagen.Bethesda.Skyrim.ISkyrimModDisposableGetter], ParameterSetName = 'readOnly')]
    [cmdletbinding(
        DefaultParameterSetName = 'forEdit'
    )]
    param (
        [Parameter(
            Mandatory,
            ParameterSetName = 'forEdit'
        )]
        [Parameter(
            Mandatory,
            ParameterSetName = 'readOnly'
        )]
        [Mutagen.Bethesda.Plugins.ModPath]$Path,
        [Parameter(
            ParameterSetName = 'forEdit'
        )]
        [Parameter(
            ParameterSetName = 'readOnly'
        )]
        [Mutagen.Bethesda.GameRelease]$Release = $MutagenGameEnvironment.GameRelease,
        [Parameter(
            ParameterSetName = 'forEdit'
        )]
        [Mutagen.Bethesda.Skyrim.GroupMask]$ImportMask = $null,
        [Parameter(
            ParameterSetName = 'forEdit'
        )]
        [Parameter(
            ParameterSetName = 'readOnly'
        )]
        [Mutagen.Bethesda.Strings.StringsReadParameters]$StringsParam = $null,
        [Parameter(
            ParameterSetName = 'forEdit'
        )]
        [bool]$Parallel = $true,
        [Parameter(
            ParameterSetName = 'forEdit'
        )]
        [Parameter(
            ParameterSetName = 'readOnly'
        )]
        [System.IO.Abstractions.IFileSystem]$FileSystem = $null,
        [Parameter(
            Mandatory,
            ParameterSetName = 'readOnly'
        )]
        [switch]$ReadOnly
    )
    if ($ReadOnly.IsPresent) {
        [Mutagen.Bethesda.Skyrim.SkyrimMod]::CreateFromBinaryOverlay($Path, $Release, $StringsParam, $FileSystem)
    } else {
        [Mutagen.Bethesda.Skyrim.SkyrimMod]::CreateFromBinary($Path, $Release, $ImportMask, $StringsParam, $Parallel, $FileSystem)
    }
}