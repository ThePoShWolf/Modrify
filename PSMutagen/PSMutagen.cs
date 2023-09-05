using System.Management.Automation;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Environments.DI;
using Mutagen.Bethesda.Installs;
using Mutagen.Bethesda.Installs.DI;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Cache;
using Mutagen.Bethesda.Plugins.Implicit.DI;
using Mutagen.Bethesda.Plugins.Order;
using Mutagen.Bethesda.Plugins.Order.DI;
using Mutagen.Bethesda.Plugins.Records.DI;
using Noggog;
using System;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace MutagenCmdlets
{

    public class Config
    {
        public static IGameEnvironment Environment;
    }

    public class MajorRecordInfo
    {
        public static Dictionary<string, Type> MajorRecordTypes = new Dictionary<string, Type>()
        {
            { "AcousticSpace", Type.GetType("Mutagen.Bethesda.Skyrim.IAcousticSpaceGetter, Mutagen.Bethesda.Skyrim") },
            { "ActionRecord", Type.GetType("Mutagen.Bethesda.Skyrim.IActionRecordGetter, Mutagen.Bethesda.Skyrim") },
            { "Activator", Type.GetType("Mutagen.Bethesda.Skyrim.IActivatorGetter, Mutagen.Bethesda.Skyrim") },
            { "ActorValueInformation", Type.GetType("Mutagen.Bethesda.Skyrim.IActorValueInformationGetter, Mutagen.Bethesda.Skyrim") },
            { "AddonNode", Type.GetType("Mutagen.Bethesda.Skyrim.IAddonNodeGetter, Mutagen.Bethesda.Skyrim") },
            { "AlchemicalApparatus", Type.GetType("Mutagen.Bethesda.Skyrim.IAlchemicalApparatusGetter, Mutagen.Bethesda.Skyrim") },
            { "Ammunition", Type.GetType("Mutagen.Bethesda.Skyrim.IAmmunitionGetter, Mutagen.Bethesda.Skyrim") },
            { "AnimatedObject", Type.GetType("Mutagen.Bethesda.Skyrim.IAnimatedObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "APlacedTrap", Type.GetType("Mutagen.Bethesda.Skyrim.IAPlacedTrapGetter, Mutagen.Bethesda.Skyrim") },
            { "Armor", Type.GetType("Mutagen.Bethesda.Skyrim.IArmorGetter, Mutagen.Bethesda.Skyrim") },
            { "ArmorAddon", Type.GetType("Mutagen.Bethesda.Skyrim.IArmorAddonGetter, Mutagen.Bethesda.Skyrim") },
            { "ArtObject", Type.GetType("Mutagen.Bethesda.Skyrim.IArtObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "AssociationType", Type.GetType("Mutagen.Bethesda.Skyrim.IAssociationTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "AStoryManagerNode", Type.GetType("Mutagen.Bethesda.Skyrim.IAStoryManagerNodeGetter, Mutagen.Bethesda.Skyrim") },
            { "BodyPartData", Type.GetType("Mutagen.Bethesda.Skyrim.IBodyPartDataGetter, Mutagen.Bethesda.Skyrim") },
            { "Book", Type.GetType("Mutagen.Bethesda.Skyrim.IBookGetter, Mutagen.Bethesda.Skyrim") },
            { "CameraPath", Type.GetType("Mutagen.Bethesda.Skyrim.ICameraPathGetter, Mutagen.Bethesda.Skyrim") },
            { "CameraShot", Type.GetType("Mutagen.Bethesda.Skyrim.ICameraShotGetter, Mutagen.Bethesda.Skyrim") },
            { "Cell", Type.GetType("Mutagen.Bethesda.Skyrim.ICellGetter, Mutagen.Bethesda.Skyrim") },
            { "Class", Type.GetType("Mutagen.Bethesda.Skyrim.IClassGetter, Mutagen.Bethesda.Skyrim") },
            { "Climate", Type.GetType("Mutagen.Bethesda.Skyrim.IClimateGetter, Mutagen.Bethesda.Skyrim") },
            { "CollisionLayer", Type.GetType("Mutagen.Bethesda.Skyrim.ICollisionLayerGetter, Mutagen.Bethesda.Skyrim") },
            { "ColorRecord", Type.GetType("Mutagen.Bethesda.Skyrim.IColorRecordGetter, Mutagen.Bethesda.Skyrim") },
            { "CombatStyle", Type.GetType("Mutagen.Bethesda.Skyrim.ICombatStyleGetter, Mutagen.Bethesda.Skyrim") },
            { "ConstructibleObject", Type.GetType("Mutagen.Bethesda.Skyrim.IConstructibleObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "Container", Type.GetType("Mutagen.Bethesda.Skyrim.IContainerGetter, Mutagen.Bethesda.Skyrim") },
            { "Debris", Type.GetType("Mutagen.Bethesda.Skyrim.IDebrisGetter, Mutagen.Bethesda.Skyrim") },
            { "DefaultObjectManager", Type.GetType("Mutagen.Bethesda.Skyrim.IDefaultObjectManagerGetter, Mutagen.Bethesda.Skyrim") },
            { "DialogBranch", Type.GetType("Mutagen.Bethesda.Skyrim.IDialogBranchGetter, Mutagen.Bethesda.Skyrim") },
            { "DialogResponses", Type.GetType("Mutagen.Bethesda.Skyrim.IDialogResponsesGetter, Mutagen.Bethesda.Skyrim") },
            { "DialogTopic", Type.GetType("Mutagen.Bethesda.Skyrim.IDialogTopicGetter, Mutagen.Bethesda.Skyrim") },
            { "DialogView", Type.GetType("Mutagen.Bethesda.Skyrim.IDialogViewGetter, Mutagen.Bethesda.Skyrim") },
            { "Door", Type.GetType("Mutagen.Bethesda.Skyrim.IDoorGetter, Mutagen.Bethesda.Skyrim") },
            { "DualCastData", Type.GetType("Mutagen.Bethesda.Skyrim.IDualCastDataGetter, Mutagen.Bethesda.Skyrim") },
            { "EffectShader", Type.GetType("Mutagen.Bethesda.Skyrim.IEffectShaderGetter, Mutagen.Bethesda.Skyrim") },
            { "EncounterZone", Type.GetType("Mutagen.Bethesda.Skyrim.IEncounterZoneGetter, Mutagen.Bethesda.Skyrim") },
            { "EquipType", Type.GetType("Mutagen.Bethesda.Skyrim.IEquipTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "Explosion", Type.GetType("Mutagen.Bethesda.Skyrim.IExplosionGetter, Mutagen.Bethesda.Skyrim") },
            { "Eyes", Type.GetType("Mutagen.Bethesda.Skyrim.IEyesGetter, Mutagen.Bethesda.Skyrim") },
            { "Faction", Type.GetType("Mutagen.Bethesda.Skyrim.IFactionGetter, Mutagen.Bethesda.Skyrim") },
            { "Flora", Type.GetType("Mutagen.Bethesda.Skyrim.IFloraGetter, Mutagen.Bethesda.Skyrim") },
            { "Footstep", Type.GetType("Mutagen.Bethesda.Skyrim.IFootstepGetter, Mutagen.Bethesda.Skyrim") },
            { "FootstepSet", Type.GetType("Mutagen.Bethesda.Skyrim.IFootstepSetGetter, Mutagen.Bethesda.Skyrim") },
            { "FormList", Type.GetType("Mutagen.Bethesda.Skyrim.IFormListGetter, Mutagen.Bethesda.Skyrim") },
            { "Furniture", Type.GetType("Mutagen.Bethesda.Skyrim.IFurnitureGetter, Mutagen.Bethesda.Skyrim") },
            { "GameSetting", Type.GetType("Mutagen.Bethesda.Skyrim.IGameSettingGetter, Mutagen.Bethesda.Skyrim") },
            { "Global", Type.GetType("Mutagen.Bethesda.Skyrim.IGlobalGetter, Mutagen.Bethesda.Skyrim") },
            { "Grass", Type.GetType("Mutagen.Bethesda.Skyrim.IGrassGetter, Mutagen.Bethesda.Skyrim") },
            { "Hair", Type.GetType("Mutagen.Bethesda.Skyrim.IHairGetter, Mutagen.Bethesda.Skyrim") },
            { "Hazard", Type.GetType("Mutagen.Bethesda.Skyrim.IHazardGetter, Mutagen.Bethesda.Skyrim") },
            { "HeadPart", Type.GetType("Mutagen.Bethesda.Skyrim.IHeadPartGetter, Mutagen.Bethesda.Skyrim") },
            { "IdleAnimation", Type.GetType("Mutagen.Bethesda.Skyrim.IIdleAnimationGetter, Mutagen.Bethesda.Skyrim") },
            { "IdleMarker", Type.GetType("Mutagen.Bethesda.Skyrim.IIdleMarkerGetter, Mutagen.Bethesda.Skyrim") },
            { "ImageSpace", Type.GetType("Mutagen.Bethesda.Skyrim.IImageSpaceGetter, Mutagen.Bethesda.Skyrim") },
            { "ImageSpaceAdapter", Type.GetType("Mutagen.Bethesda.Skyrim.IImageSpaceAdapterGetter, Mutagen.Bethesda.Skyrim") },
            { "Impact", Type.GetType("Mutagen.Bethesda.Skyrim.IImpactGetter, Mutagen.Bethesda.Skyrim") },
            { "ImpactDataSet", Type.GetType("Mutagen.Bethesda.Skyrim.IImpactDataSetGetter, Mutagen.Bethesda.Skyrim") },
            { "Ingestible", Type.GetType("Mutagen.Bethesda.Skyrim.IIngestibleGetter, Mutagen.Bethesda.Skyrim") },
            { "Ingredient", Type.GetType("Mutagen.Bethesda.Skyrim.IIngredientGetter, Mutagen.Bethesda.Skyrim") },
            { "Key", Type.GetType("Mutagen.Bethesda.Skyrim.IKeyGetter, Mutagen.Bethesda.Skyrim") },
            { "Keyword", Type.GetType("Mutagen.Bethesda.Skyrim.IKeywordGetter, Mutagen.Bethesda.Skyrim") },
            { "Landscape", Type.GetType("Mutagen.Bethesda.Skyrim.ILandscapeGetter, Mutagen.Bethesda.Skyrim") },
            { "LandscapeTexture", Type.GetType("Mutagen.Bethesda.Skyrim.ILandscapeTextureGetter, Mutagen.Bethesda.Skyrim") },
            { "LensFlare", Type.GetType("Mutagen.Bethesda.Skyrim.ILensFlareGetter, Mutagen.Bethesda.Skyrim") },
            { "LeveledItem", Type.GetType("Mutagen.Bethesda.Skyrim.ILeveledItemGetter, Mutagen.Bethesda.Skyrim") },
            { "LeveledNpc", Type.GetType("Mutagen.Bethesda.Skyrim.ILeveledNpcGetter, Mutagen.Bethesda.Skyrim") },
            { "LeveledSpell", Type.GetType("Mutagen.Bethesda.Skyrim.ILeveledSpellGetter, Mutagen.Bethesda.Skyrim") },
            { "Light", Type.GetType("Mutagen.Bethesda.Skyrim.ILightGetter, Mutagen.Bethesda.Skyrim") },
            { "LightingTemplate", Type.GetType("Mutagen.Bethesda.Skyrim.ILightingTemplateGetter, Mutagen.Bethesda.Skyrim") },
            { "LoadScreen", Type.GetType("Mutagen.Bethesda.Skyrim.ILoadScreenGetter, Mutagen.Bethesda.Skyrim") },
            { "Location", Type.GetType("Mutagen.Bethesda.Skyrim.ILocationGetter, Mutagen.Bethesda.Skyrim") },
            { "LocationReferenceType", Type.GetType("Mutagen.Bethesda.Skyrim.ILocationReferenceTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "MagicEffect", Type.GetType("Mutagen.Bethesda.Skyrim.IMagicEffectGetter, Mutagen.Bethesda.Skyrim") },
            { "MaterialObject", Type.GetType("Mutagen.Bethesda.Skyrim.IMaterialObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "MaterialType", Type.GetType("Mutagen.Bethesda.Skyrim.IMaterialTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "Message", Type.GetType("Mutagen.Bethesda.Skyrim.IMessageGetter, Mutagen.Bethesda.Skyrim") },
            { "MiscItem", Type.GetType("Mutagen.Bethesda.Skyrim.IMiscItemGetter, Mutagen.Bethesda.Skyrim") },
            { "MoveableStatic", Type.GetType("Mutagen.Bethesda.Skyrim.IMoveableStaticGetter, Mutagen.Bethesda.Skyrim") },
            { "MovementType", Type.GetType("Mutagen.Bethesda.Skyrim.IMovementTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "MusicTrack", Type.GetType("Mutagen.Bethesda.Skyrim.IMusicTrackGetter, Mutagen.Bethesda.Skyrim") },
            { "MusicType", Type.GetType("Mutagen.Bethesda.Skyrim.IMusicTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "NavigationMesh", Type.GetType("Mutagen.Bethesda.Skyrim.INavigationMeshGetter, Mutagen.Bethesda.Skyrim") },
            { "NavigationMeshInfoMap", Type.GetType("Mutagen.Bethesda.Skyrim.INavigationMeshInfoMapGetter, Mutagen.Bethesda.Skyrim") },
            { "Npc", Type.GetType("Mutagen.Bethesda.Skyrim.INpcGetter, Mutagen.Bethesda.Skyrim") },
            { "ObjectEffect", Type.GetType("Mutagen.Bethesda.Skyrim.IObjectEffectGetter, Mutagen.Bethesda.Skyrim") },
            { "Outfit", Type.GetType("Mutagen.Bethesda.Skyrim.IOutfitGetter, Mutagen.Bethesda.Skyrim") },
            { "Package", Type.GetType("Mutagen.Bethesda.Skyrim.IPackageGetter, Mutagen.Bethesda.Skyrim") },
            { "Perk", Type.GetType("Mutagen.Bethesda.Skyrim.IPerkGetter, Mutagen.Bethesda.Skyrim") },
            { "PlacedNpc", Type.GetType("Mutagen.Bethesda.Skyrim.IPlacedNpcGetter, Mutagen.Bethesda.Skyrim") },
            { "PlacedObject", Type.GetType("Mutagen.Bethesda.Skyrim.IPlacedObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "Projectile", Type.GetType("Mutagen.Bethesda.Skyrim.IProjectileGetter, Mutagen.Bethesda.Skyrim") },
            { "Quest", Type.GetType("Mutagen.Bethesda.Skyrim.IQuestGetter, Mutagen.Bethesda.Skyrim") },
            { "Race", Type.GetType("Mutagen.Bethesda.Skyrim.IRaceGetter, Mutagen.Bethesda.Skyrim") },
            { "Region", Type.GetType("Mutagen.Bethesda.Skyrim.IRegionGetter, Mutagen.Bethesda.Skyrim") },
            { "Relationship", Type.GetType("Mutagen.Bethesda.Skyrim.IRelationshipGetter, Mutagen.Bethesda.Skyrim") },
            { "ReverbParameters", Type.GetType("Mutagen.Bethesda.Skyrim.IReverbParametersGetter, Mutagen.Bethesda.Skyrim") },
            { "Scene", Type.GetType("Mutagen.Bethesda.Skyrim.ISceneGetter, Mutagen.Bethesda.Skyrim") },
            { "Scroll", Type.GetType("Mutagen.Bethesda.Skyrim.IScrollGetter, Mutagen.Bethesda.Skyrim") },
            { "ShaderParticleGeometry", Type.GetType("Mutagen.Bethesda.Skyrim.IShaderParticleGeometryGetter, Mutagen.Bethesda.Skyrim") },
            { "Shout", Type.GetType("Mutagen.Bethesda.Skyrim.IShoutGetter, Mutagen.Bethesda.Skyrim") },
            { "SkyrimMajorRecord", Type.GetType("Mutagen.Bethesda.Skyrim.ISkyrimMajorRecordGetter, Mutagen.Bethesda.Skyrim") },
            { "SoulGem", Type.GetType("Mutagen.Bethesda.Skyrim.ISoulGemGetter, Mutagen.Bethesda.Skyrim") },
            { "SoundCategory", Type.GetType("Mutagen.Bethesda.Skyrim.ISoundCategoryGetter, Mutagen.Bethesda.Skyrim") },
            { "SoundDescriptor", Type.GetType("Mutagen.Bethesda.Skyrim.ISoundDescriptorGetter, Mutagen.Bethesda.Skyrim") },
            { "SoundMarker", Type.GetType("Mutagen.Bethesda.Skyrim.ISoundMarkerGetter, Mutagen.Bethesda.Skyrim") },
            { "SoundOutputModel", Type.GetType("Mutagen.Bethesda.Skyrim.ISoundOutputModelGetter, Mutagen.Bethesda.Skyrim") },
            { "Spell", Type.GetType("Mutagen.Bethesda.Skyrim.ISpellGetter, Mutagen.Bethesda.Skyrim") },
            { "Static", Type.GetType("Mutagen.Bethesda.Skyrim.IStaticGetter, Mutagen.Bethesda.Skyrim") },
            { "TalkingActivator", Type.GetType("Mutagen.Bethesda.Skyrim.ITalkingActivatorGetter, Mutagen.Bethesda.Skyrim") },
            { "TextureSet", Type.GetType("Mutagen.Bethesda.Skyrim.ITextureSetGetter, Mutagen.Bethesda.Skyrim") },
            { "Tree", Type.GetType("Mutagen.Bethesda.Skyrim.ITreeGetter, Mutagen.Bethesda.Skyrim") },
            { "VisualEffect", Type.GetType("Mutagen.Bethesda.Skyrim.IVisualEffectGetter, Mutagen.Bethesda.Skyrim") },
            { "VoiceType", Type.GetType("Mutagen.Bethesda.Skyrim.IVoiceTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "VolumetricLighting", Type.GetType("Mutagen.Bethesda.Skyrim.IVolumetricLightingGetter, Mutagen.Bethesda.Skyrim") },
            { "Water", Type.GetType("Mutagen.Bethesda.Skyrim.IWaterGetter, Mutagen.Bethesda.Skyrim") },
            { "Weapon", Type.GetType("Mutagen.Bethesda.Skyrim.IWeaponGetter, Mutagen.Bethesda.Skyrim") },
            { "Weather", Type.GetType("Mutagen.Bethesda.Skyrim.IWeatherGetter, Mutagen.Bethesda.Skyrim") },
            { "WordOfPower", Type.GetType("Mutagen.Bethesda.Skyrim.IWordOfPowerGetter, Mutagen.Bethesda.Skyrim") },
            { "Worldspace", Type.GetType("Mutagen.Bethesda.Skyrim.IWorldspaceGetter, Mutagen.Bethesda.Skyrim") },
            { "IPlaceableObject", Type.GetType("Mutagen.Bethesda.Skyrim.IIPlaceableObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "IReferenceableObject", Type.GetType("Mutagen.Bethesda.Skyrim.IIReferenceableObjectGetter, Mutagen.Bethesda.Skyrim") },
            { "IExplodeSpawn", Type.GetType("Mutagen.Bethesda.Skyrim.IIExplodeSpawnGetter, Mutagen.Bethesda.Skyrim") },
            { "IIdleRelation", Type.GetType("Mutagen.Bethesda.Skyrim.IIIdleRelationGetter, Mutagen.Bethesda.Skyrim") },
            { "IObjectId", Type.GetType("Mutagen.Bethesda.Skyrim.IIObjectIdGetter, Mutagen.Bethesda.Skyrim") },
            { "IItem", Type.GetType("Mutagen.Bethesda.Skyrim.IIItemGetter, Mutagen.Bethesda.Skyrim") },
            { "IItemOrList", Type.GetType("Mutagen.Bethesda.Skyrim.IIItemOrListGetter, Mutagen.Bethesda.Skyrim") },
            { "IConstructible", Type.GetType("Mutagen.Bethesda.Skyrim.IIConstructibleGetter, Mutagen.Bethesda.Skyrim") },
            { "IOutfitTarget", Type.GetType("Mutagen.Bethesda.Skyrim.IIOutfitTargetGetter, Mutagen.Bethesda.Skyrim") },
            { "IBindableEquipment", Type.GetType("Mutagen.Bethesda.Skyrim.IIBindableEquipmentGetter, Mutagen.Bethesda.Skyrim") },
            { "IComplexLocation", Type.GetType("Mutagen.Bethesda.Skyrim.IIComplexLocationGetter, Mutagen.Bethesda.Skyrim") },
            { "IDialog", Type.GetType("Mutagen.Bethesda.Skyrim.IIDialogGetter, Mutagen.Bethesda.Skyrim") },
            { "IOwner", Type.GetType("Mutagen.Bethesda.Skyrim.IIOwnerGetter, Mutagen.Bethesda.Skyrim") },
            { "IRelatable", Type.GetType("Mutagen.Bethesda.Skyrim.IIRelatableGetter, Mutagen.Bethesda.Skyrim") },
            { "IRegionTarget", Type.GetType("Mutagen.Bethesda.Skyrim.IIRegionTargetGetter, Mutagen.Bethesda.Skyrim") },
            { "IAliasVoiceType", Type.GetType("Mutagen.Bethesda.Skyrim.IIAliasVoiceTypeGetter, Mutagen.Bethesda.Skyrim") },
            { "ILockList", Type.GetType("Mutagen.Bethesda.Skyrim.IILockListGetter, Mutagen.Bethesda.Skyrim") },
            { "IWorldspaceOrList", Type.GetType("Mutagen.Bethesda.Skyrim.IIWorldspaceOrListGetter, Mutagen.Bethesda.Skyrim") },
            { "IVoiceTypeOrList", Type.GetType("Mutagen.Bethesda.Skyrim.IIVoiceTypeOrListGetter, Mutagen.Bethesda.Skyrim") },
            { "INpcOrList", Type.GetType("Mutagen.Bethesda.Skyrim.IINpcOrListGetter, Mutagen.Bethesda.Skyrim") },
            { "IWeaponOrList", Type.GetType("Mutagen.Bethesda.Skyrim.IIWeaponOrListGetter, Mutagen.Bethesda.Skyrim") },
            { "ISpellOrList", Type.GetType("Mutagen.Bethesda.Skyrim.IISpellOrListGetter, Mutagen.Bethesda.Skyrim") },
            { "IPlacedTrapTarget", Type.GetType("Mutagen.Bethesda.Skyrim.IIPlacedTrapTargetGetter, Mutagen.Bethesda.Skyrim") },
            { "IHarvestTarget", Type.GetType("Mutagen.Bethesda.Skyrim.IIHarvestTargetGetter, Mutagen.Bethesda.Skyrim") },
            { "IMagicItem", Type.GetType("Mutagen.Bethesda.Skyrim.IIMagicItemGetter, Mutagen.Bethesda.Skyrim") },
            { "IKeywordLinkedReference", Type.GetType("Mutagen.Bethesda.Skyrim.IIKeywordLinkedReferenceGetter, Mutagen.Bethesda.Skyrim") },
            { "INpcSpawn", Type.GetType("Mutagen.Bethesda.Skyrim.IINpcSpawnGetter, Mutagen.Bethesda.Skyrim") },
            { "ISpellRecord", Type.GetType("Mutagen.Bethesda.Skyrim.IISpellRecordGetter, Mutagen.Bethesda.Skyrim") },
            { "IEmittance", Type.GetType("Mutagen.Bethesda.Skyrim.IIEmittanceGetter, Mutagen.Bethesda.Skyrim") },
            { "ILocationRecord", Type.GetType("Mutagen.Bethesda.Skyrim.IILocationRecordGetter, Mutagen.Bethesda.Skyrim") },
            { "IKnowable", Type.GetType("Mutagen.Bethesda.Skyrim.IIKnowableGetter, Mutagen.Bethesda.Skyrim") },
            { "IEffectRecord", Type.GetType("Mutagen.Bethesda.Skyrim.IIEffectRecordGetter, Mutagen.Bethesda.Skyrim") },
            { "ILinkedReference", Type.GetType("Mutagen.Bethesda.Skyrim.IILinkedReferenceGetter, Mutagen.Bethesda.Skyrim") },
            { "IPlaced", Type.GetType("Mutagen.Bethesda.Skyrim.IIPlacedGetter, Mutagen.Bethesda.Skyrim") },
            { "IPlacedSimple", Type.GetType("Mutagen.Bethesda.Skyrim.IIPlacedSimpleGetter, Mutagen.Bethesda.Skyrim") },
            { "IPlacedThing", Type.GetType("Mutagen.Bethesda.Skyrim.IIPlacedThingGetter, Mutagen.Bethesda.Skyrim") },
            { "ISound", Type.GetType("Mutagen.Bethesda.Skyrim.IISoundGetter, Mutagen.Bethesda.Skyrim") }
        };
    }

    [Cmdlet(VerbsCommon.Get, "MutaWinningOverrides")]
    public class GetWinningOverrides : Cmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
        public string RecordType;

        [Parameter()]
        public bool IncludeDeletedRecords = false;

        protected override void ProcessRecord()
        {
            WriteObject(OverrideMixIns.WinningOverrides(Config.Environment.LoadOrder.PriorityOrder, MajorRecordInfo.MajorRecordTypes[RecordType], IncludeDeletedRecords).ToArray());
        }
    }

    [Cmdlet(VerbsCommon.Get, "MutaMajorRecords")]
    public class GetMajorRecords : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public IModGetter Mod;

        [Parameter()]
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
        public string RecordType;

        protected override void ProcessRecord()
        {
            if (RecordType == null)
            {
                WriteObject(Mod.EnumerateMajorRecords());
            }
            else
            {
                WriteObject(Mod.EnumerateMajorRecords(MajorRecordInfo.MajorRecordTypes[RecordType]));
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "MutaGameEnvironment")]
    [OutputType(typeof(IGameEnvironment), ParameterSetName = new string[] { "passthru" })]
    public class SetGameEnvironment : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public GameRelease Game { get; set; }

        [Parameter(ParameterSetName = "passthru")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            Config.Environment = GameEnvironment.Typical.Construct(Game);
            if (PassThru.IsPresent)
            {
                WriteObject(Config.Environment);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "MutaGameEnvironment")]
    [OutputType(typeof(IGameEnvironment))]
    public class GetGameEnvironment : Cmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(Config.Environment);
        }
    }
}