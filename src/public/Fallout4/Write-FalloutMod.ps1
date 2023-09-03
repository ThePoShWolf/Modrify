Function Write-FalloutMod {
    [cmdletbinding()]
    Param (
        [Parameter(
            Mandatory,
            ValueFromPipeline
        )]
        [Mutagen.Bethesda.Plugins.Records.AMod]$Mod,
        [Parameter(
            Mandatory
        )]
        [System.IO.FileInfo]$Path,
        [Mutagen.Bethesda.Plugins.Binary.Parameters.BinaryWriteParameters]$BinaryWriteParameters = $null,
        [Mutagen.Bethesda.Plugins.Binary.Parameters.ParallelWriteParameters]$ParallelWriteParameters = $null,
        [System.IO.Abstractions.IFileSystem]$FileSystem = $null,
        [switch]$SkipCompressionFix
    )
    Begin {}
    Process {
        if ($Path.Name -ne $Mod.ModKey.FileName -and @('CorrectToPath', 'ThrowIfMisaligned') -contains $BinaryWriteParameters.ModKey) {
            Throw "Output name must match modkey. Override with `$BinaryWriteParameters.Modkey"
        }
        if (-not $SkipCompressionFix.IsPresent) {
            Get-MutaModMajorRecords -Mod $Mod | ForEach-Object { $_.IsCompressed = $false }
        }
        [Mutagen.Bethesda.Fallout4.Fallout4ModMixIn]::WriteToBinaryParallel($mod, $Path, $BinaryWriteParameters, $ParallelWriteParameters, $FileSystem)
    }
    End {}
}