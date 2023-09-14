---
external help file: Modrify.dll-Help.xml
Module Name: Modrify
online version:
schema: 2.0.0
---

# Get-MutaPriorityOrder

## SYNOPSIS
Returns the selected game's load order reversed.

## SYNTAX

```
Get-MutaPriorityOrder [<CommonParameters>]
```

## DESCRIPTION
Assuming Set-MutaGameEnvironment has been run, this will return the current game's load order reversed, which means the last mod loaded is the first mod in the returned array.

For example, in Skyrim Skyrim.esm is last in the returned array.

## EXAMPLES

### Example 1
```powershell
Get-MutaPriorityOrder
```

Returns the reversed load order.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Mutagen.Bethesda.Plugins.Order.IModListingGetter`1[[Mutagen.Bethesda.Plugins.Records.IModGetter, Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]], Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
