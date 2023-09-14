using System.Management.Automation;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using Modrify.Core;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Aspects;

namespace Modrify.Fallout4
{
    [Cmdlet(VerbsCommon.Add, "FalloutKeyword")]
    public class AddFalloutKeyword : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public required IKeyworded<IKeywordGetter> TargetRecord;

        [Parameter(Mandatory = true, Position = 0)]
        public required IKeywordGetter Keyword;

        protected override void ProcessRecord()
        {
            if (TargetRecord.Keywords == null)
            {
                WriteVerbose("Adding keyword list to record.");
                TargetRecord.Keywords = new ExtendedList<IFormLinkGetter<IKeywordGetter>>();
            }
            if (!TargetRecord.HasKeyword(Keyword))
            {
                TargetRecord.Keywords.Add(Keyword);
            }
            else
            {
                WriteVerbose("Record already has the indicated key.");
            }
        }
    }

    [Cmdlet(VerbsCommon.Add, "FalloutRecord")]
    public class AddFalloutRecord : PSCmdlet
    {
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required IFallout4Mod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required IFallout4MajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.AddRecordHelper(Mod, Record);
        }
    }

    [Cmdlet(VerbsCommon.Get, "FalloutWinningContextOverrides")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetFalloutWinningContextOverrides : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        // set taken from MajorRecordTypes
        [ValidateSet("ActionRecord", "Activator", "ActorValueInformation", "ADamageType", "AddonNode", "Ammunition", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AStoryManagerNode", "Book", "CameraPath", "CameraShot", "Cell", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "Container", "DialogBranch", "DialogResponses", "DialogTopic", "Door", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Faction", "Furniture", "GameSetting", "Global", "Grass", "Hazard", "HeadPart", "Holotape", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "Ingestible", "Ingredient", "InstanceNamingRules", "Key", "Keyword", "LeveledItem", "LeveledNpc", "Light", "LoadScreen", "Location", "MagicEffect", "MaterialObject", "MaterialSwap", "MaterialType", "Message", "MiscItem", "MovableStatic", "MusicTrack", "MusicType", "NavigationMesh", "Npc", "ObjectEffect", "AObjectModification", "Package", "PackIn", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "Scene", "ShaderParticleGeometry", "SoundCategory", "SoundDescriptor", "SoundOutputModel", "Static", "StaticCollection", "TalkingActivator", "Terminal", "TextureSet", "Transform", "Tree", "VisualEffect", "VoiceType", "Water", "Weapon", "Weather", "Worldspace", "Zoom", "AttractionRule", "Component", "LocationReferenceType", "AnimationSoundTagSet", "Class", "Debris", "FormList", "ImpactDataSet", "LeveledSpell", "Outfit", "SoundMarker", "AcousticSpace", "ReverbParameters", "LandscapeTexture", "Spell", "Footstep", "FootstepSet", "GodRays", "LensFlare", "Flora", "BodyPartData", "MovementType", "DualCastData", "ConstructibleObject", "AimModel", "BendableSpline", "NavigationMeshInfoMap", "LightingTemplate", "Layer", "ReferenceGroup", "Landscape", "AnimatedObject", "DefaultObjectManager", "DefaultObject", "DialogView", "AssociationType", "AudioEffectChain", "SoundKeywordMapping", "SceneCollection", "AudioCategorySnapshot", "NavigationMeshObstacleManager", "ObjectVisibilityManager")]
        public required string RecordType;

        [Parameter()]
        public bool IncludeDeletedRecords = false;

        protected override void ProcessRecord()
        {
            foreach (var rec in Helpers.WinningContextOverrides(RecordType).ToArray())
            {
                WriteObject(rec);
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
        [ValidateSet("ActionRecord", "Activator", "ActorValueInformation", "ADamageType", "AddonNode", "Ammunition", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AStoryManagerNode", "Book", "CameraPath", "CameraShot", "Cell", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "Container", "DialogBranch", "DialogResponses", "DialogTopic", "Door", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Faction", "Furniture", "GameSetting", "Global", "Grass", "Hazard", "HeadPart", "Holotape", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "Ingestible", "Ingredient", "InstanceNamingRules", "Key", "Keyword", "LeveledItem", "LeveledNpc", "Light", "LoadScreen", "Location", "MagicEffect", "MaterialObject", "MaterialSwap", "MaterialType", "Message", "MiscItem", "MovableStatic", "MusicTrack", "MusicType", "NavigationMesh", "Npc", "ObjectEffect", "AObjectModification", "Package", "PackIn", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "Scene", "ShaderParticleGeometry", "SoundCategory", "SoundDescriptor", "SoundOutputModel", "Static", "StaticCollection", "TalkingActivator", "Terminal", "TextureSet", "Transform", "Tree", "VisualEffect", "VoiceType", "Water", "Weapon", "Weather", "Worldspace", "Zoom", "AttractionRule", "Component", "LocationReferenceType", "AnimationSoundTagSet", "Class", "Debris", "FormList", "ImpactDataSet", "LeveledSpell", "Outfit", "SoundMarker", "AcousticSpace", "ReverbParameters", "LandscapeTexture", "Spell", "Footstep", "FootstepSet", "GodRays", "LensFlare", "Flora", "BodyPartData", "MovementType", "DualCastData", "ConstructibleObject", "AimModel", "BendableSpline", "NavigationMeshInfoMap", "LightingTemplate", "Layer", "ReferenceGroup", "Landscape", "AnimatedObject", "DefaultObjectManager", "DefaultObject", "DialogView", "AssociationType", "AudioEffectChain", "SoundKeywordMapping", "SceneCollection", "AudioCategorySnapshot", "NavigationMeshObstacleManager", "ObjectVisibilityManager"
)]
        public required string RecordType;

        [Parameter()]
        public bool IncludeDeletedRecords = false;

        protected override void ProcessRecord()
        {
            if (ModrifyConfig.Environment == null)
            {
                throw new PSInvalidOperationException("Unable to load the load order. Please set your environment with 'Set-MutaGameEnvironment'");
            }
            else
            {
                foreach (var rec in OverrideMixIns.WinningOverrides(ModrifyConfig.Environment.LoadOrder.PriorityOrder, Helpers.MajorRecordTypes[RecordType], IncludeDeletedRecords).ToArray())
                {
                    WriteObject(rec);
                }
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "FalloutMajorRecords", DefaultParameterSetName = "bymodkey")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetFalloutMajorRecords : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "bymod")]
        public required IFallout4ModGetter Mod;

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "bymodkey")]
        public ModKey ModKey;

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
                Mod = Fallout4Mod.CreateFromBinaryOverlay(ModrifyConfig.ResolveModkeyPath(ModKey));
            }
            if (RecordType == null)
            {
                foreach (var rec in Mod.EnumerateMajorRecords().ToArray())
                {
                    WriteObject(rec);
                }
            }
            else
            {
                foreach (var rec in Mod.EnumerateMajorRecords(Helpers.MajorRecordTypes[RecordType]).ToArray())
                {
                    WriteObject(rec);
                }
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