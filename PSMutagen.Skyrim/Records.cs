using System.Management.Automation;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using PSMutagen.Core;
using Mutagen.Bethesda.Plugins.Binary.Translations;

namespace PSMutagen.Skyrim
{
    public static class Helpers
    {
        public static Dictionary<string, Type> MajorRecordTypes = new Dictionary<string, Type>()
        {
            /*
                # pwsh w/Mutagen.Bethesda.Skyrim and dependencies loaded
                $skyrimTypes = [AppDomain]::CurrentDomain.GetAssemblies().GetTypes() | Where-Object { $_.Namespace -eq 'Mutagen.Bethesda.Skyrim' }
                $mrs = $skyrimTypes | ?{$_.BaseType -eq [Mutagen.Bethesda.Skyrim.SkyrimMajorRecord]}
                $mrs.Name | %{
                    "{ `"$_`", Type.GetType(`"Mutagen.Bethesda.Skyrim.I$_`Getter, Mutagen.Bethesda.Skyrim`") },"
                }
            */
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

        public static SkyrimMajorRecord CopyHelper(ISkyrimMod mod, ISkyrimMajorRecordGetter Record, CopyType copyType)
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
                case ("Hair", CopyType.AsOverride):
                case ("HairBinaryOverlay", CopyType.AsOverride):
                    return mod.Hairs.GetOrAddAsOverride(Record);
                case ("Hair", CopyType.AsNewRecord):
                case ("HairBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Hairs.DuplicateInAsNewRecord(Record);
                case ("Hair", CopyType.DeepCopy):
                case ("HairBinaryOverlay", CopyType.DeepCopy):
                    Hair newHairRecord = (Hair)Record.DeepCopy();
                    mod.Hairs.Add(newHairRecord);
                    return newHairRecord;
                case ("Eyes", CopyType.AsOverride):
                case ("EyesBinaryOverlay", CopyType.AsOverride):
                    return mod.Eyes.GetOrAddAsOverride(Record);
                case ("Eyes", CopyType.AsNewRecord):
                case ("EyesBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Eyes.DuplicateInAsNewRecord(Record);
                case ("Eyes", CopyType.DeepCopy):
                case ("EyesBinaryOverlay", CopyType.DeepCopy):
                    Eyes newEyesRecord = (Eyes)Record.DeepCopy();
                    mod.Eyes.Add(newEyesRecord);
                    return newEyesRecord;
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
                case ("Scroll", CopyType.AsOverride):
                case ("ScrollBinaryOverlay", CopyType.AsOverride):
                    return mod.Scrolls.GetOrAddAsOverride(Record);
                case ("Scroll", CopyType.AsNewRecord):
                case ("ScrollBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Scrolls.DuplicateInAsNewRecord(Record);
                case ("Scroll", CopyType.DeepCopy):
                case ("ScrollBinaryOverlay", CopyType.DeepCopy):
                    Scroll newScrollRecord = (Scroll)Record.DeepCopy();
                    mod.Scrolls.Add(newScrollRecord);
                    return newScrollRecord;
                case ("Activator", CopyType.AsOverride):
                case ("ActivatorBinaryOverlay", CopyType.AsOverride):
                    return mod.Activators.GetOrAddAsOverride(Record);
                case ("Activator", CopyType.AsNewRecord):
                case ("ActivatorBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Activators.DuplicateInAsNewRecord(Record);
                case ("Activator", CopyType.DeepCopy):
                case ("ActivatorBinaryOverlay", CopyType.DeepCopy):
                    Mutagen.Bethesda.Skyrim.Activator newActivatorRecord = (Mutagen.Bethesda.Skyrim.Activator)Record.DeepCopy();
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
                case ("AlchemicalApparatus", CopyType.AsOverride):
                case ("AlchemicalApparatusBinaryOverlay", CopyType.AsOverride):
                    return mod.AlchemicalApparatuses.GetOrAddAsOverride(Record);
                case ("AlchemicalApparatus", CopyType.AsNewRecord):
                case ("AlchemicalApparatusBinaryOverlay", CopyType.AsNewRecord):
                    return mod.AlchemicalApparatuses.DuplicateInAsNewRecord(Record);
                case ("AlchemicalApparatus", CopyType.DeepCopy):
                case ("AlchemicalApparatusBinaryOverlay", CopyType.DeepCopy):
                    AlchemicalApparatus newAlchemicalApparatusRecord = (AlchemicalApparatus)Record.DeepCopy();
                    mod.AlchemicalApparatuses.Add(newAlchemicalApparatusRecord);
                    return newAlchemicalApparatusRecord;
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
                case ("MoveableStatic", CopyType.AsOverride):
                case ("MoveableStaticBinaryOverlay", CopyType.AsOverride):
                    return mod.MoveableStatics.GetOrAddAsOverride(Record);
                case ("MoveableStatic", CopyType.AsNewRecord):
                case ("MoveableStaticBinaryOverlay", CopyType.AsNewRecord):
                    return mod.MoveableStatics.DuplicateInAsNewRecord(Record);
                case ("MoveableStatic", CopyType.DeepCopy):
                case ("MoveableStaticBinaryOverlay", CopyType.DeepCopy):
                    MoveableStatic newMoveableStaticRecord = (MoveableStatic)Record.DeepCopy();
                    mod.MoveableStatics.Add(newMoveableStaticRecord);
                    return newMoveableStaticRecord;
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
                case ("SoulGem", CopyType.AsOverride):
                case ("SoulGemBinaryOverlay", CopyType.AsOverride):
                    return mod.SoulGems.GetOrAddAsOverride(Record);
                case ("SoulGem", CopyType.AsNewRecord):
                case ("SoulGemBinaryOverlay", CopyType.AsNewRecord):
                    return mod.SoulGems.DuplicateInAsNewRecord(Record);
                case ("SoulGem", CopyType.DeepCopy):
                case ("SoulGemBinaryOverlay", CopyType.DeepCopy):
                    SoulGem newSoulGemRecord = (SoulGem)Record.DeepCopy();
                    mod.SoulGems.Add(newSoulGemRecord);
                    return newSoulGemRecord;
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
                    return mod.Weathers.GetOrAddAsOverride(Record);
                case ("Weather", CopyType.AsNewRecord):
                case ("WeatherBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Weathers.DuplicateInAsNewRecord(Record);
                case ("Weather", CopyType.DeepCopy):
                case ("WeatherBinaryOverlay", CopyType.DeepCopy):
                    Weather newWeatherRecord = (Weather)Record.DeepCopy();
                    mod.Weathers.Add(newWeatherRecord);
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
                case ("DialogTopic", CopyType.AsOverride):
                case ("DialogTopicBinaryOverlay", CopyType.AsOverride):
                    return mod.DialogTopics.GetOrAddAsOverride(Record);
                case ("DialogTopic", CopyType.AsNewRecord):
                case ("DialogTopicBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DialogTopics.DuplicateInAsNewRecord(Record);
                case ("DialogTopic", CopyType.DeepCopy):
                case ("DialogTopicBinaryOverlay", CopyType.DeepCopy):
                    DialogTopic newDialogTopicRecord = (DialogTopic)Record.DeepCopy();
                    mod.DialogTopics.Add(newDialogTopicRecord);
                    return newDialogTopicRecord;
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
                case ("LeveledSpell", CopyType.AsOverride):
                case ("LeveledSpellBinaryOverlay", CopyType.AsOverride):
                    return mod.LeveledSpells.GetOrAddAsOverride(Record);
                case ("LeveledSpell", CopyType.AsNewRecord):
                case ("LeveledSpellBinaryOverlay", CopyType.AsNewRecord):
                    return mod.LeveledSpells.DuplicateInAsNewRecord(Record);
                case ("LeveledSpell", CopyType.DeepCopy):
                case ("LeveledSpellBinaryOverlay", CopyType.DeepCopy):
                    LeveledSpell newLeveledSpellRecord = (LeveledSpell)Record.DeepCopy();
                    mod.LeveledSpells.Add(newLeveledSpellRecord);
                    return newLeveledSpellRecord;
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
                case ("DialogBranch", CopyType.AsOverride):
                case ("DialogBranchBinaryOverlay", CopyType.AsOverride):
                    return mod.DialogBranches.GetOrAddAsOverride(Record);
                case ("DialogBranch", CopyType.AsNewRecord):
                case ("DialogBranchBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DialogBranches.DuplicateInAsNewRecord(Record);
                case ("DialogBranch", CopyType.DeepCopy):
                case ("DialogBranchBinaryOverlay", CopyType.DeepCopy):
                    DialogBranch newDialogBranchRecord = (DialogBranch)Record.DeepCopy();
                    mod.DialogBranches.Add(newDialogBranchRecord);
                    return newDialogBranchRecord;
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
                case ("WordOfPower", CopyType.AsOverride):
                case ("WordOfPowerBinaryOverlay", CopyType.AsOverride):
                    return mod.WordsOfPower.GetOrAddAsOverride(Record);
                case ("WordOfPower", CopyType.AsNewRecord):
                case ("WordOfPowerBinaryOverlay", CopyType.AsNewRecord):
                    return mod.WordsOfPower.DuplicateInAsNewRecord(Record);
                case ("WordOfPower", CopyType.DeepCopy):
                case ("WordOfPowerBinaryOverlay", CopyType.DeepCopy):
                    WordOfPower newWordOfPowerRecord = (WordOfPower)Record.DeepCopy();
                    mod.WordsOfPower.Add(newWordOfPowerRecord);
                    return newWordOfPowerRecord;
                case ("Shout", CopyType.AsOverride):
                case ("ShoutBinaryOverlay", CopyType.AsOverride):
                    return mod.Shouts.GetOrAddAsOverride(Record);
                case ("Shout", CopyType.AsNewRecord):
                case ("ShoutBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Shouts.DuplicateInAsNewRecord(Record);
                case ("Shout", CopyType.DeepCopy):
                case ("ShoutBinaryOverlay", CopyType.DeepCopy):
                    Shout newShoutRecord = (Shout)Record.DeepCopy();
                    mod.Shouts.Add(newShoutRecord);
                    return newShoutRecord;
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
                case ("Scene", CopyType.AsOverride):
                case ("SceneBinaryOverlay", CopyType.AsOverride):
                    return mod.Scenes.GetOrAddAsOverride(Record);
                case ("Scene", CopyType.AsNewRecord):
                case ("SceneBinaryOverlay", CopyType.AsNewRecord):
                    return mod.Scenes.DuplicateInAsNewRecord(Record);
                case ("Scene", CopyType.DeepCopy):
                case ("SceneBinaryOverlay", CopyType.DeepCopy):
                    Scene newSceneRecord = (Scene)Record.DeepCopy();
                    mod.Scenes.Add(newSceneRecord);
                    return newSceneRecord;
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
                case ("DualCastData", CopyType.AsOverride):
                case ("DualCastDataBinaryOverlay", CopyType.AsOverride):
                    return mod.DualCastData.GetOrAddAsOverride(Record);
                case ("DualCastData", CopyType.AsNewRecord):
                case ("DualCastDataBinaryOverlay", CopyType.AsNewRecord):
                    return mod.DualCastData.DuplicateInAsNewRecord(Record);
                case ("DualCastData", CopyType.DeepCopy):
                case ("DualCastDataBinaryOverlay", CopyType.DeepCopy):
                    DualCastData newDualCastDataRecord = (DualCastData)Record.DeepCopy();
                    mod.DualCastData.Add(newDualCastDataRecord);
                    return newDualCastDataRecord;
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
                case ("VolumetricLighting", CopyType.AsOverride):
                case ("VolumetricLightingBinaryOverlay", CopyType.AsOverride):
                    return mod.VolumetricLightings.GetOrAddAsOverride(Record);
                case ("VolumetricLighting", CopyType.AsNewRecord):
                case ("VolumetricLightingBinaryOverlay", CopyType.AsNewRecord):
                    return mod.VolumetricLightings.DuplicateInAsNewRecord(Record);
                case ("VolumetricLighting", CopyType.DeepCopy):
                case ("VolumetricLightingBinaryOverlay", CopyType.DeepCopy):
                    VolumetricLighting newVolumetricLightingRecord = (VolumetricLighting)Record.DeepCopy();
                    mod.VolumetricLightings.Add(newVolumetricLightingRecord);
                    return newVolumetricLightingRecord;
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimWinningOverrides")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetSkyrimWinningOverrides : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        // set taken from MajorRecordTypes
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
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

    [Cmdlet(VerbsCommon.Get, "SkyrimMajorRecords")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetSkyrimMajorRecords : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public required IModGetter Mod;

        [Parameter()]
        // Set taken from MajorRecordTypes
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
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

    [Cmdlet(VerbsCommon.Copy, "SkyrimRecordAsOverride")]
    [OutputType(typeof(SkyrimMajorRecord))]
    public class CopySkyrimRecordAsOverride : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.AsOverride));
        }
    }

    [Cmdlet(VerbsCommon.Copy, "SkyrimRecordAsNewRecord")]
    [OutputType(typeof(SkyrimMajorRecord))]
    public class CopySkyrimRecordAsNewRecord : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.AsNewRecord));
        }
    }

    [Cmdlet(VerbsCommon.Copy, "SkyrimRecordAsDeepCopy")]
    [OutputType(typeof(SkyrimMajorRecord))]
    public class CopySkyrimRecordAsDeepCopy : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.DeepCopy));
        }
    }
}