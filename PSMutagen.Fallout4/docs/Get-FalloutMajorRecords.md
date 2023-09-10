---
external help file: PSMutagen.Fallout4.dll-Help.xml
Module Name: PSMutagen.Fallout4
online version:
schema: 2.0.0
---

# Get-FalloutMajorRecords

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### bymodkey (Default)
```
Get-FalloutMajorRecords [-ModKey] <ModKey> [-RecordType <String>] [<CommonParameters>]
```

### bymod
```
Get-FalloutMajorRecords [-Mod] <IFallout4ModGetter> [-RecordType <String>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
{{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Mod
{{ Fill Mod Description }}

```yaml
Type: IFallout4ModGetter
Parameter Sets: bymod
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ModKey
{{ Fill ModKey Description }}

```yaml
Type: ModKey
Parameter Sets: bymodkey
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecordType
{{ Fill RecordType Description }}

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: ActionRecord, Activator, ActorValueInformation, ADamageType, AddonNode, Ammunition, APlacedTrap, Armor, ArmorAddon, ArtObject, AStoryManagerNode, Book, CameraPath, CameraShot, Cell, Climate, CollisionLayer, ColorRecord, CombatStyle, Container, DialogBranch, DialogResponses, DialogTopic, Door, EffectShader, EncounterZone, EquipType, Explosion, Faction, Furniture, GameSetting, Global, Grass, Hazard, HeadPart, Holotape, IdleAnimation, IdleMarker, ImageSpace, ImageSpaceAdapter, Impact, Ingestible, Ingredient, InstanceNamingRules, Key, Keyword, LeveledItem, LeveledNpc, Light, LoadScreen, Location, MagicEffect, MaterialObject, MaterialSwap, MaterialType, Message, MiscItem, MovableStatic, MusicTrack, MusicType, NavigationMesh, Npc, ObjectEffect, AObjectModification, Package, PackIn, Perk, PlacedNpc, PlacedObject, Projectile, Quest, Race, Region, Relationship, Scene, ShaderParticleGeometry, SoundCategory, SoundDescriptor, SoundOutputModel, Static, StaticCollection, TalkingActivator, Terminal, TextureSet, Transform, Tree, VisualEffect, VoiceType, Water, Weapon, Weather, Worldspace, Zoom, AttractionRule, Component, LocationReferenceType, AnimationSoundTagSet, Class, Debris, FormList, ImpactDataSet, LeveledSpell, Outfit, SoundMarker, AcousticSpace, ReverbParameters, LandscapeTexture, Spell, Footstep, FootstepSet, GodRays, LensFlare, Flora, BodyPartData, MovementType, DualCastData, ConstructibleObject, AimModel, BendableSpline, NavigationMeshInfoMap, LightingTemplate, Layer, ReferenceGroup, Landscape, AnimatedObject, DefaultObjectManager, DefaultObject, DialogView, AssociationType, AudioEffectChain, SoundKeywordMapping, SceneCollection, AudioCategorySnapshot, NavigationMeshObstacleManager, ObjectVisibilityManager

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Mutagen.Bethesda.Fallout4.IFallout4ModGetter

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Mutagen.Bethesda.Plugins.Records.IMajorRecordGetter, Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
