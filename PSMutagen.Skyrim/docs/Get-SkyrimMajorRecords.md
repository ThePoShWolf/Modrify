---
external help file: PSMutagen.Skyrim.dll-Help.xml
Module Name: PSMutagen.Skyrim
online version:
schema: 2.0.0
---

# Get-SkyrimMajorRecords

## SYNOPSIS
Returns major records from a Skyrim mod.

## SYNTAX

### bymodkey (Default)
```
Get-SkyrimMajorRecords [-ModKey] <ModKey> [-RecordType <String>] [<CommonParameters>]
```

### bymod
```
Get-SkyrimMajorRecords [-Mod] <ISkyrimModGetter> [-RecordType <String>] [<CommonParameters>]
```

## DESCRIPTION
Returns major records from the specific Skyrim mod. Either all records or the specified type of records.

## EXAMPLES

### Example 1
```powershell
Get-SkyrimMajorRecords -ModKey 'Skyrim.esm' -RecordType Npc
```

Gets all NPCs from the Skyrim master file.

## PARAMETERS

### -Mod
A SkyrimMod object either created with New-SkyrimMod, Get-SkyrimMod, or pull from the load order with Get-MutaLoadOrder/Get-MutaPriorityOrder

```yaml
Type: ISkyrimModGetter
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
Accepted values: AcousticSpace, ActionRecord, Activator, ActorValueInformation, AddonNode, AlchemicalApparatus, Ammunition, AnimatedObject, APlacedTrap, Armor, ArmorAddon, ArtObject, AssociationType, AStoryManagerNode, BodyPartData, Book, CameraPath, CameraShot, Cell, Class, Climate, CollisionLayer, ColorRecord, CombatStyle, ConstructibleObject, Container, Debris, DefaultObjectManager, DialogBranch, DialogResponses, DialogTopic, DialogView, Door, DualCastData, EffectShader, EncounterZone, EquipType, Explosion, Eyes, Faction, Flora, Footstep, FootstepSet, FormList, Furniture, GameSetting, Global, Grass, Hair, Hazard, HeadPart, IdleAnimation, IdleMarker, ImageSpace, ImageSpaceAdapter, Impact, ImpactDataSet, Ingestible, Ingredient, Key, Keyword, Landscape, LandscapeTexture, LensFlare, LeveledItem, LeveledNpc, LeveledSpell, Light, LightingTemplate, LoadScreen, Location, LocationReferenceType, MagicEffect, MaterialObject, MaterialType, Message, MiscItem, MoveableStatic, MovementType, MusicTrack, MusicType, NavigationMesh, NavigationMeshInfoMap, Npc, ObjectEffect, Outfit, Package, Perk, PlacedNpc, PlacedObject, Projectile, Quest, Race, Region, Relationship, ReverbParameters, Scene, Scroll, ShaderParticleGeometry, Shout, SkyrimMajorRecord, SoulGem, SoundCategory, SoundDescriptor, SoundMarker, SoundOutputModel, Spell, Static, TalkingActivator, TextureSet, Tree, VisualEffect, VoiceType, VolumetricLighting, Water, Weapon, Weather, WordOfPower, Worldspace, IPlaceableObject, IReferenceableObject, IExplodeSpawn, IIdleRelation, IObjectId, IItem, IItemOrList, IConstructible, IOutfitTarget, IBindableEquipment, IComplexLocation, IDialog, IOwner, IRelatable, IRegionTarget, IAliasVoiceType, ILockList, IWorldspaceOrList, IVoiceTypeOrList, INpcOrList, IWeaponOrList, ISpellOrList, IPlacedTrapTarget, IHarvestTarget, IMagicItem, IKeywordLinkedReference, INpcSpawn, ISpellRecord, IEmittance, ILocationRecord, IKnowable, IEffectRecord, ILinkedReference, IPlaced, IPlacedSimple, IPlacedThing, ISound

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Mutagen.Bethesda.Skyrim.ISkyrimModGetter

## OUTPUTS

### System.Collections.Generic.IEnumerable`1[[Mutagen.Bethesda.Plugins.Records.IMajorRecordGetter, Mutagen.Bethesda.Core, Version=0.42.0.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
