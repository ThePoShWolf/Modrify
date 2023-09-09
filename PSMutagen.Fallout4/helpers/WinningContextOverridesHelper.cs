using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using PSMutagen.Core;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Environments;

namespace PSMutagen.Fallout4
{
    public static partial class Helpers
    {
        public static IEnumerable<IModContext<IFallout4Mod, IFallout4ModGetter, IFallout4MajorRecord, IFallout4MajorRecordGetter>> WinningContextOverrides(string recordType)
        {
            IGameEnvironment<IFallout4Mod, IFallout4ModGetter>fge = GameEnvironment.Typical.Fallout4();
            switch (recordType)
            {
                case "GameSetting":
                case "GameSettingBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.GameSetting().WinningContextOverrides();
                case "Keyword":
                case "KeywordBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Keyword().WinningContextOverrides();
                case "LocationReferenceType":
                case "LocationReferenceTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LocationReferenceType().WinningContextOverrides();
                case "ActionRecord":
                case "ActionRecordBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ActionRecord().WinningContextOverrides();
                case "Transform":
                case "TransformBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Transform().WinningContextOverrides();
                case "Component":
                case "ComponentBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Component().WinningContextOverrides();
                case "TextureSet":
                case "TextureSetBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.TextureSet().WinningContextOverrides();
                case "Global":
                case "GlobalBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Global().WinningContextOverrides();
                case "ADamageType":
                case "ADamageTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ADamageType().WinningContextOverrides();
                case "Class":
                case "ClassBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Class().WinningContextOverrides();
                case "Faction":
                case "FactionBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Faction().WinningContextOverrides();
                case "HeadPart":
                case "HeadPartBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.HeadPart().WinningContextOverrides();
                case "Race":
                case "RaceBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Race().WinningContextOverrides();
                case "SoundMarker":
                case "SoundMarkerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.SoundMarker().WinningContextOverrides();
                case "AcousticSpace":
                case "AcousticSpaceBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AcousticSpace().WinningContextOverrides();
                case "MagicEffect":
                case "MagicEffectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MagicEffect().WinningContextOverrides();
                case "LandscapeTexture":
                case "LandscapeTextureBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LandscapeTexture().WinningContextOverrides();
                case "ObjectEffect":
                case "ObjectEffectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ObjectEffect().WinningContextOverrides();
                case "Spell":
                case "SpellBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Spell().WinningContextOverrides();
                case "Activator":
                case "ActivatorBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Activator().WinningContextOverrides();
                case "TalkingActivator":
                case "TalkingActivatorBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.TalkingActivator().WinningContextOverrides();
                case "Armor":
                case "ArmorBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Armor().WinningContextOverrides();
                case "Book":
                case "BookBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Book().WinningContextOverrides();
                case "Container":
                case "ContainerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Container().WinningContextOverrides();
                case "Door":
                case "DoorBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Door().WinningContextOverrides();
                case "Ingredient":
                case "IngredientBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Ingredient().WinningContextOverrides();
                case "Light":
                case "LightBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Light().WinningContextOverrides();
                case "MiscItem":
                case "MiscItemBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MiscItem().WinningContextOverrides();
                case "Static":
                case "StaticBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Static().WinningContextOverrides();
                case "StaticCollection":
                case "StaticCollectionBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.StaticCollection().WinningContextOverrides();
                case "MovableStatic":
                case "MovableStaticBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MovableStatic().WinningContextOverrides();
                case "Grass":
                case "GrassBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Grass().WinningContextOverrides();
                case "Tree":
                case "TreeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Tree().WinningContextOverrides();
                case "Flora":
                case "FloraBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Flora().WinningContextOverrides();
                case "Furniture":
                case "FurnitureBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Furniture().WinningContextOverrides();
                case "Weapon":
                case "WeaponBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Weapon().WinningContextOverrides();
                case "Ammunition":
                case "AmmunitionBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Ammunition().WinningContextOverrides();
                case "Npc":
                case "NpcBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Npc().WinningContextOverrides();
                case "LeveledNpc":
                case "LeveledNpcBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LeveledNpc().WinningContextOverrides();
                case "Key":
                case "KeyBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Key().WinningContextOverrides();
                case "Ingestible":
                case "IngestibleBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Ingestible().WinningContextOverrides();
                case "IdleMarker":
                case "IdleMarkerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.IdleMarker().WinningContextOverrides();
                case "Holotape":
                case "HolotapeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Holotape().WinningContextOverrides();
                case "Projectile":
                case "ProjectileBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Projectile().WinningContextOverrides();
                case "Hazard":
                case "HazardBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Hazard().WinningContextOverrides();
                case "BendableSpline":
                case "BendableSplineBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.BendableSpline().WinningContextOverrides();
                case "Terminal":
                case "TerminalBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Terminal().WinningContextOverrides();
                case "LeveledItem":
                case "LeveledItemBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LeveledItem().WinningContextOverrides();
                case "Weather":
                case "WeatherBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Weather().WinningContextOverrides();
                case "Climate":
                case "ClimateBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Climate().WinningContextOverrides();
                case "ShaderParticleGeometry":
                case "ShaderParticleGeometryBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ShaderParticleGeometry().WinningContextOverrides();
                case "VisualEffect":
                case "VisualEffectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.VisualEffect().WinningContextOverrides();
                case "Region":
                case "RegionBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Region().WinningContextOverrides();
                case "NavigationMeshInfoMap":
                case "NavigationMeshInfoMapBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.NavigationMeshInfoMap().WinningContextOverrides();
                case "Worldspace":
                case "WorldspaceBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Worldspace().WinningContextOverrides();
                case "Quest":
                case "QuestBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Quest().WinningContextOverrides();
                case "IdleAnimation":
                case "IdleAnimationBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.IdleAnimation().WinningContextOverrides();
                case "Package":
                case "PackageBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Package().WinningContextOverrides();
                case "CombatStyle":
                case "CombatStyleBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.CombatStyle().WinningContextOverrides();
                case "LoadScreen":
                case "LoadScreenBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LoadScreen().WinningContextOverrides();
                case "AnimatedObject":
                case "AnimatedObjectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AnimatedObject().WinningContextOverrides();
                case "Water":
                case "WaterBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Water().WinningContextOverrides();
                case "EffectShader":
                case "EffectShaderBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.EffectShader().WinningContextOverrides();
                case "Explosion":
                case "ExplosionBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Explosion().WinningContextOverrides();
                case "Debris":
                case "DebrisBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Debris().WinningContextOverrides();
                case "ImageSpace":
                case "ImageSpaceBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ImageSpace().WinningContextOverrides();
                case "ImageSpaceAdapter":
                case "ImageSpaceAdapterBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ImageSpaceAdapter().WinningContextOverrides();
                case "FormList":
                case "FormListBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.FormList().WinningContextOverrides();
                case "Perk":
                case "PerkBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Perk().WinningContextOverrides();
                case "BodyPartData":
                case "BodyPartDataBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.BodyPartData().WinningContextOverrides();
                case "AddonNode":
                case "AddonNodeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AddonNode().WinningContextOverrides();
                case "ActorValueInformation":
                case "ActorValueInformationBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ActorValueInformation().WinningContextOverrides();
                case "CameraShot":
                case "CameraShotBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.CameraShot().WinningContextOverrides();
                case "CameraPath":
                case "CameraPathBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.CameraPath().WinningContextOverrides();
                case "VoiceType":
                case "VoiceTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.VoiceType().WinningContextOverrides();
                case "MaterialType":
                case "MaterialTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MaterialType().WinningContextOverrides();
                case "Impact":
                case "ImpactBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Impact().WinningContextOverrides();
                case "ImpactDataSet":
                case "ImpactDataSetBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ImpactDataSet().WinningContextOverrides();
                case "ArmorAddon":
                case "ArmorAddonBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ArmorAddon().WinningContextOverrides();
                case "EncounterZone":
                case "EncounterZoneBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.EncounterZone().WinningContextOverrides();
                case "Location":
                case "LocationBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Location().WinningContextOverrides();
                case "Message":
                case "MessageBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Message().WinningContextOverrides();
                case "DefaultObjectManager":
                case "DefaultObjectManagerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.DefaultObjectManager().WinningContextOverrides();
                case "DefaultObject":
                case "DefaultObjectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.DefaultObject().WinningContextOverrides();
                case "LightingTemplate":
                case "LightingTemplateBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LightingTemplate().WinningContextOverrides();
                case "MusicType":
                case "MusicTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MusicType().WinningContextOverrides();
                case "Footstep":
                case "FootstepBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Footstep().WinningContextOverrides();
                case "FootstepSet":
                case "FootstepSetBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.FootstepSet().WinningContextOverrides();
                case "MusicTrack":
                case "MusicTrackBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MusicTrack().WinningContextOverrides();
                case "DialogView":
                case "DialogViewBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.DialogView().WinningContextOverrides();
                case "EquipType":
                case "EquipTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.EquipType().WinningContextOverrides();
                case "Relationship":
                case "RelationshipBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Relationship().WinningContextOverrides();
                case "AssociationType":
                case "AssociationTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AssociationType().WinningContextOverrides();
                case "Outfit":
                case "OutfitBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Outfit().WinningContextOverrides();
                case "ArtObject":
                case "ArtObjectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ArtObject().WinningContextOverrides();
                case "MaterialObject":
                case "MaterialObjectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MaterialObject().WinningContextOverrides();
                case "MovementType":
                case "MovementTypeBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MovementType().WinningContextOverrides();
                case "SoundDescriptor":
                case "SoundDescriptorBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.SoundDescriptor().WinningContextOverrides();
                case "SoundCategory":
                case "SoundCategoryBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.SoundCategory().WinningContextOverrides();
                case "SoundOutputModel":
                case "SoundOutputModelBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.SoundOutputModel().WinningContextOverrides();
                case "CollisionLayer":
                case "CollisionLayerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.CollisionLayer().WinningContextOverrides();
                case "ColorRecord":
                case "ColorRecordBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ColorRecord().WinningContextOverrides();
                case "ReverbParameters":
                case "ReverbParametersBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ReverbParameters().WinningContextOverrides();
                case "PackIn":
                case "PackInBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.PackIn().WinningContextOverrides();
                case "ReferenceGroup":
                case "ReferenceGroupBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ReferenceGroup().WinningContextOverrides();
                case "AimModel":
                case "AimModelBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AimModel().WinningContextOverrides();
                case "Layer":
                case "LayerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Layer().WinningContextOverrides();
                case "ConstructibleObject":
                case "ConstructibleObjectBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ConstructibleObject().WinningContextOverrides();
                case "AObjectModification":
                case "AObjectModificationBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AObjectModification().WinningContextOverrides();
                case "MaterialSwap":
                case "MaterialSwapBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.MaterialSwap().WinningContextOverrides();
                case "Zoom":
                case "ZoomBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.Zoom().WinningContextOverrides();
                case "InstanceNamingRules":
                case "InstanceNamingRulesBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.InstanceNamingRules().WinningContextOverrides();
                case "SoundKeywordMapping":
                case "SoundKeywordMappingBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.SoundKeywordMapping().WinningContextOverrides();
                case "AudioEffectChain":
                case "AudioEffectChainBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AudioEffectChain().WinningContextOverrides();
                case "SceneCollection":
                case "SceneCollectionBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.SceneCollection().WinningContextOverrides();
                case "AttractionRule":
                case "AttractionRuleBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AttractionRule().WinningContextOverrides();
                case "AudioCategorySnapshot":
                case "AudioCategorySnapshotBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AudioCategorySnapshot().WinningContextOverrides();
                case "AnimationSoundTagSet":
                case "AnimationSoundTagSetBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.AnimationSoundTagSet().WinningContextOverrides();
                case "NavigationMeshObstacleManager":
                case "NavigationMeshObstacleManagerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.NavigationMeshObstacleManager().WinningContextOverrides();
                case "LensFlare":
                case "LensFlareBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.LensFlare().WinningContextOverrides();
                case "GodRays":
                case "GodRaysBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.GodRays().WinningContextOverrides();
                case "ObjectVisibilityManager":
                case "ObjectVisibilityManagerBinaryOverlay":
                    return fge.LoadOrder.PriorityOrder.ObjectVisibilityManager().WinningContextOverrides();
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {recordType}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }
}
