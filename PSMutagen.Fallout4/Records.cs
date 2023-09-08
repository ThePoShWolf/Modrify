using System.Management.Automation;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using PSMutagen.Core;

namespace PSMutagen.Fallout
{
    public class Helpers
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

        public static Fallout4MajorRecord CopyHelper(IFallout4Mod mod, IFallout4MajorRecordGetter Record, CopyType copyType)
        {
            switch (Record.GetType().Name, copyType)
            {
                case ("GameSetting", CopyType.AsOverride):
                case ("GameSettingBinaryOverlay", CopyType.AsOverride):
                    return mod.GameSettings.GetOrAddAsOverride(Record);
                case ("GameSetting", CopyType.AsNewRecord):
                case ("GameSettingBinaryOverlay", CopyType.AsNewRecord):
                    return mod.GameSettings.DuplicateInAsNewRecord(Record);
                case ("GameSetting", CopyType.DeepCopy):
                case ("GameSettingBinaryOverlay", CopyType.DeepCopy):
                    GameSetting newGameSettingRecord = (GameSetting)Record.DeepCopy();
                    mod.GameSettings.Add(newGameSettingRecord);
                    return newGameSettingRecord;
                case ("Keyword", CopyType.AsOverride):
                case ("KeywordBinaryOverlay", CopyType.AsOverride):
                    return mod.Keywords.GetOrAddAsOverride(Record);
                case ("Keyword", CopyType.AsNewRecord):
                case ("KeywordBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Keywords.DuplicateInAsNewRecord(Record);
                case ("Keyword", CopyType.DeepCopy):
                case ("KeywordBinaryOverlay", CopyType.DeepCopy):
                    Keyword newKeywordRecord = (Keyword)Record.DeepCopy();
                    mod.Keywords.Add(newKeywordRecord);
                    return newKeywordRecord;
                case ("LocationReferenceType", CopyType.AsOverride):
                case ("LocationReferenceTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.LocationReferenceTypes.GetOrAddAsOverride(Record);
                case ("LocationReferenceType", CopyType.AsNewRecord):
                case ("LocationReferenceTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LocationReferenceTypes.DuplicateInAsNewRecord(Record);
                case ("LocationReferenceType", CopyType.DeepCopy):
                case ("LocationReferenceTypeBinaryOverlay", CopyType.DeepCopy):
                    LocationReferenceType newLocationReferenceTypeRecord = (LocationReferenceType)Record.DeepCopy();
                    mod.LocationReferenceTypes.Add(newLocationReferenceTypeRecord);
                    return newLocationReferenceTypeRecord;
                case ("ActionRecord", CopyType.AsOverride):
                case ("ActionRecordBinaryOverlay", CopyType.AsOverride):
                    return mod.Actions.GetOrAddAsOverride(Record);
                case ("ActionRecord", CopyType.AsNewRecord):
                case ("ActionRecordBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Actions.DuplicateInAsNewRecord(Record);
                case ("ActionRecord", CopyType.DeepCopy):
                case ("ActionRecordBinaryOverlay", CopyType.DeepCopy):
                    ActionRecord newActionRecordRecord = (ActionRecord)Record.DeepCopy();
                    mod.Actions.Add(newActionRecordRecord);
                    return newActionRecordRecord;
                case ("Transform", CopyType.AsOverride):
                case ("TransformBinaryOverlay", CopyType.AsOverride):
                    return mod.Transforms.GetOrAddAsOverride(Record);
                case ("Transform", CopyType.AsNewRecord):
                case ("TransformBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Transforms.DuplicateInAsNewRecord(Record);
                case ("Transform", CopyType.DeepCopy):
                case ("TransformBinaryOverlay", CopyType.DeepCopy):
                    Transform newTransformRecord = (Transform)Record.DeepCopy();
                    mod.Transforms.Add(newTransformRecord);
                    return newTransformRecord;
                case ("Component", CopyType.AsOverride):
                case ("ComponentBinaryOverlay", CopyType.AsOverride):
                    return mod.Components.GetOrAddAsOverride(Record);
                case ("Component", CopyType.AsNewRecord):
                case ("ComponentBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Components.DuplicateInAsNewRecord(Record);
                case ("Component", CopyType.DeepCopy):
                case ("ComponentBinaryOverlay", CopyType.DeepCopy):
                    Component newComponentRecord = (Component)Record.DeepCopy();
                    mod.Components.Add(newComponentRecord);
                    return newComponentRecord;
                case ("TextureSet", CopyType.AsOverride):
                case ("TextureSetBinaryOverlay", CopyType.AsOverride):
                    return mod.TextureSets.GetOrAddAsOverride(Record);
                case ("TextureSet", CopyType.AsNewRecord):
                case ("TextureSetBinaryOverlay", CopyType.AsNewRecord):
                    return mod.TextureSets.DuplicateInAsNewRecord(Record);
                case ("TextureSet", CopyType.DeepCopy):
                case ("TextureSetBinaryOverlay", CopyType.DeepCopy):
                    TextureSet newTextureSetRecord = (TextureSet)Record.DeepCopy();
                    mod.TextureSets.Add(newTextureSetRecord);
                    return newTextureSetRecord;
                case ("Global", CopyType.AsOverride):
                case ("GlobalBinaryOverlay", CopyType.AsOverride):
                    return mod.Globals.GetOrAddAsOverride(Record);
                case ("Global", CopyType.AsNewRecord):
                case ("GlobalBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Globals.DuplicateInAsNewRecord(Record);
                case ("Global", CopyType.DeepCopy):
                case ("GlobalBinaryOverlay", CopyType.DeepCopy):
                    Global newGlobalRecord = (Global)Record.DeepCopy();
                    mod.Globals.Add(newGlobalRecord);
                    return newGlobalRecord;
                case ("ADamageType", CopyType.AsOverride):
                case ("ADamageTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.DamageTypes.GetOrAddAsOverride(Record);
                case ("ADamageType", CopyType.AsNewRecord):
                case ("ADamageTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DamageTypes.DuplicateInAsNewRecord(Record);
                case ("ADamageType", CopyType.DeepCopy):
                case ("ADamageTypeBinaryOverlay", CopyType.DeepCopy):
                    ADamageType newADamageTypeRecord = (ADamageType)Record.DeepCopy();
                    mod.DamageTypes.Add(newADamageTypeRecord);
                    return newADamageTypeRecord;
                case ("Class", CopyType.AsOverride):
                case ("ClassBinaryOverlay", CopyType.AsOverride):
                    return mod.Classes.GetOrAddAsOverride(Record);
                case ("Class", CopyType.AsNewRecord):
                case ("ClassBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Classes.DuplicateInAsNewRecord(Record);
                case ("Class", CopyType.DeepCopy):
                case ("ClassBinaryOverlay", CopyType.DeepCopy):
                    Class newClassRecord = (Class)Record.DeepCopy();
                    mod.Classes.Add(newClassRecord);
                    return newClassRecord;
                case ("Faction", CopyType.AsOverride):
                case ("FactionBinaryOverlay", CopyType.AsOverride):
                    return mod.Factions.GetOrAddAsOverride(Record);
                case ("Faction", CopyType.AsNewRecord):
                case ("FactionBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Factions.DuplicateInAsNewRecord(Record);
                case ("Faction", CopyType.DeepCopy):
                case ("FactionBinaryOverlay", CopyType.DeepCopy):
                    Faction newFactionRecord = (Faction)Record.DeepCopy();
                    mod.Factions.Add(newFactionRecord);
                    return newFactionRecord;
                case ("HeadPart", CopyType.AsOverride):
                case ("HeadPartBinaryOverlay", CopyType.AsOverride):
                    return mod.HeadParts.GetOrAddAsOverride(Record);
                case ("HeadPart", CopyType.AsNewRecord):
                case ("HeadPartBinaryOverlay", CopyType.AsNewRecord):
                    return mod.HeadParts.DuplicateInAsNewRecord(Record);
                case ("HeadPart", CopyType.DeepCopy):
                case ("HeadPartBinaryOverlay", CopyType.DeepCopy):
                    HeadPart newHeadPartRecord = (HeadPart)Record.DeepCopy();
                    mod.HeadParts.Add(newHeadPartRecord);
                    return newHeadPartRecord;
                case ("Race", CopyType.AsOverride):
                case ("RaceBinaryOverlay", CopyType.AsOverride):
                    return mod.Races.GetOrAddAsOverride(Record);
                case ("Race", CopyType.AsNewRecord):
                case ("RaceBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Races.DuplicateInAsNewRecord(Record);
                case ("Race", CopyType.DeepCopy):
                case ("RaceBinaryOverlay", CopyType.DeepCopy):
                    Race newRaceRecord = (Race)Record.DeepCopy();
                    mod.Races.Add(newRaceRecord);
                    return newRaceRecord;
                case ("SoundMarker", CopyType.AsOverride):
                case ("SoundMarkerBinaryOverlay", CopyType.AsOverride):
                    return mod.SoundMarkers.GetOrAddAsOverride(Record);
                case ("SoundMarker", CopyType.AsNewRecord):
                case ("SoundMarkerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SoundMarkers.DuplicateInAsNewRecord(Record);
                case ("SoundMarker", CopyType.DeepCopy):
                case ("SoundMarkerBinaryOverlay", CopyType.DeepCopy):
                    SoundMarker newSoundMarkerRecord = (SoundMarker)Record.DeepCopy();
                    mod.SoundMarkers.Add(newSoundMarkerRecord);
                    return newSoundMarkerRecord;
                case ("AcousticSpace", CopyType.AsOverride):
                case ("AcousticSpaceBinaryOverlay", CopyType.AsOverride):
                    return mod.AcousticSpaces.GetOrAddAsOverride(Record);
                case ("AcousticSpace", CopyType.AsNewRecord):
                case ("AcousticSpaceBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AcousticSpaces.DuplicateInAsNewRecord(Record);
                case ("AcousticSpace", CopyType.DeepCopy):
                case ("AcousticSpaceBinaryOverlay", CopyType.DeepCopy):
                    AcousticSpace newAcousticSpaceRecord = (AcousticSpace)Record.DeepCopy();
                    mod.AcousticSpaces.Add(newAcousticSpaceRecord);
                    return newAcousticSpaceRecord;
                case ("MagicEffect", CopyType.AsOverride):
                case ("MagicEffectBinaryOverlay", CopyType.AsOverride):
                    return mod.MagicEffects.GetOrAddAsOverride(Record);
                case ("MagicEffect", CopyType.AsNewRecord):
                case ("MagicEffectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MagicEffects.DuplicateInAsNewRecord(Record);
                case ("MagicEffect", CopyType.DeepCopy):
                case ("MagicEffectBinaryOverlay", CopyType.DeepCopy):
                    MagicEffect newMagicEffectRecord = (MagicEffect)Record.DeepCopy();
                    mod.MagicEffects.Add(newMagicEffectRecord);
                    return newMagicEffectRecord;
                case ("LandscapeTexture", CopyType.AsOverride):
                case ("LandscapeTextureBinaryOverlay", CopyType.AsOverride):
                    return mod.LandscapeTextures.GetOrAddAsOverride(Record);
                case ("LandscapeTexture", CopyType.AsNewRecord):
                case ("LandscapeTextureBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LandscapeTextures.DuplicateInAsNewRecord(Record);
                case ("LandscapeTexture", CopyType.DeepCopy):
                case ("LandscapeTextureBinaryOverlay", CopyType.DeepCopy):
                    LandscapeTexture newLandscapeTextureRecord = (LandscapeTexture)Record.DeepCopy();
                    mod.LandscapeTextures.Add(newLandscapeTextureRecord);
                    return newLandscapeTextureRecord;
                case ("ObjectEffect", CopyType.AsOverride):
                case ("ObjectEffectBinaryOverlay", CopyType.AsOverride):
                    return mod.ObjectEffects.GetOrAddAsOverride(Record);
                case ("ObjectEffect", CopyType.AsNewRecord):
                case ("ObjectEffectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ObjectEffects.DuplicateInAsNewRecord(Record);
                case ("ObjectEffect", CopyType.DeepCopy):
                case ("ObjectEffectBinaryOverlay", CopyType.DeepCopy):
                    ObjectEffect newObjectEffectRecord = (ObjectEffect)Record.DeepCopy();
                    mod.ObjectEffects.Add(newObjectEffectRecord);
                    return newObjectEffectRecord;
                case ("Spell", CopyType.AsOverride):
                case ("SpellBinaryOverlay", CopyType.AsOverride):
                    return mod.Spells.GetOrAddAsOverride(Record);
                case ("Spell", CopyType.AsNewRecord):
                case ("SpellBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Spells.DuplicateInAsNewRecord(Record);
                case ("Spell", CopyType.DeepCopy):
                case ("SpellBinaryOverlay", CopyType.DeepCopy):
                    Spell newSpellRecord = (Spell)Record.DeepCopy();
                    mod.Spells.Add(newSpellRecord);
                    return newSpellRecord;
                case ("Activator", CopyType.AsOverride):
                case ("ActivatorBinaryOverlay", CopyType.AsOverride):
                    return mod.Activators.GetOrAddAsOverride(Record);
                case ("Activator", CopyType.AsNewRecord):
                case ("ActivatorBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Activators.DuplicateInAsNewRecord(Record);
                case ("Activator", CopyType.DeepCopy):
                case ("ActivatorBinaryOverlay", CopyType.DeepCopy):
                    Mutagen.Bethesda.Fallout4.Activator newActivatorRecord = (Mutagen.Bethesda.Fallout4.Activator)Record.DeepCopy();
                    mod.Activators.Add(newActivatorRecord);
                    return newActivatorRecord;
                case ("TalkingActivator", CopyType.AsOverride):
                case ("TalkingActivatorBinaryOverlay", CopyType.AsOverride):
                    return mod.TalkingActivators.GetOrAddAsOverride(Record);
                case ("TalkingActivator", CopyType.AsNewRecord):
                case ("TalkingActivatorBinaryOverlay", CopyType.AsNewRecord):
                    return mod.TalkingActivators.DuplicateInAsNewRecord(Record);
                case ("TalkingActivator", CopyType.DeepCopy):
                case ("TalkingActivatorBinaryOverlay", CopyType.DeepCopy):
                    TalkingActivator newTalkingActivatorRecord = (TalkingActivator)Record.DeepCopy();
                    mod.TalkingActivators.Add(newTalkingActivatorRecord);
                    return newTalkingActivatorRecord;
                case ("Armor", CopyType.AsOverride):
                case ("ArmorBinaryOverlay", CopyType.AsOverride):
                    return mod.Armors.GetOrAddAsOverride(Record);
                case ("Armor", CopyType.AsNewRecord):
                case ("ArmorBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Armors.DuplicateInAsNewRecord(Record);
                case ("Armor", CopyType.DeepCopy):
                case ("ArmorBinaryOverlay", CopyType.DeepCopy):
                    Armor newArmorRecord = (Armor)Record.DeepCopy();
                    mod.Armors.Add(newArmorRecord);
                    return newArmorRecord;
                case ("Book", CopyType.AsOverride):
                case ("BookBinaryOverlay", CopyType.AsOverride):
                    return mod.Books.GetOrAddAsOverride(Record);
                case ("Book", CopyType.AsNewRecord):
                case ("BookBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Books.DuplicateInAsNewRecord(Record);
                case ("Book", CopyType.DeepCopy):
                case ("BookBinaryOverlay", CopyType.DeepCopy):
                    Book newBookRecord = (Book)Record.DeepCopy();
                    mod.Books.Add(newBookRecord);
                    return newBookRecord;
                case ("Container", CopyType.AsOverride):
                case ("ContainerBinaryOverlay", CopyType.AsOverride):
                    return mod.Containers.GetOrAddAsOverride(Record);
                case ("Container", CopyType.AsNewRecord):
                case ("ContainerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Containers.DuplicateInAsNewRecord(Record);
                case ("Container", CopyType.DeepCopy):
                case ("ContainerBinaryOverlay", CopyType.DeepCopy):
                    Container newContainerRecord = (Container)Record.DeepCopy();
                    mod.Containers.Add(newContainerRecord);
                    return newContainerRecord;
                case ("Door", CopyType.AsOverride):
                case ("DoorBinaryOverlay", CopyType.AsOverride):
                    return mod.Doors.GetOrAddAsOverride(Record);
                case ("Door", CopyType.AsNewRecord):
                case ("DoorBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Doors.DuplicateInAsNewRecord(Record);
                case ("Door", CopyType.DeepCopy):
                case ("DoorBinaryOverlay", CopyType.DeepCopy):
                    Door newDoorRecord = (Door)Record.DeepCopy();
                    mod.Doors.Add(newDoorRecord);
                    return newDoorRecord;
                case ("Ingredient", CopyType.AsOverride):
                case ("IngredientBinaryOverlay", CopyType.AsOverride):
                    return mod.Ingredients.GetOrAddAsOverride(Record);
                case ("Ingredient", CopyType.AsNewRecord):
                case ("IngredientBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Ingredients.DuplicateInAsNewRecord(Record);
                case ("Ingredient", CopyType.DeepCopy):
                case ("IngredientBinaryOverlay", CopyType.DeepCopy):
                    Ingredient newIngredientRecord = (Ingredient)Record.DeepCopy();
                    mod.Ingredients.Add(newIngredientRecord);
                    return newIngredientRecord;
                case ("Light", CopyType.AsOverride):
                case ("LightBinaryOverlay", CopyType.AsOverride):
                    return mod.Lights.GetOrAddAsOverride(Record);
                case ("Light", CopyType.AsNewRecord):
                case ("LightBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Lights.DuplicateInAsNewRecord(Record);
                case ("Light", CopyType.DeepCopy):
                case ("LightBinaryOverlay", CopyType.DeepCopy):
                    Light newLightRecord = (Light)Record.DeepCopy();
                    mod.Lights.Add(newLightRecord);
                    return newLightRecord;
                case ("MiscItem", CopyType.AsOverride):
                case ("MiscItemBinaryOverlay", CopyType.AsOverride):
                    return mod.MiscItems.GetOrAddAsOverride(Record);
                case ("MiscItem", CopyType.AsNewRecord):
                case ("MiscItemBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MiscItems.DuplicateInAsNewRecord(Record);
                case ("MiscItem", CopyType.DeepCopy):
                case ("MiscItemBinaryOverlay", CopyType.DeepCopy):
                    MiscItem newMiscItemRecord = (MiscItem)Record.DeepCopy();
                    mod.MiscItems.Add(newMiscItemRecord);
                    return newMiscItemRecord;
                case ("Static", CopyType.AsOverride):
                case ("StaticBinaryOverlay", CopyType.AsOverride):
                    return mod.Statics.GetOrAddAsOverride(Record);
                case ("Static", CopyType.AsNewRecord):
                case ("StaticBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Statics.DuplicateInAsNewRecord(Record);
                case ("Static", CopyType.DeepCopy):
                case ("StaticBinaryOverlay", CopyType.DeepCopy):
                    Static newStaticRecord = (Static)Record.DeepCopy();
                    mod.Statics.Add(newStaticRecord);
                    return newStaticRecord;
                case ("StaticCollection", CopyType.AsOverride):
                case ("StaticCollectionBinaryOverlay", CopyType.AsOverride):
                    return mod.StaticCollections.GetOrAddAsOverride(Record);
                case ("StaticCollection", CopyType.AsNewRecord):
                case ("StaticCollectionBinaryOverlay", CopyType.AsNewRecord):
                    return mod.StaticCollections.DuplicateInAsNewRecord(Record);
                case ("StaticCollection", CopyType.DeepCopy):
                case ("StaticCollectionBinaryOverlay", CopyType.DeepCopy):
                    StaticCollection newStaticCollectionRecord = (StaticCollection)Record.DeepCopy();
                    mod.StaticCollections.Add(newStaticCollectionRecord);
                    return newStaticCollectionRecord;
                case ("MovableStatic", CopyType.AsOverride):
                case ("MovableStaticBinaryOverlay", CopyType.AsOverride):
                    return mod.MovableStatics.GetOrAddAsOverride(Record);
                case ("MovableStatic", CopyType.AsNewRecord):
                case ("MovableStaticBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MovableStatics.DuplicateInAsNewRecord(Record);
                case ("MovableStatic", CopyType.DeepCopy):
                case ("MovableStaticBinaryOverlay", CopyType.DeepCopy):
                    MovableStatic newMovableStaticRecord = (MovableStatic)Record.DeepCopy();
                    mod.MovableStatics.Add(newMovableStaticRecord);
                    return newMovableStaticRecord;
                case ("Grass", CopyType.AsOverride):
                case ("GrassBinaryOverlay", CopyType.AsOverride):
                    return mod.Grasses.GetOrAddAsOverride(Record);
                case ("Grass", CopyType.AsNewRecord):
                case ("GrassBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Grasses.DuplicateInAsNewRecord(Record);
                case ("Grass", CopyType.DeepCopy):
                case ("GrassBinaryOverlay", CopyType.DeepCopy):
                    Grass newGrassRecord = (Grass)Record.DeepCopy();
                    mod.Grasses.Add(newGrassRecord);
                    return newGrassRecord;
                case ("Tree", CopyType.AsOverride):
                case ("TreeBinaryOverlay", CopyType.AsOverride):
                    return mod.Trees.GetOrAddAsOverride(Record);
                case ("Tree", CopyType.AsNewRecord):
                case ("TreeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Trees.DuplicateInAsNewRecord(Record);
                case ("Tree", CopyType.DeepCopy):
                case ("TreeBinaryOverlay", CopyType.DeepCopy):
                    Tree newTreeRecord = (Tree)Record.DeepCopy();
                    mod.Trees.Add(newTreeRecord);
                    return newTreeRecord;
                case ("Flora", CopyType.AsOverride):
                case ("FloraBinaryOverlay", CopyType.AsOverride):
                    return mod.Florae.GetOrAddAsOverride(Record);
                case ("Flora", CopyType.AsNewRecord):
                case ("FloraBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Florae.DuplicateInAsNewRecord(Record);
                case ("Flora", CopyType.DeepCopy):
                case ("FloraBinaryOverlay", CopyType.DeepCopy):
                    Flora newFloraRecord = (Flora)Record.DeepCopy();
                    mod.Florae.Add(newFloraRecord);
                    return newFloraRecord;
                case ("Furniture", CopyType.AsOverride):
                case ("FurnitureBinaryOverlay", CopyType.AsOverride):
                    return mod.Furniture.GetOrAddAsOverride(Record);
                case ("Furniture", CopyType.AsNewRecord):
                case ("FurnitureBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Furniture.DuplicateInAsNewRecord(Record);
                case ("Furniture", CopyType.DeepCopy):
                case ("FurnitureBinaryOverlay", CopyType.DeepCopy):
                    Furniture newFurnitureRecord = (Furniture)Record.DeepCopy();
                    mod.Furniture.Add(newFurnitureRecord);
                    return newFurnitureRecord;
                case ("Weapon", CopyType.AsOverride):
                case ("WeaponBinaryOverlay", CopyType.AsOverride):
                    return mod.Weapons.GetOrAddAsOverride(Record);
                case ("Weapon", CopyType.AsNewRecord):
                case ("WeaponBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Weapons.DuplicateInAsNewRecord(Record);
                case ("Weapon", CopyType.DeepCopy):
                case ("WeaponBinaryOverlay", CopyType.DeepCopy):
                    Weapon newWeaponRecord = (Weapon)Record.DeepCopy();
                    mod.Weapons.Add(newWeaponRecord);
                    return newWeaponRecord;
                case ("Ammunition", CopyType.AsOverride):
                case ("AmmunitionBinaryOverlay", CopyType.AsOverride):
                    return mod.Ammunitions.GetOrAddAsOverride(Record);
                case ("Ammunition", CopyType.AsNewRecord):
                case ("AmmunitionBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Ammunitions.DuplicateInAsNewRecord(Record);
                case ("Ammunition", CopyType.DeepCopy):
                case ("AmmunitionBinaryOverlay", CopyType.DeepCopy):
                    Ammunition newAmmunitionRecord = (Ammunition)Record.DeepCopy();
                    mod.Ammunitions.Add(newAmmunitionRecord);
                    return newAmmunitionRecord;
                case ("Npc", CopyType.AsOverride):
                case ("NpcBinaryOverlay", CopyType.AsOverride):
                    return mod.Npcs.GetOrAddAsOverride(Record);
                case ("Npc", CopyType.AsNewRecord):
                case ("NpcBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Npcs.DuplicateInAsNewRecord(Record);
                case ("Npc", CopyType.DeepCopy):
                case ("NpcBinaryOverlay", CopyType.DeepCopy):
                    Npc newNpcRecord = (Npc)Record.DeepCopy();
                    mod.Npcs.Add(newNpcRecord);
                    return newNpcRecord;
                case ("LeveledNpc", CopyType.AsOverride):
                case ("LeveledNpcBinaryOverlay", CopyType.AsOverride):
                    return mod.LeveledNpcs.GetOrAddAsOverride(Record);
                case ("LeveledNpc", CopyType.AsNewRecord):
                case ("LeveledNpcBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LeveledNpcs.DuplicateInAsNewRecord(Record);
                case ("LeveledNpc", CopyType.DeepCopy):
                case ("LeveledNpcBinaryOverlay", CopyType.DeepCopy):
                    LeveledNpc newLeveledNpcRecord = (LeveledNpc)Record.DeepCopy();
                    mod.LeveledNpcs.Add(newLeveledNpcRecord);
                    return newLeveledNpcRecord;
                case ("Key", CopyType.AsOverride):
                case ("KeyBinaryOverlay", CopyType.AsOverride):
                    return mod.Keys.GetOrAddAsOverride(Record);
                case ("Key", CopyType.AsNewRecord):
                case ("KeyBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Keys.DuplicateInAsNewRecord(Record);
                case ("Key", CopyType.DeepCopy):
                case ("KeyBinaryOverlay", CopyType.DeepCopy):
                    Key newKeyRecord = (Key)Record.DeepCopy();
                    mod.Keys.Add(newKeyRecord);
                    return newKeyRecord;
                case ("Ingestible", CopyType.AsOverride):
                case ("IngestibleBinaryOverlay", CopyType.AsOverride):
                    return mod.Ingestibles.GetOrAddAsOverride(Record);
                case ("Ingestible", CopyType.AsNewRecord):
                case ("IngestibleBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Ingestibles.DuplicateInAsNewRecord(Record);
                case ("Ingestible", CopyType.DeepCopy):
                case ("IngestibleBinaryOverlay", CopyType.DeepCopy):
                    Ingestible newIngestibleRecord = (Ingestible)Record.DeepCopy();
                    mod.Ingestibles.Add(newIngestibleRecord);
                    return newIngestibleRecord;
                case ("IdleMarker", CopyType.AsOverride):
                case ("IdleMarkerBinaryOverlay", CopyType.AsOverride):
                    return mod.IdleMarkers.GetOrAddAsOverride(Record);
                case ("IdleMarker", CopyType.AsNewRecord):
                case ("IdleMarkerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.IdleMarkers.DuplicateInAsNewRecord(Record);
                case ("IdleMarker", CopyType.DeepCopy):
                case ("IdleMarkerBinaryOverlay", CopyType.DeepCopy):
                    IdleMarker newIdleMarkerRecord = (IdleMarker)Record.DeepCopy();
                    mod.IdleMarkers.Add(newIdleMarkerRecord);
                    return newIdleMarkerRecord;
                case ("Holotape", CopyType.AsOverride):
                case ("HolotapeBinaryOverlay", CopyType.AsOverride):
                    return mod.Holotapes.GetOrAddAsOverride(Record);
                case ("Holotape", CopyType.AsNewRecord):
                case ("HolotapeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Holotapes.DuplicateInAsNewRecord(Record);
                case ("Holotape", CopyType.DeepCopy):
                case ("HolotapeBinaryOverlay", CopyType.DeepCopy):
                    Holotape newHolotapeRecord = (Holotape)Record.DeepCopy();
                    mod.Holotapes.Add(newHolotapeRecord);
                    return newHolotapeRecord;
                case ("Projectile", CopyType.AsOverride):
                case ("ProjectileBinaryOverlay", CopyType.AsOverride):
                    return mod.Projectiles.GetOrAddAsOverride(Record);
                case ("Projectile", CopyType.AsNewRecord):
                case ("ProjectileBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Projectiles.DuplicateInAsNewRecord(Record);
                case ("Projectile", CopyType.DeepCopy):
                case ("ProjectileBinaryOverlay", CopyType.DeepCopy):
                    Projectile newProjectileRecord = (Projectile)Record.DeepCopy();
                    mod.Projectiles.Add(newProjectileRecord);
                    return newProjectileRecord;
                case ("Hazard", CopyType.AsOverride):
                case ("HazardBinaryOverlay", CopyType.AsOverride):
                    return mod.Hazards.GetOrAddAsOverride(Record);
                case ("Hazard", CopyType.AsNewRecord):
                case ("HazardBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Hazards.DuplicateInAsNewRecord(Record);
                case ("Hazard", CopyType.DeepCopy):
                case ("HazardBinaryOverlay", CopyType.DeepCopy):
                    Hazard newHazardRecord = (Hazard)Record.DeepCopy();
                    mod.Hazards.Add(newHazardRecord);
                    return newHazardRecord;
                case ("BendableSpline", CopyType.AsOverride):
                case ("BendableSplineBinaryOverlay", CopyType.AsOverride):
                    return mod.BendableSplines.GetOrAddAsOverride(Record);
                case ("BendableSpline", CopyType.AsNewRecord):
                case ("BendableSplineBinaryOverlay", CopyType.AsNewRecord):
                    return mod.BendableSplines.DuplicateInAsNewRecord(Record);
                case ("BendableSpline", CopyType.DeepCopy):
                case ("BendableSplineBinaryOverlay", CopyType.DeepCopy):
                    BendableSpline newBendableSplineRecord = (BendableSpline)Record.DeepCopy();
                    mod.BendableSplines.Add(newBendableSplineRecord);
                    return newBendableSplineRecord;
                case ("Terminal", CopyType.AsOverride):
                case ("TerminalBinaryOverlay", CopyType.AsOverride):
                    return mod.Terminals.GetOrAddAsOverride(Record);
                case ("Terminal", CopyType.AsNewRecord):
                case ("TerminalBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Terminals.DuplicateInAsNewRecord(Record);
                case ("Terminal", CopyType.DeepCopy):
                case ("TerminalBinaryOverlay", CopyType.DeepCopy):
                    Terminal newTerminalRecord = (Terminal)Record.DeepCopy();
                    mod.Terminals.Add(newTerminalRecord);
                    return newTerminalRecord;
                case ("LeveledItem", CopyType.AsOverride):
                case ("LeveledItemBinaryOverlay", CopyType.AsOverride):
                    return mod.LeveledItems.GetOrAddAsOverride(Record);
                case ("LeveledItem", CopyType.AsNewRecord):
                case ("LeveledItemBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LeveledItems.DuplicateInAsNewRecord(Record);
                case ("LeveledItem", CopyType.DeepCopy):
                case ("LeveledItemBinaryOverlay", CopyType.DeepCopy):
                    LeveledItem newLeveledItemRecord = (LeveledItem)Record.DeepCopy();
                    mod.LeveledItems.Add(newLeveledItemRecord);
                    return newLeveledItemRecord;
                case ("Weather", CopyType.AsOverride):
                case ("WeatherBinaryOverlay", CopyType.AsOverride):
                    return mod.Weather.GetOrAddAsOverride(Record);
                case ("Weather", CopyType.AsNewRecord):
                case ("WeatherBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Weather.DuplicateInAsNewRecord(Record);
                case ("Weather", CopyType.DeepCopy):
                case ("WeatherBinaryOverlay", CopyType.DeepCopy):
                    Weather newWeatherRecord = (Weather)Record.DeepCopy();
                    mod.Weather.Add(newWeatherRecord);
                    return newWeatherRecord;
                case ("Climate", CopyType.AsOverride):
                case ("ClimateBinaryOverlay", CopyType.AsOverride):
                    return mod.Climates.GetOrAddAsOverride(Record);
                case ("Climate", CopyType.AsNewRecord):
                case ("ClimateBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Climates.DuplicateInAsNewRecord(Record);
                case ("Climate", CopyType.DeepCopy):
                case ("ClimateBinaryOverlay", CopyType.DeepCopy):
                    Climate newClimateRecord = (Climate)Record.DeepCopy();
                    mod.Climates.Add(newClimateRecord);
                    return newClimateRecord;
                case ("ShaderParticleGeometry", CopyType.AsOverride):
                case ("ShaderParticleGeometryBinaryOverlay", CopyType.AsOverride):
                    return mod.ShaderParticleGeometries.GetOrAddAsOverride(Record);
                case ("ShaderParticleGeometry", CopyType.AsNewRecord):
                case ("ShaderParticleGeometryBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ShaderParticleGeometries.DuplicateInAsNewRecord(Record);
                case ("ShaderParticleGeometry", CopyType.DeepCopy):
                case ("ShaderParticleGeometryBinaryOverlay", CopyType.DeepCopy):
                    ShaderParticleGeometry newShaderParticleGeometryRecord = (ShaderParticleGeometry)Record.DeepCopy();
                    mod.ShaderParticleGeometries.Add(newShaderParticleGeometryRecord);
                    return newShaderParticleGeometryRecord;
                case ("VisualEffect", CopyType.AsOverride):
                case ("VisualEffectBinaryOverlay", CopyType.AsOverride):
                    return mod.VisualEffects.GetOrAddAsOverride(Record);
                case ("VisualEffect", CopyType.AsNewRecord):
                case ("VisualEffectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.VisualEffects.DuplicateInAsNewRecord(Record);
                case ("VisualEffect", CopyType.DeepCopy):
                case ("VisualEffectBinaryOverlay", CopyType.DeepCopy):
                    VisualEffect newVisualEffectRecord = (VisualEffect)Record.DeepCopy();
                    mod.VisualEffects.Add(newVisualEffectRecord);
                    return newVisualEffectRecord;
                case ("Region", CopyType.AsOverride):
                case ("RegionBinaryOverlay", CopyType.AsOverride):
                    return mod.Regions.GetOrAddAsOverride(Record);
                case ("Region", CopyType.AsNewRecord):
                case ("RegionBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Regions.DuplicateInAsNewRecord(Record);
                case ("Region", CopyType.DeepCopy):
                case ("RegionBinaryOverlay", CopyType.DeepCopy):
                    Region newRegionRecord = (Region)Record.DeepCopy();
                    mod.Regions.Add(newRegionRecord);
                    return newRegionRecord;
                case ("NavigationMeshInfoMap", CopyType.AsOverride):
                case ("NavigationMeshInfoMapBinaryOverlay", CopyType.AsOverride):
                    return mod.NavigationMeshInfoMaps.GetOrAddAsOverride(Record);
                case ("NavigationMeshInfoMap", CopyType.AsNewRecord):
                case ("NavigationMeshInfoMapBinaryOverlay", CopyType.AsNewRecord):
                    return mod.NavigationMeshInfoMaps.DuplicateInAsNewRecord(Record);
                case ("NavigationMeshInfoMap", CopyType.DeepCopy):
                case ("NavigationMeshInfoMapBinaryOverlay", CopyType.DeepCopy):
                    NavigationMeshInfoMap newNavigationMeshInfoMapRecord = (NavigationMeshInfoMap)Record.DeepCopy();
                    mod.NavigationMeshInfoMaps.Add(newNavigationMeshInfoMapRecord);
                    return newNavigationMeshInfoMapRecord;
                case ("Worldspace", CopyType.AsOverride):
                case ("WorldspaceBinaryOverlay", CopyType.AsOverride):
                    return mod.Worldspaces.GetOrAddAsOverride(Record);
                case ("Worldspace", CopyType.AsNewRecord):
                case ("WorldspaceBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Worldspaces.DuplicateInAsNewRecord(Record);
                case ("Worldspace", CopyType.DeepCopy):
                case ("WorldspaceBinaryOverlay", CopyType.DeepCopy):
                    Worldspace newWorldspaceRecord = (Worldspace)Record.DeepCopy();
                    mod.Worldspaces.Add(newWorldspaceRecord);
                    return newWorldspaceRecord;
                case ("Quest", CopyType.AsOverride):
                case ("QuestBinaryOverlay", CopyType.AsOverride):
                    return mod.Quests.GetOrAddAsOverride(Record);
                case ("Quest", CopyType.AsNewRecord):
                case ("QuestBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Quests.DuplicateInAsNewRecord(Record);
                case ("Quest", CopyType.DeepCopy):
                case ("QuestBinaryOverlay", CopyType.DeepCopy):
                    Quest newQuestRecord = (Quest)Record.DeepCopy();
                    mod.Quests.Add(newQuestRecord);
                    return newQuestRecord;
                case ("IdleAnimation", CopyType.AsOverride):
                case ("IdleAnimationBinaryOverlay", CopyType.AsOverride):
                    return mod.IdleAnimations.GetOrAddAsOverride(Record);
                case ("IdleAnimation", CopyType.AsNewRecord):
                case ("IdleAnimationBinaryOverlay", CopyType.AsNewRecord):
                    return mod.IdleAnimations.DuplicateInAsNewRecord(Record);
                case ("IdleAnimation", CopyType.DeepCopy):
                case ("IdleAnimationBinaryOverlay", CopyType.DeepCopy):
                    IdleAnimation newIdleAnimationRecord = (IdleAnimation)Record.DeepCopy();
                    mod.IdleAnimations.Add(newIdleAnimationRecord);
                    return newIdleAnimationRecord;
                case ("Package", CopyType.AsOverride):
                case ("PackageBinaryOverlay", CopyType.AsOverride):
                    return mod.Packages.GetOrAddAsOverride(Record);
                case ("Package", CopyType.AsNewRecord):
                case ("PackageBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Packages.DuplicateInAsNewRecord(Record);
                case ("Package", CopyType.DeepCopy):
                case ("PackageBinaryOverlay", CopyType.DeepCopy):
                    Package newPackageRecord = (Package)Record.DeepCopy();
                    mod.Packages.Add(newPackageRecord);
                    return newPackageRecord;
                case ("CombatStyle", CopyType.AsOverride):
                case ("CombatStyleBinaryOverlay", CopyType.AsOverride):
                    return mod.CombatStyles.GetOrAddAsOverride(Record);
                case ("CombatStyle", CopyType.AsNewRecord):
                case ("CombatStyleBinaryOverlay", CopyType.AsNewRecord):
                    return mod.CombatStyles.DuplicateInAsNewRecord(Record);
                case ("CombatStyle", CopyType.DeepCopy):
                case ("CombatStyleBinaryOverlay", CopyType.DeepCopy):
                    CombatStyle newCombatStyleRecord = (CombatStyle)Record.DeepCopy();
                    mod.CombatStyles.Add(newCombatStyleRecord);
                    return newCombatStyleRecord;
                case ("LoadScreen", CopyType.AsOverride):
                case ("LoadScreenBinaryOverlay", CopyType.AsOverride):
                    return mod.LoadScreens.GetOrAddAsOverride(Record);
                case ("LoadScreen", CopyType.AsNewRecord):
                case ("LoadScreenBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LoadScreens.DuplicateInAsNewRecord(Record);
                case ("LoadScreen", CopyType.DeepCopy):
                case ("LoadScreenBinaryOverlay", CopyType.DeepCopy):
                    LoadScreen newLoadScreenRecord = (LoadScreen)Record.DeepCopy();
                    mod.LoadScreens.Add(newLoadScreenRecord);
                    return newLoadScreenRecord;
                case ("AnimatedObject", CopyType.AsOverride):
                case ("AnimatedObjectBinaryOverlay", CopyType.AsOverride):
                    return mod.AnimatedObjects.GetOrAddAsOverride(Record);
                case ("AnimatedObject", CopyType.AsNewRecord):
                case ("AnimatedObjectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AnimatedObjects.DuplicateInAsNewRecord(Record);
                case ("AnimatedObject", CopyType.DeepCopy):
                case ("AnimatedObjectBinaryOverlay", CopyType.DeepCopy):
                    AnimatedObject newAnimatedObjectRecord = (AnimatedObject)Record.DeepCopy();
                    mod.AnimatedObjects.Add(newAnimatedObjectRecord);
                    return newAnimatedObjectRecord;
                case ("Water", CopyType.AsOverride):
                case ("WaterBinaryOverlay", CopyType.AsOverride):
                    return mod.Waters.GetOrAddAsOverride(Record);
                case ("Water", CopyType.AsNewRecord):
                case ("WaterBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Waters.DuplicateInAsNewRecord(Record);
                case ("Water", CopyType.DeepCopy):
                case ("WaterBinaryOverlay", CopyType.DeepCopy):
                    Water newWaterRecord = (Water)Record.DeepCopy();
                    mod.Waters.Add(newWaterRecord);
                    return newWaterRecord;
                case ("EffectShader", CopyType.AsOverride):
                case ("EffectShaderBinaryOverlay", CopyType.AsOverride):
                    return mod.EffectShaders.GetOrAddAsOverride(Record);
                case ("EffectShader", CopyType.AsNewRecord):
                case ("EffectShaderBinaryOverlay", CopyType.AsNewRecord):
                    return mod.EffectShaders.DuplicateInAsNewRecord(Record);
                case ("EffectShader", CopyType.DeepCopy):
                case ("EffectShaderBinaryOverlay", CopyType.DeepCopy):
                    EffectShader newEffectShaderRecord = (EffectShader)Record.DeepCopy();
                    mod.EffectShaders.Add(newEffectShaderRecord);
                    return newEffectShaderRecord;
                case ("Explosion", CopyType.AsOverride):
                case ("ExplosionBinaryOverlay", CopyType.AsOverride):
                    return mod.Explosions.GetOrAddAsOverride(Record);
                case ("Explosion", CopyType.AsNewRecord):
                case ("ExplosionBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Explosions.DuplicateInAsNewRecord(Record);
                case ("Explosion", CopyType.DeepCopy):
                case ("ExplosionBinaryOverlay", CopyType.DeepCopy):
                    Explosion newExplosionRecord = (Explosion)Record.DeepCopy();
                    mod.Explosions.Add(newExplosionRecord);
                    return newExplosionRecord;
                case ("Debris", CopyType.AsOverride):
                case ("DebrisBinaryOverlay", CopyType.AsOverride):
                    return mod.Debris.GetOrAddAsOverride(Record);
                case ("Debris", CopyType.AsNewRecord):
                case ("DebrisBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Debris.DuplicateInAsNewRecord(Record);
                case ("Debris", CopyType.DeepCopy):
                case ("DebrisBinaryOverlay", CopyType.DeepCopy):
                    Debris newDebrisRecord = (Debris)Record.DeepCopy();
                    mod.Debris.Add(newDebrisRecord);
                    return newDebrisRecord;
                case ("ImageSpace", CopyType.AsOverride):
                case ("ImageSpaceBinaryOverlay", CopyType.AsOverride):
                    return mod.ImageSpaces.GetOrAddAsOverride(Record);
                case ("ImageSpace", CopyType.AsNewRecord):
                case ("ImageSpaceBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ImageSpaces.DuplicateInAsNewRecord(Record);
                case ("ImageSpace", CopyType.DeepCopy):
                case ("ImageSpaceBinaryOverlay", CopyType.DeepCopy):
                    ImageSpace newImageSpaceRecord = (ImageSpace)Record.DeepCopy();
                    mod.ImageSpaces.Add(newImageSpaceRecord);
                    return newImageSpaceRecord;
                case ("ImageSpaceAdapter", CopyType.AsOverride):
                case ("ImageSpaceAdapterBinaryOverlay", CopyType.AsOverride):
                    return mod.ImageSpaceAdapters.GetOrAddAsOverride(Record);
                case ("ImageSpaceAdapter", CopyType.AsNewRecord):
                case ("ImageSpaceAdapterBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ImageSpaceAdapters.DuplicateInAsNewRecord(Record);
                case ("ImageSpaceAdapter", CopyType.DeepCopy):
                case ("ImageSpaceAdapterBinaryOverlay", CopyType.DeepCopy):
                    ImageSpaceAdapter newImageSpaceAdapterRecord = (ImageSpaceAdapter)Record.DeepCopy();
                    mod.ImageSpaceAdapters.Add(newImageSpaceAdapterRecord);
                    return newImageSpaceAdapterRecord;
                case ("FormList", CopyType.AsOverride):
                case ("FormListBinaryOverlay", CopyType.AsOverride):
                    return mod.FormLists.GetOrAddAsOverride(Record);
                case ("FormList", CopyType.AsNewRecord):
                case ("FormListBinaryOverlay", CopyType.AsNewRecord):
                    return mod.FormLists.DuplicateInAsNewRecord(Record);
                case ("FormList", CopyType.DeepCopy):
                case ("FormListBinaryOverlay", CopyType.DeepCopy):
                    FormList newFormListRecord = (FormList)Record.DeepCopy();
                    mod.FormLists.Add(newFormListRecord);
                    return newFormListRecord;
                case ("Perk", CopyType.AsOverride):
                case ("PerkBinaryOverlay", CopyType.AsOverride):
                    return mod.Perks.GetOrAddAsOverride(Record);
                case ("Perk", CopyType.AsNewRecord):
                case ("PerkBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Perks.DuplicateInAsNewRecord(Record);
                case ("Perk", CopyType.DeepCopy):
                case ("PerkBinaryOverlay", CopyType.DeepCopy):
                    Perk newPerkRecord = (Perk)Record.DeepCopy();
                    mod.Perks.Add(newPerkRecord);
                    return newPerkRecord;
                case ("BodyPartData", CopyType.AsOverride):
                case ("BodyPartDataBinaryOverlay", CopyType.AsOverride):
                    return mod.BodyParts.GetOrAddAsOverride(Record);
                case ("BodyPartData", CopyType.AsNewRecord):
                case ("BodyPartDataBinaryOverlay", CopyType.AsNewRecord):
                    return mod.BodyParts.DuplicateInAsNewRecord(Record);
                case ("BodyPartData", CopyType.DeepCopy):
                case ("BodyPartDataBinaryOverlay", CopyType.DeepCopy):
                    BodyPartData newBodyPartDataRecord = (BodyPartData)Record.DeepCopy();
                    mod.BodyParts.Add(newBodyPartDataRecord);
                    return newBodyPartDataRecord;
                case ("AddonNode", CopyType.AsOverride):
                case ("AddonNodeBinaryOverlay", CopyType.AsOverride):
                    return mod.AddonNodes.GetOrAddAsOverride(Record);
                case ("AddonNode", CopyType.AsNewRecord):
                case ("AddonNodeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AddonNodes.DuplicateInAsNewRecord(Record);
                case ("AddonNode", CopyType.DeepCopy):
                case ("AddonNodeBinaryOverlay", CopyType.DeepCopy):
                    AddonNode newAddonNodeRecord = (AddonNode)Record.DeepCopy();
                    mod.AddonNodes.Add(newAddonNodeRecord);
                    return newAddonNodeRecord;
                case ("ActorValueInformation", CopyType.AsOverride):
                case ("ActorValueInformationBinaryOverlay", CopyType.AsOverride):
                    return mod.ActorValueInformation.GetOrAddAsOverride(Record);
                case ("ActorValueInformation", CopyType.AsNewRecord):
                case ("ActorValueInformationBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ActorValueInformation.DuplicateInAsNewRecord(Record);
                case ("ActorValueInformation", CopyType.DeepCopy):
                case ("ActorValueInformationBinaryOverlay", CopyType.DeepCopy):
                    ActorValueInformation newActorValueInformationRecord = (ActorValueInformation)Record.DeepCopy();
                    mod.ActorValueInformation.Add(newActorValueInformationRecord);
                    return newActorValueInformationRecord;
                case ("CameraShot", CopyType.AsOverride):
                case ("CameraShotBinaryOverlay", CopyType.AsOverride):
                    return mod.CameraShots.GetOrAddAsOverride(Record);
                case ("CameraShot", CopyType.AsNewRecord):
                case ("CameraShotBinaryOverlay", CopyType.AsNewRecord):
                    return mod.CameraShots.DuplicateInAsNewRecord(Record);
                case ("CameraShot", CopyType.DeepCopy):
                case ("CameraShotBinaryOverlay", CopyType.DeepCopy):
                    CameraShot newCameraShotRecord = (CameraShot)Record.DeepCopy();
                    mod.CameraShots.Add(newCameraShotRecord);
                    return newCameraShotRecord;
                case ("CameraPath", CopyType.AsOverride):
                case ("CameraPathBinaryOverlay", CopyType.AsOverride):
                    return mod.CameraPaths.GetOrAddAsOverride(Record);
                case ("CameraPath", CopyType.AsNewRecord):
                case ("CameraPathBinaryOverlay", CopyType.AsNewRecord):
                    return mod.CameraPaths.DuplicateInAsNewRecord(Record);
                case ("CameraPath", CopyType.DeepCopy):
                case ("CameraPathBinaryOverlay", CopyType.DeepCopy):
                    CameraPath newCameraPathRecord = (CameraPath)Record.DeepCopy();
                    mod.CameraPaths.Add(newCameraPathRecord);
                    return newCameraPathRecord;
                case ("VoiceType", CopyType.AsOverride):
                case ("VoiceTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.VoiceTypes.GetOrAddAsOverride(Record);
                case ("VoiceType", CopyType.AsNewRecord):
                case ("VoiceTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.VoiceTypes.DuplicateInAsNewRecord(Record);
                case ("VoiceType", CopyType.DeepCopy):
                case ("VoiceTypeBinaryOverlay", CopyType.DeepCopy):
                    VoiceType newVoiceTypeRecord = (VoiceType)Record.DeepCopy();
                    mod.VoiceTypes.Add(newVoiceTypeRecord);
                    return newVoiceTypeRecord;
                case ("MaterialType", CopyType.AsOverride):
                case ("MaterialTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.MaterialTypes.GetOrAddAsOverride(Record);
                case ("MaterialType", CopyType.AsNewRecord):
                case ("MaterialTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MaterialTypes.DuplicateInAsNewRecord(Record);
                case ("MaterialType", CopyType.DeepCopy):
                case ("MaterialTypeBinaryOverlay", CopyType.DeepCopy):
                    MaterialType newMaterialTypeRecord = (MaterialType)Record.DeepCopy();
                    mod.MaterialTypes.Add(newMaterialTypeRecord);
                    return newMaterialTypeRecord;
                case ("Impact", CopyType.AsOverride):
                case ("ImpactBinaryOverlay", CopyType.AsOverride):
                    return mod.Impacts.GetOrAddAsOverride(Record);
                case ("Impact", CopyType.AsNewRecord):
                case ("ImpactBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Impacts.DuplicateInAsNewRecord(Record);
                case ("Impact", CopyType.DeepCopy):
                case ("ImpactBinaryOverlay", CopyType.DeepCopy):
                    Impact newImpactRecord = (Impact)Record.DeepCopy();
                    mod.Impacts.Add(newImpactRecord);
                    return newImpactRecord;
                case ("ImpactDataSet", CopyType.AsOverride):
                case ("ImpactDataSetBinaryOverlay", CopyType.AsOverride):
                    return mod.ImpactDataSets.GetOrAddAsOverride(Record);
                case ("ImpactDataSet", CopyType.AsNewRecord):
                case ("ImpactDataSetBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ImpactDataSets.DuplicateInAsNewRecord(Record);
                case ("ImpactDataSet", CopyType.DeepCopy):
                case ("ImpactDataSetBinaryOverlay", CopyType.DeepCopy):
                    ImpactDataSet newImpactDataSetRecord = (ImpactDataSet)Record.DeepCopy();
                    mod.ImpactDataSets.Add(newImpactDataSetRecord);
                    return newImpactDataSetRecord;
                case ("ArmorAddon", CopyType.AsOverride):
                case ("ArmorAddonBinaryOverlay", CopyType.AsOverride):
                    return mod.ArmorAddons.GetOrAddAsOverride(Record);
                case ("ArmorAddon", CopyType.AsNewRecord):
                case ("ArmorAddonBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ArmorAddons.DuplicateInAsNewRecord(Record);
                case ("ArmorAddon", CopyType.DeepCopy):
                case ("ArmorAddonBinaryOverlay", CopyType.DeepCopy):
                    ArmorAddon newArmorAddonRecord = (ArmorAddon)Record.DeepCopy();
                    mod.ArmorAddons.Add(newArmorAddonRecord);
                    return newArmorAddonRecord;
                case ("EncounterZone", CopyType.AsOverride):
                case ("EncounterZoneBinaryOverlay", CopyType.AsOverride):
                    return mod.EncounterZones.GetOrAddAsOverride(Record);
                case ("EncounterZone", CopyType.AsNewRecord):
                case ("EncounterZoneBinaryOverlay", CopyType.AsNewRecord):
                    return mod.EncounterZones.DuplicateInAsNewRecord(Record);
                case ("EncounterZone", CopyType.DeepCopy):
                case ("EncounterZoneBinaryOverlay", CopyType.DeepCopy):
                    EncounterZone newEncounterZoneRecord = (EncounterZone)Record.DeepCopy();
                    mod.EncounterZones.Add(newEncounterZoneRecord);
                    return newEncounterZoneRecord;
                case ("Location", CopyType.AsOverride):
                case ("LocationBinaryOverlay", CopyType.AsOverride):
                    return mod.Locations.GetOrAddAsOverride(Record);
                case ("Location", CopyType.AsNewRecord):
                case ("LocationBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Locations.DuplicateInAsNewRecord(Record);
                case ("Location", CopyType.DeepCopy):
                case ("LocationBinaryOverlay", CopyType.DeepCopy):
                    Location newLocationRecord = (Location)Record.DeepCopy();
                    mod.Locations.Add(newLocationRecord);
                    return newLocationRecord;
                case ("Message", CopyType.AsOverride):
                case ("MessageBinaryOverlay", CopyType.AsOverride):
                    return mod.Messages.GetOrAddAsOverride(Record);
                case ("Message", CopyType.AsNewRecord):
                case ("MessageBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Messages.DuplicateInAsNewRecord(Record);
                case ("Message", CopyType.DeepCopy):
                case ("MessageBinaryOverlay", CopyType.DeepCopy):
                    Message newMessageRecord = (Message)Record.DeepCopy();
                    mod.Messages.Add(newMessageRecord);
                    return newMessageRecord;
                case ("DefaultObjectManager", CopyType.AsOverride):
                case ("DefaultObjectManagerBinaryOverlay", CopyType.AsOverride):
                    return mod.DefaultObjectManagers.GetOrAddAsOverride(Record);
                case ("DefaultObjectManager", CopyType.AsNewRecord):
                case ("DefaultObjectManagerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DefaultObjectManagers.DuplicateInAsNewRecord(Record);
                case ("DefaultObjectManager", CopyType.DeepCopy):
                case ("DefaultObjectManagerBinaryOverlay", CopyType.DeepCopy):
                    DefaultObjectManager newDefaultObjectManagerRecord = (DefaultObjectManager)Record.DeepCopy();
                    mod.DefaultObjectManagers.Add(newDefaultObjectManagerRecord);
                    return newDefaultObjectManagerRecord;
                case ("DefaultObject", CopyType.AsOverride):
                case ("DefaultObjectBinaryOverlay", CopyType.AsOverride):
                    return mod.DefaultObjects.GetOrAddAsOverride(Record);
                case ("DefaultObject", CopyType.AsNewRecord):
                case ("DefaultObjectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DefaultObjects.DuplicateInAsNewRecord(Record);
                case ("DefaultObject", CopyType.DeepCopy):
                case ("DefaultObjectBinaryOverlay", CopyType.DeepCopy):
                    DefaultObject newDefaultObjectRecord = (DefaultObject)Record.DeepCopy();
                    mod.DefaultObjects.Add(newDefaultObjectRecord);
                    return newDefaultObjectRecord;
                case ("LightingTemplate", CopyType.AsOverride):
                case ("LightingTemplateBinaryOverlay", CopyType.AsOverride):
                    return mod.LightingTemplates.GetOrAddAsOverride(Record);
                case ("LightingTemplate", CopyType.AsNewRecord):
                case ("LightingTemplateBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LightingTemplates.DuplicateInAsNewRecord(Record);
                case ("LightingTemplate", CopyType.DeepCopy):
                case ("LightingTemplateBinaryOverlay", CopyType.DeepCopy):
                    LightingTemplate newLightingTemplateRecord = (LightingTemplate)Record.DeepCopy();
                    mod.LightingTemplates.Add(newLightingTemplateRecord);
                    return newLightingTemplateRecord;
                case ("MusicType", CopyType.AsOverride):
                case ("MusicTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.MusicTypes.GetOrAddAsOverride(Record);
                case ("MusicType", CopyType.AsNewRecord):
                case ("MusicTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MusicTypes.DuplicateInAsNewRecord(Record);
                case ("MusicType", CopyType.DeepCopy):
                case ("MusicTypeBinaryOverlay", CopyType.DeepCopy):
                    MusicType newMusicTypeRecord = (MusicType)Record.DeepCopy();
                    mod.MusicTypes.Add(newMusicTypeRecord);
                    return newMusicTypeRecord;
                case ("Footstep", CopyType.AsOverride):
                case ("FootstepBinaryOverlay", CopyType.AsOverride):
                    return mod.Footsteps.GetOrAddAsOverride(Record);
                case ("Footstep", CopyType.AsNewRecord):
                case ("FootstepBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Footsteps.DuplicateInAsNewRecord(Record);
                case ("Footstep", CopyType.DeepCopy):
                case ("FootstepBinaryOverlay", CopyType.DeepCopy):
                    Footstep newFootstepRecord = (Footstep)Record.DeepCopy();
                    mod.Footsteps.Add(newFootstepRecord);
                    return newFootstepRecord;
                case ("FootstepSet", CopyType.AsOverride):
                case ("FootstepSetBinaryOverlay", CopyType.AsOverride):
                    return mod.FootstepSets.GetOrAddAsOverride(Record);
                case ("FootstepSet", CopyType.AsNewRecord):
                case ("FootstepSetBinaryOverlay", CopyType.AsNewRecord):
                    return mod.FootstepSets.DuplicateInAsNewRecord(Record);
                case ("FootstepSet", CopyType.DeepCopy):
                case ("FootstepSetBinaryOverlay", CopyType.DeepCopy):
                    FootstepSet newFootstepSetRecord = (FootstepSet)Record.DeepCopy();
                    mod.FootstepSets.Add(newFootstepSetRecord);
                    return newFootstepSetRecord;
                case ("StoryManagerBranchNode", CopyType.AsOverride):
                case ("StoryManagerBranchNodeBinaryOverlay", CopyType.AsOverride):
                    return mod.StoryManagerBranchNodes.GetOrAddAsOverride(Record);
                case ("StoryManagerBranchNode", CopyType.AsNewRecord):
                case ("StoryManagerBranchNodeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.StoryManagerBranchNodes.DuplicateInAsNewRecord(Record);
                case ("StoryManagerBranchNode", CopyType.DeepCopy):
                case ("StoryManagerBranchNodeBinaryOverlay", CopyType.DeepCopy):
                    StoryManagerBranchNode newStoryManagerBranchNodeRecord = (StoryManagerBranchNode)Record.DeepCopy();
                    mod.StoryManagerBranchNodes.Add(newStoryManagerBranchNodeRecord);
                    return newStoryManagerBranchNodeRecord;
                case ("StoryManagerQuestNode", CopyType.AsOverride):
                case ("StoryManagerQuestNodeBinaryOverlay", CopyType.AsOverride):
                    return mod.StoryManagerQuestNodes.GetOrAddAsOverride(Record);
                case ("StoryManagerQuestNode", CopyType.AsNewRecord):
                case ("StoryManagerQuestNodeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.StoryManagerQuestNodes.DuplicateInAsNewRecord(Record);
                case ("StoryManagerQuestNode", CopyType.DeepCopy):
                case ("StoryManagerQuestNodeBinaryOverlay", CopyType.DeepCopy):
                    StoryManagerQuestNode newStoryManagerQuestNodeRecord = (StoryManagerQuestNode)Record.DeepCopy();
                    mod.StoryManagerQuestNodes.Add(newStoryManagerQuestNodeRecord);
                    return newStoryManagerQuestNodeRecord;
                case ("StoryManagerEventNode", CopyType.AsOverride):
                case ("StoryManagerEventNodeBinaryOverlay", CopyType.AsOverride):
                    return mod.StoryManagerEventNodes.GetOrAddAsOverride(Record);
                case ("StoryManagerEventNode", CopyType.AsNewRecord):
                case ("StoryManagerEventNodeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.StoryManagerEventNodes.DuplicateInAsNewRecord(Record);
                case ("StoryManagerEventNode", CopyType.DeepCopy):
                case ("StoryManagerEventNodeBinaryOverlay", CopyType.DeepCopy):
                    StoryManagerEventNode newStoryManagerEventNodeRecord = (StoryManagerEventNode)Record.DeepCopy();
                    mod.StoryManagerEventNodes.Add(newStoryManagerEventNodeRecord);
                    return newStoryManagerEventNodeRecord;
                case ("MusicTrack", CopyType.AsOverride):
                case ("MusicTrackBinaryOverlay", CopyType.AsOverride):
                    return mod.MusicTracks.GetOrAddAsOverride(Record);
                case ("MusicTrack", CopyType.AsNewRecord):
                case ("MusicTrackBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MusicTracks.DuplicateInAsNewRecord(Record);
                case ("MusicTrack", CopyType.DeepCopy):
                case ("MusicTrackBinaryOverlay", CopyType.DeepCopy):
                    MusicTrack newMusicTrackRecord = (MusicTrack)Record.DeepCopy();
                    mod.MusicTracks.Add(newMusicTrackRecord);
                    return newMusicTrackRecord;
                case ("DialogView", CopyType.AsOverride):
                case ("DialogViewBinaryOverlay", CopyType.AsOverride):
                    return mod.DialogViews.GetOrAddAsOverride(Record);
                case ("DialogView", CopyType.AsNewRecord):
                case ("DialogViewBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DialogViews.DuplicateInAsNewRecord(Record);
                case ("DialogView", CopyType.DeepCopy):
                case ("DialogViewBinaryOverlay", CopyType.DeepCopy):
                    DialogView newDialogViewRecord = (DialogView)Record.DeepCopy();
                    mod.DialogViews.Add(newDialogViewRecord);
                    return newDialogViewRecord;
                case ("EquipType", CopyType.AsOverride):
                case ("EquipTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.EquipTypes.GetOrAddAsOverride(Record);
                case ("EquipType", CopyType.AsNewRecord):
                case ("EquipTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.EquipTypes.DuplicateInAsNewRecord(Record);
                case ("EquipType", CopyType.DeepCopy):
                case ("EquipTypeBinaryOverlay", CopyType.DeepCopy):
                    EquipType newEquipTypeRecord = (EquipType)Record.DeepCopy();
                    mod.EquipTypes.Add(newEquipTypeRecord);
                    return newEquipTypeRecord;
                case ("Relationship", CopyType.AsOverride):
                case ("RelationshipBinaryOverlay", CopyType.AsOverride):
                    return mod.Relationships.GetOrAddAsOverride(Record);
                case ("Relationship", CopyType.AsNewRecord):
                case ("RelationshipBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Relationships.DuplicateInAsNewRecord(Record);
                case ("Relationship", CopyType.DeepCopy):
                case ("RelationshipBinaryOverlay", CopyType.DeepCopy):
                    Relationship newRelationshipRecord = (Relationship)Record.DeepCopy();
                    mod.Relationships.Add(newRelationshipRecord);
                    return newRelationshipRecord;
                case ("AssociationType", CopyType.AsOverride):
                case ("AssociationTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.AssociationTypes.GetOrAddAsOverride(Record);
                case ("AssociationType", CopyType.AsNewRecord):
                case ("AssociationTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AssociationTypes.DuplicateInAsNewRecord(Record);
                case ("AssociationType", CopyType.DeepCopy):
                case ("AssociationTypeBinaryOverlay", CopyType.DeepCopy):
                    AssociationType newAssociationTypeRecord = (AssociationType)Record.DeepCopy();
                    mod.AssociationTypes.Add(newAssociationTypeRecord);
                    return newAssociationTypeRecord;
                case ("Outfit", CopyType.AsOverride):
                case ("OutfitBinaryOverlay", CopyType.AsOverride):
                    return mod.Outfits.GetOrAddAsOverride(Record);
                case ("Outfit", CopyType.AsNewRecord):
                case ("OutfitBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Outfits.DuplicateInAsNewRecord(Record);
                case ("Outfit", CopyType.DeepCopy):
                case ("OutfitBinaryOverlay", CopyType.DeepCopy):
                    Outfit newOutfitRecord = (Outfit)Record.DeepCopy();
                    mod.Outfits.Add(newOutfitRecord);
                    return newOutfitRecord;
                case ("ArtObject", CopyType.AsOverride):
                case ("ArtObjectBinaryOverlay", CopyType.AsOverride):
                    return mod.ArtObjects.GetOrAddAsOverride(Record);
                case ("ArtObject", CopyType.AsNewRecord):
                case ("ArtObjectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ArtObjects.DuplicateInAsNewRecord(Record);
                case ("ArtObject", CopyType.DeepCopy):
                case ("ArtObjectBinaryOverlay", CopyType.DeepCopy):
                    ArtObject newArtObjectRecord = (ArtObject)Record.DeepCopy();
                    mod.ArtObjects.Add(newArtObjectRecord);
                    return newArtObjectRecord;
                case ("MaterialObject", CopyType.AsOverride):
                case ("MaterialObjectBinaryOverlay", CopyType.AsOverride):
                    return mod.MaterialObjects.GetOrAddAsOverride(Record);
                case ("MaterialObject", CopyType.AsNewRecord):
                case ("MaterialObjectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MaterialObjects.DuplicateInAsNewRecord(Record);
                case ("MaterialObject", CopyType.DeepCopy):
                case ("MaterialObjectBinaryOverlay", CopyType.DeepCopy):
                    MaterialObject newMaterialObjectRecord = (MaterialObject)Record.DeepCopy();
                    mod.MaterialObjects.Add(newMaterialObjectRecord);
                    return newMaterialObjectRecord;
                case ("MovementType", CopyType.AsOverride):
                case ("MovementTypeBinaryOverlay", CopyType.AsOverride):
                    return mod.MovementTypes.GetOrAddAsOverride(Record);
                case ("MovementType", CopyType.AsNewRecord):
                case ("MovementTypeBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MovementTypes.DuplicateInAsNewRecord(Record);
                case ("MovementType", CopyType.DeepCopy):
                case ("MovementTypeBinaryOverlay", CopyType.DeepCopy):
                    MovementType newMovementTypeRecord = (MovementType)Record.DeepCopy();
                    mod.MovementTypes.Add(newMovementTypeRecord);
                    return newMovementTypeRecord;
                case ("SoundDescriptor", CopyType.AsOverride):
                case ("SoundDescriptorBinaryOverlay", CopyType.AsOverride):
                    return mod.SoundDescriptors.GetOrAddAsOverride(Record);
                case ("SoundDescriptor", CopyType.AsNewRecord):
                case ("SoundDescriptorBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SoundDescriptors.DuplicateInAsNewRecord(Record);
                case ("SoundDescriptor", CopyType.DeepCopy):
                case ("SoundDescriptorBinaryOverlay", CopyType.DeepCopy):
                    SoundDescriptor newSoundDescriptorRecord = (SoundDescriptor)Record.DeepCopy();
                    mod.SoundDescriptors.Add(newSoundDescriptorRecord);
                    return newSoundDescriptorRecord;
                case ("SoundCategory", CopyType.AsOverride):
                case ("SoundCategoryBinaryOverlay", CopyType.AsOverride):
                    return mod.SoundCategories.GetOrAddAsOverride(Record);
                case ("SoundCategory", CopyType.AsNewRecord):
                case ("SoundCategoryBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SoundCategories.DuplicateInAsNewRecord(Record);
                case ("SoundCategory", CopyType.DeepCopy):
                case ("SoundCategoryBinaryOverlay", CopyType.DeepCopy):
                    SoundCategory newSoundCategoryRecord = (SoundCategory)Record.DeepCopy();
                    mod.SoundCategories.Add(newSoundCategoryRecord);
                    return newSoundCategoryRecord;
                case ("SoundOutputModel", CopyType.AsOverride):
                case ("SoundOutputModelBinaryOverlay", CopyType.AsOverride):
                    return mod.SoundOutputModels.GetOrAddAsOverride(Record);
                case ("SoundOutputModel", CopyType.AsNewRecord):
                case ("SoundOutputModelBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SoundOutputModels.DuplicateInAsNewRecord(Record);
                case ("SoundOutputModel", CopyType.DeepCopy):
                case ("SoundOutputModelBinaryOverlay", CopyType.DeepCopy):
                    SoundOutputModel newSoundOutputModelRecord = (SoundOutputModel)Record.DeepCopy();
                    mod.SoundOutputModels.Add(newSoundOutputModelRecord);
                    return newSoundOutputModelRecord;
                case ("CollisionLayer", CopyType.AsOverride):
                case ("CollisionLayerBinaryOverlay", CopyType.AsOverride):
                    return mod.CollisionLayers.GetOrAddAsOverride(Record);
                case ("CollisionLayer", CopyType.AsNewRecord):
                case ("CollisionLayerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.CollisionLayers.DuplicateInAsNewRecord(Record);
                case ("CollisionLayer", CopyType.DeepCopy):
                case ("CollisionLayerBinaryOverlay", CopyType.DeepCopy):
                    CollisionLayer newCollisionLayerRecord = (CollisionLayer)Record.DeepCopy();
                    mod.CollisionLayers.Add(newCollisionLayerRecord);
                    return newCollisionLayerRecord;
                case ("ColorRecord", CopyType.AsOverride):
                case ("ColorRecordBinaryOverlay", CopyType.AsOverride):
                    return mod.Colors.GetOrAddAsOverride(Record);
                case ("ColorRecord", CopyType.AsNewRecord):
                case ("ColorRecordBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Colors.DuplicateInAsNewRecord(Record);
                case ("ColorRecord", CopyType.DeepCopy):
                case ("ColorRecordBinaryOverlay", CopyType.DeepCopy):
                    ColorRecord newColorRecordRecord = (ColorRecord)Record.DeepCopy();
                    mod.Colors.Add(newColorRecordRecord);
                    return newColorRecordRecord;
                case ("ReverbParameters", CopyType.AsOverride):
                case ("ReverbParametersBinaryOverlay", CopyType.AsOverride):
                    return mod.ReverbParameters.GetOrAddAsOverride(Record);
                case ("ReverbParameters", CopyType.AsNewRecord):
                case ("ReverbParametersBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ReverbParameters.DuplicateInAsNewRecord(Record);
                case ("ReverbParameters", CopyType.DeepCopy):
                case ("ReverbParametersBinaryOverlay", CopyType.DeepCopy):
                    ReverbParameters newReverbParametersRecord = (ReverbParameters)Record.DeepCopy();
                    mod.ReverbParameters.Add(newReverbParametersRecord);
                    return newReverbParametersRecord;
                case ("PackIn", CopyType.AsOverride):
                case ("PackInBinaryOverlay", CopyType.AsOverride):
                    return mod.PackIns.GetOrAddAsOverride(Record);
                case ("PackIn", CopyType.AsNewRecord):
                case ("PackInBinaryOverlay", CopyType.AsNewRecord):
                    return mod.PackIns.DuplicateInAsNewRecord(Record);
                case ("PackIn", CopyType.DeepCopy):
                case ("PackInBinaryOverlay", CopyType.DeepCopy):
                    PackIn newPackInRecord = (PackIn)Record.DeepCopy();
                    mod.PackIns.Add(newPackInRecord);
                    return newPackInRecord;
                case ("ReferenceGroup", CopyType.AsOverride):
                case ("ReferenceGroupBinaryOverlay", CopyType.AsOverride):
                    return mod.ReferenceGroups.GetOrAddAsOverride(Record);
                case ("ReferenceGroup", CopyType.AsNewRecord):
                case ("ReferenceGroupBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ReferenceGroups.DuplicateInAsNewRecord(Record);
                case ("ReferenceGroup", CopyType.DeepCopy):
                case ("ReferenceGroupBinaryOverlay", CopyType.DeepCopy):
                    ReferenceGroup newReferenceGroupRecord = (ReferenceGroup)Record.DeepCopy();
                    mod.ReferenceGroups.Add(newReferenceGroupRecord);
                    return newReferenceGroupRecord;
                case ("AimModel", CopyType.AsOverride):
                case ("AimModelBinaryOverlay", CopyType.AsOverride):
                    return mod.AimModels.GetOrAddAsOverride(Record);
                case ("AimModel", CopyType.AsNewRecord):
                case ("AimModelBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AimModels.DuplicateInAsNewRecord(Record);
                case ("AimModel", CopyType.DeepCopy):
                case ("AimModelBinaryOverlay", CopyType.DeepCopy):
                    AimModel newAimModelRecord = (AimModel)Record.DeepCopy();
                    mod.AimModels.Add(newAimModelRecord);
                    return newAimModelRecord;
                case ("Layer", CopyType.AsOverride):
                case ("LayerBinaryOverlay", CopyType.AsOverride):
                    return mod.Layers.GetOrAddAsOverride(Record);
                case ("Layer", CopyType.AsNewRecord):
                case ("LayerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Layers.DuplicateInAsNewRecord(Record);
                case ("Layer", CopyType.DeepCopy):
                case ("LayerBinaryOverlay", CopyType.DeepCopy):
                    Layer newLayerRecord = (Layer)Record.DeepCopy();
                    mod.Layers.Add(newLayerRecord);
                    return newLayerRecord;
                case ("ConstructibleObject", CopyType.AsOverride):
                case ("ConstructibleObjectBinaryOverlay", CopyType.AsOverride):
                    return mod.ConstructibleObjects.GetOrAddAsOverride(Record);
                case ("ConstructibleObject", CopyType.AsNewRecord):
                case ("ConstructibleObjectBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ConstructibleObjects.DuplicateInAsNewRecord(Record);
                case ("ConstructibleObject", CopyType.DeepCopy):
                case ("ConstructibleObjectBinaryOverlay", CopyType.DeepCopy):
                    ConstructibleObject newConstructibleObjectRecord = (ConstructibleObject)Record.DeepCopy();
                    mod.ConstructibleObjects.Add(newConstructibleObjectRecord);
                    return newConstructibleObjectRecord;
                case ("AObjectModification", CopyType.AsOverride):
                case ("AObjectModificationBinaryOverlay", CopyType.AsOverride):
                    return mod.ObjectModifications.GetOrAddAsOverride(Record);
                case ("AObjectModification", CopyType.AsNewRecord):
                case ("AObjectModificationBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ObjectModifications.DuplicateInAsNewRecord(Record);
                case ("AObjectModification", CopyType.DeepCopy):
                case ("AObjectModificationBinaryOverlay", CopyType.DeepCopy):
                    AObjectModification newAObjectModificationRecord = (AObjectModification)Record.DeepCopy();
                    mod.ObjectModifications.Add(newAObjectModificationRecord);
                    return newAObjectModificationRecord;
                case ("MaterialSwap", CopyType.AsOverride):
                case ("MaterialSwapBinaryOverlay", CopyType.AsOverride):
                    return mod.MaterialSwaps.GetOrAddAsOverride(Record);
                case ("MaterialSwap", CopyType.AsNewRecord):
                case ("MaterialSwapBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MaterialSwaps.DuplicateInAsNewRecord(Record);
                case ("MaterialSwap", CopyType.DeepCopy):
                case ("MaterialSwapBinaryOverlay", CopyType.DeepCopy):
                    MaterialSwap newMaterialSwapRecord = (MaterialSwap)Record.DeepCopy();
                    mod.MaterialSwaps.Add(newMaterialSwapRecord);
                    return newMaterialSwapRecord;
                case ("Zoom", CopyType.AsOverride):
                case ("ZoomBinaryOverlay", CopyType.AsOverride):
                    return mod.Zooms.GetOrAddAsOverride(Record);
                case ("Zoom", CopyType.AsNewRecord):
                case ("ZoomBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Zooms.DuplicateInAsNewRecord(Record);
                case ("Zoom", CopyType.DeepCopy):
                case ("ZoomBinaryOverlay", CopyType.DeepCopy):
                    Zoom newZoomRecord = (Zoom)Record.DeepCopy();
                    mod.Zooms.Add(newZoomRecord);
                    return newZoomRecord;
                case ("InstanceNamingRules", CopyType.AsOverride):
                case ("InstanceNamingRulesBinaryOverlay", CopyType.AsOverride):
                    return mod.InstanceNamingRules.GetOrAddAsOverride(Record);
                case ("InstanceNamingRules", CopyType.AsNewRecord):
                case ("InstanceNamingRulesBinaryOverlay", CopyType.AsNewRecord):
                    return mod.InstanceNamingRules.DuplicateInAsNewRecord(Record);
                case ("InstanceNamingRules", CopyType.DeepCopy):
                case ("InstanceNamingRulesBinaryOverlay", CopyType.DeepCopy):
                    InstanceNamingRules newInstanceNamingRulesRecord = (InstanceNamingRules)Record.DeepCopy();
                    mod.InstanceNamingRules.Add(newInstanceNamingRulesRecord);
                    return newInstanceNamingRulesRecord;
                case ("SoundKeywordMapping", CopyType.AsOverride):
                case ("SoundKeywordMappingBinaryOverlay", CopyType.AsOverride):
                    return mod.SoundKeywordMappings.GetOrAddAsOverride(Record);
                case ("SoundKeywordMapping", CopyType.AsNewRecord):
                case ("SoundKeywordMappingBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SoundKeywordMappings.DuplicateInAsNewRecord(Record);
                case ("SoundKeywordMapping", CopyType.DeepCopy):
                case ("SoundKeywordMappingBinaryOverlay", CopyType.DeepCopy):
                    SoundKeywordMapping newSoundKeywordMappingRecord = (SoundKeywordMapping)Record.DeepCopy();
                    mod.SoundKeywordMappings.Add(newSoundKeywordMappingRecord);
                    return newSoundKeywordMappingRecord;
                case ("AudioEffectChain", CopyType.AsOverride):
                case ("AudioEffectChainBinaryOverlay", CopyType.AsOverride):
                    return mod.AudioEffectChains.GetOrAddAsOverride(Record);
                case ("AudioEffectChain", CopyType.AsNewRecord):
                case ("AudioEffectChainBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AudioEffectChains.DuplicateInAsNewRecord(Record);
                case ("AudioEffectChain", CopyType.DeepCopy):
                case ("AudioEffectChainBinaryOverlay", CopyType.DeepCopy):
                    AudioEffectChain newAudioEffectChainRecord = (AudioEffectChain)Record.DeepCopy();
                    mod.AudioEffectChains.Add(newAudioEffectChainRecord);
                    return newAudioEffectChainRecord;
                case ("SceneCollection", CopyType.AsOverride):
                case ("SceneCollectionBinaryOverlay", CopyType.AsOverride):
                    return mod.SceneCollections.GetOrAddAsOverride(Record);
                case ("SceneCollection", CopyType.AsNewRecord):
                case ("SceneCollectionBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SceneCollections.DuplicateInAsNewRecord(Record);
                case ("SceneCollection", CopyType.DeepCopy):
                case ("SceneCollectionBinaryOverlay", CopyType.DeepCopy):
                    SceneCollection newSceneCollectionRecord = (SceneCollection)Record.DeepCopy();
                    mod.SceneCollections.Add(newSceneCollectionRecord);
                    return newSceneCollectionRecord;
                case ("AttractionRule", CopyType.AsOverride):
                case ("AttractionRuleBinaryOverlay", CopyType.AsOverride):
                    return mod.AttractionRules.GetOrAddAsOverride(Record);
                case ("AttractionRule", CopyType.AsNewRecord):
                case ("AttractionRuleBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AttractionRules.DuplicateInAsNewRecord(Record);
                case ("AttractionRule", CopyType.DeepCopy):
                case ("AttractionRuleBinaryOverlay", CopyType.DeepCopy):
                    AttractionRule newAttractionRuleRecord = (AttractionRule)Record.DeepCopy();
                    mod.AttractionRules.Add(newAttractionRuleRecord);
                    return newAttractionRuleRecord;
                case ("AudioCategorySnapshot", CopyType.AsOverride):
                case ("AudioCategorySnapshotBinaryOverlay", CopyType.AsOverride):
                    return mod.AudioCategorySnapshots.GetOrAddAsOverride(Record);
                case ("AudioCategorySnapshot", CopyType.AsNewRecord):
                case ("AudioCategorySnapshotBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AudioCategorySnapshots.DuplicateInAsNewRecord(Record);
                case ("AudioCategorySnapshot", CopyType.DeepCopy):
                case ("AudioCategorySnapshotBinaryOverlay", CopyType.DeepCopy):
                    AudioCategorySnapshot newAudioCategorySnapshotRecord = (AudioCategorySnapshot)Record.DeepCopy();
                    mod.AudioCategorySnapshots.Add(newAudioCategorySnapshotRecord);
                    return newAudioCategorySnapshotRecord;
                case ("AnimationSoundTagSet", CopyType.AsOverride):
                case ("AnimationSoundTagSetBinaryOverlay", CopyType.AsOverride):
                    return mod.AnimationSoundTagSets.GetOrAddAsOverride(Record);
                case ("AnimationSoundTagSet", CopyType.AsNewRecord):
                case ("AnimationSoundTagSetBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AnimationSoundTagSets.DuplicateInAsNewRecord(Record);
                case ("AnimationSoundTagSet", CopyType.DeepCopy):
                case ("AnimationSoundTagSetBinaryOverlay", CopyType.DeepCopy):
                    AnimationSoundTagSet newAnimationSoundTagSetRecord = (AnimationSoundTagSet)Record.DeepCopy();
                    mod.AnimationSoundTagSets.Add(newAnimationSoundTagSetRecord);
                    return newAnimationSoundTagSetRecord;
                case ("NavigationMeshObstacleManager", CopyType.AsOverride):
                case ("NavigationMeshObstacleManagerBinaryOverlay", CopyType.AsOverride):
                    return mod.NavigationMeshObstacleManagers.GetOrAddAsOverride(Record);
                case ("NavigationMeshObstacleManager", CopyType.AsNewRecord):
                case ("NavigationMeshObstacleManagerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.NavigationMeshObstacleManagers.DuplicateInAsNewRecord(Record);
                case ("NavigationMeshObstacleManager", CopyType.DeepCopy):
                case ("NavigationMeshObstacleManagerBinaryOverlay", CopyType.DeepCopy):
                    NavigationMeshObstacleManager newNavigationMeshObstacleManagerRecord = (NavigationMeshObstacleManager)Record.DeepCopy();
                    mod.NavigationMeshObstacleManagers.Add(newNavigationMeshObstacleManagerRecord);
                    return newNavigationMeshObstacleManagerRecord;
                case ("LensFlare", CopyType.AsOverride):
                case ("LensFlareBinaryOverlay", CopyType.AsOverride):
                    return mod.LensFlares.GetOrAddAsOverride(Record);
                case ("LensFlare", CopyType.AsNewRecord):
                case ("LensFlareBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LensFlares.DuplicateInAsNewRecord(Record);
                case ("LensFlare", CopyType.DeepCopy):
                case ("LensFlareBinaryOverlay", CopyType.DeepCopy):
                    LensFlare newLensFlareRecord = (LensFlare)Record.DeepCopy();
                    mod.LensFlares.Add(newLensFlareRecord);
                    return newLensFlareRecord;
                case ("GodRays", CopyType.AsOverride):
                case ("GodRaysBinaryOverlay", CopyType.AsOverride):
                    return mod.GodRays.GetOrAddAsOverride(Record);
                case ("GodRays", CopyType.AsNewRecord):
                case ("GodRaysBinaryOverlay", CopyType.AsNewRecord):
                    return mod.GodRays.DuplicateInAsNewRecord(Record);
                case ("GodRays", CopyType.DeepCopy):
                case ("GodRaysBinaryOverlay", CopyType.DeepCopy):
                    GodRays newGodRaysRecord = (GodRays)Record.DeepCopy();
                    mod.GodRays.Add(newGodRaysRecord);
                    return newGodRaysRecord;
                case ("ObjectVisibilityManager", CopyType.AsOverride):
                case ("ObjectVisibilityManagerBinaryOverlay", CopyType.AsOverride):
                    return mod.ObjectVisibilityManagers.GetOrAddAsOverride(Record);
                case ("ObjectVisibilityManager", CopyType.AsNewRecord):
                case ("ObjectVisibilityManagerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.ObjectVisibilityManagers.DuplicateInAsNewRecord(Record);
                case ("ObjectVisibilityManager", CopyType.DeepCopy):
                case ("ObjectVisibilityManagerBinaryOverlay", CopyType.DeepCopy):
                    ObjectVisibilityManager newObjectVisibilityManagerRecord = (ObjectVisibilityManager)Record.DeepCopy();
                    mod.ObjectVisibilityManagers.Add(newObjectVisibilityManagerRecord);
                    return newObjectVisibilityManagerRecord;

                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }

    }

    [Cmdlet(VerbsCommon.Get, "FalloutWinningOverrides")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetFalloutWinningOverrides : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        // set taken from Helpers
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
                WriteObject(OverrideMixIns.WinningOverrides(PSMutagenConfig.Environment.LoadOrder.PriorityOrder, Helpers.MajorRecordTypes[RecordType], IncludeDeletedRecords).ToArray());
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "FalloutMajorRecords")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetFalloutMajorRecords : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public required IModGetter Mod;

        [Parameter()]
        // set taken from Helpers
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
                WriteObject(Mod.EnumerateMajorRecords(Helpers.MajorRecordTypes[RecordType]));
            }
        }
    }

    [Cmdlet(VerbsCommon.Copy, "FalloutRecordAsOverride")]
    [OutputType(typeof(Fallout4MajorRecord))]
    public class CopyFalloutRecordAsOverride : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.AsOverride));
        }
    }

    [Cmdlet(VerbsCommon.Copy, "FalloutRecordAsNewRecord")]
    [OutputType(typeof(Fallout4MajorRecord))]
    public class CopyFalloutRecordAsNewRecord : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.AsNewRecord));
        }
    }

    [Cmdlet(VerbsCommon.Copy, "FalloutRecordAsDeepCopy")]
    [OutputType(typeof(Fallout4MajorRecord))]
    public class CopyFallout4RecordAsDeepCopy : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.DeepCopy));
        }
    }
}