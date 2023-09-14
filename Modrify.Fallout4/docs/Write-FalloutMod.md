---
external help file: Modrify.Fallout4.dll-Help.xml
Module Name: Modrify.Fallout4
online version:
schema: 2.0.0
---

# Write-FalloutMod

## SYNOPSIS
Writes a Fallout4Mod object to disk.

## SYNTAX

```
Write-FalloutMod -Mod <IMod> -Path <FileInfo> [-BinaryWriteParameters <BinaryWriteParameters>]
 [-ParallelWriteParameters <ParallelWriteParameters>] [-FileSystem <IFileSystem>] [-SkipCompressionFix]
 [<CommonParameters>]
```

## DESCRIPTION
Writes the data stored in a Fallout4Mod object to disk.

## EXAMPLES

### Example 1
```powershell
# Create a new mod
$mod = New-FalloutMod -ModKey 'TestMod.esp'
# find the human race
$humanRace = Get-FalloutMajorRecords -ModKey Fallout4.esm -RecordType Race | Where-Object {$_.EditorID -eq 'HumanRace'}
# Get all human NPCs
$humanNpcs = Get-FalloutMajorRecords -ModKey Fallout4.esm -RecordType Npc | Where-Object {$_.Race -eq $humanRace}
# copy all nord NPCs as overrides into the new mod
$overrides = $humanNpcs | Copy-FalloutRecordAsOverride -Mod $mod
# do something to the humans
$overrides | %{
    ...
}
# Write the new data to a file in the data directory
Write-FalloutMod -Mod $mod -Path "$((Get-ModrifyGame).DataFolderPath)\TestMod.esp"
```

This example gets all Human NPCs using Get-FalloutMajorRecords and filtering with Where-Object.

This will only return Races and NPCs from the Fallout4.esm master file. If you wish to get the winning overrides from your entire load order, use: Get-FalloutWinningOverrides instead.


## PARAMETERS

### -BinaryWriteParameters
The [Mutagen.Bethesda.Plugins.Binary.Parameters.BinaryWriteParameters] object to pass to the mod writer.

In the future there will be a function to create this object type. For now, use:

```powershell
$bwp = [Mutagen.Bethesda.Plugins.Binary.Parameters.BinaryWriteParameters]::new()
# If the modkey to write to is different then the modkey provided on mod creation, ignore that error
$bwp.ModKey = [Mutagen.Bethesda.Plugins.Binary.Parameters.ModKeyOption]::NoCheck
Write-FalloutMod -Mod $mod -Path "$((Get-ModrifyGame).DataFolderPath)\TestMod.esp"
```

```yaml
Type: BinaryWriteParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileSystem
{{ Fill FileSystem Description }}

```yaml
Type: IFileSystem
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mod
The mod object to write. Can be created from scratch with New-FalloutMod or retrieved from disk with Get-FalloutMod.

```yaml
Type: IMod
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParallelWriteParameters
{{ Fill ParallelWriteParameters Description }}

```yaml
Type: ParallelWriteParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
The fully qualified file path to write to.

The data folder can be retrieved with:

```powershell
(Get-ModrifyGame).DataFolderPath
```

```yaml
Type: FileInfo
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipCompressionFix
Currently Mutagen does not support writting mods that have the compression flag enabled so Write-FalloutMod will cycle through each record and ensure that flag is disabled.

Use this flag to disable that functionality.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Mutagen.Bethesda.Plugins.Records.IMod

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
