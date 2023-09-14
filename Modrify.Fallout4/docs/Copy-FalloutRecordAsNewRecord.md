---
external help file: Modrify.Fallout4.dll-Help.xml
Module Name: Modrify.Fallout4
online version:
schema: 2.0.0
---

# Copy-FalloutRecordAsNewRecord

## SYNOPSIS
Copy a record as a new record into a mod file.

## SYNTAX

```
Copy-FalloutRecordAsNewRecord -Mod <IFallout4Mod> [-Record] <IFallout4MajorRecordGetter> [<CommonParameters>]
```

## DESCRIPTION
Copies the selected record into a mod as a new record. Requires a mod object to have been created with Get-FalloutMod, New-FalloutMod, or pull from the load order Get-MutaLoadOrder/Get-MutaPriorityOrder.

## EXAMPLES

### Example 1
```powershell
$mod = New-FalloutMod -ModKey 'TestMod.esp'
Get-FalloutMajorRecord -Mod 'Fallout4.esm' -RecordType Npc | Copy-FalloutRecordAsNewRecord -Mod $mod
```

This will copy all Npcs from the Fallout 4 master file into TestMod as new records. This is actually quite fast.

## PARAMETERS

### -Mod
The mod object. Created with Get-FalloutMod, New-FalloutMod, or pulled from the load order Get-MutaLoadOrder/Get-MutaPriorityOrder.

```yaml
Type: IFallout4Mod
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

This can be created by going into a mod group or by using Get-FalloutMajorRecords.

For example, to get NPCs from a mod, use:

```powershell
(Get-FalloutMod 'Fallout4.esm').Npc
```

```yaml
Type: IFallout4MajorRecordGetter
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

### Mutagen.Bethesda.Fallout4.IFallout4MajorRecordGetter

## OUTPUTS

### Mutagen.Bethesda.Fallout4.Fallout4MajorRecord

## NOTES

## RELATED LINKS
