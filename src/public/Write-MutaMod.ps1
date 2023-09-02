Function Write-MutaMod {
    [cmdletbinding()]
    Param (
        [Mutagen.Bethesda.Plugins.Records.AMod]$Mod,
        [System.IO.FileInfo]$Path,
        [Mutagen.Bethesda.Plugins.Binary.Parameters.BinaryWriteParameters]$BinaryWriteParameters = $null,
        [Mutagen.Bethesda.Plugins.Binary.Parameters.ParallelWriteParameters]$ParallelWriteParameters = $null,
        [System.IO.Abstractions.IFileSystem]$FileSystem = $null
    )
    [Mutagen.Bethesda.Skyrim.SkyrimModMixIn]::WriteToBinaryParallel($mod, $Path, $BinaryWriteParameters, $ParallelWriteParameters, $FileSystem)
}