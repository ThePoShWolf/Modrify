using System.Management.Automation;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using PSMutagen.Core;

namespace PSMutagen.Fallout
{
    public class MajorRecordInfo
    {
        public static Dictionary<string, Type> MajorRecordTypes = new Dictionary<string, Type>()
        {
            /*
                # pwsh w/Mutagen.Bethesda.Fallout4 and dependencies loaded
                $falloutTypes = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes() | Where-Object { $_.Namespace -eq 'Mutagen.Bethesda.Fallout4' }
                $mrs = $falloutTypes | ?{$_.BaseType -eq [Mutagen.Bethesda.Fallout4.Fallout4MajorRecord]}
                $mrs.Name | %{
                    "{ `"$_`", Type.GetType(`"Mutagen.Bethesda.Fallout4.I$_`Getter, Mutagen.Bethesda.Fallout4`") },"
                }
            */
            { "ActionRecord", Type.GetType("Mutagen.Bethesda.Fallout4.IActionRecordGetter, Mutagen.Bethesda.Fallout4") },
            { "Activator", Type.GetType("Mutagen.Bethesda.Fallout4.IActivatorGetter, Mutagen.Bethesda.Fallout4") },
            { "ActorValueInformation", Type.GetType("Mutagen.Bethesda.Fallout4.IActorValueInformationGetter, Mutagen.Bethesda.Fallout4") },
            { "ADamageType", Type.GetType("Mutagen.Bethesda.Fallout4.IADamageTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "AddonNode", Type.GetType("Mutagen.Bethesda.Fallout4.IAddonNodeGetter, Mutagen.Bethesda.Fallout4") },
            { "Ammunition", Type.GetType("Mutagen.Bethesda.Fallout4.IAmmunitionGetter, Mutagen.Bethesda.Fallout4") },
            { "APlacedTrap", Type.GetType("Mutagen.Bethesda.Fallout4.IAPlacedTrapGetter, Mutagen.Bethesda.Fallout4") },
            { "Armor", Type.GetType("Mutagen.Bethesda.Fallout4.IArmorGetter, Mutagen.Bethesda.Fallout4") },
            { "ArmorAddon", Type.GetType("Mutagen.Bethesda.Fallout4.IArmorAddonGetter, Mutagen.Bethesda.Fallout4") },
            { "ArtObject", Type.GetType("Mutagen.Bethesda.Fallout4.IArtObjectGetter, Mutagen.Bethesda.Fallout4") },
            { "AStoryManagerNode", Type.GetType("Mutagen.Bethesda.Fallout4.IAStoryManagerNodeGetter, Mutagen.Bethesda.Fallout4") },
            { "Book", Type.GetType("Mutagen.Bethesda.Fallout4.IBookGetter, Mutagen.Bethesda.Fallout4") },
            { "CameraPath", Type.GetType("Mutagen.Bethesda.Fallout4.ICameraPathGetter, Mutagen.Bethesda.Fallout4") },
            { "CameraShot", Type.GetType("Mutagen.Bethesda.Fallout4.ICameraShotGetter, Mutagen.Bethesda.Fallout4") },
            { "Cell", Type.GetType("Mutagen.Bethesda.Fallout4.ICellGetter, Mutagen.Bethesda.Fallout4") },
            { "Climate", Type.GetType("Mutagen.Bethesda.Fallout4.IClimateGetter, Mutagen.Bethesda.Fallout4") },
            { "CollisionLayer", Type.GetType("Mutagen.Bethesda.Fallout4.ICollisionLayerGetter, Mutagen.Bethesda.Fallout4") },
            { "ColorRecord", Type.GetType("Mutagen.Bethesda.Fallout4.IColorRecordGetter, Mutagen.Bethesda.Fallout4") },
            { "CombatStyle", Type.GetType("Mutagen.Bethesda.Fallout4.ICombatStyleGetter, Mutagen.Bethesda.Fallout4") },
            { "Container", Type.GetType("Mutagen.Bethesda.Fallout4.IContainerGetter, Mutagen.Bethesda.Fallout4") },
            { "DialogBranch", Type.GetType("Mutagen.Bethesda.Fallout4.IDialogBranchGetter, Mutagen.Bethesda.Fallout4") },
            { "DialogResponses", Type.GetType("Mutagen.Bethesda.Fallout4.IDialogResponsesGetter, Mutagen.Bethesda.Fallout4") },
            { "DialogTopic", Type.GetType("Mutagen.Bethesda.Fallout4.IDialogTopicGetter, Mutagen.Bethesda.Fallout4") },
            { "Door", Type.GetType("Mutagen.Bethesda.Fallout4.IDoorGetter, Mutagen.Bethesda.Fallout4") },
            { "EffectShader", Type.GetType("Mutagen.Bethesda.Fallout4.IEffectShaderGetter, Mutagen.Bethesda.Fallout4") },
            { "EncounterZone", Type.GetType("Mutagen.Bethesda.Fallout4.IEncounterZoneGetter, Mutagen.Bethesda.Fallout4") },
            { "EquipType", Type.GetType("Mutagen.Bethesda.Fallout4.IEquipTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "Explosion", Type.GetType("Mutagen.Bethesda.Fallout4.IExplosionGetter, Mutagen.Bethesda.Fallout4") },
            { "Faction", Type.GetType("Mutagen.Bethesda.Fallout4.IFactionGetter, Mutagen.Bethesda.Fallout4") },
            { "Furniture", Type.GetType("Mutagen.Bethesda.Fallout4.IFurnitureGetter, Mutagen.Bethesda.Fallout4") },
            { "GameSetting", Type.GetType("Mutagen.Bethesda.Fallout4.IGameSettingGetter, Mutagen.Bethesda.Fallout4") },
            { "Global", Type.GetType("Mutagen.Bethesda.Fallout4.IGlobalGetter, Mutagen.Bethesda.Fallout4") },
            { "Grass", Type.GetType("Mutagen.Bethesda.Fallout4.IGrassGetter, Mutagen.Bethesda.Fallout4") },
            { "Hazard", Type.GetType("Mutagen.Bethesda.Fallout4.IHazardGetter, Mutagen.Bethesda.Fallout4") },
            { "HeadPart", Type.GetType("Mutagen.Bethesda.Fallout4.IHeadPartGetter, Mutagen.Bethesda.Fallout4") },
            { "Holotape", Type.GetType("Mutagen.Bethesda.Fallout4.IHolotapeGetter, Mutagen.Bethesda.Fallout4") },
            { "IdleAnimation", Type.GetType("Mutagen.Bethesda.Fallout4.IIdleAnimationGetter, Mutagen.Bethesda.Fallout4") },
            { "IdleMarker", Type.GetType("Mutagen.Bethesda.Fallout4.IIdleMarkerGetter, Mutagen.Bethesda.Fallout4") },
            { "ImageSpace", Type.GetType("Mutagen.Bethesda.Fallout4.IImageSpaceGetter, Mutagen.Bethesda.Fallout4") },
            { "ImageSpaceAdapter", Type.GetType("Mutagen.Bethesda.Fallout4.IImageSpaceAdapterGetter, Mutagen.Bethesda.Fallout4") },
            { "Impact", Type.GetType("Mutagen.Bethesda.Fallout4.IImpactGetter, Mutagen.Bethesda.Fallout4") },
            { "Ingestible", Type.GetType("Mutagen.Bethesda.Fallout4.IIngestibleGetter, Mutagen.Bethesda.Fallout4") },
            { "Ingredient", Type.GetType("Mutagen.Bethesda.Fallout4.IIngredientGetter, Mutagen.Bethesda.Fallout4") },
            { "InstanceNamingRules", Type.GetType("Mutagen.Bethesda.Fallout4.IInstanceNamingRulesGetter, Mutagen.Bethesda.Fallout4") },
            { "Key", Type.GetType("Mutagen.Bethesda.Fallout4.IKeyGetter, Mutagen.Bethesda.Fallout4") },
            { "Keyword", Type.GetType("Mutagen.Bethesda.Fallout4.IKeywordGetter, Mutagen.Bethesda.Fallout4") },
            { "LeveledItem", Type.GetType("Mutagen.Bethesda.Fallout4.ILeveledItemGetter, Mutagen.Bethesda.Fallout4") },
            { "LeveledNpc", Type.GetType("Mutagen.Bethesda.Fallout4.ILeveledNpcGetter, Mutagen.Bethesda.Fallout4") },
            { "Light", Type.GetType("Mutagen.Bethesda.Fallout4.ILightGetter, Mutagen.Bethesda.Fallout4") },
            { "LoadScreen", Type.GetType("Mutagen.Bethesda.Fallout4.ILoadScreenGetter, Mutagen.Bethesda.Fallout4") },
            { "Location", Type.GetType("Mutagen.Bethesda.Fallout4.ILocationGetter, Mutagen.Bethesda.Fallout4") },
            { "MagicEffect", Type.GetType("Mutagen.Bethesda.Fallout4.IMagicEffectGetter, Mutagen.Bethesda.Fallout4") },
            { "MaterialObject", Type.GetType("Mutagen.Bethesda.Fallout4.IMaterialObjectGetter, Mutagen.Bethesda.Fallout4") },
            { "MaterialSwap", Type.GetType("Mutagen.Bethesda.Fallout4.IMaterialSwapGetter, Mutagen.Bethesda.Fallout4") },
            { "MaterialType", Type.GetType("Mutagen.Bethesda.Fallout4.IMaterialTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "Message", Type.GetType("Mutagen.Bethesda.Fallout4.IMessageGetter, Mutagen.Bethesda.Fallout4") },
            { "MiscItem", Type.GetType("Mutagen.Bethesda.Fallout4.IMiscItemGetter, Mutagen.Bethesda.Fallout4") },
            { "MovableStatic", Type.GetType("Mutagen.Bethesda.Fallout4.IMovableStaticGetter, Mutagen.Bethesda.Fallout4") },
            { "MusicTrack", Type.GetType("Mutagen.Bethesda.Fallout4.IMusicTrackGetter, Mutagen.Bethesda.Fallout4") },
            { "MusicType", Type.GetType("Mutagen.Bethesda.Fallout4.IMusicTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "NavigationMesh", Type.GetType("Mutagen.Bethesda.Fallout4.INavigationMeshGetter, Mutagen.Bethesda.Fallout4") },
            { "Npc", Type.GetType("Mutagen.Bethesda.Fallout4.INpcGetter, Mutagen.Bethesda.Fallout4") },
            { "ObjectEffect", Type.GetType("Mutagen.Bethesda.Fallout4.IObjectEffectGetter, Mutagen.Bethesda.Fallout4") },
            { "AObjectModification", Type.GetType("Mutagen.Bethesda.Fallout4.IAObjectModificationGetter, Mutagen.Bethesda.Fallout4") },
            { "Package", Type.GetType("Mutagen.Bethesda.Fallout4.IPackageGetter, Mutagen.Bethesda.Fallout4") },
            { "PackIn", Type.GetType("Mutagen.Bethesda.Fallout4.IPackInGetter, Mutagen.Bethesda.Fallout4") },
            { "Perk", Type.GetType("Mutagen.Bethesda.Fallout4.IPerkGetter, Mutagen.Bethesda.Fallout4") },
            { "PlacedNpc", Type.GetType("Mutagen.Bethesda.Fallout4.IPlacedNpcGetter, Mutagen.Bethesda.Fallout4") },
            { "PlacedObject", Type.GetType("Mutagen.Bethesda.Fallout4.IPlacedObjectGetter, Mutagen.Bethesda.Fallout4") },
            { "Projectile", Type.GetType("Mutagen.Bethesda.Fallout4.IProjectileGetter, Mutagen.Bethesda.Fallout4") },
            { "Quest", Type.GetType("Mutagen.Bethesda.Fallout4.IQuestGetter, Mutagen.Bethesda.Fallout4") },
            { "Race", Type.GetType("Mutagen.Bethesda.Fallout4.IRaceGetter, Mutagen.Bethesda.Fallout4") },
            { "Region", Type.GetType("Mutagen.Bethesda.Fallout4.IRegionGetter, Mutagen.Bethesda.Fallout4") },
            { "Relationship", Type.GetType("Mutagen.Bethesda.Fallout4.IRelationshipGetter, Mutagen.Bethesda.Fallout4") },
            { "Scene", Type.GetType("Mutagen.Bethesda.Fallout4.ISceneGetter, Mutagen.Bethesda.Fallout4") },
            { "ShaderParticleGeometry", Type.GetType("Mutagen.Bethesda.Fallout4.IShaderParticleGeometryGetter, Mutagen.Bethesda.Fallout4") },
            { "SoundCategory", Type.GetType("Mutagen.Bethesda.Fallout4.ISoundCategoryGetter, Mutagen.Bethesda.Fallout4") },
            { "SoundDescriptor", Type.GetType("Mutagen.Bethesda.Fallout4.ISoundDescriptorGetter, Mutagen.Bethesda.Fallout4") },
            { "SoundOutputModel", Type.GetType("Mutagen.Bethesda.Fallout4.ISoundOutputModelGetter, Mutagen.Bethesda.Fallout4") },
            { "Static", Type.GetType("Mutagen.Bethesda.Fallout4.IStaticGetter, Mutagen.Bethesda.Fallout4") },
            { "StaticCollection", Type.GetType("Mutagen.Bethesda.Fallout4.IStaticCollectionGetter, Mutagen.Bethesda.Fallout4") },
            { "TalkingActivator", Type.GetType("Mutagen.Bethesda.Fallout4.ITalkingActivatorGetter, Mutagen.Bethesda.Fallout4") },
            { "Terminal", Type.GetType("Mutagen.Bethesda.Fallout4.ITerminalGetter, Mutagen.Bethesda.Fallout4") },
            { "TextureSet", Type.GetType("Mutagen.Bethesda.Fallout4.ITextureSetGetter, Mutagen.Bethesda.Fallout4") },
            { "Transform", Type.GetType("Mutagen.Bethesda.Fallout4.ITransformGetter, Mutagen.Bethesda.Fallout4") },
            { "Tree", Type.GetType("Mutagen.Bethesda.Fallout4.ITreeGetter, Mutagen.Bethesda.Fallout4") },
            { "VisualEffect", Type.GetType("Mutagen.Bethesda.Fallout4.IVisualEffectGetter, Mutagen.Bethesda.Fallout4") },
            { "VoiceType", Type.GetType("Mutagen.Bethesda.Fallout4.IVoiceTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "Water", Type.GetType("Mutagen.Bethesda.Fallout4.IWaterGetter, Mutagen.Bethesda.Fallout4") },
            { "Weapon", Type.GetType("Mutagen.Bethesda.Fallout4.IWeaponGetter, Mutagen.Bethesda.Fallout4") },
            { "Weather", Type.GetType("Mutagen.Bethesda.Fallout4.IWeatherGetter, Mutagen.Bethesda.Fallout4") },
            { "Worldspace", Type.GetType("Mutagen.Bethesda.Fallout4.IWorldspaceGetter, Mutagen.Bethesda.Fallout4") },
            { "Zoom", Type.GetType("Mutagen.Bethesda.Fallout4.IZoomGetter, Mutagen.Bethesda.Fallout4") },
            { "AttractionRule", Type.GetType("Mutagen.Bethesda.Fallout4.IAttractionRuleGetter, Mutagen.Bethesda.Fallout4") },
            { "Component", Type.GetType("Mutagen.Bethesda.Fallout4.IComponentGetter, Mutagen.Bethesda.Fallout4") },
            { "LocationReferenceType", Type.GetType("Mutagen.Bethesda.Fallout4.ILocationReferenceTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "AnimationSoundTagSet", Type.GetType("Mutagen.Bethesda.Fallout4.IAnimationSoundTagSetGetter, Mutagen.Bethesda.Fallout4") },
            { "Class", Type.GetType("Mutagen.Bethesda.Fallout4.IClassGetter, Mutagen.Bethesda.Fallout4") },
            { "Debris", Type.GetType("Mutagen.Bethesda.Fallout4.IDebrisGetter, Mutagen.Bethesda.Fallout4") },
            { "FormList", Type.GetType("Mutagen.Bethesda.Fallout4.IFormListGetter, Mutagen.Bethesda.Fallout4") },
            { "ImpactDataSet", Type.GetType("Mutagen.Bethesda.Fallout4.IImpactDataSetGetter, Mutagen.Bethesda.Fallout4") },
            { "LeveledSpell", Type.GetType("Mutagen.Bethesda.Fallout4.ILeveledSpellGetter, Mutagen.Bethesda.Fallout4") },
            { "Outfit", Type.GetType("Mutagen.Bethesda.Fallout4.IOutfitGetter, Mutagen.Bethesda.Fallout4") },
            { "SoundMarker", Type.GetType("Mutagen.Bethesda.Fallout4.ISoundMarkerGetter, Mutagen.Bethesda.Fallout4") },
            { "AcousticSpace", Type.GetType("Mutagen.Bethesda.Fallout4.IAcousticSpaceGetter, Mutagen.Bethesda.Fallout4") },
            { "ReverbParameters", Type.GetType("Mutagen.Bethesda.Fallout4.IReverbParametersGetter, Mutagen.Bethesda.Fallout4") },
            { "LandscapeTexture", Type.GetType("Mutagen.Bethesda.Fallout4.ILandscapeTextureGetter, Mutagen.Bethesda.Fallout4") },
            { "Spell", Type.GetType("Mutagen.Bethesda.Fallout4.ISpellGetter, Mutagen.Bethesda.Fallout4") },
            { "Footstep", Type.GetType("Mutagen.Bethesda.Fallout4.IFootstepGetter, Mutagen.Bethesda.Fallout4") },
            { "FootstepSet", Type.GetType("Mutagen.Bethesda.Fallout4.IFootstepSetGetter, Mutagen.Bethesda.Fallout4") },
            { "GodRays", Type.GetType("Mutagen.Bethesda.Fallout4.IGodRaysGetter, Mutagen.Bethesda.Fallout4") },
            { "LensFlare", Type.GetType("Mutagen.Bethesda.Fallout4.ILensFlareGetter, Mutagen.Bethesda.Fallout4") },
            { "Flora", Type.GetType("Mutagen.Bethesda.Fallout4.IFloraGetter, Mutagen.Bethesda.Fallout4") },
            { "BodyPartData", Type.GetType("Mutagen.Bethesda.Fallout4.IBodyPartDataGetter, Mutagen.Bethesda.Fallout4") },
            { "MovementType", Type.GetType("Mutagen.Bethesda.Fallout4.IMovementTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "DualCastData", Type.GetType("Mutagen.Bethesda.Fallout4.IDualCastDataGetter, Mutagen.Bethesda.Fallout4") },
            { "ConstructibleObject", Type.GetType("Mutagen.Bethesda.Fallout4.IConstructibleObjectGetter, Mutagen.Bethesda.Fallout4") },
            { "AimModel", Type.GetType("Mutagen.Bethesda.Fallout4.IAimModelGetter, Mutagen.Bethesda.Fallout4") },
            { "BendableSpline", Type.GetType("Mutagen.Bethesda.Fallout4.IBendableSplineGetter, Mutagen.Bethesda.Fallout4") },
            { "NavigationMeshInfoMap", Type.GetType("Mutagen.Bethesda.Fallout4.INavigationMeshInfoMapGetter, Mutagen.Bethesda.Fallout4") },
            { "LightingTemplate", Type.GetType("Mutagen.Bethesda.Fallout4.ILightingTemplateGetter, Mutagen.Bethesda.Fallout4") },
            { "Layer", Type.GetType("Mutagen.Bethesda.Fallout4.ILayerGetter, Mutagen.Bethesda.Fallout4") },
            { "ReferenceGroup", Type.GetType("Mutagen.Bethesda.Fallout4.IReferenceGroupGetter, Mutagen.Bethesda.Fallout4") },
            { "Landscape", Type.GetType("Mutagen.Bethesda.Fallout4.ILandscapeGetter, Mutagen.Bethesda.Fallout4") },
            { "AnimatedObject", Type.GetType("Mutagen.Bethesda.Fallout4.IAnimatedObjectGetter, Mutagen.Bethesda.Fallout4") },
            { "DefaultObjectManager", Type.GetType("Mutagen.Bethesda.Fallout4.IDefaultObjectManagerGetter, Mutagen.Bethesda.Fallout4") },
            { "DefaultObject", Type.GetType("Mutagen.Bethesda.Fallout4.IDefaultObjectGetter, Mutagen.Bethesda.Fallout4") },
            { "DialogView", Type.GetType("Mutagen.Bethesda.Fallout4.IDialogViewGetter, Mutagen.Bethesda.Fallout4") },
            { "AssociationType", Type.GetType("Mutagen.Bethesda.Fallout4.IAssociationTypeGetter, Mutagen.Bethesda.Fallout4") },
            { "AudioEffectChain", Type.GetType("Mutagen.Bethesda.Fallout4.IAudioEffectChainGetter, Mutagen.Bethesda.Fallout4") },
            { "SoundKeywordMapping", Type.GetType("Mutagen.Bethesda.Fallout4.ISoundKeywordMappingGetter, Mutagen.Bethesda.Fallout4") },
            { "SceneCollection", Type.GetType("Mutagen.Bethesda.Fallout4.ISceneCollectionGetter, Mutagen.Bethesda.Fallout4") },
            { "AudioCategorySnapshot", Type.GetType("Mutagen.Bethesda.Fallout4.IAudioCategorySnapshotGetter, Mutagen.Bethesda.Fallout4") },
            { "NavigationMeshObstacleManager", Type.GetType("Mutagen.Bethesda.Fallout4.INavigationMeshObstacleManagerGetter, Mutagen.Bethesda.Fallout4") },
            { "ObjectVisibilityManager", Type.GetType("Mutagen.Bethesda.Fallout4.IObjectVisibilityManagerGetter, Mutagen.Bethesda.Fallout4") },
        };
    }

    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    [Cmdlet(VerbsCommon.Get, "FalloutWinningOverrides")]
    public class GetFalloutWinningOverrides : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        // set taken from MajorRecordInfo
        // "$($mrs.Name -join '","')"
        [ValidateSet("ActionRecord", "Activator", "ActorValueInformation", "ADamageType", "AddonNode", "Ammunition", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AStoryManagerNode", "Book", "CameraPath", "CameraShot", "Cell", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "Container", "DialogBranch", "DialogResponses", "DialogTopic", "Door", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Faction", "Furniture", "GameSetting", "Global", "Grass", "Hazard", "HeadPart", "Holotape", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "Ingestible", "Ingredient", "InstanceNamingRules", "Key", "Keyword", "LeveledItem", "LeveledNpc", "Light", "LoadScreen", "Location", "MagicEffect", "MaterialObject", "MaterialSwap", "MaterialType", "Message", "MiscItem", "MovableStatic", "MusicTrack", "MusicType", "NavigationMesh", "Npc", "ObjectEffect", "AObjectModification", "Package", "PackIn", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "Scene", "ShaderParticleGeometry", "SoundCategory", "SoundDescriptor", "SoundOutputModel", "Static", "StaticCollection", "TalkingActivator", "Terminal", "TextureSet", "Transform", "Tree", "VisualEffect", "VoiceType", "Water", "Weapon", "Weather", "Worldspace", "Zoom", "AttractionRule", "Component", "LocationReferenceType", "AnimationSoundTagSet", "Class", "Debris", "FormList", "ImpactDataSet", "LeveledSpell", "Outfit", "SoundMarker", "AcousticSpace", "ReverbParameters", "LandscapeTexture", "Spell", "Footstep", "FootstepSet", "GodRays", "LensFlare", "Flora", "BodyPartData", "MovementType", "DualCastData", "ConstructibleObject", "AimModel", "BendableSpline", "NavigationMeshInfoMap", "LightingTemplate", "Layer", "ReferenceGroup", "Landscape", "AnimatedObject", "DefaultObjectManager", "DefaultObject", "DialogView", "AssociationType", "AudioEffectChain", "SoundKeywordMapping", "SceneCollection", "AudioCategorySnapshot", "NavigationMeshObstacleManager", "ObjectVisibilityManager")]
        public required string RecordType;

        [Parameter()]
        public bool IncludeDeletedRecords = false;

        protected override void ProcessRecord()
        {
            if (PSMutagenConfig.Environment == null)
            {
                throw new PSInvalidOperationException("Unable to load the load order. Please set your environment with 'Set-MutaGameEnvironment'");
            }
            else
            {
                WriteObject(OverrideMixIns.WinningOverrides(PSMutagenConfig.Environment.LoadOrder.PriorityOrder, MajorRecordInfo.MajorRecordTypes[RecordType], IncludeDeletedRecords).ToArray());
            }
        }
    }

    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    [Cmdlet(VerbsCommon.Get, "FalloutMajorRecords")]
    public class GetFalloutMajorRecords : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public required IModGetter Mod;

        [Parameter()]
        // set taken from MajorRecordInfo
        // "$($mrs.Name -join '","')"
        [ValidateSet("ActionRecord", "Activator", "ActorValueInformation", "ADamageType", "AddonNode", "Ammunition", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AStoryManagerNode", "Book", "CameraPath", "CameraShot", "Cell", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "Container", "DialogBranch", "DialogResponses", "DialogTopic", "Door", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Faction", "Furniture", "GameSetting", "Global", "Grass", "Hazard", "HeadPart", "Holotape", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "Ingestible", "Ingredient", "InstanceNamingRules", "Key", "Keyword", "LeveledItem", "LeveledNpc", "Light", "LoadScreen", "Location", "MagicEffect", "MaterialObject", "MaterialSwap", "MaterialType", "Message", "MiscItem", "MovableStatic", "MusicTrack", "MusicType", "NavigationMesh", "Npc", "ObjectEffect", "AObjectModification", "Package", "PackIn", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "Scene", "ShaderParticleGeometry", "SoundCategory", "SoundDescriptor", "SoundOutputModel", "Static", "StaticCollection", "TalkingActivator", "Terminal", "TextureSet", "Transform", "Tree", "VisualEffect", "VoiceType", "Water", "Weapon", "Weather", "Worldspace", "Zoom", "AttractionRule", "Component", "LocationReferenceType", "AnimationSoundTagSet", "Class", "Debris", "FormList", "ImpactDataSet", "LeveledSpell", "Outfit", "SoundMarker", "AcousticSpace", "ReverbParameters", "LandscapeTexture", "Spell", "Footstep", "FootstepSet", "GodRays", "LensFlare", "Flora", "BodyPartData", "MovementType", "DualCastData", "ConstructibleObject", "AimModel", "BendableSpline", "NavigationMeshInfoMap", "LightingTemplate", "Layer", "ReferenceGroup", "Landscape", "AnimatedObject", "DefaultObjectManager", "DefaultObject", "DialogView", "AssociationType", "AudioEffectChain", "SoundKeywordMapping", "SceneCollection", "AudioCategorySnapshot", "NavigationMeshObstacleManager", "ObjectVisibilityManager")]
        public string? RecordType;

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

    [OutputType(typeof(IFallout4MajorRecordInternal))]
    [Cmdlet(VerbsCommon.Copy, "FalloutRecordAsOverride")]
    public class CopyFalloutRecordAsOverride : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            switch (Record.GetType().Name)
            {
                case "GameSetting":
                case "GameSettingBinaryOverlay":
                    Mod.GameSettings.GetOrAddAsOverride(Record);
                    break;
                case "Keyword":
                case "KeywordBinaryOverlay":
                    Mod.Keywords.GetOrAddAsOverride(Record);
                    break;
                case "LocationReferenceType":
                case "LocationReferenceTypeBinaryOverlay":
                    Mod.LocationReferenceTypes.GetOrAddAsOverride(Record);
                    break;
                case "ActionRecord":
                case "ActionRecordBinaryOverlay":
                    Mod.Actions.GetOrAddAsOverride(Record);
                    break;
                case "Transform":
                case "TransformBinaryOverlay":
                    Mod.Transforms.GetOrAddAsOverride(Record);
                    break;
                case "Component":
                case "ComponentBinaryOverlay":
                    Mod.Components.GetOrAddAsOverride(Record);
                    break;
                case "TextureSet":
                case "TextureSetBinaryOverlay":
                    Mod.TextureSets.GetOrAddAsOverride(Record);
                    break;
                case "Global":
                case "GlobalBinaryOverlay":
                    Mod.Globals.GetOrAddAsOverride(Record);
                    break;
                case "ADamageType":
                case "ADamageTypeBinaryOverlay":
                    Mod.DamageTypes.GetOrAddAsOverride(Record);
                    break;
                case "Class":
                case "ClassBinaryOverlay":
                    Mod.Classes.GetOrAddAsOverride(Record);
                    break;
                case "Faction":
                case "FactionBinaryOverlay":
                    Mod.Factions.GetOrAddAsOverride(Record);
                    break;
                case "HeadPart":
                case "HeadPartBinaryOverlay":
                    Mod.HeadParts.GetOrAddAsOverride(Record);
                    break;
                case "Race":
                case "RaceBinaryOverlay":
                    Mod.Races.GetOrAddAsOverride(Record);
                    break;
                case "SoundMarker":
                case "SoundMarkerBinaryOverlay":
                    Mod.SoundMarkers.GetOrAddAsOverride(Record);
                    break;
                case "AcousticSpace":
                case "AcousticSpaceBinaryOverlay":
                    Mod.AcousticSpaces.GetOrAddAsOverride(Record);
                    break;
                case "MagicEffect":
                case "MagicEffectBinaryOverlay":
                    Mod.MagicEffects.GetOrAddAsOverride(Record);
                    break;
                case "LandscapeTexture":
                case "LandscapeTextureBinaryOverlay":
                    Mod.LandscapeTextures.GetOrAddAsOverride(Record);
                    break;
                case "ObjectEffect":
                case "ObjectEffectBinaryOverlay":
                    Mod.ObjectEffects.GetOrAddAsOverride(Record);
                    break;
                case "Spell":
                case "SpellBinaryOverlay":
                    Mod.Spells.GetOrAddAsOverride(Record);
                    break;
                case "Activator":
                case "ActivatorBinaryOverlay":
                    Mod.Activators.GetOrAddAsOverride(Record);
                    break;
                case "TalkingActivator":
                case "TalkingActivatorBinaryOverlay":
                    Mod.TalkingActivators.GetOrAddAsOverride(Record);
                    break;
                case "Armor":
                case "ArmorBinaryOverlay":
                    Mod.Armors.GetOrAddAsOverride(Record);
                    break;
                case "Book":
                case "BookBinaryOverlay":
                    Mod.Books.GetOrAddAsOverride(Record);
                    break;
                case "Container":
                case "ContainerBinaryOverlay":
                    Mod.Containers.GetOrAddAsOverride(Record);
                    break;
                case "Door":
                case "DoorBinaryOverlay":
                    Mod.Doors.GetOrAddAsOverride(Record);
                    break;
                case "Ingredient":
                case "IngredientBinaryOverlay":
                    Mod.Ingredients.GetOrAddAsOverride(Record);
                    break;
                case "Light":
                case "LightBinaryOverlay":
                    Mod.Lights.GetOrAddAsOverride(Record);
                    break;
                case "MiscItem":
                case "MiscItemBinaryOverlay":
                    Mod.MiscItems.GetOrAddAsOverride(Record);
                    break;
                case "Static":
                case "StaticBinaryOverlay":
                    Mod.Statics.GetOrAddAsOverride(Record);
                    break;
                case "StaticCollection":
                case "StaticCollectionBinaryOverlay":
                    Mod.StaticCollections.GetOrAddAsOverride(Record);
                    break;
                case "MovableStatic":
                case "MovableStaticBinaryOverlay":
                    Mod.MovableStatics.GetOrAddAsOverride(Record);
                    break;
                case "Grass":
                case "GrassBinaryOverlay":
                    Mod.Grasses.GetOrAddAsOverride(Record);
                    break;
                case "Tree":
                case "TreeBinaryOverlay":
                    Mod.Trees.GetOrAddAsOverride(Record);
                    break;
                case "Flora":
                case "FloraBinaryOverlay":
                    Mod.Florae.GetOrAddAsOverride(Record);
                    break;
                case "Furniture":
                case "FurnitureBinaryOverlay":
                    Mod.Furniture.GetOrAddAsOverride(Record);
                    break;
                case "Weapon":
                case "WeaponBinaryOverlay":
                    Mod.Weapons.GetOrAddAsOverride(Record);
                    break;
                case "Ammunition":
                case "AmmunitionBinaryOverlay":
                    Mod.Ammunitions.GetOrAddAsOverride(Record);
                    break;
                case "Npc":
                case "NpcBinaryOverlay":
                    Mod.Npcs.GetOrAddAsOverride(Record);
                    break;
                case "LeveledNpc":
                case "LeveledNpcBinaryOverlay":
                    Mod.LeveledNpcs.GetOrAddAsOverride(Record);
                    break;
                case "Key":
                case "KeyBinaryOverlay":
                    Mod.Keys.GetOrAddAsOverride(Record);
                    break;
                case "Ingestible":
                case "IngestibleBinaryOverlay":
                    Mod.Ingestibles.GetOrAddAsOverride(Record);
                    break;
                case "IdleMarker":
                case "IdleMarkerBinaryOverlay":
                    Mod.IdleMarkers.GetOrAddAsOverride(Record);
                    break;
                case "Holotape":
                case "HolotapeBinaryOverlay":
                    Mod.Holotapes.GetOrAddAsOverride(Record);
                    break;
                case "Projectile":
                case "ProjectileBinaryOverlay":
                    Mod.Projectiles.GetOrAddAsOverride(Record);
                    break;
                case "Hazard":
                case "HazardBinaryOverlay":
                    Mod.Hazards.GetOrAddAsOverride(Record);
                    break;
                case "BendableSpline":
                case "BendableSplineBinaryOverlay":
                    Mod.BendableSplines.GetOrAddAsOverride(Record);
                    break;
                case "Terminal":
                case "TerminalBinaryOverlay":
                    Mod.Terminals.GetOrAddAsOverride(Record);
                    break;
                case "LeveledItem":
                case "LeveledItemBinaryOverlay":
                    Mod.LeveledItems.GetOrAddAsOverride(Record);
                    break;
                case "Weather":
                case "WeatherBinaryOverlay":
                    Mod.Weather.GetOrAddAsOverride(Record);
                    break;
                case "Climate":
                case "ClimateBinaryOverlay":
                    Mod.Climates.GetOrAddAsOverride(Record);
                    break;
                case "ShaderParticleGeometry":
                case "ShaderParticleGeometryBinaryOverlay":
                    Mod.ShaderParticleGeometries.GetOrAddAsOverride(Record);
                    break;
                case "VisualEffect":
                case "VisualEffectBinaryOverlay":
                    Mod.VisualEffects.GetOrAddAsOverride(Record);
                    break;
                case "Region":
                case "RegionBinaryOverlay":
                    Mod.Regions.GetOrAddAsOverride(Record);
                    break;
                case "NavigationMeshInfoMap":
                case "NavigationMeshInfoMapBinaryOverlay":
                    Mod.NavigationMeshInfoMaps.GetOrAddAsOverride(Record);
                    break;
                case "Worldspace":
                case "WorldspaceBinaryOverlay":
                    Mod.Worldspaces.GetOrAddAsOverride(Record);
                    break;
                case "Quest":
                case "QuestBinaryOverlay":
                    Mod.Quests.GetOrAddAsOverride(Record);
                    break;
                case "IdleAnimation":
                case "IdleAnimationBinaryOverlay":
                    Mod.IdleAnimations.GetOrAddAsOverride(Record);
                    break;
                case "Package":
                case "PackageBinaryOverlay":
                    Mod.Packages.GetOrAddAsOverride(Record);
                    break;
                case "CombatStyle":
                case "CombatStyleBinaryOverlay":
                    Mod.CombatStyles.GetOrAddAsOverride(Record);
                    break;
                case "LoadScreen":
                case "LoadScreenBinaryOverlay":
                    Mod.LoadScreens.GetOrAddAsOverride(Record);
                    break;
                case "AnimatedObject":
                case "AnimatedObjectBinaryOverlay":
                    Mod.AnimatedObjects.GetOrAddAsOverride(Record);
                    break;
                case "Water":
                case "WaterBinaryOverlay":
                    Mod.Waters.GetOrAddAsOverride(Record);
                    break;
                case "EffectShader":
                case "EffectShaderBinaryOverlay":
                    Mod.EffectShaders.GetOrAddAsOverride(Record);
                    break;
                case "Explosion":
                case "ExplosionBinaryOverlay":
                    Mod.Explosions.GetOrAddAsOverride(Record);
                    break;
                case "Debris":
                case "DebrisBinaryOverlay":
                    Mod.Debris.GetOrAddAsOverride(Record);
                    break;
                case "ImageSpace":
                case "ImageSpaceBinaryOverlay":
                    Mod.ImageSpaces.GetOrAddAsOverride(Record);
                    break;
                case "ImageSpaceAdapter":
                case "ImageSpaceAdapterBinaryOverlay":
                    Mod.ImageSpaceAdapters.GetOrAddAsOverride(Record);
                    break;
                case "FormList":
                case "FormListBinaryOverlay":
                    Mod.FormLists.GetOrAddAsOverride(Record);
                    break;
                case "Perk":
                case "PerkBinaryOverlay":
                    Mod.Perks.GetOrAddAsOverride(Record);
                    break;
                case "BodyPartData":
                case "BodyPartDataBinaryOverlay":
                    Mod.BodyParts.GetOrAddAsOverride(Record);
                    break;
                case "AddonNode":
                case "AddonNodeBinaryOverlay":
                    Mod.AddonNodes.GetOrAddAsOverride(Record);
                    break;
                case "ActorValueInformation":
                case "ActorValueInformationBinaryOverlay":
                    Mod.ActorValueInformation.GetOrAddAsOverride(Record);
                    break;
                case "CameraShot":
                case "CameraShotBinaryOverlay":
                    Mod.CameraShots.GetOrAddAsOverride(Record);
                    break;
                case "CameraPath":
                case "CameraPathBinaryOverlay":
                    Mod.CameraPaths.GetOrAddAsOverride(Record);
                    break;
                case "VoiceType":
                case "VoiceTypeBinaryOverlay":
                    Mod.VoiceTypes.GetOrAddAsOverride(Record);
                    break;
                case "MaterialType":
                case "MaterialTypeBinaryOverlay":
                    Mod.MaterialTypes.GetOrAddAsOverride(Record);
                    break;
                case "Impact":
                case "ImpactBinaryOverlay":
                    Mod.Impacts.GetOrAddAsOverride(Record);
                    break;
                case "ImpactDataSet":
                case "ImpactDataSetBinaryOverlay":
                    Mod.ImpactDataSets.GetOrAddAsOverride(Record);
                    break;
                case "ArmorAddon":
                case "ArmorAddonBinaryOverlay":
                    Mod.ArmorAddons.GetOrAddAsOverride(Record);
                    break;
                case "EncounterZone":
                case "EncounterZoneBinaryOverlay":
                    Mod.EncounterZones.GetOrAddAsOverride(Record);
                    break;
                case "Location":
                case "LocationBinaryOverlay":
                    Mod.Locations.GetOrAddAsOverride(Record);
                    break;
                case "Message":
                case "MessageBinaryOverlay":
                    Mod.Messages.GetOrAddAsOverride(Record);
                    break;
                case "DefaultObjectManager":
                case "DefaultObjectManagerBinaryOverlay":
                    Mod.DefaultObjectManagers.GetOrAddAsOverride(Record);
                    break;
                case "DefaultObject":
                case "DefaultObjectBinaryOverlay":
                    Mod.DefaultObjects.GetOrAddAsOverride(Record);
                    break;
                case "LightingTemplate":
                case "LightingTemplateBinaryOverlay":
                    Mod.LightingTemplates.GetOrAddAsOverride(Record);
                    break;
                case "MusicType":
                case "MusicTypeBinaryOverlay":
                    Mod.MusicTypes.GetOrAddAsOverride(Record);
                    break;
                case "Footstep":
                case "FootstepBinaryOverlay":
                    Mod.Footsteps.GetOrAddAsOverride(Record);
                    break;
                case "FootstepSet":
                case "FootstepSetBinaryOverlay":
                    Mod.FootstepSets.GetOrAddAsOverride(Record);
                    break;
                case "StoryManagerBranchNode":
                case "StoryManagerBranchNodeBinaryOverlay":
                    Mod.StoryManagerBranchNodes.GetOrAddAsOverride(Record);
                    break;
                case "StoryManagerQuestNode":
                case "StoryManagerQuestNodeBinaryOverlay":
                    Mod.StoryManagerQuestNodes.GetOrAddAsOverride(Record);
                    break;
                case "StoryManagerEventNode":
                case "StoryManagerEventNodeBinaryOverlay":
                    Mod.StoryManagerEventNodes.GetOrAddAsOverride(Record);
                    break;
                case "MusicTrack":
                case "MusicTrackBinaryOverlay":
                    Mod.MusicTracks.GetOrAddAsOverride(Record);
                    break;
                case "DialogView":
                case "DialogViewBinaryOverlay":
                    Mod.DialogViews.GetOrAddAsOverride(Record);
                    break;
                case "EquipType":
                case "EquipTypeBinaryOverlay":
                    Mod.EquipTypes.GetOrAddAsOverride(Record);
                    break;
                case "Relationship":
                case "RelationshipBinaryOverlay":
                    Mod.Relationships.GetOrAddAsOverride(Record);
                    break;
                case "AssociationType":
                case "AssociationTypeBinaryOverlay":
                    Mod.AssociationTypes.GetOrAddAsOverride(Record);
                    break;
                case "Outfit":
                case "OutfitBinaryOverlay":
                    Mod.Outfits.GetOrAddAsOverride(Record);
                    break;
                case "ArtObject":
                case "ArtObjectBinaryOverlay":
                    Mod.ArtObjects.GetOrAddAsOverride(Record);
                    break;
                case "MaterialObject":
                case "MaterialObjectBinaryOverlay":
                    Mod.MaterialObjects.GetOrAddAsOverride(Record);
                    break;
                case "MovementType":
                case "MovementTypeBinaryOverlay":
                    Mod.MovementTypes.GetOrAddAsOverride(Record);
                    break;
                case "SoundDescriptor":
                case "SoundDescriptorBinaryOverlay":
                    Mod.SoundDescriptors.GetOrAddAsOverride(Record);
                    break;
                case "SoundCategory":
                case "SoundCategoryBinaryOverlay":
                    Mod.SoundCategories.GetOrAddAsOverride(Record);
                    break;
                case "SoundOutputModel":
                case "SoundOutputModelBinaryOverlay":
                    Mod.SoundOutputModels.GetOrAddAsOverride(Record);
                    break;
                case "CollisionLayer":
                case "CollisionLayerBinaryOverlay":
                    Mod.CollisionLayers.GetOrAddAsOverride(Record);
                    break;
                case "ColorRecord":
                case "ColorRecordBinaryOverlay":
                    Mod.Colors.GetOrAddAsOverride(Record);
                    break;
                case "ReverbParameters":
                case "ReverbParametersBinaryOverlay":
                    Mod.ReverbParameters.GetOrAddAsOverride(Record);
                    break;
                case "PackIn":
                case "PackInBinaryOverlay":
                    Mod.PackIns.GetOrAddAsOverride(Record);
                    break;
                case "ReferenceGroup":
                case "ReferenceGroupBinaryOverlay":
                    Mod.ReferenceGroups.GetOrAddAsOverride(Record);
                    break;
                case "AimModel":
                case "AimModelBinaryOverlay":
                    Mod.AimModels.GetOrAddAsOverride(Record);
                    break;
                case "Layer":
                case "LayerBinaryOverlay":
                    Mod.Layers.GetOrAddAsOverride(Record);
                    break;
                case "ConstructibleObject":
                case "ConstructibleObjectBinaryOverlay":
                    Mod.ConstructibleObjects.GetOrAddAsOverride(Record);
                    break;
                case "AObjectModification":
                case "AObjectModificationBinaryOverlay":
                    Mod.ObjectModifications.GetOrAddAsOverride(Record);
                    break;
                case "MaterialSwap":
                case "MaterialSwapBinaryOverlay":
                    Mod.MaterialSwaps.GetOrAddAsOverride(Record);
                    break;
                case "Zoom":
                case "ZoomBinaryOverlay":
                    Mod.Zooms.GetOrAddAsOverride(Record);
                    break;
                case "InstanceNamingRules":
                case "InstanceNamingRulesBinaryOverlay":
                    Mod.InstanceNamingRules.GetOrAddAsOverride(Record);
                    break;
                case "SoundKeywordMapping":
                case "SoundKeywordMappingBinaryOverlay":
                    Mod.SoundKeywordMappings.GetOrAddAsOverride(Record);
                    break;
                case "AudioEffectChain":
                case "AudioEffectChainBinaryOverlay":
                    Mod.AudioEffectChains.GetOrAddAsOverride(Record);
                    break;
                case "SceneCollection":
                case "SceneCollectionBinaryOverlay":
                    Mod.SceneCollections.GetOrAddAsOverride(Record);
                    break;
                case "AttractionRule":
                case "AttractionRuleBinaryOverlay":
                    Mod.AttractionRules.GetOrAddAsOverride(Record);
                    break;
                case "AudioCategorySnapshot":
                case "AudioCategorySnapshotBinaryOverlay":
                    Mod.AudioCategorySnapshots.GetOrAddAsOverride(Record);
                    break;
                case "AnimationSoundTagSet":
                case "AnimationSoundTagSetBinaryOverlay":
                    Mod.AnimationSoundTagSets.GetOrAddAsOverride(Record);
                    break;
                case "NavigationMeshObstacleManager":
                case "NavigationMeshObstacleManagerBinaryOverlay":
                    Mod.NavigationMeshObstacleManagers.GetOrAddAsOverride(Record);
                    break;
                case "LensFlare":
                case "LensFlareBinaryOverlay":
                    Mod.LensFlares.GetOrAddAsOverride(Record);
                    break;
                case "GodRays":
                case "GodRaysBinaryOverlay":
                    Mod.GodRays.GetOrAddAsOverride(Record);
                    break;
                case "ObjectVisibilityManager":
                case "ObjectVisibilityManagerBinaryOverlay":
                    Mod.ObjectVisibilityManagers.GetOrAddAsOverride(Record);
                    break;
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }
}