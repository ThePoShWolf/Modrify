using System.Management.Automation;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using PSMutagen.Core;
using Mutagen.Bethesda.Plugins;

namespace PSMutagen.Fallout4
{
    [Cmdlet(VerbsCommon.Get, "FalloutWinningContextOverrides")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetFalloutWinningContextOverrides : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        // set taken from MajorRecordTypes
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
        public required string RecordType;

        [Parameter()]
        public bool IncludeDeletedRecords = false;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.WinningContextOverrides(RecordType).ToArray());
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

    [Cmdlet(VerbsCommon.Get, "FalloutMajorRecords", DefaultParameterSetName = "bymodkey")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetFalloutMajorRecords : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "bymod")]
        public IFallout4ModGetter? Mod;

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "bymodkey")]
        public ModKey? ModKey;

        [Parameter(ParameterSetName = "bymodkey")]
        [Parameter(ParameterSetName = "bymod")]
        // set taken from Helpers
        // "$($mrs.Name -join '","')"
        [ValidateSet("ActionRecord", "Activator", "ActorValueInformation", "ADamageType", "AddonNode", "Ammunition", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AStoryManagerNode", "Book", "CameraPath", "CameraShot", "Cell", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "Container", "DialogBranch", "DialogResponses", "DialogTopic", "Door", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Faction", "Furniture", "GameSetting", "Global", "Grass", "Hazard", "HeadPart", "Holotape", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "Ingestible", "Ingredient", "InstanceNamingRules", "Key", "Keyword", "LeveledItem", "LeveledNpc", "Light", "LoadScreen", "Location", "MagicEffect", "MaterialObject", "MaterialSwap", "MaterialType", "Message", "MiscItem", "MovableStatic", "MusicTrack", "MusicType", "NavigationMesh", "Npc", "ObjectEffect", "AObjectModification", "Package", "PackIn", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "Scene", "ShaderParticleGeometry", "SoundCategory", "SoundDescriptor", "SoundOutputModel", "Static", "StaticCollection", "TalkingActivator", "Terminal", "TextureSet", "Transform", "Tree", "VisualEffect", "VoiceType", "Water", "Weapon", "Weather", "Worldspace", "Zoom", "AttractionRule", "Component", "LocationReferenceType", "AnimationSoundTagSet", "Class", "Debris", "FormList", "ImpactDataSet", "LeveledSpell", "Outfit", "SoundMarker", "AcousticSpace", "ReverbParameters", "LandscapeTexture", "Spell", "Footstep", "FootstepSet", "GodRays", "LensFlare", "Flora", "BodyPartData", "MovementType", "DualCastData", "ConstructibleObject", "AimModel", "BendableSpline", "NavigationMeshInfoMap", "LightingTemplate", "Layer", "ReferenceGroup", "Landscape", "AnimatedObject", "DefaultObjectManager", "DefaultObject", "DialogView", "AssociationType", "AudioEffectChain", "SoundKeywordMapping", "SceneCollection", "AudioCategorySnapshot", "NavigationMeshObstacleManager", "ObjectVisibilityManager")]
        public string? RecordType;

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "bymodkey")
            {
                ModPath path = $"{PSMutagenConfig.TryGetEnvironment().DataFolderPath}\\{ModKey.ToString()}";
                Mod = Fallout4Mod.CreateFromBinaryOverlay(path);
            }
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
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
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
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
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
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.DeepCopy));
        }
    }
}