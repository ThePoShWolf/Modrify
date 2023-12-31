namespace Modrify.Fallout4
{
    public static partial class Helpers
    {
        public static Dictionary<string, Type> MajorRecordTypes = new Dictionary<string, Type>()
        {
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
            { "ObjectVisibilityManager", Type.GetType("Mutagen.Bethesda.Fallout4.IObjectVisibilityManagerGetter, Mutagen.Bethesda.Fallout4") }
        };
    }
}
