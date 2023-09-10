---
external help file: PSMutagen.Skyrim.dll-Help.xml
Module Name: PSMutagen.Skyrim
online version:
schema: 2.0.0
---

# Get-SkyrimMod

## SYNOPSIS
Returns a Skyrim Mod object, optionally readonly.

## SYNTAX

### modkey-readwrite (Default)
```
Get-SkyrimMod -ModKey <ModKey> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [-Release <SkyrimRelease>] [<CommonParameters>]
```

### path-readonly
```
Get-SkyrimMod -Path <ModPath> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [-Release <SkyrimRelease>] [-ReadOnly] [<CommonParameters>]
```

### path-readwrite
```
Get-SkyrimMod -Path <ModPath> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [-Release <SkyrimRelease>] [<CommonParameters>]
```

### modkey-readonly
```
Get-SkyrimMod -ModKey <ModKey> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [-Release <SkyrimRelease>] [-ReadOnly] [<CommonParameters>]
```

## DESCRIPTION
Returns a Skyrim Mod object either by path or mod name and optionally read only, which is more performant.

## EXAMPLES

### Example 1
```powershell
Get-SkyrimMod -ModKey HearthFires.esm -ReadOnly
```

Returns a Skyrim Mod object that will contain all of the data in HearthFires.esm, specifically read only.

## PARAMETERS

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

### -ImportMask
{{ Fill ImportMask Description }}

```yaml
Type: GroupMask
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ModKey
This is the name of the mod. For example: Completionist.esp

```yaml
Type: ModKey
Parameter Sets: modkey-readwrite, modkey-readonly
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parallel
{{ Fill Parallel Description }}

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
The fully qualified path to the mod.

```yaml
Type: ModPath
Parameter Sets: path-readonly, path-readwrite
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadOnly
Optionally return the mod as readonly, which is much more performant. Useful for reporting purposes.

```yaml
Type: SwitchParameter
Parameter Sets: path-readonly, modkey-readonly
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Release
Only required if you haven't already set your game environment with Set-MutaGameEnvironment.

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

### -StringsParam
{{ Fill StringsParam Description }}

```yaml
Type: StringsReadParameters
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

### Mutagen.Bethesda.Skyrim.ISkyrimModDisposableGetter

### Mutagen.Bethesda.Skyrim.ISkyrimMod

## NOTES

## RELATED LINKS
