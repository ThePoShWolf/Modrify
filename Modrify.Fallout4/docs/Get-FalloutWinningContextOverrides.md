---
external help file: Modrify.Fallout4.dll-Help.xml
Module Name: Modrify.Fallout4
online version:
schema: 2.0.0
---

# Get-FalloutWinningContextOverrides

## SYNOPSIS
Returns the winning overrides with additional context.

## SYNTAX

```
Get-FalloutWinningContextOverrides -RecordType <String> [-IncludeDeletedRecords <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Returns an array of winning overrides contexts for the specified type for your entire load order. This is actually quite fast.

## EXAMPLES

### Example 1
```powershell
Get-FalloutWinningContextOverrides -RecordType Npc
```

Returns the Winning Context Override for all Npcs present in your load order.

## PARAMETERS

### -IncludeDeletedRecords
If true, includes deleted records.

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

### -RecordType
The type of record to search for. Use tab completion to see the full list.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: ActionRecord, Activator, ActorValueInformation, ADamageType, AddonNode, Ammunition, APlacedTrap, Armor, ArmorAddon, ArtObject, AStoryManagerNode, Book, CameraPath, CameraShot, Cell, Climate, CollisionLayer, ColorRecord, CombatStyle, Container, DialogBranch, DialogResponses, DialogTopic, Door, EffectShader, EncounterZone, EquipType, Explosion, Faction, Furniture, GameSetting, Global, Grass, Hazard, HeadPart, Holotape, IdleAnimation, IdleMarker, ImageSpace, ImageSpaceAdapter, Impact, Ingestible, Ingredient, InstanceNamingRules, Key, Keyword, LeveledItem, LeveledNpc, Light, LoadScreen, Location, MagicEffect, MaterialObject, MaterialSwap, MaterialType, Message, MiscItem, MovableStatic, MusicTrack, MusicType, NavigationMesh, Npc, ObjectEffect, AObjectModification, Package, PackIn, Perk, PlacedNpc, PlacedObject, Projectile, Quest, Race, Region, Relationship, Scene, ShaderParticleGeometry, SoundCategory, SoundDescriptor, SoundOutputModel, Static, StaticCollection, TalkingActivator, Terminal, TextureSet, Transform, Tree, VisualEffect, VoiceType, Water, Weapon, Weather, Worldspace, Zoom, AttractionRule, Component, LocationReferenceType, AnimationSoundTagSet, Class, Debris, FormList, ImpactDataSet, LeveledSpell, Outfit, SoundMarker, AcousticSpace, ReverbParameters, LandscapeTexture, Spell, Footstep, FootstepSet, GodRays, LensFlare, Flora, BodyPartData, MovementType, DualCastData, ConstructibleObject, AimModel, BendableSpline, NavigationMeshInfoMap, LightingTemplate, Layer, ReferenceGroup, Landscape, AnimatedObject, DefaultObjectManager, DefaultObject, DialogView, AssociationType, AudioEffectChain, SoundKeywordMapping, SceneCollection, AudioCategorySnapshot, NavigationMeshObstacleManager, ObjectVisibilityManager

Required: True
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

### System.Collections.Generic.IEnumerable`1[[Mutagen.Bethesda.Plugins.Records.IMajorRecordGetter, Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
