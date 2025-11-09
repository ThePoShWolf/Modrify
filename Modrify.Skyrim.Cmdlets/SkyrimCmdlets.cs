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

    [Cmdlet(VerbsCommon.Get, "SkyrimMajorRecords")]
    public class GetSkyrimMajorRecordsCommand : PSCmdlet
    {
        [Parameter()]
        public string? ModKey { get; set; }

        [Parameter()]
        public object? Mod { get; set; }

        [Parameter()]
        public string? RecordType { get; set; }

        protected override void ProcessRecord()
        {
            var results = SkyrimEngine.GetSkyrimMajorRecords(ModKey, Mod, RecordType);
            foreach (var result in results)
            {
                WriteObject(result);
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