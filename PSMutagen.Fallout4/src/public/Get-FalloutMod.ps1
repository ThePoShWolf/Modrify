Function Get-FalloutMod {
    [OutputType([Mutagen.Bethesda.Fallout4.Fallout4Mod], ParameterSetName = 'forEdit')]
    [OutputType([Mutagen.Bethesda.Fallout4.IFallout4ModDisposableGetter], ParameterSetName = 'readOnly')]
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
        [Mutagen.Bethesda.Fallout4.GroupMask]$ImportMask = $null,
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
    Begin {}
    Process {
        if ($ReadOnly.IsPresent) {
            [Mutagen.Bethesda.Fallout4.Fallout4Mod]::CreateFromBinaryOverlay($Path, $StringsParam, $FileSystem)
        } else {
            [Mutagen.Bethesda.Fallout4.Fallout4Mod]::CreateFromBinary($Path, $ImportMask, $StringsParam, $Parallel, $FileSystem)
        }
    }
    End {}
}