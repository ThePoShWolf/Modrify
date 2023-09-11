---
external help file: PSMutagen.dll-Help.xml
Module Name: PSMutagen
online version:
schema: 2.0.0
---

# Get-MutaLoadOrder

## SYNOPSIS
Returns the sorted load order for the selected game.

## SYNTAX

```
Get-MutaLoadOrder [<CommonParameters>]
```

## DESCRIPTION
Returns the sorted load order for the selected game. First mod loaded is the first mod in this array.

For example, in Skyrim Skyrim.esm is the first item in this list.

## EXAMPLES

### Example 1
```powershell
Get-MutaLoadOrder
```

Returns the load order.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Mutagen.Bethesda.Plugins.Order.ILoadOrderGetter`1[[Mutagen.Bethesda.Plugins.Order.IModListingGetter`1[[Mutagen.Bethesda.Plugins.Records.IModGetter, Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]], Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
