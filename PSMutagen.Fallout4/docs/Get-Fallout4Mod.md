---
external help file: PSMutagen.Fallout4.dll-Help.xml
Module Name: PSMutagen.Fallout4
online version:
schema: 2.0.0
---

# Get-Fallout4Mod

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### modkey-readwrite (Default)
```
Get-Fallout4Mod -ModKey <ModKey> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [<CommonParameters>]
```

### path-readonly
```
Get-Fallout4Mod -Path <ModPath> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [-ReadOnly] [<CommonParameters>]
```

### path-readwrite
```
Get-Fallout4Mod -Path <ModPath> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [<CommonParameters>]
```

### modkey-readonly
```
Get-Fallout4Mod -ModKey <ModKey> [-ImportMask <GroupMask>] [-StringsParam <StringsReadParameters>]
 [-Parallel <Boolean>] [-FileSystem <IFileSystem>] [-ReadOnly] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
{{ Fill ModKey Description }}

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
{{ Fill Path Description }}

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
{{ Fill ReadOnly Description }}

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

### Mutagen.Bethesda.Fallout4.IFallout4ModDisposableGetter

### Mutagen.Bethesda.Fallout4.IFallout4Mod

## NOTES

## RELATED LINKS
