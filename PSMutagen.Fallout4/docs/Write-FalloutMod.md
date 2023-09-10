---
external help file: PSMutagen.Fallout4.dll-Help.xml
Module Name: PSMutagen.Fallout4
online version:
schema: 2.0.0
---

# Write-FalloutMod

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

```
Write-FalloutMod -Mod <IMod> -Path <FileInfo> [-BinaryWriteParameters <BinaryWriteParameters>]
 [-ParallelWriteParameters <ParallelWriteParameters>] [-FileSystem <IFileSystem>] [-SkipCompressionFix]
 [<CommonParameters>]
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

### -BinaryWriteParameters
{{ Fill BinaryWriteParameters Description }}

```yaml
Type: BinaryWriteParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Mod
{{ Fill Mod Description }}

```yaml
Type: IMod
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParallelWriteParameters
{{ Fill ParallelWriteParameters Description }}

```yaml
Type: ParallelWriteParameters
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
Type: FileInfo
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipCompressionFix
{{ Fill SkipCompressionFix Description }}

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

### Mutagen.Bethesda.Plugins.Records.IMod

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
