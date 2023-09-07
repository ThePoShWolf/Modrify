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

        public static void CopyHelper(ISkyrimMod mod, ISkyrimMajorRecordGetter Record, CopyType copyType)
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
                case ("Hair", CopyType.AsOverride):
                case ("HairBinaryOverlay", CopyType.AsOverride):
                    mod.Hairs.GetOrAddAsOverride(Record);
                    break;
                case ("Hair", CopyType.AsNewRecord):
                case ("HairBinaryOverlay", CopyType.AsNewRecord):
                    mod.Hairs.DuplicateInAsNewRecord(Record);
                    break;
                case ("Hair", CopyType.DeepCopy):
                case ("HairBinaryOverlay", CopyType.DeepCopy):
                    Hair newHairRecord = (Hair)Record.DeepCopy();
                    mod.Hairs.Add(newHairRecord);
                    break;
                case ("Eyes", CopyType.AsOverride):
                case ("EyesBinaryOverlay", CopyType.AsOverride):
                    mod.Eyes.GetOrAddAsOverride(Record);
                    break;
                case ("Eyes", CopyType.AsNewRecord):
                case ("EyesBinaryOverlay", CopyType.AsNewRecord):
                    mod.Eyes.DuplicateInAsNewRecord(Record);
                    break;
                case ("Eyes", CopyType.DeepCopy):
                case ("EyesBinaryOverlay", CopyType.DeepCopy):
                    Eyes newEyesRecord = (Eyes)Record.DeepCopy();
                    mod.Eyes.Add(newEyesRecord);
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
                case ("Scroll", CopyType.AsOverride):
                case ("ScrollBinaryOverlay", CopyType.AsOverride):
                    mod.Scrolls.GetOrAddAsOverride(Record);
                    break;
                case ("Scroll", CopyType.AsNewRecord):
                case ("ScrollBinaryOverlay", CopyType.AsNewRecord):
                    mod.Scrolls.DuplicateInAsNewRecord(Record);
                    break;
                case ("Scroll", CopyType.DeepCopy):
                case ("ScrollBinaryOverlay", CopyType.DeepCopy):
                    Scroll newScrollRecord = (Scroll)Record.DeepCopy();
                    mod.Scrolls.Add(newScrollRecord);
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
                    Mutagen.Bethesda.Skyrim.Activator newActivatorRecord = (Mutagen.Bethesda.Skyrim.Activator)Record.DeepCopy();
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
                case ("AlchemicalApparatus", CopyType.AsOverride):
                case ("AlchemicalApparatusBinaryOverlay", CopyType.AsOverride):
                    mod.AlchemicalApparatuses.GetOrAddAsOverride(Record);
                    break;
                case ("AlchemicalApparatus", CopyType.AsNewRecord):
                case ("AlchemicalApparatusBinaryOverlay", CopyType.AsNewRecord):
                    mod.AlchemicalApparatuses.DuplicateInAsNewRecord(Record);
                    break;
                case ("AlchemicalApparatus", CopyType.DeepCopy):
                case ("AlchemicalApparatusBinaryOverlay", CopyType.DeepCopy):
                    AlchemicalApparatus newAlchemicalApparatusRecord = (AlchemicalApparatus)Record.DeepCopy();
                    mod.AlchemicalApparatuses.Add(newAlchemicalApparatusRecord);
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
                case ("MoveableStatic", CopyType.AsOverride):
                case ("MoveableStaticBinaryOverlay", CopyType.AsOverride):
                    mod.MoveableStatics.GetOrAddAsOverride(Record);
                    break;
                case ("MoveableStatic", CopyType.AsNewRecord):
                case ("MoveableStaticBinaryOverlay", CopyType.AsNewRecord):
                    mod.MoveableStatics.DuplicateInAsNewRecord(Record);
                    break;
                case ("MoveableStatic", CopyType.DeepCopy):
                case ("MoveableStaticBinaryOverlay", CopyType.DeepCopy):
                    MoveableStatic newMoveableStaticRecord = (MoveableStatic)Record.DeepCopy();
                    mod.MoveableStatics.Add(newMoveableStaticRecord);
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
                case ("SoulGem", CopyType.AsOverride):
                case ("SoulGemBinaryOverlay", CopyType.AsOverride):
                    mod.SoulGems.GetOrAddAsOverride(Record);
                    break;
                case ("SoulGem", CopyType.AsNewRecord):
                case ("SoulGemBinaryOverlay", CopyType.AsNewRecord):
                    mod.SoulGems.DuplicateInAsNewRecord(Record);
                    break;
                case ("SoulGem", CopyType.DeepCopy):
                case ("SoulGemBinaryOverlay", CopyType.DeepCopy):
                    SoulGem newSoulGemRecord = (SoulGem)Record.DeepCopy();
                    mod.SoulGems.Add(newSoulGemRecord);
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
                    mod.Weathers.GetOrAddAsOverride(Record);
                    break;
                case ("Weather", CopyType.AsNewRecord):
                case ("WeatherBinaryOverlay", CopyType.AsNewRecord):
                    mod.Weathers.DuplicateInAsNewRecord(Record);
                    break;
                case ("Weather", CopyType.DeepCopy):
                case ("WeatherBinaryOverlay", CopyType.DeepCopy):
                    Weather newWeatherRecord = (Weather)Record.DeepCopy();
                    mod.Weathers.Add(newWeatherRecord);
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
                case ("DialogTopic", CopyType.AsOverride):
                case ("DialogTopicBinaryOverlay", CopyType.AsOverride):
                    mod.DialogTopics.GetOrAddAsOverride(Record);
                    break;
                case ("DialogTopic", CopyType.AsNewRecord):
                case ("DialogTopicBinaryOverlay", CopyType.AsNewRecord):
                    mod.DialogTopics.DuplicateInAsNewRecord(Record);
                    break;
                case ("DialogTopic", CopyType.DeepCopy):
                case ("DialogTopicBinaryOverlay", CopyType.DeepCopy):
                    DialogTopic newDialogTopicRecord = (DialogTopic)Record.DeepCopy();
                    mod.DialogTopics.Add(newDialogTopicRecord);
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
                case ("LeveledSpell", CopyType.AsOverride):
                case ("LeveledSpellBinaryOverlay", CopyType.AsOverride):
                    mod.LeveledSpells.GetOrAddAsOverride(Record);
                    break;
                case ("LeveledSpell", CopyType.AsNewRecord):
                case ("LeveledSpellBinaryOverlay", CopyType.AsNewRecord):
                    mod.LeveledSpells.DuplicateInAsNewRecord(Record);
                    break;
                case ("LeveledSpell", CopyType.DeepCopy):
                case ("LeveledSpellBinaryOverlay", CopyType.DeepCopy):
                    LeveledSpell newLeveledSpellRecord = (LeveledSpell)Record.DeepCopy();
                    mod.LeveledSpells.Add(newLeveledSpellRecord);
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
                case ("DialogBranch", CopyType.AsOverride):
                case ("DialogBranchBinaryOverlay", CopyType.AsOverride):
                    mod.DialogBranches.GetOrAddAsOverride(Record);
                    break;
                case ("DialogBranch", CopyType.AsNewRecord):
                case ("DialogBranchBinaryOverlay", CopyType.AsNewRecord):
                    mod.DialogBranches.DuplicateInAsNewRecord(Record);
                    break;
                case ("DialogBranch", CopyType.DeepCopy):
                case ("DialogBranchBinaryOverlay", CopyType.DeepCopy):
                    DialogBranch newDialogBranchRecord = (DialogBranch)Record.DeepCopy();
                    mod.DialogBranches.Add(newDialogBranchRecord);
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
                case ("WordOfPower", CopyType.AsOverride):
                case ("WordOfPowerBinaryOverlay", CopyType.AsOverride):
                    mod.WordsOfPower.GetOrAddAsOverride(Record);
                    break;
                case ("WordOfPower", CopyType.AsNewRecord):
                case ("WordOfPowerBinaryOverlay", CopyType.AsNewRecord):
                    mod.WordsOfPower.DuplicateInAsNewRecord(Record);
                    break;
                case ("WordOfPower", CopyType.DeepCopy):
                case ("WordOfPowerBinaryOverlay", CopyType.DeepCopy):
                    WordOfPower newWordOfPowerRecord = (WordOfPower)Record.DeepCopy();
                    mod.WordsOfPower.Add(newWordOfPowerRecord);
                    break;
                case ("Shout", CopyType.AsOverride):
                case ("ShoutBinaryOverlay", CopyType.AsOverride):
                    mod.Shouts.GetOrAddAsOverride(Record);
                    break;
                case ("Shout", CopyType.AsNewRecord):
                case ("ShoutBinaryOverlay", CopyType.AsNewRecord):
                    mod.Shouts.DuplicateInAsNewRecord(Record);
                    break;
                case ("Shout", CopyType.DeepCopy):
                case ("ShoutBinaryOverlay", CopyType.DeepCopy):
                    Shout newShoutRecord = (Shout)Record.DeepCopy();
                    mod.Shouts.Add(newShoutRecord);
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
                case ("Scene", CopyType.AsOverride):
                case ("SceneBinaryOverlay", CopyType.AsOverride):
                    mod.Scenes.GetOrAddAsOverride(Record);
                    break;
                case ("Scene", CopyType.AsNewRecord):
                case ("SceneBinaryOverlay", CopyType.AsNewRecord):
                    mod.Scenes.DuplicateInAsNewRecord(Record);
                    break;
                case ("Scene", CopyType.DeepCopy):
                case ("SceneBinaryOverlay", CopyType.DeepCopy):
                    Scene newSceneRecord = (Scene)Record.DeepCopy();
                    mod.Scenes.Add(newSceneRecord);
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
                case ("DualCastData", CopyType.AsOverride):
                case ("DualCastDataBinaryOverlay", CopyType.AsOverride):
                    mod.DualCastData.GetOrAddAsOverride(Record);
                    break;
                case ("DualCastData", CopyType.AsNewRecord):
                case ("DualCastDataBinaryOverlay", CopyType.AsNewRecord):
                    mod.DualCastData.DuplicateInAsNewRecord(Record);
                    break;
                case ("DualCastData", CopyType.DeepCopy):
                case ("DualCastDataBinaryOverlay", CopyType.DeepCopy):
                    DualCastData newDualCastDataRecord = (DualCastData)Record.DeepCopy();
                    mod.DualCastData.Add(newDualCastDataRecord);
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
                case ("VolumetricLighting", CopyType.AsOverride):
                case ("VolumetricLightingBinaryOverlay", CopyType.AsOverride):
                    mod.VolumetricLightings.GetOrAddAsOverride(Record);
                    break;
                case ("VolumetricLighting", CopyType.AsNewRecord):
                case ("VolumetricLightingBinaryOverlay", CopyType.AsNewRecord):
                    mod.VolumetricLightings.DuplicateInAsNewRecord(Record);
                    break;
                case ("VolumetricLighting", CopyType.DeepCopy):
                case ("VolumetricLightingBinaryOverlay", CopyType.DeepCopy):
                    VolumetricLighting newVolumetricLightingRecord = (VolumetricLighting)Record.DeepCopy();
                    mod.VolumetricLightings.Add(newVolumetricLightingRecord);
                    break;
                default:
                    throw new ArgumentException($"Unsupported or improperly implemented type: {Record.GetType().Name}. Please raise an issue in PSMutagen's GitHub repository.");
            }
        }

    }

    [Cmdlet(VerbsCommon.Get, "SkyrimWinningOverrides")]
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
    public class CopySkyrimRecordAsOverride : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.CopyHelper(Mod, Record, CopyType.AsOverride);
        }
    }

    [Cmdlet(VerbsCommon.Copy, "SkyrimRecordAsNewRecord")]
    public class CopySkyrimRecordAsNewRecord : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.CopyHelper(Mod, Record, CopyType.AsNewRecord);
        }
    }

    [Cmdlet(VerbsCommon.Copy, "SkyrimRecordAsDeepCopy")]
    public class CopySkyrimRecordAsDeepCopy : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.CopyHelper(Mod, Record, CopyType.DeepCopy);
        }
    }
}