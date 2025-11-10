using System.Management.Automation;
using Modrify.Skyrim.Engine;

namespace Modrify.Skyrim.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "SkyrimMod")]
    public class GetSkyrimModCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ModKey { get; set; } = "";

        [Parameter()]
        public SwitchParameter ReadOnly { get; set; }

        protected override void ProcessRecord()
        {
            var result = SkyrimEngine.GetSkyrimMod(ModKey, ReadOnly.IsPresent);
            WriteObject(result);
        }
    }

    [Cmdlet(VerbsCommon.New, "SkyrimMod")]
    public class NewSkyrimModCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string ModKey { get; set; } = "";

        [Parameter()]
        public string Release { get; set; } = "SkyrimSE";

        protected override void ProcessRecord()
        {
            var result = SkyrimEngine.NewSkyrimMod(ModKey, Release);
            WriteObject(result);
        }
    }

    [Cmdlet(VerbsCommunications.Write, "SkyrimMod")]
    public class WriteSkyrimModCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public object Mod { get; set; } = new();

        [Parameter()]
        public string? Path { get; set; }

        protected override void ProcessRecord()
        {
            SkyrimEngine.WriteSkyrimMod(Mod, Path);
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimMajorRecords", DefaultParameterSetName = "bymodkey")]
    public class GetSkyrimMajorRecordsCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "bymod")]
        public required Object Mod;

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = "bymodkey")]
        public string ModKey;

        [Parameter(ParameterSetName = "bymodkey")]
        [Parameter(ParameterSetName = "bymod")]
        // Set taken from MajorRecordTypes
        [ValidateSet("AcousticSpace", "ActionRecord", "Activator", "ActorValueInformation", "AddonNode", "AlchemicalApparatus", "Ammunition", "AnimatedObject", "APlacedTrap", "Armor", "ArmorAddon", "ArtObject", "AssociationType", "AStoryManagerNode", "BodyPartData", "Book", "CameraPath", "CameraShot", "Cell", "Class", "Climate", "CollisionLayer", "ColorRecord", "CombatStyle", "ConstructibleObject", "Container", "Debris", "DefaultObjectManager", "DialogBranch", "DialogResponses", "DialogTopic", "DialogView", "Door", "DualCastData", "EffectShader", "EncounterZone", "EquipType", "Explosion", "Eyes", "Faction", "Flora", "Footstep", "FootstepSet", "FormList", "Furniture", "GameSetting", "Global", "Grass", "Hair", "Hazard", "HeadPart", "IdleAnimation", "IdleMarker", "ImageSpace", "ImageSpaceAdapter", "Impact", "ImpactDataSet", "Ingestible", "Ingredient", "Key", "Keyword", "Landscape", "LandscapeTexture", "LensFlare", "LeveledItem", "LeveledNpc", "LeveledSpell", "Light", "LightingTemplate", "LoadScreen", "Location", "LocationReferenceType", "MagicEffect", "MaterialObject", "MaterialType", "Message", "MiscItem", "MoveableStatic", "MovementType", "MusicTrack", "MusicType", "NavigationMesh", "NavigationMeshInfoMap", "Npc", "ObjectEffect", "Outfit", "Package", "Perk", "PlacedNpc", "PlacedObject", "Projectile", "Quest", "Race", "Region", "Relationship", "ReverbParameters", "Scene", "Scroll", "ShaderParticleGeometry", "Shout", "SkyrimMajorRecord", "SoulGem", "SoundCategory", "SoundDescriptor", "SoundMarker", "SoundOutputModel", "Spell", "Static", "TalkingActivator", "TextureSet", "Tree", "VisualEffect", "VoiceType", "VolumetricLighting", "Water", "Weapon", "Weather", "WordOfPower", "Worldspace", "IPlaceableObject", "IReferenceableObject", "IExplodeSpawn", "IIdleRelation", "IObjectId", "IItem", "IItemOrList", "IConstructible", "IOutfitTarget", "IBindableEquipment", "IComplexLocation", "IDialog", "IOwner", "IRelatable", "IRegionTarget", "IAliasVoiceType", "ILockList", "IWorldspaceOrList", "IVoiceTypeOrList", "INpcOrList", "IWeaponOrList", "ISpellOrList", "IPlacedTrapTarget", "IHarvestTarget", "IMagicItem", "IKeywordLinkedReference", "INpcSpawn", "ISpellRecord", "IEmittance", "ILocationRecord", "IKnowable", "IEffectRecord", "ILinkedReference", "IPlaced", "IPlacedSimple", "IPlacedThing", "ISound")]
        public string? RecordType;

        protected override void ProcessRecord()
        {
            if (ParameterSetName == "bymodkey")
            {
                Mod = SkyrimEngine.GetSkyrimMod(ModKey);
            }
            foreach (var rec in SkyrimEngine.GetSkyrimMajorRecords(null, Mod, RecordType))
            {
                WriteObject(rec);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimWinningOverrides")]
    public class GetSkyrimWinningOverridesCommand : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string RecordType { get; set; } = "";

        [Parameter()]
        public SwitchParameter IncludeDeletedRecords { get; set; }

        protected override void ProcessRecord()
        {
            var results = SkyrimEngine.GetSkyrimWinningOverrides(RecordType, IncludeDeletedRecords.IsPresent);
            foreach (var result in results)
            {
                WriteObject(result);
            }
        }
    }

    [Cmdlet(VerbsCommon.Set, "SkyrimGame")]
    public class SetSkyrimGameCommand : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Release { get; set; } = "";

        [Parameter()]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            var result = SkyrimEngine.SetSkyrimGame(Release);
            if (PassThru.IsPresent)
            {
                WriteObject(result);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimGame")]
    public class GetSkyrimGameCommand : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var result = SkyrimEngine.GetSkyrimGame();
            WriteObject(result);
        }
    }
}