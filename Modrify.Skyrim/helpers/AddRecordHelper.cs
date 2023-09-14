using Mutagen.Bethesda.Skyrim;

namespace Modrify.Skyrim
{
    public static partial class Helpers
    {
        public static void AddRecordHelper(ISkyrimMod mod, ISkyrimMajorRecordGetter Record)
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
                case "TextureSet":
                case "TextureSetBinaryOverlay":
                    mod.TextureSets.Add((TextureSet)Record);
                    break;
                case "Global":
                case "GlobalBinaryOverlay":
                    mod.Globals.Add((Global)Record);
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
                case "Hair":
                case "HairBinaryOverlay":
                    mod.Hairs.Add((Hair)Record);
                    break;
                case "Eyes":
                case "EyesBinaryOverlay":
                    mod.Eyes.Add((Eyes)Record);
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
                case "Scroll":
                case "ScrollBinaryOverlay":
                    mod.Scrolls.Add((Scroll)Record);
                    break;
                case "Activator":
                case "ActivatorBinaryOverlay":
                    mod.Activators.Add((Mutagen.Bethesda.Skyrim.Activator)Record);
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
                case "AlchemicalApparatus":
                case "AlchemicalApparatusBinaryOverlay":
                    mod.AlchemicalApparatuses.Add((AlchemicalApparatus)Record);
                    break;
                case "Static":
                case "StaticBinaryOverlay":
                    mod.Statics.Add((Static)Record);
                    break;
                case "MoveableStatic":
                case "MoveableStaticBinaryOverlay":
                    mod.MoveableStatics.Add((MoveableStatic)Record);
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
                case "ConstructibleObject":
                case "ConstructibleObjectBinaryOverlay":
                    mod.ConstructibleObjects.Add((ConstructibleObject)Record);
                    break;
                case "Projectile":
                case "ProjectileBinaryOverlay":
                    mod.Projectiles.Add((Projectile)Record);
                    break;
                case "Hazard":
                case "HazardBinaryOverlay":
                    mod.Hazards.Add((Hazard)Record);
                    break;
                case "SoulGem":
                case "SoulGemBinaryOverlay":
                    mod.SoulGems.Add((SoulGem)Record);
                    break;
                case "LeveledItem":
                case "LeveledItemBinaryOverlay":
                    mod.LeveledItems.Add((LeveledItem)Record);
                    break;
                case "Weather":
                case "WeatherBinaryOverlay":
                    mod.Weathers.Add((Weather)Record);
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
                case "DialogTopic":
                case "DialogTopicBinaryOverlay":
                    mod.DialogTopics.Add((DialogTopic)Record);
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
                case "LeveledSpell":
                case "LeveledSpellBinaryOverlay":
                    mod.LeveledSpells.Add((LeveledSpell)Record);
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
                case "DialogBranch":
                case "DialogBranchBinaryOverlay":
                    mod.DialogBranches.Add((DialogBranch)Record);
                    break;
                case "MusicTrack":
                case "MusicTrackBinaryOverlay":
                    mod.MusicTracks.Add((MusicTrack)Record);
                    break;
                case "DialogView":
                case "DialogViewBinaryOverlay":
                    mod.DialogViews.Add((DialogView)Record);
                    break;
                case "WordOfPower":
                case "WordOfPowerBinaryOverlay":
                    mod.WordsOfPower.Add((WordOfPower)Record);
                    break;
                case "Shout":
                case "ShoutBinaryOverlay":
                    mod.Shouts.Add((Shout)Record);
                    break;
                case "EquipType":
                case "EquipTypeBinaryOverlay":
                    mod.EquipTypes.Add((EquipType)Record);
                    break;
                case "Relationship":
                case "RelationshipBinaryOverlay":
                    mod.Relationships.Add((Relationship)Record);
                    break;
                case "Scene":
                case "SceneBinaryOverlay":
                    mod.Scenes.Add((Scene)Record);
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
                case "DualCastData":
                case "DualCastDataBinaryOverlay":
                    mod.DualCastData.Add((DualCastData)Record);
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
                case "VolumetricLighting":
                case "VolumetricLightingBinaryOverlay":
                    mod.VolumetricLightings.Add((VolumetricLighting)Record);
                    break;

                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in Modrify's GitHub repository.");
            }
        }
    }
}
