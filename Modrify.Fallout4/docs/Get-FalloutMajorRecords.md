---
external help file: Modrify.Fallout4.dll-Help.xml
Module Name: Modrify.Fallout4
online version:
schema: 2.0.0
---

# Get-FalloutMajorRecords

## SYNOPSIS
Returns major records from a Fallout 4 mod.

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
Returns major records from the specific Fallout 4 mod. Either all records or the specified type of records.

## EXAMPLES

### Example 1
```powershell
Get-FalloutMajorRecords -ModKey 'Fallout4.esm' -RecordType Npc
```

Gets all NPCs from the Fallout 4 master file.

## PARAMETERS

### -Mod
A Fallout4Mod object either created with New-FalloutMod, Get-FalloutMod, or pull from the load order with Get-MutaLoadOrder/Get-MutaPriorityOrder

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
The name of a mod to pull. The cmdlet will look for the mod in the data folder.

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
The type of record to be returned. Use tab-completion to see the full list.

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
