using System.Management.Automation;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using Modrify.Core;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Aspects;

namespace Modrify.Skyrim
{
    [Cmdlet(VerbsCommon.Add, "SkyrimKeyword")]
    public class AddSkyrimKeyword : PSCmdlet
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

    [Cmdlet(VerbsCommon.Add, "SkyrimRecord")]
    public class AddSkyrimRecord : PSCmdlet
    {
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            Helpers.AddRecordHelper(Mod, Record);
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimWinningContextOverrides")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetSkyrimWinningContextOverrides : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        // set taken from MajorRecordTypes
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
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
            foreach (var rec in OverrideMixIns.WinningOverrides(ModrifyConfig.TryGetEnvironment().LoadOrder.PriorityOrder, Helpers.MajorRecordTypes[RecordType], IncludeDeletedRecords).ToArray())
            {
                WriteObject(rec);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimMajorRecords", DefaultParameterSetName = "bymodkey")]
    [OutputType(typeof(IEnumerable<IMajorRecordGetter>))]
    public class GetSkyrimMajorRecords : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "bymod")]
        public required ISkyrimModGetter Mod;

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "bymodkey")]
        public ModKey ModKey;

        [Parameter(ParameterSetName = "bymodkey")]
        [Parameter(ParameterSetName = "bymod")]
        // Set taken from MajorRecordTypes
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
        public string? RecordType;

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "bymodkey")
            {
                Mod = SkyrimMod.CreateFromBinaryOverlay(ModrifyConfig.ResolveModkeyPath(ModKey), ModrifyConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease());
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

    [Cmdlet(VerbsCommon.Copy, "SkyrimRecordAsOverride")]
    [OutputType(typeof(SkyrimMajorRecord))]
    public class CopySkyrimRecordAsOverride : PSCmdlet
    {
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
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
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
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
        [Alias("DestinationMod", "TargetMod")]
        [Parameter(Mandatory = true)]
        public required ISkyrimMod Mod;

        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public required ISkyrimMajorRecordGetter Record;

        protected override void ProcessRecord()
        {
            WriteObject(Helpers.CopyHelper(Mod, Record, CopyType.DeepCopy));
        }
    }
}