using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using PSMutagen.Core;

namespace PSMutagen.Fallout4
{
    public static partial class Helpers
    {
        public static void AddRecordHelper(IFallout4Mod mod, IFallout4MajorRecordGetter Record)
        {
            switch (Record.GetType().Name)
            {
                case "GameSetting":
                case "GameSettingBinaryOverlay":
                    mod.GameSettings.Add((GameSetting)Record);
                    break;
                case "Keyword":
                case "KeywordBinaryOverlay":
                    mod.Keywords.Add((Keyword)Record);
                    break;
                case "LocationReferenceType":
                case "LocationReferenceTypeBinaryOverlay":
                    mod.LocationReferenceTypes.Add((LocationReferenceType)Record);
                    break;
                case "ActionRecord":
                case "ActionRecordBinaryOverlay":
                    mod.Actions.Add((ActionRecord)Record);
                    break;
                case "Transform":
                case "TransformBinaryOverlay":
                    mod.Transforms.Add((Transform)Record);
                    break;
                case "Component":
                case "ComponentBinaryOverlay":
                    mod.Components.Add((Component)Record);
                    break;
                case "TextureSet":
                case "TextureSetBinaryOverlay":
                    mod.TextureSets.Add((TextureSet)Record);
                    break;
                case "Global":
                case "GlobalBinaryOverlay":
                    mod.Globals.Add((Global)Record);
                    break;
                case "ADamageType":
                case "ADamageTypeBinaryOverlay":
                    mod.DamageTypes.Add((ADamageType)Record);
                    break;
                case "Class":
                case "ClassBinaryOverlay":
                    mod.Classes.Add((Class)Record);
                    break;
                case "Faction":
                case "FactionBinaryOverlay":
                    mod.Factions.Add((Faction)Record);
                    break;
                case "HeadPart":
                case "HeadPartBinaryOverlay":
                    mod.HeadParts.Add((HeadPart)Record);
                    break;
                case "Race":
                case "RaceBinaryOverlay":
                    mod.Races.Add((Race)Record);
                    break;
                case "SoundMarker":
                case "SoundMarkerBinaryOverlay":
                    mod.SoundMarkers.Add((SoundMarker)Record);
                    break;
                case "AcousticSpace":
                case "AcousticSpaceBinaryOverlay":
                    mod.AcousticSpaces.Add((AcousticSpace)Record);
                    break;
                case "MagicEffect":
                case "MagicEffectBinaryOverlay":
                    mod.MagicEffects.Add((MagicEffect)Record);
                    break;
                case "LandscapeTexture":
                case "LandscapeTextureBinaryOverlay":
                    mod.LandscapeTextures.Add((LandscapeTexture)Record);
                    break;
                case "ObjectEffect":
                case "ObjectEffectBinaryOverlay":
                    mod.ObjectEffects.Add((ObjectEffect)Record);
                    break;
                case "Spell":
                case "SpellBinaryOverlay":
                    mod.Spells.Add((Spell)Record);
                    break;
                case "Activator":
                case "ActivatorBinaryOverlay":
                    mod.Activators.Add((Mutagen.Bethesda.Fallout4.Activator)Record);
                    break;
                case "TalkingActivator":
                case "TalkingActivatorBinaryOverlay":
                    mod.TalkingActivators.Add((TalkingActivator)Record);
                    break;
                case "Armor":
                case "ArmorBinaryOverlay":
                    mod.Armors.Add((Armor)Record);
                    break;
                case "Book":
                case "BookBinaryOverlay":
                    mod.Books.Add((Book)Record);
                    break;
                case "Container":
                case "ContainerBinaryOverlay":
                    mod.Containers.Add((Container)Record);
                    break;
                case "Door":
                case "DoorBinaryOverlay":
                    mod.Doors.Add((Door)Record);
                    break;
                case "Ingredient":
                case "IngredientBinaryOverlay":
                    mod.Ingredients.Add((Ingredient)Record);
                    break;
                case "Light":
                case "LightBinaryOverlay":
                    mod.Lights.Add((Light)Record);
                    break;
                case "MiscItem":
                case "MiscItemBinaryOverlay":
                    mod.MiscItems.Add((MiscItem)Record);
                    break;
                case "Static":
                case "StaticBinaryOverlay":
                    mod.Statics.Add((Static)Record);
                    break;
                case "StaticCollection":
                case "StaticCollectionBinaryOverlay":
                    mod.StaticCollections.Add((StaticCollection)Record);
                    break;
                case "MovableStatic":
                case "MovableStaticBinaryOverlay":
                    mod.MovableStatics.Add((MovableStatic)Record);
                    break;
                case "Grass":
                case "GrassBinaryOverlay":
                    mod.Grasses.Add((Grass)Record);
                    break;
                case "Tree":
                case "TreeBinaryOverlay":
                    mod.Trees.Add((Tree)Record);
                    break;
                case "Flora":
                case "FloraBinaryOverlay":
                    mod.Florae.Add((Flora)Record);
                    break;
                case "Furniture":
                case "FurnitureBinaryOverlay":
                    mod.Furniture.Add((Furniture)Record);
                    break;
                case "Weapon":
                case "WeaponBinaryOverlay":
                    mod.Weapons.Add((Weapon)Record);
                    break;
                case "Ammunition":
                case "AmmunitionBinaryOverlay":
                    mod.Ammunitions.Add((Ammunition)Record);
                    break;
                case "Npc":
                case "NpcBinaryOverlay":
                    mod.Npcs.Add((Npc)Record);
                    break;
                case "LeveledNpc":
                case "LeveledNpcBinaryOverlay":
                    mod.LeveledNpcs.Add((LeveledNpc)Record);
                    break;
                case "Key":
                case "KeyBinaryOverlay":
                    mod.Keys.Add((Key)Record);
                    break;
                case "Ingestible":
                case "IngestibleBinaryOverlay":
                    mod.Ingestibles.Add((Ingestible)Record);
                    break;
                case "IdleMarker":
                case "IdleMarkerBinaryOverlay":
                    mod.IdleMarkers.Add((IdleMarker)Record);
                    break;
                case "Holotape":
                case "HolotapeBinaryOverlay":
                    mod.Holotapes.Add((Holotape)Record);
                    break;
                case "Projectile":
                case "ProjectileBinaryOverlay":
                    mod.Projectiles.Add((Projectile)Record);
                    break;
                case "Hazard":
                case "HazardBinaryOverlay":
                    mod.Hazards.Add((Hazard)Record);
                    break;
                case "BendableSpline":
                case "BendableSplineBinaryOverlay":
                    mod.BendableSplines.Add((BendableSpline)Record);
                    break;
                case "Terminal":
                case "TerminalBinaryOverlay":
                    mod.Terminals.Add((Terminal)Record);
                    break;
                case "LeveledItem":
                case "LeveledItemBinaryOverlay":
                    mod.LeveledItems.Add((LeveledItem)Record);
                    break;
                case "Weather":
                case "WeatherBinaryOverlay":
                    mod.Weather.Add((Weather)Record);
                    break;
                case "Climate":
                case "ClimateBinaryOverlay":
                    mod.Climates.Add((Climate)Record);
                    break;
                case "ShaderParticleGeometry":
                case "ShaderParticleGeometryBinaryOverlay":
                    mod.ShaderParticleGeometries.Add((ShaderParticleGeometry)Record);
                    break;
                case "VisualEffect":
                case "VisualEffectBinaryOverlay":
                    mod.VisualEffects.Add((VisualEffect)Record);
                    break;
                case "Region":
                case "RegionBinaryOverlay":
                    mod.Regions.Add((Region)Record);
                    break;
                case "NavigationMeshInfoMap":
                case "NavigationMeshInfoMapBinaryOverlay":
                    mod.NavigationMeshInfoMaps.Add((NavigationMeshInfoMap)Record);
                    break;
                case "Worldspace":
                case "WorldspaceBinaryOverlay":
                    mod.Worldspaces.Add((Worldspace)Record);
                    break;
                case "Quest":
                case "QuestBinaryOverlay":
                    mod.Quests.Add((Quest)Record);
                    break;
                case "IdleAnimation":
                case "IdleAnimationBinaryOverlay":
                    mod.IdleAnimations.Add((IdleAnimation)Record);
                    break;
                case "Package":
                case "PackageBinaryOverlay":
                    mod.Packages.Add((Package)Record);
                    break;
                case "CombatStyle":
                case "CombatStyleBinaryOverlay":
                    mod.CombatStyles.Add((CombatStyle)Record);
                    break;
                case "LoadScreen":
                case "LoadScreenBinaryOverlay":
                    mod.LoadScreens.Add((LoadScreen)Record);
                    break;
                case "AnimatedObject":
                case "AnimatedObjectBinaryOverlay":
                    mod.AnimatedObjects.Add((AnimatedObject)Record);
                    break;
                case "Water":
                case "WaterBinaryOverlay":
                    mod.Waters.Add((Water)Record);
                    break;
                case "EffectShader":
                case "EffectShaderBinaryOverlay":
                    mod.EffectShaders.Add((EffectShader)Record);
                    break;
                case "Explosion":
                case "ExplosionBinaryOverlay":
                    mod.Explosions.Add((Explosion)Record);
                    break;
                case "Debris":
                case "DebrisBinaryOverlay":
                    mod.Debris.Add((Debris)Record);
                    break;
                case "ImageSpace":
                case "ImageSpaceBinaryOverlay":
                    mod.ImageSpaces.Add((ImageSpace)Record);
                    break;
                case "ImageSpaceAdapter":
                case "ImageSpaceAdapterBinaryOverlay":
                    mod.ImageSpaceAdapters.Add((ImageSpaceAdapter)Record);
                    break;
                case "FormList":
                case "FormListBinaryOverlay":
                    mod.FormLists.Add((FormList)Record);
                    break;
                case "Perk":
                case "PerkBinaryOverlay":
                    mod.Perks.Add((Perk)Record);
                    break;
                case "BodyPartData":
                case "BodyPartDataBinaryOverlay":
                    mod.BodyParts.Add((BodyPartData)Record);
                    break;
                case "AddonNode":
                case "AddonNodeBinaryOverlay":
                    mod.AddonNodes.Add((AddonNode)Record);
                    break;
                case "ActorValueInformation":
                case "ActorValueInformationBinaryOverlay":
                    mod.ActorValueInformation.Add((ActorValueInformation)Record);
                    break;
                case "CameraShot":
                case "CameraShotBinaryOverlay":
                    mod.CameraShots.Add((CameraShot)Record);
                    break;
                case "CameraPath":
                case "CameraPathBinaryOverlay":
                    mod.CameraPaths.Add((CameraPath)Record);
                    break;
                case "VoiceType":
                case "VoiceTypeBinaryOverlay":
                    mod.VoiceTypes.Add((VoiceType)Record);
                    break;
                case "MaterialType":
                case "MaterialTypeBinaryOverlay":
                    mod.MaterialTypes.Add((MaterialType)Record);
                    break;
                case "Impact":
                case "ImpactBinaryOverlay":
                    mod.Impacts.Add((Impact)Record);
                    break;
                case "ImpactDataSet":
                case "ImpactDataSetBinaryOverlay":
                    mod.ImpactDataSets.Add((ImpactDataSet)Record);
                    break;
                case "ArmorAddon":
                case "ArmorAddonBinaryOverlay":
                    mod.ArmorAddons.Add((ArmorAddon)Record);
                    break;
                case "EncounterZone":
                case "EncounterZoneBinaryOverlay":
                    mod.EncounterZones.Add((EncounterZone)Record);
                    break;
                case "Location":
                case "LocationBinaryOverlay":
                    mod.Locations.Add((Location)Record);
                    break;
                case "Message":
                case "MessageBinaryOverlay":
                    mod.Messages.Add((Message)Record);
                    break;
                case "DefaultObjectManager":
                case "DefaultObjectManagerBinaryOverlay":
                    mod.DefaultObjectManagers.Add((DefaultObjectManager)Record);
                    break;
                case "DefaultObject":
                case "DefaultObjectBinaryOverlay":
                    mod.DefaultObjects.Add((DefaultObject)Record);
                    break;
                case "LightingTemplate":
                case "LightingTemplateBinaryOverlay":
                    mod.LightingTemplates.Add((LightingTemplate)Record);
                    break;
                case "MusicType":
                case "MusicTypeBinaryOverlay":
                    mod.MusicTypes.Add((MusicType)Record);
                    break;
                case "Footstep":
                case "FootstepBinaryOverlay":
                    mod.Footsteps.Add((Footstep)Record);
                    break;
                case "FootstepSet":
                case "FootstepSetBinaryOverlay":
                    mod.FootstepSets.Add((FootstepSet)Record);
                    break;
                case "StoryManagerBranchNode":
                case "StoryManagerBranchNodeBinaryOverlay":
                    mod.StoryManagerBranchNodes.Add((StoryManagerBranchNode)Record);
                    break;
                case "StoryManagerQuestNode":
                case "StoryManagerQuestNodeBinaryOverlay":
                    mod.StoryManagerQuestNodes.Add((StoryManagerQuestNode)Record);
                    break;
                case "StoryManagerEventNode":
                case "StoryManagerEventNodeBinaryOverlay":
                    mod.StoryManagerEventNodes.Add((StoryManagerEventNode)Record);
                    break;
                case "MusicTrack":
                case "MusicTrackBinaryOverlay":
                    mod.MusicTracks.Add((MusicTrack)Record);
                    break;
                case "DialogView":
                case "DialogViewBinaryOverlay":
                    mod.DialogViews.Add((DialogView)Record);
                    break;
                case "EquipType":
                case "EquipTypeBinaryOverlay":
                    mod.EquipTypes.Add((EquipType)Record);
                    break;
                case "Relationship":
                case "RelationshipBinaryOverlay":
                    mod.Relationships.Add((Relationship)Record);
                    break;
                case "AssociationType":
                case "AssociationTypeBinaryOverlay":
                    mod.AssociationTypes.Add((AssociationType)Record);
                    break;
                case "Outfit":
                case "OutfitBinaryOverlay":
                    mod.Outfits.Add((Outfit)Record);
                    break;
                case "ArtObject":
                case "ArtObjectBinaryOverlay":
                    mod.ArtObjects.Add((ArtObject)Record);
                    break;
                case "MaterialObject":
                case "MaterialObjectBinaryOverlay":
                    mod.MaterialObjects.Add((MaterialObject)Record);
                    break;
                case "MovementType":
                case "MovementTypeBinaryOverlay":
                    mod.MovementTypes.Add((MovementType)Record);
                    break;
                case "SoundDescriptor":
                case "SoundDescriptorBinaryOverlay":
                    mod.SoundDescriptors.Add((SoundDescriptor)Record);
                    break;
                case "SoundCategory":
                case "SoundCategoryBinaryOverlay":
                    mod.SoundCategories.Add((SoundCategory)Record);
                    break;
                case "SoundOutputModel":
                case "SoundOutputModelBinaryOverlay":
                    mod.SoundOutputModels.Add((SoundOutputModel)Record);
                    break;
                case "CollisionLayer":
                case "CollisionLayerBinaryOverlay":
                    mod.CollisionLayers.Add((CollisionLayer)Record);
                    break;
                case "ColorRecord":
                case "ColorRecordBinaryOverlay":
                    mod.Colors.Add((ColorRecord)Record);
                    break;
                case "ReverbParameters":
                case "ReverbParametersBinaryOverlay":
                    mod.ReverbParameters.Add((ReverbParameters)Record);
                    break;
                case "PackIn":
                case "PackInBinaryOverlay":
                    mod.PackIns.Add((PackIn)Record);
                    break;
                case "ReferenceGroup":
                case "ReferenceGroupBinaryOverlay":
                    mod.ReferenceGroups.Add((ReferenceGroup)Record);
                    break;
                case "AimModel":
                case "AimModelBinaryOverlay":
                    mod.AimModels.Add((AimModel)Record);
                    break;
                case "Layer":
                case "LayerBinaryOverlay":
                    mod.Layers.Add((Layer)Record);
                    break;
                case "ConstructibleObject":
                case "ConstructibleObjectBinaryOverlay":
                    mod.ConstructibleObjects.Add((ConstructibleObject)Record);
                    break;
                case "AObjectModification":
                case "AObjectModificationBinaryOverlay":
                    mod.ObjectModifications.Add((AObjectModification)Record);
                    break;
                case "MaterialSwap":
                case "MaterialSwapBinaryOverlay":
                    mod.MaterialSwaps.Add((MaterialSwap)Record);
                    break;
                case "Zoom":
                case "ZoomBinaryOverlay":
                    mod.Zooms.Add((Zoom)Record);
                    break;
                case "InstanceNamingRules":
                case "InstanceNamingRulesBinaryOverlay":
                    mod.InstanceNamingRules.Add((InstanceNamingRules)Record);
                    break;
                case "SoundKeywordMapping":
                case "SoundKeywordMappingBinaryOverlay":
                    mod.SoundKeywordMappings.Add((SoundKeywordMapping)Record);
                    break;
                case "AudioEffectChain":
                case "AudioEffectChainBinaryOverlay":
                    mod.AudioEffectChains.Add((AudioEffectChain)Record);
                    break;
                case "SceneCollection":
                case "SceneCollectionBinaryOverlay":
                    mod.SceneCollections.Add((SceneCollection)Record);
                    break;
                case "AttractionRule":
                case "AttractionRuleBinaryOverlay":
                    mod.AttractionRules.Add((AttractionRule)Record);
                    break;
                case "AudioCategorySnapshot":
                case "AudioCategorySnapshotBinaryOverlay":
                    mod.AudioCategorySnapshots.Add((AudioCategorySnapshot)Record);
                    break;
                case "AnimationSoundTagSet":
                case "AnimationSoundTagSetBinaryOverlay":
                    mod.AnimationSoundTagSets.Add((AnimationSoundTagSet)Record);
                    break;
                case "NavigationMeshObstacleManager":
                case "NavigationMeshObstacleManagerBinaryOverlay":
                    mod.NavigationMeshObstacleManagers.Add((NavigationMeshObstacleManager)Record);
                    break;
                case "LensFlare":
                case "LensFlareBinaryOverlay":
                    mod.LensFlares.Add((LensFlare)Record);
                    break;
                case "GodRays":
                case "GodRaysBinaryOverlay":
                    mod.GodRays.Add((GodRays)Record);
                    break;
                case "ObjectVisibilityManager":
                case "ObjectVisibilityManagerBinaryOverlay":
                    mod.ObjectVisibilityManagers.Add((ObjectVisibilityManager)Record);
                    break;

                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }
}
