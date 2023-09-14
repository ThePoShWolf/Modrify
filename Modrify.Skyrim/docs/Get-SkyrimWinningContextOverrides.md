---
external help file: Modrify.Skyrim.dll-Help.xml
Module Name: Modrify.Skyrim
online version:
schema: 2.0.0
---

# Get-SkyrimWinningContextOverrides

## SYNOPSIS
Returns the winning overrides with additional context.

## SYNTAX

```
Get-SkyrimWinningContextOverrides -RecordType <String> [-IncludeDeletedRecords <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Returns an array of winning overrides contexts for the specified type for your entire load order. This is actually quite fast.

## EXAMPLES

### Example 1
```powershell
Get-SkyrimWinningContextOverrides -RecordType Npc
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
Accepted values: AcousticSpace, ActionRecord, Activator, ActorValueInformation, AddonNode, AlchemicalApparatus, Ammunition, AnimatedObject, APlacedTrap, Armor, ArmorAddon, ArtObject, AssociationType, AStoryManagerNode, BodyPartData, Book, CameraPath, CameraShot, Cell, Class, Climate, CollisionLayer, ColorRecord, CombatStyle, ConstructibleObject, Container, Debris, DefaultObjectManager, DialogBranch, DialogResponses, DialogTopic, DialogView, Door, DualCastData, EffectShader, EncounterZone, EquipType, Explosion, Eyes, Faction, Flora, Footstep, FootstepSet, FormList, Furniture, GameSetting, Global, Grass, Hair, Hazard, HeadPart, IdleAnimation, IdleMarker, ImageSpace, ImageSpaceAdapter, Impact, ImpactDataSet, Ingestible, Ingredient, Key, Keyword, Landscape, LandscapeTexture, LensFlare, LeveledItem, LeveledNpc, LeveledSpell, Light, LightingTemplate, LoadScreen, Location, LocationReferenceType, MagicEffect, MaterialObject, MaterialType, Message, MiscItem, MoveableStatic, MovementType, MusicTrack, MusicType, NavigationMesh, NavigationMeshInfoMap, Npc, ObjectEffect, Outfit, Package, Perk, PlacedNpc, PlacedObject, Projectile, Quest, Race, Region, Relationship, ReverbParameters, Scene, Scroll, ShaderParticleGeometry, Shout, SkyrimMajorRecord, SoulGem, SoundCategory, SoundDescriptor, SoundMarker, SoundOutputModel, Spell, Static, TalkingActivator, TextureSet, Tree, VisualEffect, VoiceType, VolumetricLighting, Water, Weapon, Weather, WordOfPower, Worldspace, IPlaceableObject, IReferenceableObject, IExplodeSpawn, IIdleRelation, IObjectId, IItem, IItemOrList, IConstructible, IOutfitTarget, IBindableEquipment, IComplexLocation, IDialog, IOwner, IRelatable, IRegionTarget, IAliasVoiceType, ILockList, IWorldspaceOrList, IVoiceTypeOrList, INpcOrList, IWeaponOrList, ISpellOrList, IPlacedTrapTarget, IHarvestTarget, IMagicItem, IKeywordLinkedReference, INpcSpawn, ISpellRecord, IEmittance, ILocationRecord, IKnowable, IEffectRecord, ILinkedReference, IPlaced, IPlacedSimple, IPlacedThing, ISound

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
