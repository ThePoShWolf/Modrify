---
external help file: Modrify.Skyrim.dll-Help.xml
Module Name: Modrify.Skyrim
online version:
schema: 2.0.0
---

# Copy-SkyrimRecordAsNewRecord

## SYNOPSIS
Copy a record as a new record into a mod file.

## SYNTAX

```
Copy-SkyrimRecordAsNewRecord -Mod <ISkyrimMod> [-Record] <ISkyrimMajorRecordGetter> [<CommonParameters>]
```

## DESCRIPTION
Copies the selected record into a mod as a new record. Requires a mod object to have been created with Get-SkyrimMod, New-SkyrimMod, or pull from the load order Get-ModLoadOrder/Get-ModPriorityOrder.

## EXAMPLES

### Example 1
```powershell
$mod = New-SkyrimMod -ModKey 'TestMod.esp'
Get-SkyrimMajorRecord -Mod 'Skyrim.esm' -RecordType Npc | Copy-SkyrimRecordAsNewRecord -Mod $mod
```

This will copy all Npcs from the Skyrim master file into TestMod as new records. This is actually quite fast.

## PARAMETERS

### -Mod
The mod object. Created with Get-SkyrimMod, New-SkyrimMod, or pulled from the load order Get-ModLoadOrder/Get-ModPriorityOrder.

```yaml
Type: ISkyrimMod
Parameter Sets: (All)
Aliases: DestinationMod, TargetMod

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Record
The record to be copied.

This can be created by going into a mod group or by using Get-SkyrimMajorRecords.

For example, to get NPCs from a mod, use:

```powershell
(Get-SkyrimMod 'Skyrim.esm').Npc
```

```yaml
Type: ISkyrimMajorRecordGetter
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Mutagen.Bethesda.Skyrim.ISkyrimMajorRecordGetter

## OUTPUTS

### Mutagen.Bethesda.Skyrim.SkyrimMajorRecord

## NOTES

## RELATED LINKS
