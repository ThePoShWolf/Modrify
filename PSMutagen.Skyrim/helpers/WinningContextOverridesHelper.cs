using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using PSMutagen.Core;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Environments;

namespace PSMutagen.Skyrim
{
    public static partial class Helpers
    {
        public static IEnumerable<IModContext<ISkyrimMod, ISkyrimModGetter, ISkyrimMajorRecord, ISkyrimMajorRecordGetter>> WinningContextOverrides(string recordType)
        {
            IGameEnvironment<ISkyrimMod, ISkyrimModGetter> sge = GameEnvironment.Typical.Skyrim(PSMutagenConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease());
            switch (recordType)
            {
                case "GameSetting":
                case "GameSettingBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.GameSetting().WinningContextOverrides();
                case "Keyword":
                case "KeywordBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Keyword().WinningContextOverrides();
                case "LocationReferenceType":
                case "LocationReferenceTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LocationReferenceType().WinningContextOverrides();
                case "ActionRecord":
                case "ActionRecordBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ActionRecord().WinningContextOverrides();
                case "TextureSet":
                case "TextureSetBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.TextureSet().WinningContextOverrides();
                case "Global":
                case "GlobalBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Global().WinningContextOverrides();
                case "Class":
                case "ClassBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Class().WinningContextOverrides();
                case "Faction":
                case "FactionBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Faction().WinningContextOverrides();
                case "HeadPart":
                case "HeadPartBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.HeadPart().WinningContextOverrides();
                case "Hair":
                case "HairBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Hair().WinningContextOverrides();
                case "Eyes":
                case "EyesBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Eyes().WinningContextOverrides();
                case "Race":
                case "RaceBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Race().WinningContextOverrides();
                case "SoundMarker":
                case "SoundMarkerBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.SoundMarker().WinningContextOverrides();
                case "AcousticSpace":
                case "AcousticSpaceBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.AcousticSpace().WinningContextOverrides();
                case "MagicEffect":
                case "MagicEffectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MagicEffect().WinningContextOverrides();
                case "LandscapeTexture":
                case "LandscapeTextureBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LandscapeTexture().WinningContextOverrides();
                case "ObjectEffect":
                case "ObjectEffectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ObjectEffect().WinningContextOverrides();
                case "Spell":
                case "SpellBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Spell().WinningContextOverrides();
                case "Scroll":
                case "ScrollBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Scroll().WinningContextOverrides();
                case "Activator":
                case "ActivatorBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Activator().WinningContextOverrides();
                case "TalkingActivator":
                case "TalkingActivatorBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.TalkingActivator().WinningContextOverrides();
                case "Armor":
                case "ArmorBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Armor().WinningContextOverrides();
                case "Book":
                case "BookBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Book().WinningContextOverrides();
                case "Container":
                case "ContainerBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Container().WinningContextOverrides();
                case "Door":
                case "DoorBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Door().WinningContextOverrides();
                case "Ingredient":
                case "IngredientBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Ingredient().WinningContextOverrides();
                case "Light":
                case "LightBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Light().WinningContextOverrides();
                case "MiscItem":
                case "MiscItemBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MiscItem().WinningContextOverrides();
                case "AlchemicalApparatus":
                case "AlchemicalApparatusBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.AlchemicalApparatus().WinningContextOverrides();
                case "Static":
                case "StaticBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Static().WinningContextOverrides();
                case "MoveableStatic":
                case "MoveableStaticBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MoveableStatic().WinningContextOverrides();
                case "Grass":
                case "GrassBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Grass().WinningContextOverrides();
                case "Tree":
                case "TreeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Tree().WinningContextOverrides();
                case "Flora":
                case "FloraBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Flora().WinningContextOverrides();
                case "Furniture":
                case "FurnitureBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Furniture().WinningContextOverrides();
                case "Weapon":
                case "WeaponBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Weapon().WinningContextOverrides();
                case "Ammunition":
                case "AmmunitionBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Ammunition().WinningContextOverrides();
                case "Npc":
                case "NpcBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Npc().WinningContextOverrides();
                case "LeveledNpc":
                case "LeveledNpcBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LeveledNpc().WinningContextOverrides();
                case "Key":
                case "KeyBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Key().WinningContextOverrides();
                case "Ingestible":
                case "IngestibleBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Ingestible().WinningContextOverrides();
                case "IdleMarker":
                case "IdleMarkerBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.IdleMarker().WinningContextOverrides();
                case "ConstructibleObject":
                case "ConstructibleObjectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ConstructibleObject().WinningContextOverrides();
                case "Projectile":
                case "ProjectileBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Projectile().WinningContextOverrides();
                case "Hazard":
                case "HazardBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Hazard().WinningContextOverrides();
                case "SoulGem":
                case "SoulGemBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.SoulGem().WinningContextOverrides();
                case "LeveledItem":
                case "LeveledItemBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LeveledItem().WinningContextOverrides();
                case "Weather":
                case "WeatherBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Weather().WinningContextOverrides();
                case "Climate":
                case "ClimateBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Climate().WinningContextOverrides();
                case "ShaderParticleGeometry":
                case "ShaderParticleGeometryBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ShaderParticleGeometry().WinningContextOverrides();
                case "VisualEffect":
                case "VisualEffectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.VisualEffect().WinningContextOverrides();
                case "Region":
                case "RegionBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Region().WinningContextOverrides();
                case "NavigationMeshInfoMap":
                case "NavigationMeshInfoMapBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.NavigationMeshInfoMap().WinningContextOverrides();
                case "Worldspace":
                case "WorldspaceBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Worldspace().WinningContextOverrides();
                case "DialogTopic":
                case "DialogTopicBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.DialogTopic().WinningContextOverrides();
                case "Quest":
                case "QuestBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Quest().WinningContextOverrides();
                case "IdleAnimation":
                case "IdleAnimationBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.IdleAnimation().WinningContextOverrides();
                case "Package":
                case "PackageBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Package().WinningContextOverrides();
                case "CombatStyle":
                case "CombatStyleBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.CombatStyle().WinningContextOverrides();
                case "LoadScreen":
                case "LoadScreenBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LoadScreen().WinningContextOverrides();
                case "LeveledSpell":
                case "LeveledSpellBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LeveledSpell().WinningContextOverrides();
                case "AnimatedObject":
                case "AnimatedObjectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.AnimatedObject().WinningContextOverrides();
                case "Water":
                case "WaterBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Water().WinningContextOverrides();
                case "EffectShader":
                case "EffectShaderBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.EffectShader().WinningContextOverrides();
                case "Explosion":
                case "ExplosionBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Explosion().WinningContextOverrides();
                case "Debris":
                case "DebrisBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Debris().WinningContextOverrides();
                case "ImageSpace":
                case "ImageSpaceBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ImageSpace().WinningContextOverrides();
                case "ImageSpaceAdapter":
                case "ImageSpaceAdapterBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ImageSpaceAdapter().WinningContextOverrides();
                case "FormList":
                case "FormListBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.FormList().WinningContextOverrides();
                case "Perk":
                case "PerkBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Perk().WinningContextOverrides();
                case "BodyPartData":
                case "BodyPartDataBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.BodyPartData().WinningContextOverrides();
                case "AddonNode":
                case "AddonNodeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.AddonNode().WinningContextOverrides();
                case "ActorValueInformation":
                case "ActorValueInformationBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ActorValueInformation().WinningContextOverrides();
                case "CameraShot":
                case "CameraShotBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.CameraShot().WinningContextOverrides();
                case "CameraPath":
                case "CameraPathBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.CameraPath().WinningContextOverrides();
                case "VoiceType":
                case "VoiceTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.VoiceType().WinningContextOverrides();
                case "MaterialType":
                case "MaterialTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MaterialType().WinningContextOverrides();
                case "Impact":
                case "ImpactBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Impact().WinningContextOverrides();
                case "ImpactDataSet":
                case "ImpactDataSetBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ImpactDataSet().WinningContextOverrides();
                case "ArmorAddon":
                case "ArmorAddonBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ArmorAddon().WinningContextOverrides();
                case "EncounterZone":
                case "EncounterZoneBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.EncounterZone().WinningContextOverrides();
                case "Location":
                case "LocationBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Location().WinningContextOverrides();
                case "Message":
                case "MessageBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Message().WinningContextOverrides();
                case "DefaultObjectManager":
                case "DefaultObjectManagerBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.DefaultObjectManager().WinningContextOverrides();
                case "LightingTemplate":
                case "LightingTemplateBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.LightingTemplate().WinningContextOverrides();
                case "MusicType":
                case "MusicTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MusicType().WinningContextOverrides();
                case "Footstep":
                case "FootstepBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Footstep().WinningContextOverrides();
                case "FootstepSet":
                case "FootstepSetBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.FootstepSet().WinningContextOverrides();
                case "DialogBranch":
                case "DialogBranchBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.DialogBranch().WinningContextOverrides();
                case "MusicTrack":
                case "MusicTrackBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MusicTrack().WinningContextOverrides();
                case "DialogView":
                case "DialogViewBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.DialogView().WinningContextOverrides();
                case "WordOfPower":
                case "WordOfPowerBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.WordOfPower().WinningContextOverrides();
                case "Shout":
                case "ShoutBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Shout().WinningContextOverrides();
                case "EquipType":
                case "EquipTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.EquipType().WinningContextOverrides();
                case "Relationship":
                case "RelationshipBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Relationship().WinningContextOverrides();
                case "Scene":
                case "SceneBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Scene().WinningContextOverrides();
                case "AssociationType":
                case "AssociationTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.AssociationType().WinningContextOverrides();
                case "Outfit":
                case "OutfitBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.Outfit().WinningContextOverrides();
                case "ArtObject":
                case "ArtObjectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ArtObject().WinningContextOverrides();
                case "MaterialObject":
                case "MaterialObjectBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MaterialObject().WinningContextOverrides();
                case "MovementType":
                case "MovementTypeBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.MovementType().WinningContextOverrides();
                case "SoundDescriptor":
                case "SoundDescriptorBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.SoundDescriptor().WinningContextOverrides();
                case "DualCastData":
                case "DualCastDataBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.DualCastData().WinningContextOverrides();
                case "SoundCategory":
                case "SoundCategoryBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.SoundCategory().WinningContextOverrides();
                case "SoundOutputModel":
                case "SoundOutputModelBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.SoundOutputModel().WinningContextOverrides();
                case "CollisionLayer":
                case "CollisionLayerBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.CollisionLayer().WinningContextOverrides();
                case "ColorRecord":
                case "ColorRecordBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ColorRecord().WinningContextOverrides();
                case "ReverbParameters":
                case "ReverbParametersBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.ReverbParameters().WinningContextOverrides();
                case "VolumetricLighting":
                case "VolumetricLightingBinaryOverlay":
                    return sge.LoadOrder.PriorityOrder.VolumetricLighting().WinningContextOverrides();
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {recordType}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }
}