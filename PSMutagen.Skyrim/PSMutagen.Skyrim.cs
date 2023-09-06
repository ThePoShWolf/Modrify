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
using PSMutagen.Core;

namespace PSMutagen.Skyrim
{
    [Cmdlet(VerbsCommon.Get, "SkyrimMod", DefaultParameterSetName = "readwrite")]
    [OutputType(typeof(ISkyrimModDisposableGetter), ParameterSetName = new string[] { "readonly" })]
    [OutputType(typeof(ISkyrimMod), ParameterSetName = new string[] { "readwrite" })]
    public class GetSkyrimMod : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public required ModPath Path;

        [Parameter()]
        public GroupMask? ImportMask;

        [Parameter()]
        public StringsReadParameters? StringsParam;

        [Parameter()]
        public bool Parallel;

        [Parameter()]
        public IFileSystem? FileSystem;

        [Parameter()]
        public SkyrimRelease Release = PSMutagenConfig.TryGetGameRelease().ToSkyrimRelease();

        [Parameter(ParameterSetName = "readonly")]
        public SwitchParameter ReadOnly;

        protected override void ProcessRecord()
        {
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
    public class NewSkyrimMod : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public required ModKey ModKey;

        [Parameter()]
        public SkyrimRelease Release = PSMutagenConfig.Environment.GameRelease.ToSkyrimRelease();

        protected override void ProcessRecord()
        {
            WriteObject(new SkyrimMod(ModKey, Release));
        }
    }

    [Cmdlet(VerbsCommunications.Write, "SkyrimMod")]
    public class WriteSkyrimMod : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public required IMod Mod;

        [Parameter(Mandatory = true)]
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