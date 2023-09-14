---
external help file: Modrify.Fallout4.dll-Help.xml
Module Name: Modrify.Fallout4
online version:
schema: 2.0.0
---

# Copy-FalloutRecordAsOverride

## SYNOPSIS
Copy a record as an override into a mod file.

## SYNTAX

```
Copy-FalloutRecordAsOverride -Mod <IFallout4Mod> [-Record] <IFallout4MajorRecordGetter> [<CommonParameters>]
```

## DESCRIPTION
Copies the selected record into a mod as an override. Requires a mod object to have been created with GetFalloutMod, NewFalloutMod, or pull from the load order Get-ModLoadOrder/Get-ModPriorityOrder.

## EXAMPLES

### Example 1
```powershell
$mod = NewFalloutMod -ModKey 'TestMod.esp'
GetFalloutMajorRecord -Mod 'Fallout4.esm' -RecordType Npc | CopyFalloutRecordAsOverride -Mod $mod
```

This will copy all Npcs from the Fallout 4 master file into TestMod as an override. This is actually quite fast.

## PARAMETERS

### -Mod
The mod object. Created with GetFalloutMod, NewFalloutMod, or pulled from the load order Get-ModLoadOrder/Get-ModPriorityOrder.

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
