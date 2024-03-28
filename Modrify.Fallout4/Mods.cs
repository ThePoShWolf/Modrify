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
using Modrify.Core;

namespace Modrify.Fallout4
{
    [Cmdlet(VerbsCommon.Get, "FalloutMod", DefaultParameterSetName = "modkey-readwrite")]
    [OutputType(typeof(IFallout4ModDisposableGetter), ParameterSetName = new string[] { "path-readonly", "modkey-readonly" })]
    [OutputType(typeof(IFallout4Mod), ParameterSetName = new string[] { "path-readwrite", "path-readonly" })]
    public class GetFalloutMod : PSCmdlet
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
        public Fallout4Release Release = ModrifyConfig.TryGetEnvironment().GameRelease.ToFallout4Release();

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
                WriteObject(Fallout4Mod.CreateFromBinaryOverlay(Path, Release, StringsParam, FileSystem));
            }
            else
            {
                WriteObject(Fallout4Mod.CreateFromBinary(Path, Release, ImportMask, StringsParam, Parallel, FileSystem));
            }
        }
    }

    [Cmdlet(VerbsCommon.New, "FalloutMod")]
    [OutputType(typeof(IFallout4Mod))]
    public class NewFalloutMod : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public ModKey ModKey;


        [Parameter()]
        public Fallout4Release Release = ModrifyConfig.TryGetEnvironment().GameRelease.ToFallout4Release();

        protected override void ProcessRecord()
        {
            WriteObject(new Fallout4Mod(ModKey, Release));
        }
    }

    [Cmdlet(VerbsCommunications.Write, "FalloutMod")]
    public class WriteFalloutMod : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
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