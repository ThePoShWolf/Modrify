---
external help file: Modrify.Fallout4.dll-Help.xml
Module Name: Modrify.Fallout4
online version:
schema: 2.0.0
---

# New-FalloutMod

## SYNOPSIS
Creates a new Fallout 4 mod in memory.

## SYNTAX

```
New-FalloutMod -ModKey <ModKey> [<CommonParameters>]
```

## DESCRIPTION
Returns a new Fallout 4 mod in memory. Use Get-FalloutMod to retrieve existing mods from disk.

## EXAMPLES

### Example 1
```powershell
New-FalloutMod -Modkey 'TestMod.esp'
```

Creates a new mod in memory called 'TestMod.esp'

## PARAMETERS

### -ModKey
The name of the mod.

```yaml
Type: ModKey
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Mutagen.Bethesda.Fallout4.IFallout4Mod

## NOTES

## RELATED LINKS
