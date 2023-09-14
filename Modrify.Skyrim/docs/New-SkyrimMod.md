---
external help file: Modrify.Skyrim.dll-Help.xml
Module Name: Modrify.Skyrim
online version:
schema: 2.0.0
---

# New-SkyrimMod

## SYNOPSIS
Creates a new Skyrim mod in memory.

## SYNTAX

```
New-SkyrimMod -ModKey <ModKey> [-Release <SkyrimRelease>] [<CommonParameters>]
```

## DESCRIPTION
Returns a new Skyrim mod in memory. Use Get-SkyrimMod to retrieve existing mods from disk.

## EXAMPLES

### Example 1
```powershell
New-SkyrimMod -Modkey 'TestMod.esp'
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

### -Release
If you haven't already set your game environment with Set-MutaGameEnvironment, specify the Skyrim version with this parameter.

If you have set your game environment already, this parameter is not needed.

```yaml
Type: SkyrimRelease
Parameter Sets: (All)
Aliases:
Accepted values: SkyrimLE, SkyrimSE, SkyrimVR, EnderalLE, EnderalSE, SkyrimSEGog

Required: False
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

### Mutagen.Bethesda.Skyrim.ISkyrimMod

## NOTES

## RELATED LINKS
