$properties = @('ModKey', 'GameRelease')

# Skyrim
Write-FormatView -TypeName Mutagen.Bethesda.Skyrim.SkyrimMod -Property $properties -AutoSize
Write-FormatView -TypeName Mutagen.Bethesda.Skyrim.SkyrimModBinaryOverlay -Property $properties -AutoSize

# Fallout 4
Write-FormatView -TypeName Mutagen.Bethesda.Fallout4.Fallout4Mod -Property $properties -AutoSize
Write-FormatView -TypeName Mutagen.Bethesda.Fallout4.Fallout4ModBinaryOverlay -Property $properties -AutoSize