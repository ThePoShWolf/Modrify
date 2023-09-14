---
external help file: Modrify.dll-Help.xml
Module Name: Modrify
online version:
schema: 2.0.0
---

# Get-MutaGameEnvironment

## SYNOPSIS
Returns the GameEnvironment object created by Set-MutaGameEnvironment.

## SYNTAX

```
Get-MutaGameEnvironment [<CommonParameters>]
```

## DESCRIPTION
The GameEnvironment object created by Set-MutaGameEnvironment has a lot of useful information about your game including the data folder path, the load order file path, and your load order.

## EXAMPLES

### Example 1
```powershell
Get-MutaGameEnvironment
```

As simple as it comes, returns the GameEnvironment object.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Mutagen.Bethesda.Environments.IGameEnvironment

## NOTES

## RELATED LINKS
