using System.Management.Automation;
using Mutagen.Bethesda.Fallout4;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using Mutagen.Bethesda.Plugins;

namespace PSMutagen.Fallout4
{
    [Cmdlet(VerbsCommon.Get, "FalloutMod", DefaultParameterSetName = "readwrite")]
    [OutputType(typeof(IFallout4ModDisposableGetter), ParameterSetName = new string[] { "readonly" })]
    [OutputType(typeof(IFallout4Mod), ParameterSetName = new string[] { "readwrite" })]
    public class GetFalloutMod : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public Mutagen.Bethesda.Plugins.ModPath Path;

        [Parameter()]
        public Mutagen.Bethesda.Fallout4.GroupMask ImportMask;

        [Parameter()]
        public Mutagen.Bethesda.Strings.StringsReadParameters StringsParam;

        [Parameter()]
        public bool Parallel;

        [Parameter()]
        public System.IO.Abstractions.IFileSystem FileSystem;

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
        [Parameter()]
        public ModKey ModKey;

        protected override void ProcessRecord()
        {
            WriteObject(new Fallout4Mod(ModKey));
        }
    }
}