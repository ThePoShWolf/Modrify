using System.Management.Automation;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Strings;
using Noggog;
using System.Reflection.Metadata;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Binary.Parameters;
using System.IO.Abstractions;

namespace PSMutagen.Fallout4
{
    [Cmdlet(VerbsCommon.Get, "FalloutMod", DefaultParameterSetName = "readwrite")]
    [OutputType(typeof(IFallout4ModDisposableGetter), ParameterSetName = new string[] { "readonly" })]
    [OutputType(typeof(IFallout4Mod), ParameterSetName = new string[] { "readwrite" })]
    public class GetFalloutMod : Cmdlet
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

        [Parameter(ParameterSetName = "readonly")]
        public SwitchParameter ReadOnly;

        protected override void ProcessRecord()
        {
            if (ReadOnly.IsPresent)
            {
                WriteObject(Fallout4Mod.CreateFromBinaryOverlay(Path, StringsParam, FileSystem));
            }
            else
            {
                WriteObject(Fallout4Mod.CreateFromBinary(Path, ImportMask, StringsParam, Parallel, FileSystem));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "FalloutMod")]
    [OutputType(typeof(IFallout4Mod))]
    public class NewFalloutMod : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public ModKey ModKey;

        protected override void ProcessRecord()
        {
            WriteObject(new Fallout4Mod(ModKey));
        }
    }

    [Cmdlet(VerbsCommunications.Write, "FalloutMod")]
    public class WriteFalloutMod : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public required IMod Mod;

        [Parameter()]
        public FileInfo? Path;

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