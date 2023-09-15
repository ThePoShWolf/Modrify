using System.Management.Automation;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Mutagen.Bethesda.Strings;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Parameters;
using System.IO.Abstractions;
using Modrify.Core;

namespace Modrify.Skyrim
{
    [Cmdlet(VerbsCommon.Get, "SkyrimMod", DefaultParameterSetName = "modkey-readwrite")]
    [OutputType(typeof(ISkyrimModDisposableGetter), ParameterSetName = new string[] { "path-readonly", "modkey-readonly" })]
    [OutputType(typeof(ISkyrimMod), ParameterSetName = new string[] { "path-readwrite", "path-readonly" })]
    public class GetSkyrimMod : PSCmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "path-readonly")]
        [Parameter(Mandatory = true, ParameterSetName = "path-readwrite")]
        public required ModPath Path;

        [Parameter(Mandatory = true, ParameterSetName = "modkey-readonly")]
        [Parameter(Mandatory = true, ParameterSetName = "modkey-readwrite")]
        public ModKey ModKey;

        [Parameter()]
        public GroupMask? ImportMask;

        [Parameter()]
        public StringsReadParameters? StringsParam;

        [Parameter()]
        public bool Parallel;

        [Parameter()]
        public IFileSystem? FileSystem;

        [Parameter()]
        public SkyrimRelease Release = ModrifyConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease();

        [Parameter(Mandatory = true, ParameterSetName = "modkey-readonly")]
        [Parameter(Mandatory = true, ParameterSetName = "path-readonly")]
        public SwitchParameter ReadOnly;

        protected override void ProcessRecord()
        {
            if (ParameterSetName.StartsWith("modkey"))
            {
                Path = ModrifyConfig.ResolveModkeyPath(ModKey);
            }
            if (ReadOnly.IsPresent)
            {
                WriteObject(SkyrimMod.CreateFromBinaryOverlay(Path, Release, StringsParam, FileSystem));
            }
            else
            {
                WriteObject(SkyrimMod.CreateFromBinary(Path, Release, ImportMask, StringsParam, Parallel, FileSystem));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "SkyrimMod")]
    [OutputType(typeof(ISkyrimMod))]
    public class NewSkyrimMod : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public required ModKey ModKey;

        [Parameter()]
        public SkyrimRelease Release = ModrifyConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease();

        [Parameter()]
        public SkyrimModHeader.HeaderFlag? HeaderFlag;

        protected override void ProcessRecord()
        {
            ISkyrimMod mod = new SkyrimMod(ModKey, Release);
            if (HeaderFlag != null)
            {
                mod.ModHeader.Flags = (SkyrimModHeader.HeaderFlag)HeaderFlag;
            }
            WriteObject(mod);
        }
    }

    [Cmdlet(VerbsCommunications.Write, "SkyrimMod")]
    public class WriteSkyrimMod : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public required IMod Mod;

        [Parameter()]
        public required FileInfo Path;

        [Parameter()]
        public BinaryWriteParameters BinaryWriteParameters = BinaryWriteParameters.Default;

        [Parameter()]
        public ParallelWriteParameters ParallelWriteParameters = ParallelWriteParameters.Default;

        [Parameter()]
        public IFileSystem? FileSystem;

        [Parameter()]
        public SwitchParameter SkipCompressionFix;

        protected override void ProcessRecord()
        {
            if (!SkipCompressionFix.IsPresent)
            {
                foreach (var rec in Mod.EnumerateMajorRecords())
                {
                    rec.IsCompressed = false;
                }
            }
            if (Path == null)
            {
                Path = new FileInfo(ModrifyConfig.ResolveModkeyPath(Mod.ModKey));
            }
            if (ParallelWriteParameters != null)
            {
                Mod.WriteToBinaryParallel(Path, BinaryWriteParameters, FileSystem, ParallelWriteParameters);
            }
            else
            {
                Mod.WriteToBinary(Path, BinaryWriteParameters, FileSystem);
            }
        }
    }
}