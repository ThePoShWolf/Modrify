---
external help file: Modrify.dll-Help.xml
Module Name: Modrify
online version:
schema: 2.0.0
---

# Set-MutaGameEnvironment

## SYNOPSIS
The first command to run for any work in Modrify. This sets your game environment to be the specified game.

## SYNTAX

```
Set-MutaGameEnvironment [-Game] <GameRelease> [-PassThru] [<CommonParameters>]
```

## DESCRIPTION
Modrify supports several game releases that are supported by Mutagen. In order to know which game to work with, you specify that with this command.

## EXAMPLES

### Example 1
```powershell
Set-MutaGameEnvironment SkyrimSE
```

Sets the game environment to be Skyrim Special Edition.

## PARAMETERS

### -Game
The game to be referenced. Not all games supported by Mutagen are yet supported by Modrify.

Options are:

Oblivion
SkyrimLE
SkyrimSE
SkyrimVR
Fallout4
EnderalLE
EnderalSE
SkyrimSEGog

```yaml
Type: GameRelease
Parameter Sets: (All)
Aliases:
Accepted values: Oblivion, SkyrimLE, SkyrimSE, SkyrimVR, Fallout4, EnderalLE, EnderalSE, SkyrimSEGog

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Will return the GameEnvironment object.

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

### None

## OUTPUTS

### Mutagen.Bethesda.Environments.IGameEnvironment

## NOTES

## RELATED LINKS
