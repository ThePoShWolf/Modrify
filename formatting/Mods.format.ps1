$properties = @('ModKey', 'GameRelease')
Write-FormatView -TypeName Mutagen.Bethesda.Skyrim.SkyrimMod -Property $properties -AutoSize
Write-FormatView -TypeName Mutagen.Bethesda.Skyrim.ISkyrimModDisposableGetter -Property $properties -AutoSize