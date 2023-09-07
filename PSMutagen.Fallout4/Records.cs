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

        public static void CopyHelper(IFallout4Mod mod, IFallout4MajorRecordGetter Record, CopyType copyType)
        {
            switch (Record.GetType().Name, copyType)
            {
                case ("GameSetting", CopyType.AsOverride):
                case ("GameSettingBinaryOverlay", CopyType.AsOverride):
                    mod.GameSettings.GetOrAddAsOverride(Record);
                    break;
                case ("GameSetting", CopyType.AsNewRecord):
                case ("GameSettingBinaryOverlay", CopyType.AsNewRecord):
                    mod.GameSettings.DuplicateInAsNewRecord(Record);
                    break;
                case ("GameSetting", CopyType.DeepCopy):
                case ("GameSettingBinaryOverlay", CopyType.DeepCopy):
                    GameSetting newGameSettingRecord = (GameSetting)Record.DeepCopy();
                    mod.GameSettings.Add(newGameSettingRecord);
                    break;
                case ("Keyword", CopyType.AsOverride):
                case ("KeywordBinaryOverlay", CopyType.AsOverride):
                    mod.Keywords.GetOrAddAsOverride(Record);
                    break;
                case ("Keyword", CopyType.AsNewRecord):
                case ("KeywordBinaryOverlay", CopyType.AsNewRecord):
                    mod.Keywords.DuplicateInAsNewRecord(Record);
                    break;
                case ("Keyword", CopyType.DeepCopy):
                case ("KeywordBinaryOverlay", CopyType.DeepCopy):
                    Keyword newKeywordRecord = (Keyword)Record.DeepCopy();
                    mod.Keywords.Add(newKeywordRecord);
                    break;
                case ("LocationReferenceType", CopyType.AsOverride):
                case ("LocationReferenceTypeBinaryOverlay", CopyType.AsOverride):
                    mod.LocationReferenceTypes.GetOrAddAsOverride(Record);
                    break;
                case ("LocationReferenceType", CopyType.AsNewRecord):
                case ("LocationReferenceTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.LocationReferenceTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("LocationReferenceType", CopyType.DeepCopy):
                case ("LocationReferenceTypeBinaryOverlay", CopyType.DeepCopy):
                    LocationReferenceType newLocationReferenceTypeRecord = (LocationReferenceType)Record.DeepCopy();
                    mod.LocationReferenceTypes.Add(newLocationReferenceTypeRecord);
                    break;
                case ("ActionRecord", CopyType.AsOverride):
                case ("ActionRecordBinaryOverlay", CopyType.AsOverride):
                    mod.Actions.GetOrAddAsOverride(Record);
                    break;
                case ("ActionRecord", CopyType.AsNewRecord):
                case ("ActionRecordBinaryOverlay", CopyType.AsNewRecord):
                    mod.Actions.DuplicateInAsNewRecord(Record);
                    break;
                case ("ActionRecord", CopyType.DeepCopy):
                case ("ActionRecordBinaryOverlay", CopyType.DeepCopy):
                    ActionRecord newActionRecordRecord = (ActionRecord)Record.DeepCopy();
                    mod.Actions.Add(newActionRecordRecord);
                    break;
                case ("Transform", CopyType.AsOverride):
                case ("TransformBinaryOverlay", CopyType.AsOverride):
                    mod.Transforms.GetOrAddAsOverride(Record);
                    break;
                case ("Transform", CopyType.AsNewRecord):
                case ("TransformBinaryOverlay", CopyType.AsNewRecord):
                    mod.Transforms.DuplicateInAsNewRecord(Record);
                    break;
                case ("Transform", CopyType.DeepCopy):
                case ("TransformBinaryOverlay", CopyType.DeepCopy):
                    Transform newTransformRecord = (Transform)Record.DeepCopy();
                    mod.Transforms.Add(newTransformRecord);
                    break;
                case ("Component", CopyType.AsOverride):
                case ("ComponentBinaryOverlay", CopyType.AsOverride):
                    mod.Components.GetOrAddAsOverride(Record);
                    break;
                case ("Component", CopyType.AsNewRecord):
                case ("ComponentBinaryOverlay", CopyType.AsNewRecord):
                    mod.Components.DuplicateInAsNewRecord(Record);
                    break;
                case ("Component", CopyType.DeepCopy):
                case ("ComponentBinaryOverlay", CopyType.DeepCopy):
                    Component newComponentRecord = (Component)Record.DeepCopy();
                    mod.Components.Add(newComponentRecord);
                    break;
                case ("TextureSet", CopyType.AsOverride):
                case ("TextureSetBinaryOverlay", CopyType.AsOverride):
                    mod.TextureSets.GetOrAddAsOverride(Record);
                    break;
                case ("TextureSet", CopyType.AsNewRecord):
                case ("TextureSetBinaryOverlay", CopyType.AsNewRecord):
                    mod.TextureSets.DuplicateInAsNewRecord(Record);
                    break;
                case ("TextureSet", CopyType.DeepCopy):
                case ("TextureSetBinaryOverlay", CopyType.DeepCopy):
                    TextureSet newTextureSetRecord = (TextureSet)Record.DeepCopy();
                    mod.TextureSets.Add(newTextureSetRecord);
                    break;
                case ("Global", CopyType.AsOverride):
                case ("GlobalBinaryOverlay", CopyType.AsOverride):
                    mod.Globals.GetOrAddAsOverride(Record);
                    break;
                case ("Global", CopyType.AsNewRecord):
                case ("GlobalBinaryOverlay", CopyType.AsNewRecord):
                    mod.Globals.DuplicateInAsNewRecord(Record);
                    break;
                case ("Global", CopyType.DeepCopy):
                case ("GlobalBinaryOverlay", CopyType.DeepCopy):
                    Global newGlobalRecord = (Global)Record.DeepCopy();
                    mod.Globals.Add(newGlobalRecord);
                    break;
                case ("ADamageType", CopyType.AsOverride):
                case ("ADamageTypeBinaryOverlay", CopyType.AsOverride):
                    mod.DamageTypes.GetOrAddAsOverride(Record);
                    break;
                case ("ADamageType", CopyType.AsNewRecord):
                case ("ADamageTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.DamageTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("ADamageType", CopyType.DeepCopy):
                case ("ADamageTypeBinaryOverlay", CopyType.DeepCopy):
                    ADamageType newADamageTypeRecord = (ADamageType)Record.DeepCopy();
                    mod.DamageTypes.Add(newADamageTypeRecord);
                    break;
                case ("Class", CopyType.AsOverride):
                case ("ClassBinaryOverlay", CopyType.AsOverride):
                    mod.Classes.GetOrAddAsOverride(Record);
                    break;
                case ("Class", CopyType.AsNewRecord):
                case ("ClassBinaryOverlay", CopyType.AsNewRecord):
                    mod.Classes.DuplicateInAsNewRecord(Record);
                    break;
                case ("Class", CopyType.DeepCopy):
                case ("ClassBinaryOverlay", CopyType.DeepCopy):
                    Class newClassRecord = (Class)Record.DeepCopy();
                    mod.Classes.Add(newClassRecord);
                    break;
                case ("Faction", CopyType.AsOverride):
                case ("FactionBinaryOverlay", CopyType.AsOverride):
                    mod.Factions.GetOrAddAsOverride(Record);
                    break;
                case ("Faction", CopyType.AsNewRecord):
                case ("FactionBinaryOverlay", CopyType.AsNewRecord):
                    mod.Factions.DuplicateInAsNewRecord(Record);
                    break;
                case ("Faction", CopyType.DeepCopy):
                case ("FactionBinaryOverlay", CopyType.DeepCopy):
                    Faction newFactionRecord = (Faction)Record.DeepCopy();
                    mod.Factions.Add(newFactionRecord);
                    break;
                case ("HeadPart", CopyType.AsOverride):
                case ("HeadPartBinaryOverlay", CopyType.AsOverride):
                    mod.HeadParts.GetOrAddAsOverride(Record);
                    break;
                case ("HeadPart", CopyType.AsNewRecord):
                case ("HeadPartBinaryOverlay", CopyType.AsNewRecord):
                    mod.HeadParts.DuplicateInAsNewRecord(Record);
                    break;
                case ("HeadPart", CopyType.DeepCopy):
                case ("HeadPartBinaryOverlay", CopyType.DeepCopy):
                    HeadPart newHeadPartRecord = (HeadPart)Record.DeepCopy();
                    mod.HeadParts.Add(newHeadPartRecord);
                    break;
                case ("Race", CopyType.AsOverride):
                case ("RaceBinaryOverlay", CopyType.AsOverride):
                    mod.Races.GetOrAddAsOverride(Record);
                    break;
                case ("Race", CopyType.AsNewRecord):
                case ("RaceBinaryOverlay", CopyType.AsNewRecord):
                    mod.Races.DuplicateInAsNewRecord(Record);
                    break;
                case ("Race", CopyType.DeepCopy):
                case ("RaceBinaryOverlay", CopyType.DeepCopy):
                    Race newRaceRecord = (Race)Record.DeepCopy();
                    mod.Races.Add(newRaceRecord);
                    break;
                case ("SoundMarker", CopyType.AsOverride):
                case ("SoundMarkerBinaryOverlay", CopyType.AsOverride):
                    mod.SoundMarkers.GetOrAddAsOverride(Record);
                    break;
                case ("SoundMarker", CopyType.AsNewRecord):
                case ("SoundMarkerBinaryOverlay", CopyType.AsNewRecord):
                    mod.SoundMarkers.DuplicateInAsNewRecord(Record);
                    break;
                case ("SoundMarker", CopyType.DeepCopy):
                case ("SoundMarkerBinaryOverlay", CopyType.DeepCopy):
                    SoundMarker newSoundMarkerRecord = (SoundMarker)Record.DeepCopy();
                    mod.SoundMarkers.Add(newSoundMarkerRecord);
                    break;
                case ("AcousticSpace", CopyType.AsOverride):
                case ("AcousticSpaceBinaryOverlay", CopyType.AsOverride):
                    mod.AcousticSpaces.GetOrAddAsOverride(Record);
                    break;
                case ("AcousticSpace", CopyType.AsNewRecord):
                case ("AcousticSpaceBinaryOverlay", CopyType.AsNewRecord):
                    mod.AcousticSpaces.DuplicateInAsNewRecord(Record);
                    break;
                case ("AcousticSpace", CopyType.DeepCopy):
                case ("AcousticSpaceBinaryOverlay", CopyType.DeepCopy):
                    AcousticSpace newAcousticSpaceRecord = (AcousticSpace)Record.DeepCopy();
                    mod.AcousticSpaces.Add(newAcousticSpaceRecord);
                    break;
                case ("MagicEffect", CopyType.AsOverride):
                case ("MagicEffectBinaryOverlay", CopyType.AsOverride):
                    mod.MagicEffects.GetOrAddAsOverride(Record);
                    break;
                case ("MagicEffect", CopyType.AsNewRecord):
                case ("MagicEffectBinaryOverlay", CopyType.AsNewRecord):
                    mod.MagicEffects.DuplicateInAsNewRecord(Record);
                    break;
                case ("MagicEffect", CopyType.DeepCopy):
                case ("MagicEffectBinaryOverlay", CopyType.DeepCopy):
                    MagicEffect newMagicEffectRecord = (MagicEffect)Record.DeepCopy();
                    mod.MagicEffects.Add(newMagicEffectRecord);
                    break;
                case ("LandscapeTexture", CopyType.AsOverride):
                case ("LandscapeTextureBinaryOverlay", CopyType.AsOverride):
                    mod.LandscapeTextures.GetOrAddAsOverride(Record);
                    break;
                case ("LandscapeTexture", CopyType.AsNewRecord):
                case ("LandscapeTextureBinaryOverlay", CopyType.AsNewRecord):
                    mod.LandscapeTextures.DuplicateInAsNewRecord(Record);
                    break;
                case ("LandscapeTexture", CopyType.DeepCopy):
                case ("LandscapeTextureBinaryOverlay", CopyType.DeepCopy):
                    LandscapeTexture newLandscapeTextureRecord = (LandscapeTexture)Record.DeepCopy();
                    mod.LandscapeTextures.Add(newLandscapeTextureRecord);
                    break;
                case ("ObjectEffect", CopyType.AsOverride):
                case ("ObjectEffectBinaryOverlay", CopyType.AsOverride):
                    mod.ObjectEffects.GetOrAddAsOverride(Record);
                    break;
                case ("ObjectEffect", CopyType.AsNewRecord):
                case ("ObjectEffectBinaryOverlay", CopyType.AsNewRecord):
                    mod.ObjectEffects.DuplicateInAsNewRecord(Record);
                    break;
                case ("ObjectEffect", CopyType.DeepCopy):
                case ("ObjectEffectBinaryOverlay", CopyType.DeepCopy):
                    ObjectEffect newObjectEffectRecord = (ObjectEffect)Record.DeepCopy();
                    mod.ObjectEffects.Add(newObjectEffectRecord);
                    break;
                case ("Spell", CopyType.AsOverride):
                case ("SpellBinaryOverlay", CopyType.AsOverride):
                    mod.Spells.GetOrAddAsOverride(Record);
                    break;
                case ("Spell", CopyType.AsNewRecord):
                case ("SpellBinaryOverlay", CopyType.AsNewRecord):
                    mod.Spells.DuplicateInAsNewRecord(Record);
                    break;
                case ("Spell", CopyType.DeepCopy):
                case ("SpellBinaryOverlay", CopyType.DeepCopy):
                    Spell newSpellRecord = (Spell)Record.DeepCopy();
                    mod.Spells.Add(newSpellRecord);
                    break;
                case ("Activator", CopyType.AsOverride):
                case ("ActivatorBinaryOverlay", CopyType.AsOverride):
                    mod.Activators.GetOrAddAsOverride(Record);
                    break;
                case ("Activator", CopyType.AsNewRecord):
                case ("ActivatorBinaryOverlay", CopyType.AsNewRecord):
                    mod.Activators.DuplicateInAsNewRecord(Record);
                    break;
                case ("Activator", CopyType.DeepCopy):
                case ("ActivatorBinaryOverlay", CopyType.DeepCopy):
                    Mutagen.Bethesda.Fallout4.Activator newActivatorRecord = (Mutagen.Bethesda.Fallout4.Activator)Record.DeepCopy();
                    mod.Activators.Add(newActivatorRecord);
                    break;
                case ("TalkingActivator", CopyType.AsOverride):
                case ("TalkingActivatorBinaryOverlay", CopyType.AsOverride):
                    mod.TalkingActivators.GetOrAddAsOverride(Record);
                    break;
                case ("TalkingActivator", CopyType.AsNewRecord):
                case ("TalkingActivatorBinaryOverlay", CopyType.AsNewRecord):
                    mod.TalkingActivators.DuplicateInAsNewRecord(Record);
                    break;
                case ("TalkingActivator", CopyType.DeepCopy):
                case ("TalkingActivatorBinaryOverlay", CopyType.DeepCopy):
                    TalkingActivator newTalkingActivatorRecord = (TalkingActivator)Record.DeepCopy();
                    mod.TalkingActivators.Add(newTalkingActivatorRecord);
                    break;
                case ("Armor", CopyType.AsOverride):
                case ("ArmorBinaryOverlay", CopyType.AsOverride):
                    mod.Armors.GetOrAddAsOverride(Record);
                    break;
                case ("Armor", CopyType.AsNewRecord):
                case ("ArmorBinaryOverlay", CopyType.AsNewRecord):
                    mod.Armors.DuplicateInAsNewRecord(Record);
                    break;
                case ("Armor", CopyType.DeepCopy):
                case ("ArmorBinaryOverlay", CopyType.DeepCopy):
                    Armor newArmorRecord = (Armor)Record.DeepCopy();
                    mod.Armors.Add(newArmorRecord);
                    break;
                case ("Book", CopyType.AsOverride):
                case ("BookBinaryOverlay", CopyType.AsOverride):
                    mod.Books.GetOrAddAsOverride(Record);
                    break;
                case ("Book", CopyType.AsNewRecord):
                case ("BookBinaryOverlay", CopyType.AsNewRecord):
                    mod.Books.DuplicateInAsNewRecord(Record);
                    break;
                case ("Book", CopyType.DeepCopy):
                case ("BookBinaryOverlay", CopyType.DeepCopy):
                    Book newBookRecord = (Book)Record.DeepCopy();
                    mod.Books.Add(newBookRecord);
                    break;
                case ("Container", CopyType.AsOverride):
                case ("ContainerBinaryOverlay", CopyType.AsOverride):
                    mod.Containers.GetOrAddAsOverride(Record);
                    break;
                case ("Container", CopyType.AsNewRecord):
                case ("ContainerBinaryOverlay", CopyType.AsNewRecord):
                    mod.Containers.DuplicateInAsNewRecord(Record);
                    break;
                case ("Container", CopyType.DeepCopy):
                case ("ContainerBinaryOverlay", CopyType.DeepCopy):
                    Container newContainerRecord = (Container)Record.DeepCopy();
                    mod.Containers.Add(newContainerRecord);
                    break;
                case ("Door", CopyType.AsOverride):
                case ("DoorBinaryOverlay", CopyType.AsOverride):
                    mod.Doors.GetOrAddAsOverride(Record);
                    break;
                case ("Door", CopyType.AsNewRecord):
                case ("DoorBinaryOverlay", CopyType.AsNewRecord):
                    mod.Doors.DuplicateInAsNewRecord(Record);
                    break;
                case ("Door", CopyType.DeepCopy):
                case ("DoorBinaryOverlay", CopyType.DeepCopy):
                    Door newDoorRecord = (Door)Record.DeepCopy();
                    mod.Doors.Add(newDoorRecord);
                    break;
                case ("Ingredient", CopyType.AsOverride):
                case ("IngredientBinaryOverlay", CopyType.AsOverride):
                    mod.Ingredients.GetOrAddAsOverride(Record);
                    break;
                case ("Ingredient", CopyType.AsNewRecord):
                case ("IngredientBinaryOverlay", CopyType.AsNewRecord):
                    mod.Ingredients.DuplicateInAsNewRecord(Record);
                    break;
                case ("Ingredient", CopyType.DeepCopy):
                case ("IngredientBinaryOverlay", CopyType.DeepCopy):
                    Ingredient newIngredientRecord = (Ingredient)Record.DeepCopy();
                    mod.Ingredients.Add(newIngredientRecord);
                    break;
                case ("Light", CopyType.AsOverride):
                case ("LightBinaryOverlay", CopyType.AsOverride):
                    mod.Lights.GetOrAddAsOverride(Record);
                    break;
                case ("Light", CopyType.AsNewRecord):
                case ("LightBinaryOverlay", CopyType.AsNewRecord):
                    mod.Lights.DuplicateInAsNewRecord(Record);
                    break;
                case ("Light", CopyType.DeepCopy):
                case ("LightBinaryOverlay", CopyType.DeepCopy):
                    Light newLightRecord = (Light)Record.DeepCopy();
                    mod.Lights.Add(newLightRecord);
                    break;
                case ("MiscItem", CopyType.AsOverride):
                case ("MiscItemBinaryOverlay", CopyType.AsOverride):
                    mod.MiscItems.GetOrAddAsOverride(Record);
                    break;
                case ("MiscItem", CopyType.AsNewRecord):
                case ("MiscItemBinaryOverlay", CopyType.AsNewRecord):
                    mod.MiscItems.DuplicateInAsNewRecord(Record);
                    break;
                case ("MiscItem", CopyType.DeepCopy):
                case ("MiscItemBinaryOverlay", CopyType.DeepCopy):
                    MiscItem newMiscItemRecord = (MiscItem)Record.DeepCopy();
                    mod.MiscItems.Add(newMiscItemRecord);
                    break;
                case ("Static", CopyType.AsOverride):
                case ("StaticBinaryOverlay", CopyType.AsOverride):
                    mod.Statics.GetOrAddAsOverride(Record);
                    break;
                case ("Static", CopyType.AsNewRecord):
                case ("StaticBinaryOverlay", CopyType.AsNewRecord):
                    mod.Statics.DuplicateInAsNewRecord(Record);
                    break;
                case ("Static", CopyType.DeepCopy):
                case ("StaticBinaryOverlay", CopyType.DeepCopy):
                    Static newStaticRecord = (Static)Record.DeepCopy();
                    mod.Statics.Add(newStaticRecord);
                    break;
                case ("StaticCollection", CopyType.AsOverride):
                case ("StaticCollectionBinaryOverlay", CopyType.AsOverride):
                    mod.StaticCollections.GetOrAddAsOverride(Record);
                    break;
                case ("StaticCollection", CopyType.AsNewRecord):
                case ("StaticCollectionBinaryOverlay", CopyType.AsNewRecord):
                    mod.StaticCollections.DuplicateInAsNewRecord(Record);
                    break;
                case ("StaticCollection", CopyType.DeepCopy):
                case ("StaticCollectionBinaryOverlay", CopyType.DeepCopy):
                    StaticCollection newStaticCollectionRecord = (StaticCollection)Record.DeepCopy();
                    mod.StaticCollections.Add(newStaticCollectionRecord);
                    break;
                case ("MovableStatic", CopyType.AsOverride):
                case ("MovableStaticBinaryOverlay", CopyType.AsOverride):
                    mod.MovableStatics.GetOrAddAsOverride(Record);
                    break;
                case ("MovableStatic", CopyType.AsNewRecord):
                case ("MovableStaticBinaryOverlay", CopyType.AsNewRecord):
                    mod.MovableStatics.DuplicateInAsNewRecord(Record);
                    break;
                case ("MovableStatic", CopyType.DeepCopy):
                case ("MovableStaticBinaryOverlay", CopyType.DeepCopy):
                    MovableStatic newMovableStaticRecord = (MovableStatic)Record.DeepCopy();
                    mod.MovableStatics.Add(newMovableStaticRecord);
                    break;
                case ("Grass", CopyType.AsOverride):
                case ("GrassBinaryOverlay", CopyType.AsOverride):
                    mod.Grasses.GetOrAddAsOverride(Record);
                    break;
                case ("Grass", CopyType.AsNewRecord):
                case ("GrassBinaryOverlay", CopyType.AsNewRecord):
                    mod.Grasses.DuplicateInAsNewRecord(Record);
                    break;
                case ("Grass", CopyType.DeepCopy):
                case ("GrassBinaryOverlay", CopyType.DeepCopy):
                    Grass newGrassRecord = (Grass)Record.DeepCopy();
                    mod.Grasses.Add(newGrassRecord);
                    break;
                case ("Tree", CopyType.AsOverride):
                case ("TreeBinaryOverlay", CopyType.AsOverride):
                    mod.Trees.GetOrAddAsOverride(Record);
                    break;
                case ("Tree", CopyType.AsNewRecord):
                case ("TreeBinaryOverlay", CopyType.AsNewRecord):
                    mod.Trees.DuplicateInAsNewRecord(Record);
                    break;
                case ("Tree", CopyType.DeepCopy):
                case ("TreeBinaryOverlay", CopyType.DeepCopy):
                    Tree newTreeRecord = (Tree)Record.DeepCopy();
                    mod.Trees.Add(newTreeRecord);
                    break;
                case ("Flora", CopyType.AsOverride):
                case ("FloraBinaryOverlay", CopyType.AsOverride):
                    mod.Florae.GetOrAddAsOverride(Record);
                    break;
                case ("Flora", CopyType.AsNewRecord):
                case ("FloraBinaryOverlay", CopyType.AsNewRecord):
                    mod.Florae.DuplicateInAsNewRecord(Record);
                    break;
                case ("Flora", CopyType.DeepCopy):
                case ("FloraBinaryOverlay", CopyType.DeepCopy):
                    Flora newFloraRecord = (Flora)Record.DeepCopy();
                    mod.Florae.Add(newFloraRecord);
                    break;
                case ("Furniture", CopyType.AsOverride):
                case ("FurnitureBinaryOverlay", CopyType.AsOverride):
                    mod.Furniture.GetOrAddAsOverride(Record);
                    break;
                case ("Furniture", CopyType.AsNewRecord):
                case ("FurnitureBinaryOverlay", CopyType.AsNewRecord):
                    mod.Furniture.DuplicateInAsNewRecord(Record);
                    break;
                case ("Furniture", CopyType.DeepCopy):
                case ("FurnitureBinaryOverlay", CopyType.DeepCopy):
                    Furniture newFurnitureRecord = (Furniture)Record.DeepCopy();
                    mod.Furniture.Add(newFurnitureRecord);
                    break;
                case ("Weapon", CopyType.AsOverride):
                case ("WeaponBinaryOverlay", CopyType.AsOverride):
                    mod.Weapons.GetOrAddAsOverride(Record);
                    break;
                case ("Weapon", CopyType.AsNewRecord):
                case ("WeaponBinaryOverlay", CopyType.AsNewRecord):
                    mod.Weapons.DuplicateInAsNewRecord(Record);
                    break;
                case ("Weapon", CopyType.DeepCopy):
                case ("WeaponBinaryOverlay", CopyType.DeepCopy):
                    Weapon newWeaponRecord = (Weapon)Record.DeepCopy();
                    mod.Weapons.Add(newWeaponRecord);
                    break;
                case ("Ammunition", CopyType.AsOverride):
                case ("AmmunitionBinaryOverlay", CopyType.AsOverride):
                    mod.Ammunitions.GetOrAddAsOverride(Record);
                    break;
                case ("Ammunition", CopyType.AsNewRecord):
                case ("AmmunitionBinaryOverlay", CopyType.AsNewRecord):
                    mod.Ammunitions.DuplicateInAsNewRecord(Record);
                    break;
                case ("Ammunition", CopyType.DeepCopy):
                case ("AmmunitionBinaryOverlay", CopyType.DeepCopy):
                    Ammunition newAmmunitionRecord = (Ammunition)Record.DeepCopy();
                    mod.Ammunitions.Add(newAmmunitionRecord);
                    break;
                case ("Npc", CopyType.AsOverride):
                case ("NpcBinaryOverlay", CopyType.AsOverride):
                    mod.Npcs.GetOrAddAsOverride(Record);
                    break;
                case ("Npc", CopyType.AsNewRecord):
                case ("NpcBinaryOverlay", CopyType.AsNewRecord):
                    mod.Npcs.DuplicateInAsNewRecord(Record);
                    break;
                case ("Npc", CopyType.DeepCopy):
                case ("NpcBinaryOverlay", CopyType.DeepCopy):
                    Npc newNpcRecord = (Npc)Record.DeepCopy();
                    mod.Npcs.Add(newNpcRecord);
                    break;
                case ("LeveledNpc", CopyType.AsOverride):
                case ("LeveledNpcBinaryOverlay", CopyType.AsOverride):
                    mod.LeveledNpcs.GetOrAddAsOverride(Record);
                    break;
                case ("LeveledNpc", CopyType.AsNewRecord):
                case ("LeveledNpcBinaryOverlay", CopyType.AsNewRecord):
                    mod.LeveledNpcs.DuplicateInAsNewRecord(Record);
                    break;
                case ("LeveledNpc", CopyType.DeepCopy):
                case ("LeveledNpcBinaryOverlay", CopyType.DeepCopy):
                    LeveledNpc newLeveledNpcRecord = (LeveledNpc)Record.DeepCopy();
                    mod.LeveledNpcs.Add(newLeveledNpcRecord);
                    break;
                case ("Key", CopyType.AsOverride):
                case ("KeyBinaryOverlay", CopyType.AsOverride):
                    mod.Keys.GetOrAddAsOverride(Record);
                    break;
                case ("Key", CopyType.AsNewRecord):
                case ("KeyBinaryOverlay", CopyType.AsNewRecord):
                    mod.Keys.DuplicateInAsNewRecord(Record);
                    break;
                case ("Key", CopyType.DeepCopy):
                case ("KeyBinaryOverlay", CopyType.DeepCopy):
                    Key newKeyRecord = (Key)Record.DeepCopy();
                    mod.Keys.Add(newKeyRecord);
                    break;
                case ("Ingestible", CopyType.AsOverride):
                case ("IngestibleBinaryOverlay", CopyType.AsOverride):
                    mod.Ingestibles.GetOrAddAsOverride(Record);
                    break;
                case ("Ingestible", CopyType.AsNewRecord):
                case ("IngestibleBinaryOverlay", CopyType.AsNewRecord):
                    mod.Ingestibles.DuplicateInAsNewRecord(Record);
                    break;
                case ("Ingestible", CopyType.DeepCopy):
                case ("IngestibleBinaryOverlay", CopyType.DeepCopy):
                    Ingestible newIngestibleRecord = (Ingestible)Record.DeepCopy();
                    mod.Ingestibles.Add(newIngestibleRecord);
                    break;
                case ("IdleMarker", CopyType.AsOverride):
                case ("IdleMarkerBinaryOverlay", CopyType.AsOverride):
                    mod.IdleMarkers.GetOrAddAsOverride(Record);
                    break;
                case ("IdleMarker", CopyType.AsNewRecord):
                case ("IdleMarkerBinaryOverlay", CopyType.AsNewRecord):
                    mod.IdleMarkers.DuplicateInAsNewRecord(Record);
                    break;
                case ("IdleMarker", CopyType.DeepCopy):
                case ("IdleMarkerBinaryOverlay", CopyType.DeepCopy):
                    IdleMarker newIdleMarkerRecord = (IdleMarker)Record.DeepCopy();
                    mod.IdleMarkers.Add(newIdleMarkerRecord);
                    break;
                case ("Holotape", CopyType.AsOverride):
                case ("HolotapeBinaryOverlay", CopyType.AsOverride):
                    mod.Holotapes.GetOrAddAsOverride(Record);
                    break;
                case ("Holotape", CopyType.AsNewRecord):
                case ("HolotapeBinaryOverlay", CopyType.AsNewRecord):
                    mod.Holotapes.DuplicateInAsNewRecord(Record);
                    break;
                case ("Holotape", CopyType.DeepCopy):
                case ("HolotapeBinaryOverlay", CopyType.DeepCopy):
                    Holotape newHolotapeRecord = (Holotape)Record.DeepCopy();
                    mod.Holotapes.Add(newHolotapeRecord);
                    break;
                case ("Projectile", CopyType.AsOverride):
                case ("ProjectileBinaryOverlay", CopyType.AsOverride):
                    mod.Projectiles.GetOrAddAsOverride(Record);
                    break;
                case ("Projectile", CopyType.AsNewRecord):
                case ("ProjectileBinaryOverlay", CopyType.AsNewRecord):
                    mod.Projectiles.DuplicateInAsNewRecord(Record);
                    break;
                case ("Projectile", CopyType.DeepCopy):
                case ("ProjectileBinaryOverlay", CopyType.DeepCopy):
                    Projectile newProjectileRecord = (Projectile)Record.DeepCopy();
                    mod.Projectiles.Add(newProjectileRecord);
                    break;
                case ("Hazard", CopyType.AsOverride):
                case ("HazardBinaryOverlay", CopyType.AsOverride):
                    mod.Hazards.GetOrAddAsOverride(Record);
                    break;
                case ("Hazard", CopyType.AsNewRecord):
                case ("HazardBinaryOverlay", CopyType.AsNewRecord):
                    mod.Hazards.DuplicateInAsNewRecord(Record);
                    break;
                case ("Hazard", CopyType.DeepCopy):
                case ("HazardBinaryOverlay", CopyType.DeepCopy):
                    Hazard newHazardRecord = (Hazard)Record.DeepCopy();
                    mod.Hazards.Add(newHazardRecord);
                    break;
                case ("BendableSpline", CopyType.AsOverride):
                case ("BendableSplineBinaryOverlay", CopyType.AsOverride):
                    mod.BendableSplines.GetOrAddAsOverride(Record);
                    break;
                case ("BendableSpline", CopyType.AsNewRecord):
                case ("BendableSplineBinaryOverlay", CopyType.AsNewRecord):
                    mod.BendableSplines.DuplicateInAsNewRecord(Record);
                    break;
                case ("BendableSpline", CopyType.DeepCopy):
                case ("BendableSplineBinaryOverlay", CopyType.DeepCopy):
                    BendableSpline newBendableSplineRecord = (BendableSpline)Record.DeepCopy();
                    mod.BendableSplines.Add(newBendableSplineRecord);
                    break;
                case ("Terminal", CopyType.AsOverride):
                case ("TerminalBinaryOverlay", CopyType.AsOverride):
                    mod.Terminals.GetOrAddAsOverride(Record);
                    break;
                case ("Terminal", CopyType.AsNewRecord):
                case ("TerminalBinaryOverlay", CopyType.AsNewRecord):
                    mod.Terminals.DuplicateInAsNewRecord(Record);
                    break;
                case ("Terminal", CopyType.DeepCopy):
                case ("TerminalBinaryOverlay", CopyType.DeepCopy):
                    Terminal newTerminalRecord = (Terminal)Record.DeepCopy();
                    mod.Terminals.Add(newTerminalRecord);
                    break;
                case ("LeveledItem", CopyType.AsOverride):
                case ("LeveledItemBinaryOverlay", CopyType.AsOverride):
                    mod.LeveledItems.GetOrAddAsOverride(Record);
                    break;
                case ("LeveledItem", CopyType.AsNewRecord):
                case ("LeveledItemBinaryOverlay", CopyType.AsNewRecord):
                    mod.LeveledItems.DuplicateInAsNewRecord(Record);
                    break;
                case ("LeveledItem", CopyType.DeepCopy):
                case ("LeveledItemBinaryOverlay", CopyType.DeepCopy):
                    LeveledItem newLeveledItemRecord = (LeveledItem)Record.DeepCopy();
                    mod.LeveledItems.Add(newLeveledItemRecord);
                    break;
                case ("Weather", CopyType.AsOverride):
                case ("WeatherBinaryOverlay", CopyType.AsOverride):
                    mod.Weather.GetOrAddAsOverride(Record);
                    break;
                case ("Weather", CopyType.AsNewRecord):
                case ("WeatherBinaryOverlay", CopyType.AsNewRecord):
                    mod.Weather.DuplicateInAsNewRecord(Record);
                    break;
                case ("Weather", CopyType.DeepCopy):
                case ("WeatherBinaryOverlay", CopyType.DeepCopy):
                    Weather newWeatherRecord = (Weather)Record.DeepCopy();
                    mod.Weather.Add(newWeatherRecord);
                    break;
                case ("Climate", CopyType.AsOverride):
                case ("ClimateBinaryOverlay", CopyType.AsOverride):
                    mod.Climates.GetOrAddAsOverride(Record);
                    break;
                case ("Climate", CopyType.AsNewRecord):
                case ("ClimateBinaryOverlay", CopyType.AsNewRecord):
                    mod.Climates.DuplicateInAsNewRecord(Record);
                    break;
                case ("Climate", CopyType.DeepCopy):
                case ("ClimateBinaryOverlay", CopyType.DeepCopy):
                    Climate newClimateRecord = (Climate)Record.DeepCopy();
                    mod.Climates.Add(newClimateRecord);
                    break;
                case ("ShaderParticleGeometry", CopyType.AsOverride):
                case ("ShaderParticleGeometryBinaryOverlay", CopyType.AsOverride):
                    mod.ShaderParticleGeometries.GetOrAddAsOverride(Record);
                    break;
                case ("ShaderParticleGeometry", CopyType.AsNewRecord):
                case ("ShaderParticleGeometryBinaryOverlay", CopyType.AsNewRecord):
                    mod.ShaderParticleGeometries.DuplicateInAsNewRecord(Record);
                    break;
                case ("ShaderParticleGeometry", CopyType.DeepCopy):
                case ("ShaderParticleGeometryBinaryOverlay", CopyType.DeepCopy):
                    ShaderParticleGeometry newShaderParticleGeometryRecord = (ShaderParticleGeometry)Record.DeepCopy();
                    mod.ShaderParticleGeometries.Add(newShaderParticleGeometryRecord);
                    break;
                case ("VisualEffect", CopyType.AsOverride):
                case ("VisualEffectBinaryOverlay", CopyType.AsOverride):
                    mod.VisualEffects.GetOrAddAsOverride(Record);
                    break;
                case ("VisualEffect", CopyType.AsNewRecord):
                case ("VisualEffectBinaryOverlay", CopyType.AsNewRecord):
                    mod.VisualEffects.DuplicateInAsNewRecord(Record);
                    break;
                case ("VisualEffect", CopyType.DeepCopy):
                case ("VisualEffectBinaryOverlay", CopyType.DeepCopy):
                    VisualEffect newVisualEffectRecord = (VisualEffect)Record.DeepCopy();
                    mod.VisualEffects.Add(newVisualEffectRecord);
                    break;
                case ("Region", CopyType.AsOverride):
                case ("RegionBinaryOverlay", CopyType.AsOverride):
                    mod.Regions.GetOrAddAsOverride(Record);
                    break;
                case ("Region", CopyType.AsNewRecord):
                case ("RegionBinaryOverlay", CopyType.AsNewRecord):
                    mod.Regions.DuplicateInAsNewRecord(Record);
                    break;
                case ("Region", CopyType.DeepCopy):
                case ("RegionBinaryOverlay", CopyType.DeepCopy):
                    Region newRegionRecord = (Region)Record.DeepCopy();
                    mod.Regions.Add(newRegionRecord);
                    break;
                case ("NavigationMeshInfoMap", CopyType.AsOverride):
                case ("NavigationMeshInfoMapBinaryOverlay", CopyType.AsOverride):
                    mod.NavigationMeshInfoMaps.GetOrAddAsOverride(Record);
                    break;
                case ("NavigationMeshInfoMap", CopyType.AsNewRecord):
                case ("NavigationMeshInfoMapBinaryOverlay", CopyType.AsNewRecord):
                    mod.NavigationMeshInfoMaps.DuplicateInAsNewRecord(Record);
                    break;
                case ("NavigationMeshInfoMap", CopyType.DeepCopy):
                case ("NavigationMeshInfoMapBinaryOverlay", CopyType.DeepCopy):
                    NavigationMeshInfoMap newNavigationMeshInfoMapRecord = (NavigationMeshInfoMap)Record.DeepCopy();
                    mod.NavigationMeshInfoMaps.Add(newNavigationMeshInfoMapRecord);
                    break;
                case ("Worldspace", CopyType.AsOverride):
                case ("WorldspaceBinaryOverlay", CopyType.AsOverride):
                    mod.Worldspaces.GetOrAddAsOverride(Record);
                    break;
                case ("Worldspace", CopyType.AsNewRecord):
                case ("WorldspaceBinaryOverlay", CopyType.AsNewRecord):
                    mod.Worldspaces.DuplicateInAsNewRecord(Record);
                    break;
                case ("Worldspace", CopyType.DeepCopy):
                case ("WorldspaceBinaryOverlay", CopyType.DeepCopy):
                    Worldspace newWorldspaceRecord = (Worldspace)Record.DeepCopy();
                    mod.Worldspaces.Add(newWorldspaceRecord);
                    break;
                case ("Quest", CopyType.AsOverride):
                case ("QuestBinaryOverlay", CopyType.AsOverride):
                    mod.Quests.GetOrAddAsOverride(Record);
                    break;
                case ("Quest", CopyType.AsNewRecord):
                case ("QuestBinaryOverlay", CopyType.AsNewRecord):
                    mod.Quests.DuplicateInAsNewRecord(Record);
                    break;
                case ("Quest", CopyType.DeepCopy):
                case ("QuestBinaryOverlay", CopyType.DeepCopy):
                    Quest newQuestRecord = (Quest)Record.DeepCopy();
                    mod.Quests.Add(newQuestRecord);
                    break;
                case ("IdleAnimation", CopyType.AsOverride):
                case ("IdleAnimationBinaryOverlay", CopyType.AsOverride):
                    mod.IdleAnimations.GetOrAddAsOverride(Record);
                    break;
                case ("IdleAnimation", CopyType.AsNewRecord):
                case ("IdleAnimationBinaryOverlay", CopyType.AsNewRecord):
                    mod.IdleAnimations.DuplicateInAsNewRecord(Record);
                    break;
                case ("IdleAnimation", CopyType.DeepCopy):
                case ("IdleAnimationBinaryOverlay", CopyType.DeepCopy):
                    IdleAnimation newIdleAnimationRecord = (IdleAnimation)Record.DeepCopy();
                    mod.IdleAnimations.Add(newIdleAnimationRecord);
                    break;
                case ("Package", CopyType.AsOverride):
                case ("PackageBinaryOverlay", CopyType.AsOverride):
                    mod.Packages.GetOrAddAsOverride(Record);
                    break;
                case ("Package", CopyType.AsNewRecord):
                case ("PackageBinaryOverlay", CopyType.AsNewRecord):
                    mod.Packages.DuplicateInAsNewRecord(Record);
                    break;
                case ("Package", CopyType.DeepCopy):
                case ("PackageBinaryOverlay", CopyType.DeepCopy):
                    Package newPackageRecord = (Package)Record.DeepCopy();
                    mod.Packages.Add(newPackageRecord);
                    break;
                case ("CombatStyle", CopyType.AsOverride):
                case ("CombatStyleBinaryOverlay", CopyType.AsOverride):
                    mod.CombatStyles.GetOrAddAsOverride(Record);
                    break;
                case ("CombatStyle", CopyType.AsNewRecord):
                case ("CombatStyleBinaryOverlay", CopyType.AsNewRecord):
                    mod.CombatStyles.DuplicateInAsNewRecord(Record);
                    break;
                case ("CombatStyle", CopyType.DeepCopy):
                case ("CombatStyleBinaryOverlay", CopyType.DeepCopy):
                    CombatStyle newCombatStyleRecord = (CombatStyle)Record.DeepCopy();
                    mod.CombatStyles.Add(newCombatStyleRecord);
                    break;
                case ("LoadScreen", CopyType.AsOverride):
                case ("LoadScreenBinaryOverlay", CopyType.AsOverride):
                    mod.LoadScreens.GetOrAddAsOverride(Record);
                    break;
                case ("LoadScreen", CopyType.AsNewRecord):
                case ("LoadScreenBinaryOverlay", CopyType.AsNewRecord):
                    mod.LoadScreens.DuplicateInAsNewRecord(Record);
                    break;
                case ("LoadScreen", CopyType.DeepCopy):
                case ("LoadScreenBinaryOverlay", CopyType.DeepCopy):
                    LoadScreen newLoadScreenRecord = (LoadScreen)Record.DeepCopy();
                    mod.LoadScreens.Add(newLoadScreenRecord);
                    break;
                case ("AnimatedObject", CopyType.AsOverride):
                case ("AnimatedObjectBinaryOverlay", CopyType.AsOverride):
                    mod.AnimatedObjects.GetOrAddAsOverride(Record);
                    break;
                case ("AnimatedObject", CopyType.AsNewRecord):
                case ("AnimatedObjectBinaryOverlay", CopyType.AsNewRecord):
                    mod.AnimatedObjects.DuplicateInAsNewRecord(Record);
                    break;
                case ("AnimatedObject", CopyType.DeepCopy):
                case ("AnimatedObjectBinaryOverlay", CopyType.DeepCopy):
                    AnimatedObject newAnimatedObjectRecord = (AnimatedObject)Record.DeepCopy();
                    mod.AnimatedObjects.Add(newAnimatedObjectRecord);
                    break;
                case ("Water", CopyType.AsOverride):
                case ("WaterBinaryOverlay", CopyType.AsOverride):
                    mod.Waters.GetOrAddAsOverride(Record);
                    break;
                case ("Water", CopyType.AsNewRecord):
                case ("WaterBinaryOverlay", CopyType.AsNewRecord):
                    mod.Waters.DuplicateInAsNewRecord(Record);
                    break;
                case ("Water", CopyType.DeepCopy):
                case ("WaterBinaryOverlay", CopyType.DeepCopy):
                    Water newWaterRecord = (Water)Record.DeepCopy();
                    mod.Waters.Add(newWaterRecord);
                    break;
                case ("EffectShader", CopyType.AsOverride):
                case ("EffectShaderBinaryOverlay", CopyType.AsOverride):
                    mod.EffectShaders.GetOrAddAsOverride(Record);
                    break;
                case ("EffectShader", CopyType.AsNewRecord):
                case ("EffectShaderBinaryOverlay", CopyType.AsNewRecord):
                    mod.EffectShaders.DuplicateInAsNewRecord(Record);
                    break;
                case ("EffectShader", CopyType.DeepCopy):
                case ("EffectShaderBinaryOverlay", CopyType.DeepCopy):
                    EffectShader newEffectShaderRecord = (EffectShader)Record.DeepCopy();
                    mod.EffectShaders.Add(newEffectShaderRecord);
                    break;
                case ("Explosion", CopyType.AsOverride):
                case ("ExplosionBinaryOverlay", CopyType.AsOverride):
                    mod.Explosions.GetOrAddAsOverride(Record);
                    break;
                case ("Explosion", CopyType.AsNewRecord):
                case ("ExplosionBinaryOverlay", CopyType.AsNewRecord):
                    mod.Explosions.DuplicateInAsNewRecord(Record);
                    break;
                case ("Explosion", CopyType.DeepCopy):
                case ("ExplosionBinaryOverlay", CopyType.DeepCopy):
                    Explosion newExplosionRecord = (Explosion)Record.DeepCopy();
                    mod.Explosions.Add(newExplosionRecord);
                    break;
                case ("Debris", CopyType.AsOverride):
                case ("DebrisBinaryOverlay", CopyType.AsOverride):
                    mod.Debris.GetOrAddAsOverride(Record);
                    break;
                case ("Debris", CopyType.AsNewRecord):
                case ("DebrisBinaryOverlay", CopyType.AsNewRecord):
                    mod.Debris.DuplicateInAsNewRecord(Record);
                    break;
                case ("Debris", CopyType.DeepCopy):
                case ("DebrisBinaryOverlay", CopyType.DeepCopy):
                    Debris newDebrisRecord = (Debris)Record.DeepCopy();
                    mod.Debris.Add(newDebrisRecord);
                    break;
                case ("ImageSpace", CopyType.AsOverride):
                case ("ImageSpaceBinaryOverlay", CopyType.AsOverride):
                    mod.ImageSpaces.GetOrAddAsOverride(Record);
                    break;
                case ("ImageSpace", CopyType.AsNewRecord):
                case ("ImageSpaceBinaryOverlay", CopyType.AsNewRecord):
                    mod.ImageSpaces.DuplicateInAsNewRecord(Record);
                    break;
                case ("ImageSpace", CopyType.DeepCopy):
                case ("ImageSpaceBinaryOverlay", CopyType.DeepCopy):
                    ImageSpace newImageSpaceRecord = (ImageSpace)Record.DeepCopy();
                    mod.ImageSpaces.Add(newImageSpaceRecord);
                    break;
                case ("ImageSpaceAdapter", CopyType.AsOverride):
                case ("ImageSpaceAdapterBinaryOverlay", CopyType.AsOverride):
                    mod.ImageSpaceAdapters.GetOrAddAsOverride(Record);
                    break;
                case ("ImageSpaceAdapter", CopyType.AsNewRecord):
                case ("ImageSpaceAdapterBinaryOverlay", CopyType.AsNewRecord):
                    mod.ImageSpaceAdapters.DuplicateInAsNewRecord(Record);
                    break;
                case ("ImageSpaceAdapter", CopyType.DeepCopy):
                case ("ImageSpaceAdapterBinaryOverlay", CopyType.DeepCopy):
                    ImageSpaceAdapter newImageSpaceAdapterRecord = (ImageSpaceAdapter)Record.DeepCopy();
                    mod.ImageSpaceAdapters.Add(newImageSpaceAdapterRecord);
                    break;
                case ("FormList", CopyType.AsOverride):
                case ("FormListBinaryOverlay", CopyType.AsOverride):
                    mod.FormLists.GetOrAddAsOverride(Record);
                    break;
                case ("FormList", CopyType.AsNewRecord):
                case ("FormListBinaryOverlay", CopyType.AsNewRecord):
                    mod.FormLists.DuplicateInAsNewRecord(Record);
                    break;
                case ("FormList", CopyType.DeepCopy):
                case ("FormListBinaryOverlay", CopyType.DeepCopy):
                    FormList newFormListRecord = (FormList)Record.DeepCopy();
                    mod.FormLists.Add(newFormListRecord);
                    break;
                case ("Perk", CopyType.AsOverride):
                case ("PerkBinaryOverlay", CopyType.AsOverride):
                    mod.Perks.GetOrAddAsOverride(Record);
                    break;
                case ("Perk", CopyType.AsNewRecord):
                case ("PerkBinaryOverlay", CopyType.AsNewRecord):
                    mod.Perks.DuplicateInAsNewRecord(Record);
                    break;
                case ("Perk", CopyType.DeepCopy):
                case ("PerkBinaryOverlay", CopyType.DeepCopy):
                    Perk newPerkRecord = (Perk)Record.DeepCopy();
                    mod.Perks.Add(newPerkRecord);
                    break;
                case ("BodyPartData", CopyType.AsOverride):
                case ("BodyPartDataBinaryOverlay", CopyType.AsOverride):
                    mod.BodyParts.GetOrAddAsOverride(Record);
                    break;
                case ("BodyPartData", CopyType.AsNewRecord):
                case ("BodyPartDataBinaryOverlay", CopyType.AsNewRecord):
                    mod.BodyParts.DuplicateInAsNewRecord(Record);
                    break;
                case ("BodyPartData", CopyType.DeepCopy):
                case ("BodyPartDataBinaryOverlay", CopyType.DeepCopy):
                    BodyPartData newBodyPartDataRecord = (BodyPartData)Record.DeepCopy();
                    mod.BodyParts.Add(newBodyPartDataRecord);
                    break;
                case ("AddonNode", CopyType.AsOverride):
                case ("AddonNodeBinaryOverlay", CopyType.AsOverride):
                    mod.AddonNodes.GetOrAddAsOverride(Record);
                    break;
                case ("AddonNode", CopyType.AsNewRecord):
                case ("AddonNodeBinaryOverlay", CopyType.AsNewRecord):
                    mod.AddonNodes.DuplicateInAsNewRecord(Record);
                    break;
                case ("AddonNode", CopyType.DeepCopy):
                case ("AddonNodeBinaryOverlay", CopyType.DeepCopy):
                    AddonNode newAddonNodeRecord = (AddonNode)Record.DeepCopy();
                    mod.AddonNodes.Add(newAddonNodeRecord);
                    break;
                case ("ActorValueInformation", CopyType.AsOverride):
                case ("ActorValueInformationBinaryOverlay", CopyType.AsOverride):
                    mod.ActorValueInformation.GetOrAddAsOverride(Record);
                    break;
                case ("ActorValueInformation", CopyType.AsNewRecord):
                case ("ActorValueInformationBinaryOverlay", CopyType.AsNewRecord):
                    mod.ActorValueInformation.DuplicateInAsNewRecord(Record);
                    break;
                case ("ActorValueInformation", CopyType.DeepCopy):
                case ("ActorValueInformationBinaryOverlay", CopyType.DeepCopy):
                    ActorValueInformation newActorValueInformationRecord = (ActorValueInformation)Record.DeepCopy();
                    mod.ActorValueInformation.Add(newActorValueInformationRecord);
                    break;
                case ("CameraShot", CopyType.AsOverride):
                case ("CameraShotBinaryOverlay", CopyType.AsOverride):
                    mod.CameraShots.GetOrAddAsOverride(Record);
                    break;
                case ("CameraShot", CopyType.AsNewRecord):
                case ("CameraShotBinaryOverlay", CopyType.AsNewRecord):
                    mod.CameraShots.DuplicateInAsNewRecord(Record);
                    break;
                case ("CameraShot", CopyType.DeepCopy):
                case ("CameraShotBinaryOverlay", CopyType.DeepCopy):
                    CameraShot newCameraShotRecord = (CameraShot)Record.DeepCopy();
                    mod.CameraShots.Add(newCameraShotRecord);
                    break;
                case ("CameraPath", CopyType.AsOverride):
                case ("CameraPathBinaryOverlay", CopyType.AsOverride):
                    mod.CameraPaths.GetOrAddAsOverride(Record);
                    break;
                case ("CameraPath", CopyType.AsNewRecord):
                case ("CameraPathBinaryOverlay", CopyType.AsNewRecord):
                    mod.CameraPaths.DuplicateInAsNewRecord(Record);
                    break;
                case ("CameraPath", CopyType.DeepCopy):
                case ("CameraPathBinaryOverlay", CopyType.DeepCopy):
                    CameraPath newCameraPathRecord = (CameraPath)Record.DeepCopy();
                    mod.CameraPaths.Add(newCameraPathRecord);
                    break;
                case ("VoiceType", CopyType.AsOverride):
                case ("VoiceTypeBinaryOverlay", CopyType.AsOverride):
                    mod.VoiceTypes.GetOrAddAsOverride(Record);
                    break;
                case ("VoiceType", CopyType.AsNewRecord):
                case ("VoiceTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.VoiceTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("VoiceType", CopyType.DeepCopy):
                case ("VoiceTypeBinaryOverlay", CopyType.DeepCopy):
                    VoiceType newVoiceTypeRecord = (VoiceType)Record.DeepCopy();
                    mod.VoiceTypes.Add(newVoiceTypeRecord);
                    break;
                case ("MaterialType", CopyType.AsOverride):
                case ("MaterialTypeBinaryOverlay", CopyType.AsOverride):
                    mod.MaterialTypes.GetOrAddAsOverride(Record);
                    break;
                case ("MaterialType", CopyType.AsNewRecord):
                case ("MaterialTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.MaterialTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("MaterialType", CopyType.DeepCopy):
                case ("MaterialTypeBinaryOverlay", CopyType.DeepCopy):
                    MaterialType newMaterialTypeRecord = (MaterialType)Record.DeepCopy();
                    mod.MaterialTypes.Add(newMaterialTypeRecord);
                    break;
                case ("Impact", CopyType.AsOverride):
                case ("ImpactBinaryOverlay", CopyType.AsOverride):
                    mod.Impacts.GetOrAddAsOverride(Record);
                    break;
                case ("Impact", CopyType.AsNewRecord):
                case ("ImpactBinaryOverlay", CopyType.AsNewRecord):
                    mod.Impacts.DuplicateInAsNewRecord(Record);
                    break;
                case ("Impact", CopyType.DeepCopy):
                case ("ImpactBinaryOverlay", CopyType.DeepCopy):
                    Impact newImpactRecord = (Impact)Record.DeepCopy();
                    mod.Impacts.Add(newImpactRecord);
                    break;
                case ("ImpactDataSet", CopyType.AsOverride):
                case ("ImpactDataSetBinaryOverlay", CopyType.AsOverride):
                    mod.ImpactDataSets.GetOrAddAsOverride(Record);
                    break;
                case ("ImpactDataSet", CopyType.AsNewRecord):
                case ("ImpactDataSetBinaryOverlay", CopyType.AsNewRecord):
                    mod.ImpactDataSets.DuplicateInAsNewRecord(Record);
                    break;
                case ("ImpactDataSet", CopyType.DeepCopy):
                case ("ImpactDataSetBinaryOverlay", CopyType.DeepCopy):
                    ImpactDataSet newImpactDataSetRecord = (ImpactDataSet)Record.DeepCopy();
                    mod.ImpactDataSets.Add(newImpactDataSetRecord);
                    break;
                case ("ArmorAddon", CopyType.AsOverride):
                case ("ArmorAddonBinaryOverlay", CopyType.AsOverride):
                    mod.ArmorAddons.GetOrAddAsOverride(Record);
                    break;
                case ("ArmorAddon", CopyType.AsNewRecord):
                case ("ArmorAddonBinaryOverlay", CopyType.AsNewRecord):
                    mod.ArmorAddons.DuplicateInAsNewRecord(Record);
                    break;
                case ("ArmorAddon", CopyType.DeepCopy):
                case ("ArmorAddonBinaryOverlay", CopyType.DeepCopy):
                    ArmorAddon newArmorAddonRecord = (ArmorAddon)Record.DeepCopy();
                    mod.ArmorAddons.Add(newArmorAddonRecord);
                    break;
                case ("EncounterZone", CopyType.AsOverride):
                case ("EncounterZoneBinaryOverlay", CopyType.AsOverride):
                    mod.EncounterZones.GetOrAddAsOverride(Record);
                    break;
                case ("EncounterZone", CopyType.AsNewRecord):
                case ("EncounterZoneBinaryOverlay", CopyType.AsNewRecord):
                    mod.EncounterZones.DuplicateInAsNewRecord(Record);
                    break;
                case ("EncounterZone", CopyType.DeepCopy):
                case ("EncounterZoneBinaryOverlay", CopyType.DeepCopy):
                    EncounterZone newEncounterZoneRecord = (EncounterZone)Record.DeepCopy();
                    mod.EncounterZones.Add(newEncounterZoneRecord);
                    break;
                case ("Location", CopyType.AsOverride):
                case ("LocationBinaryOverlay", CopyType.AsOverride):
                    mod.Locations.GetOrAddAsOverride(Record);
                    break;
                case ("Location", CopyType.AsNewRecord):
                case ("LocationBinaryOverlay", CopyType.AsNewRecord):
                    mod.Locations.DuplicateInAsNewRecord(Record);
                    break;
                case ("Location", CopyType.DeepCopy):
                case ("LocationBinaryOverlay", CopyType.DeepCopy):
                    Location newLocationRecord = (Location)Record.DeepCopy();
                    mod.Locations.Add(newLocationRecord);
                    break;
                case ("Message", CopyType.AsOverride):
                case ("MessageBinaryOverlay", CopyType.AsOverride):
                    mod.Messages.GetOrAddAsOverride(Record);
                    break;
                case ("Message", CopyType.AsNewRecord):
                case ("MessageBinaryOverlay", CopyType.AsNewRecord):
                    mod.Messages.DuplicateInAsNewRecord(Record);
                    break;
                case ("Message", CopyType.DeepCopy):
                case ("MessageBinaryOverlay", CopyType.DeepCopy):
                    Message newMessageRecord = (Message)Record.DeepCopy();
                    mod.Messages.Add(newMessageRecord);
                    break;
                case ("DefaultObjectManager", CopyType.AsOverride):
                case ("DefaultObjectManagerBinaryOverlay", CopyType.AsOverride):
                    mod.DefaultObjectManagers.GetOrAddAsOverride(Record);
                    break;
                case ("DefaultObjectManager", CopyType.AsNewRecord):
                case ("DefaultObjectManagerBinaryOverlay", CopyType.AsNewRecord):
                    mod.DefaultObjectManagers.DuplicateInAsNewRecord(Record);
                    break;
                case ("DefaultObjectManager", CopyType.DeepCopy):
                case ("DefaultObjectManagerBinaryOverlay", CopyType.DeepCopy):
                    DefaultObjectManager newDefaultObjectManagerRecord = (DefaultObjectManager)Record.DeepCopy();
                    mod.DefaultObjectManagers.Add(newDefaultObjectManagerRecord);
                    break;
                case ("DefaultObject", CopyType.AsOverride):
                case ("DefaultObjectBinaryOverlay", CopyType.AsOverride):
                    mod.DefaultObjects.GetOrAddAsOverride(Record);
                    break;
                case ("DefaultObject", CopyType.AsNewRecord):
                case ("DefaultObjectBinaryOverlay", CopyType.AsNewRecord):
                    mod.DefaultObjects.DuplicateInAsNewRecord(Record);
                    break;
                case ("DefaultObject", CopyType.DeepCopy):
                case ("DefaultObjectBinaryOverlay", CopyType.DeepCopy):
                    DefaultObject newDefaultObjectRecord = (DefaultObject)Record.DeepCopy();
                    mod.DefaultObjects.Add(newDefaultObjectRecord);
                    break;
                case ("LightingTemplate", CopyType.AsOverride):
                case ("LightingTemplateBinaryOverlay", CopyType.AsOverride):
                    mod.LightingTemplates.GetOrAddAsOverride(Record);
                    break;
                case ("LightingTemplate", CopyType.AsNewRecord):
                case ("LightingTemplateBinaryOverlay", CopyType.AsNewRecord):
                    mod.LightingTemplates.DuplicateInAsNewRecord(Record);
                    break;
                case ("LightingTemplate", CopyType.DeepCopy):
                case ("LightingTemplateBinaryOverlay", CopyType.DeepCopy):
                    LightingTemplate newLightingTemplateRecord = (LightingTemplate)Record.DeepCopy();
                    mod.LightingTemplates.Add(newLightingTemplateRecord);
                    break;
                case ("MusicType", CopyType.AsOverride):
                case ("MusicTypeBinaryOverlay", CopyType.AsOverride):
                    mod.MusicTypes.GetOrAddAsOverride(Record);
                    break;
                case ("MusicType", CopyType.AsNewRecord):
                case ("MusicTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.MusicTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("MusicType", CopyType.DeepCopy):
                case ("MusicTypeBinaryOverlay", CopyType.DeepCopy):
                    MusicType newMusicTypeRecord = (MusicType)Record.DeepCopy();
                    mod.MusicTypes.Add(newMusicTypeRecord);
                    break;
                case ("Footstep", CopyType.AsOverride):
                case ("FootstepBinaryOverlay", CopyType.AsOverride):
                    mod.Footsteps.GetOrAddAsOverride(Record);
                    break;
                case ("Footstep", CopyType.AsNewRecord):
                case ("FootstepBinaryOverlay", CopyType.AsNewRecord):
                    mod.Footsteps.DuplicateInAsNewRecord(Record);
                    break;
                case ("Footstep", CopyType.DeepCopy):
                case ("FootstepBinaryOverlay", CopyType.DeepCopy):
                    Footstep newFootstepRecord = (Footstep)Record.DeepCopy();
                    mod.Footsteps.Add(newFootstepRecord);
                    break;
                case ("FootstepSet", CopyType.AsOverride):
                case ("FootstepSetBinaryOverlay", CopyType.AsOverride):
                    mod.FootstepSets.GetOrAddAsOverride(Record);
                    break;
                case ("FootstepSet", CopyType.AsNewRecord):
                case ("FootstepSetBinaryOverlay", CopyType.AsNewRecord):
                    mod.FootstepSets.DuplicateInAsNewRecord(Record);
                    break;
                case ("FootstepSet", CopyType.DeepCopy):
                case ("FootstepSetBinaryOverlay", CopyType.DeepCopy):
                    FootstepSet newFootstepSetRecord = (FootstepSet)Record.DeepCopy();
                    mod.FootstepSets.Add(newFootstepSetRecord);
                    break;
                case ("StoryManagerBranchNode", CopyType.AsOverride):
                case ("StoryManagerBranchNodeBinaryOverlay", CopyType.AsOverride):
                    mod.StoryManagerBranchNodes.GetOrAddAsOverride(Record);
                    break;
                case ("StoryManagerBranchNode", CopyType.AsNewRecord):
                case ("StoryManagerBranchNodeBinaryOverlay", CopyType.AsNewRecord):
                    mod.StoryManagerBranchNodes.DuplicateInAsNewRecord(Record);
                    break;
                case ("StoryManagerBranchNode", CopyType.DeepCopy):
                case ("StoryManagerBranchNodeBinaryOverlay", CopyType.DeepCopy):
                    StoryManagerBranchNode newStoryManagerBranchNodeRecord = (StoryManagerBranchNode)Record.DeepCopy();
                    mod.StoryManagerBranchNodes.Add(newStoryManagerBranchNodeRecord);
                    break;
                case ("StoryManagerQuestNode", CopyType.AsOverride):
                case ("StoryManagerQuestNodeBinaryOverlay", CopyType.AsOverride):
                    mod.StoryManagerQuestNodes.GetOrAddAsOverride(Record);
                    break;
                case ("StoryManagerQuestNode", CopyType.AsNewRecord):
                case ("StoryManagerQuestNodeBinaryOverlay", CopyType.AsNewRecord):
                    mod.StoryManagerQuestNodes.DuplicateInAsNewRecord(Record);
                    break;
                case ("StoryManagerQuestNode", CopyType.DeepCopy):
                case ("StoryManagerQuestNodeBinaryOverlay", CopyType.DeepCopy):
                    StoryManagerQuestNode newStoryManagerQuestNodeRecord = (StoryManagerQuestNode)Record.DeepCopy();
                    mod.StoryManagerQuestNodes.Add(newStoryManagerQuestNodeRecord);
                    break;
                case ("StoryManagerEventNode", CopyType.AsOverride):
                case ("StoryManagerEventNodeBinaryOverlay", CopyType.AsOverride):
                    mod.StoryManagerEventNodes.GetOrAddAsOverride(Record);
                    break;
                case ("StoryManagerEventNode", CopyType.AsNewRecord):
                case ("StoryManagerEventNodeBinaryOverlay", CopyType.AsNewRecord):
                    mod.StoryManagerEventNodes.DuplicateInAsNewRecord(Record);
                    break;
                case ("StoryManagerEventNode", CopyType.DeepCopy):
                case ("StoryManagerEventNodeBinaryOverlay", CopyType.DeepCopy):
                    StoryManagerEventNode newStoryManagerEventNodeRecord = (StoryManagerEventNode)Record.DeepCopy();
                    mod.StoryManagerEventNodes.Add(newStoryManagerEventNodeRecord);
                    break;
                case ("MusicTrack", CopyType.AsOverride):
                case ("MusicTrackBinaryOverlay", CopyType.AsOverride):
                    mod.MusicTracks.GetOrAddAsOverride(Record);
                    break;
                case ("MusicTrack", CopyType.AsNewRecord):
                case ("MusicTrackBinaryOverlay", CopyType.AsNewRecord):
                    mod.MusicTracks.DuplicateInAsNewRecord(Record);
                    break;
                case ("MusicTrack", CopyType.DeepCopy):
                case ("MusicTrackBinaryOverlay", CopyType.DeepCopy):
                    MusicTrack newMusicTrackRecord = (MusicTrack)Record.DeepCopy();
                    mod.MusicTracks.Add(newMusicTrackRecord);
                    break;
                case ("DialogView", CopyType.AsOverride):
                case ("DialogViewBinaryOverlay", CopyType.AsOverride):
                    mod.DialogViews.GetOrAddAsOverride(Record);
                    break;
                case ("DialogView", CopyType.AsNewRecord):
                case ("DialogViewBinaryOverlay", CopyType.AsNewRecord):
                    mod.DialogViews.DuplicateInAsNewRecord(Record);
                    break;
                case ("DialogView", CopyType.DeepCopy):
                case ("DialogViewBinaryOverlay", CopyType.DeepCopy):
                    DialogView newDialogViewRecord = (DialogView)Record.DeepCopy();
                    mod.DialogViews.Add(newDialogViewRecord);
                    break;
                case ("EquipType", CopyType.AsOverride):
                case ("EquipTypeBinaryOverlay", CopyType.AsOverride):
                    mod.EquipTypes.GetOrAddAsOverride(Record);
                    break;
                case ("EquipType", CopyType.AsNewRecord):
                case ("EquipTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.EquipTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("EquipType", CopyType.DeepCopy):
                case ("EquipTypeBinaryOverlay", CopyType.DeepCopy):
                    EquipType newEquipTypeRecord = (EquipType)Record.DeepCopy();
                    mod.EquipTypes.Add(newEquipTypeRecord);
                    break;
                case ("Relationship", CopyType.AsOverride):
                case ("RelationshipBinaryOverlay", CopyType.AsOverride):
                    mod.Relationships.GetOrAddAsOverride(Record);
                    break;
                case ("Relationship", CopyType.AsNewRecord):
                case ("RelationshipBinaryOverlay", CopyType.AsNewRecord):
                    mod.Relationships.DuplicateInAsNewRecord(Record);
                    break;
                case ("Relationship", CopyType.DeepCopy):
                case ("RelationshipBinaryOverlay", CopyType.DeepCopy):
                    Relationship newRelationshipRecord = (Relationship)Record.DeepCopy();
                    mod.Relationships.Add(newRelationshipRecord);
                    break;
                case ("AssociationType", CopyType.AsOverride):
                case ("AssociationTypeBinaryOverlay", CopyType.AsOverride):
                    mod.AssociationTypes.GetOrAddAsOverride(Record);
                    break;
                case ("AssociationType", CopyType.AsNewRecord):
                case ("AssociationTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.AssociationTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("AssociationType", CopyType.DeepCopy):
                case ("AssociationTypeBinaryOverlay", CopyType.DeepCopy):
                    AssociationType newAssociationTypeRecord = (AssociationType)Record.DeepCopy();
                    mod.AssociationTypes.Add(newAssociationTypeRecord);
                    break;
                case ("Outfit", CopyType.AsOverride):
                case ("OutfitBinaryOverlay", CopyType.AsOverride):
                    mod.Outfits.GetOrAddAsOverride(Record);
                    break;
                case ("Outfit", CopyType.AsNewRecord):
                case ("OutfitBinaryOverlay", CopyType.AsNewRecord):
                    mod.Outfits.DuplicateInAsNewRecord(Record);
                    break;
                case ("Outfit", CopyType.DeepCopy):
                case ("OutfitBinaryOverlay", CopyType.DeepCopy):
                    Outfit newOutfitRecord = (Outfit)Record.DeepCopy();
                    mod.Outfits.Add(newOutfitRecord);
                    break;
                case ("ArtObject", CopyType.AsOverride):
                case ("ArtObjectBinaryOverlay", CopyType.AsOverride):
                    mod.ArtObjects.GetOrAddAsOverride(Record);
                    break;
                case ("ArtObject", CopyType.AsNewRecord):
                case ("ArtObjectBinaryOverlay", CopyType.AsNewRecord):
                    mod.ArtObjects.DuplicateInAsNewRecord(Record);
                    break;
                case ("ArtObject", CopyType.DeepCopy):
                case ("ArtObjectBinaryOverlay", CopyType.DeepCopy):
                    ArtObject newArtObjectRecord = (ArtObject)Record.DeepCopy();
                    mod.ArtObjects.Add(newArtObjectRecord);
                    break;
                case ("MaterialObject", CopyType.AsOverride):
                case ("MaterialObjectBinaryOverlay", CopyType.AsOverride):
                    mod.MaterialObjects.GetOrAddAsOverride(Record);
                    break;
                case ("MaterialObject", CopyType.AsNewRecord):
                case ("MaterialObjectBinaryOverlay", CopyType.AsNewRecord):
                    mod.MaterialObjects.DuplicateInAsNewRecord(Record);
                    break;
                case ("MaterialObject", CopyType.DeepCopy):
                case ("MaterialObjectBinaryOverlay", CopyType.DeepCopy):
                    MaterialObject newMaterialObjectRecord = (MaterialObject)Record.DeepCopy();
                    mod.MaterialObjects.Add(newMaterialObjectRecord);
                    break;
                case ("MovementType", CopyType.AsOverride):
                case ("MovementTypeBinaryOverlay", CopyType.AsOverride):
                    mod.MovementTypes.GetOrAddAsOverride(Record);
                    break;
                case ("MovementType", CopyType.AsNewRecord):
                case ("MovementTypeBinaryOverlay", CopyType.AsNewRecord):
                    mod.MovementTypes.DuplicateInAsNewRecord(Record);
                    break;
                case ("MovementType", CopyType.DeepCopy):
                case ("MovementTypeBinaryOverlay", CopyType.DeepCopy):
                    MovementType newMovementTypeRecord = (MovementType)Record.DeepCopy();
                    mod.MovementTypes.Add(newMovementTypeRecord);
                    break;
                case ("SoundDescriptor", CopyType.AsOverride):
                case ("SoundDescriptorBinaryOverlay", CopyType.AsOverride):
                    mod.SoundDescriptors.GetOrAddAsOverride(Record);
                    break;
                case ("SoundDescriptor", CopyType.AsNewRecord):
                case ("SoundDescriptorBinaryOverlay", CopyType.AsNewRecord):
                    mod.SoundDescriptors.DuplicateInAsNewRecord(Record);
                    break;
                case ("SoundDescriptor", CopyType.DeepCopy):
                case ("SoundDescriptorBinaryOverlay", CopyType.DeepCopy):
                    SoundDescriptor newSoundDescriptorRecord = (SoundDescriptor)Record.DeepCopy();
                    mod.SoundDescriptors.Add(newSoundDescriptorRecord);
                    break;
                case ("SoundCategory", CopyType.AsOverride):
                case ("SoundCategoryBinaryOverlay", CopyType.AsOverride):
                    mod.SoundCategories.GetOrAddAsOverride(Record);
                    break;
                case ("SoundCategory", CopyType.AsNewRecord):
                case ("SoundCategoryBinaryOverlay", CopyType.AsNewRecord):
                    mod.SoundCategories.DuplicateInAsNewRecord(Record);
                    break;
                case ("SoundCategory", CopyType.DeepCopy):
                case ("SoundCategoryBinaryOverlay", CopyType.DeepCopy):
                    SoundCategory newSoundCategoryRecord = (SoundCategory)Record.DeepCopy();
                    mod.SoundCategories.Add(newSoundCategoryRecord);
                    break;
                case ("SoundOutputModel", CopyType.AsOverride):
                case ("SoundOutputModelBinaryOverlay", CopyType.AsOverride):
                    mod.SoundOutputModels.GetOrAddAsOverride(Record);
                    break;
                case ("SoundOutputModel", CopyType.AsNewRecord):
                case ("SoundOutputModelBinaryOverlay", CopyType.AsNewRecord):
                    mod.SoundOutputModels.DuplicateInAsNewRecord(Record);
                    break;
                case ("SoundOutputModel", CopyType.DeepCopy):
                case ("SoundOutputModelBinaryOverlay", CopyType.DeepCopy):
                    SoundOutputModel newSoundOutputModelRecord = (SoundOutputModel)Record.DeepCopy();
                    mod.SoundOutputModels.Add(newSoundOutputModelRecord);
                    break;
                case ("CollisionLayer", CopyType.AsOverride):
                case ("CollisionLayerBinaryOverlay", CopyType.AsOverride):
                    mod.CollisionLayers.GetOrAddAsOverride(Record);
                    break;
                case ("CollisionLayer", CopyType.AsNewRecord):
                case ("CollisionLayerBinaryOverlay", CopyType.AsNewRecord):
                    mod.CollisionLayers.DuplicateInAsNewRecord(Record);
                    break;
                case ("CollisionLayer", CopyType.DeepCopy):
                case ("CollisionLayerBinaryOverlay", CopyType.DeepCopy):
                    CollisionLayer newCollisionLayerRecord = (CollisionLayer)Record.DeepCopy();
                    mod.CollisionLayers.Add(newCollisionLayerRecord);
                    break;
                case ("ColorRecord", CopyType.AsOverride):
                case ("ColorRecordBinaryOverlay", CopyType.AsOverride):
                    mod.Colors.GetOrAddAsOverride(Record);
                    break;
                case ("ColorRecord", CopyType.AsNewRecord):
                case ("ColorRecordBinaryOverlay", CopyType.AsNewRecord):
                    mod.Colors.DuplicateInAsNewRecord(Record);
                    break;
                case ("ColorRecord", CopyType.DeepCopy):
                case ("ColorRecordBinaryOverlay", CopyType.DeepCopy):
                    ColorRecord newColorRecordRecord = (ColorRecord)Record.DeepCopy();
                    mod.Colors.Add(newColorRecordRecord);
                    break;
                case ("ReverbParameters", CopyType.AsOverride):
                case ("ReverbParametersBinaryOverlay", CopyType.AsOverride):
                    mod.ReverbParameters.GetOrAddAsOverride(Record);
                    break;
                case ("ReverbParameters", CopyType.AsNewRecord):
                case ("ReverbParametersBinaryOverlay", CopyType.AsNewRecord):
                    mod.ReverbParameters.DuplicateInAsNewRecord(Record);
                    break;
                case ("ReverbParameters", CopyType.DeepCopy):
                case ("ReverbParametersBinaryOverlay", CopyType.DeepCopy):
                    ReverbParameters newReverbParametersRecord = (ReverbParameters)Record.DeepCopy();
                    mod.ReverbParameters.Add(newReverbParametersRecord);
                    break;
                case ("PackIn", CopyType.AsOverride):
                case ("PackInBinaryOverlay", CopyType.AsOverride):
                    mod.PackIns.GetOrAddAsOverride(Record);
                    break;
                case ("PackIn", CopyType.AsNewRecord):
                case ("PackInBinaryOverlay", CopyType.AsNewRecord):
                    mod.PackIns.DuplicateInAsNewRecord(Record);
                    break;
                case ("PackIn", CopyType.DeepCopy):
                case ("PackInBinaryOverlay", CopyType.DeepCopy):
                    PackIn newPackInRecord = (PackIn)Record.DeepCopy();
                    mod.PackIns.Add(newPackInRecord);
                    break;
                case ("ReferenceGroup", CopyType.AsOverride):
                case ("ReferenceGroupBinaryOverlay", CopyType.AsOverride):
                    mod.ReferenceGroups.GetOrAddAsOverride(Record);
                    break;
                case ("ReferenceGroup", CopyType.AsNewRecord):
                case ("ReferenceGroupBinaryOverlay", CopyType.AsNewRecord):
                    mod.ReferenceGroups.DuplicateInAsNewRecord(Record);
                    break;
                case ("ReferenceGroup", CopyType.DeepCopy):
                case ("ReferenceGroupBinaryOverlay", CopyType.DeepCopy):
                    ReferenceGroup newReferenceGroupRecord = (ReferenceGroup)Record.DeepCopy();
                    mod.ReferenceGroups.Add(newReferenceGroupRecord);
                    break;
                case ("AimModel", CopyType.AsOverride):
                case ("AimModelBinaryOverlay", CopyType.AsOverride):
                    mod.AimModels.GetOrAddAsOverride(Record);
                    break;
                case ("AimModel", CopyType.AsNewRecord):
                case ("AimModelBinaryOverlay", CopyType.AsNewRecord):
                    mod.AimModels.DuplicateInAsNewRecord(Record);
                    break;
                case ("AimModel", CopyType.DeepCopy):
                case ("AimModelBinaryOverlay", CopyType.DeepCopy):
                    AimModel newAimModelRecord = (AimModel)Record.DeepCopy();
                    mod.AimModels.Add(newAimModelRecord);
                    break;
                case ("Layer", CopyType.AsOverride):
                case ("LayerBinaryOverlay", CopyType.AsOverride):
                    mod.Layers.GetOrAddAsOverride(Record);
                    break;
                case ("Layer", CopyType.AsNewRecord):
                case ("LayerBinaryOverlay", CopyType.AsNewRecord):
                    mod.Layers.DuplicateInAsNewRecord(Record);
                    break;
                case ("Layer", CopyType.DeepCopy):
                case ("LayerBinaryOverlay", CopyType.DeepCopy):
                    Layer newLayerRecord = (Layer)Record.DeepCopy();
                    mod.Layers.Add(newLayerRecord);
                    break;
                case ("ConstructibleObject", CopyType.AsOverride):
                case ("ConstructibleObjectBinaryOverlay", CopyType.AsOverride):
                    mod.ConstructibleObjects.GetOrAddAsOverride(Record);
                    break;
                case ("ConstructibleObject", CopyType.AsNewRecord):
                case ("ConstructibleObjectBinaryOverlay", CopyType.AsNewRecord):
                    mod.ConstructibleObjects.DuplicateInAsNewRecord(Record);
                    break;
                case ("ConstructibleObject", CopyType.DeepCopy):
                case ("ConstructibleObjectBinaryOverlay", CopyType.DeepCopy):
                    ConstructibleObject newConstructibleObjectRecord = (ConstructibleObject)Record.DeepCopy();
                    mod.ConstructibleObjects.Add(newConstructibleObjectRecord);
                    break;
                case ("AObjectModification", CopyType.AsOverride):
                case ("AObjectModificationBinaryOverlay", CopyType.AsOverride):
                    mod.ObjectModifications.GetOrAddAsOverride(Record);
                    break;
                case ("AObjectModification", CopyType.AsNewRecord):
                case ("AObjectModificationBinaryOverlay", CopyType.AsNewRecord):
                    mod.ObjectModifications.DuplicateInAsNewRecord(Record);
                    break;
                case ("AObjectModification", CopyType.DeepCopy):
                case ("AObjectModificationBinaryOverlay", CopyType.DeepCopy):
                    AObjectModification newAObjectModificationRecord = (AObjectModification)Record.DeepCopy();
                    mod.ObjectModifications.Add(newAObjectModificationRecord);
                    break;
                case ("MaterialSwap", CopyType.AsOverride):
                case ("MaterialSwapBinaryOverlay", CopyType.AsOverride):
                    mod.MaterialSwaps.GetOrAddAsOverride(Record);
                    break;
                case ("MaterialSwap", CopyType.AsNewRecord):
                case ("MaterialSwapBinaryOverlay", CopyType.AsNewRecord):
                    mod.MaterialSwaps.DuplicateInAsNewRecord(Record);
                    break;
                case ("MaterialSwap", CopyType.DeepCopy):
                case ("MaterialSwapBinaryOverlay", CopyType.DeepCopy):
                    MaterialSwap newMaterialSwapRecord = (MaterialSwap)Record.DeepCopy();
                    mod.MaterialSwaps.Add(newMaterialSwapRecord);
                    break;
                case ("Zoom", CopyType.AsOverride):
                case ("ZoomBinaryOverlay", CopyType.AsOverride):
                    mod.Zooms.GetOrAddAsOverride(Record);
                    break;
                case ("Zoom", CopyType.AsNewRecord):
                case ("ZoomBinaryOverlay", CopyType.AsNewRecord):
                    mod.Zooms.DuplicateInAsNewRecord(Record);
                    break;
                case ("Zoom", CopyType.DeepCopy):
                case ("ZoomBinaryOverlay", CopyType.DeepCopy):
                    Zoom newZoomRecord = (Zoom)Record.DeepCopy();
                    mod.Zooms.Add(newZoomRecord);
                    break;
                case ("InstanceNamingRules", CopyType.AsOverride):
                case ("InstanceNamingRulesBinaryOverlay", CopyType.AsOverride):
                    mod.InstanceNamingRules.GetOrAddAsOverride(Record);
                    break;
                case ("InstanceNamingRules", CopyType.AsNewRecord):
                case ("InstanceNamingRulesBinaryOverlay", CopyType.AsNewRecord):
                    mod.InstanceNamingRules.DuplicateInAsNewRecord(Record);
                    break;
                case ("InstanceNamingRules", CopyType.DeepCopy):
                case ("InstanceNamingRulesBinaryOverlay", CopyType.DeepCopy):
                    InstanceNamingRules newInstanceNamingRulesRecord = (InstanceNamingRules)Record.DeepCopy();
                    mod.InstanceNamingRules.Add(newInstanceNamingRulesRecord);
                    break;
                case ("SoundKeywordMapping", CopyType.AsOverride):
                case ("SoundKeywordMappingBinaryOverlay", CopyType.AsOverride):
                    mod.SoundKeywordMappings.GetOrAddAsOverride(Record);
                    break;
                case ("SoundKeywordMapping", CopyType.AsNewRecord):
                case ("SoundKeywordMappingBinaryOverlay", CopyType.AsNewRecord):
                    mod.SoundKeywordMappings.DuplicateInAsNewRecord(Record);
                    break;
                case ("SoundKeywordMapping", CopyType.DeepCopy):
                case ("SoundKeywordMappingBinaryOverlay", CopyType.DeepCopy):
                    SoundKeywordMapping newSoundKeywordMappingRecord = (SoundKeywordMapping)Record.DeepCopy();
                    mod.SoundKeywordMappings.Add(newSoundKeywordMappingRecord);
                    break;
                case ("AudioEffectChain", CopyType.AsOverride):
                case ("AudioEffectChainBinaryOverlay", CopyType.AsOverride):
                    mod.AudioEffectChains.GetOrAddAsOverride(Record);
                    break;
                case ("AudioEffectChain", CopyType.AsNewRecord):
                case ("AudioEffectChainBinaryOverlay", CopyType.AsNewRecord):
                    mod.AudioEffectChains.DuplicateInAsNewRecord(Record);
                    break;
                case ("AudioEffectChain", CopyType.DeepCopy):
                case ("AudioEffectChainBinaryOverlay", CopyType.DeepCopy):
                    AudioEffectChain newAudioEffectChainRecord = (AudioEffectChain)Record.DeepCopy();
                    mod.AudioEffectChains.Add(newAudioEffectChainRecord);
                    break;
                case ("SceneCollection", CopyType.AsOverride):
                case ("SceneCollectionBinaryOverlay", CopyType.AsOverride):
                    mod.SceneCollections.GetOrAddAsOverride(Record);
                    break;
                case ("SceneCollection", CopyType.AsNewRecord):
                case ("SceneCollectionBinaryOverlay", CopyType.AsNewRecord):
                    mod.SceneCollections.DuplicateInAsNewRecord(Record);
                    break;
                case ("SceneCollection", CopyType.DeepCopy):
                case ("SceneCollectionBinaryOverlay", CopyType.DeepCopy):
                    SceneCollection newSceneCollectionRecord = (SceneCollection)Record.DeepCopy();
                    mod.SceneCollections.Add(newSceneCollectionRecord);
                    break;
                case ("AttractionRule", CopyType.AsOverride):
                case ("AttractionRuleBinaryOverlay", CopyType.AsOverride):
                    mod.AttractionRules.GetOrAddAsOverride(Record);
                    break;
                case ("AttractionRule", CopyType.AsNewRecord):
                case ("AttractionRuleBinaryOverlay", CopyType.AsNewRecord):
                    mod.AttractionRules.DuplicateInAsNewRecord(Record);
                    break;
                case ("AttractionRule", CopyType.DeepCopy):
                case ("AttractionRuleBinaryOverlay", CopyType.DeepCopy):
                    AttractionRule newAttractionRuleRecord = (AttractionRule)Record.DeepCopy();
                    mod.AttractionRules.Add(newAttractionRuleRecord);
                    break;
                case ("AudioCategorySnapshot", CopyType.AsOverride):
                case ("AudioCategorySnapshotBinaryOverlay", CopyType.AsOverride):
                    mod.AudioCategorySnapshots.GetOrAddAsOverride(Record);
                    break;
                case ("AudioCategorySnapshot", CopyType.AsNewRecord):
                case ("AudioCategorySnapshotBinaryOverlay", CopyType.AsNewRecord):
                    mod.AudioCategorySnapshots.DuplicateInAsNewRecord(Record);
                    break;
                case ("AudioCategorySnapshot", CopyType.DeepCopy):
                case ("AudioCategorySnapshotBinaryOverlay", CopyType.DeepCopy):
                    AudioCategorySnapshot newAudioCategorySnapshotRecord = (AudioCategorySnapshot)Record.DeepCopy();
                    mod.AudioCategorySnapshots.Add(newAudioCategorySnapshotRecord);
                    break;
                case ("AnimationSoundTagSet", CopyType.AsOverride):
                case ("AnimationSoundTagSetBinaryOverlay", CopyType.AsOverride):
                    mod.AnimationSoundTagSets.GetOrAddAsOverride(Record);
                    break;
                case ("AnimationSoundTagSet", CopyType.AsNewRecord):
                case ("AnimationSoundTagSetBinaryOverlay", CopyType.AsNewRecord):
                    mod.AnimationSoundTagSets.DuplicateInAsNewRecord(Record);
                    break;
                case ("AnimationSoundTagSet", CopyType.DeepCopy):
                case ("AnimationSoundTagSetBinaryOverlay", CopyType.DeepCopy):
                    AnimationSoundTagSet newAnimationSoundTagSetRecord = (AnimationSoundTagSet)Record.DeepCopy();
                    mod.AnimationSoundTagSets.Add(newAnimationSoundTagSetRecord);
                    break;
                case ("NavigationMeshObstacleManager", CopyType.AsOverride):
                case ("NavigationMeshObstacleManagerBinaryOverlay", CopyType.AsOverride):
                    mod.NavigationMeshObstacleManagers.GetOrAddAsOverride(Record);
                    break;
                case ("NavigationMeshObstacleManager", CopyType.AsNewRecord):
                case ("NavigationMeshObstacleManagerBinaryOverlay", CopyType.AsNewRecord):
                    mod.NavigationMeshObstacleManagers.DuplicateInAsNewRecord(Record);
                    break;
                case ("NavigationMeshObstacleManager", CopyType.DeepCopy):
                case ("NavigationMeshObstacleManagerBinaryOverlay", CopyType.DeepCopy):
                    NavigationMeshObstacleManager newNavigationMeshObstacleManagerRecord = (NavigationMeshObstacleManager)Record.DeepCopy();
                    mod.NavigationMeshObstacleManagers.Add(newNavigationMeshObstacleManagerRecord);
                    break;
                case ("LensFlare", CopyType.AsOverride):
                case ("LensFlareBinaryOverlay", CopyType.AsOverride):
                    mod.LensFlares.GetOrAddAsOverride(Record);
                    break;
                case ("LensFlare", CopyType.AsNewRecord):
                case ("LensFlareBinaryOverlay", CopyType.AsNewRecord):
                    mod.LensFlares.DuplicateInAsNewRecord(Record);
                    break;
                case ("LensFlare", CopyType.DeepCopy):
                case ("LensFlareBinaryOverlay", CopyType.DeepCopy):
                    LensFlare newLensFlareRecord = (LensFlare)Record.DeepCopy();
                    mod.LensFlares.Add(newLensFlareRecord);
                    break;
                case ("GodRays", CopyType.AsOverride):
                case ("GodRaysBinaryOverlay", CopyType.AsOverride):
                    mod.GodRays.GetOrAddAsOverride(Record);
                    break;
                case ("GodRays", CopyType.AsNewRecord):
                case ("GodRaysBinaryOverlay", CopyType.AsNewRecord):
                    mod.GodRays.DuplicateInAsNewRecord(Record);
                    break;
                case ("GodRays", CopyType.DeepCopy):
                case ("GodRaysBinaryOverlay", CopyType.DeepCopy):
                    GodRays newGodRaysRecord = (GodRays)Record.DeepCopy();
                    mod.GodRays.Add(newGodRaysRecord);
                    break;
                case ("ObjectVisibilityManager", CopyType.AsOverride):
                case ("ObjectVisibilityManagerBinaryOverlay", CopyType.AsOverride):
                    mod.ObjectVisibilityManagers.GetOrAddAsOverride(Record);
                    break;
                case ("ObjectVisibilityManager", CopyType.AsNewRecord):
                case ("ObjectVisibilityManagerBinaryOverlay", CopyType.AsNewRecord):
                    mod.ObjectVisibilityManagers.DuplicateInAsNewRecord(Record);
                    break;
                case ("ObjectVisibilityManager", CopyType.DeepCopy):
                case ("ObjectVisibilityManagerBinaryOverlay", CopyType.DeepCopy):
                    ObjectVisibilityManager newObjectVisibilityManagerRecord = (ObjectVisibilityManager)Record.DeepCopy();
                    mod.ObjectVisibilityManagers.Add(newObjectVisibilityManagerRecord);
                    break;
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");

            }
        }
    }

    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    [Cmdlet(VerbsCommon.Get, "FalloutWinningOverrides")]
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

    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    [Cmdlet(VerbsCommon.Get, "FalloutMajorRecords")]
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
    public class CopyFalloutRecordAsOverride : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.CopyHelper(Mod, Record, CopyType.AsOverride);
        }
    }

    [Cmdlet(VerbsCommon.Copy, "FalloutRecordAsNewRecord")]
    public class CopyFalloutRecordAsNewRecord : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.CopyHelper(Mod, Record, CopyType.AsNewRecord);
        }
    }

    [Cmdlet(VerbsCommon.Copy, "FalloutRecordAsDeepCopy")]
    public class CopyFallout4RecordAsDeepCopy : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.CopyHelper(Mod, Record, CopyType.DeepCopy);
        }
    }
}