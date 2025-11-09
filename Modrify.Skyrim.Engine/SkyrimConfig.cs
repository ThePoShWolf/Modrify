using System.Management.Automation;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Noggog;
using System.Reflection.Metadata;
using System.Collections;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Order;
using Mutagen.Bethesda.Plugins.Records;
using Mutagen.Bethesda.Skyrim;

namespace Modrify.Skyrim.Core
{
    public enum CopyType
    {
        AsOverride,
        AsNewRecord,
        DeepCopy
    }

    public class SkyrimConfig
    {
        public static IGameEnvironment<ISkyrimMod, ISkyrimModGetter>? Environment;

        public static IGameEnvironment<ISkyrimMod, ISkyrimModGetter> TryGetEnvironment()
        {
            if (Environment == null)
            {
                // Auto-detect Skyrim environment
                foreach (SkyrimRelease release in Enum.GetValues<SkyrimRelease>())
                {
                    try
                    {
                        var env = GameEnvironment.Typical.Skyrim(release);
                        if (Directory.Exists(env.DataFolderPath))
                        {
                            Environment = env;
                            break;
                        }
                    }
                    catch
                    {
                        // Continue trying other releases
                    }
                }

                if (Environment == null)
                {
                    throw new InvalidOperationException("Unable to auto-detect Skyrim installation. Please ensure Skyrim is properly installed.");
                }
            }
            return Environment;
        }

        public static string ResolveModkeyPath(ModKey modkey)
        {
            return $"{TryGetEnvironment().DataFolderPath}\\{modkey}";
        }
    }

    [Cmdlet(VerbsCommon.Set, "SkyrimGame")]
    [OutputType(typeof(IGameEnvironment<ISkyrimMod, ISkyrimModGetter>), ParameterSetName = new string[] { "passthru" })]
    public class SetSkyrimGameEnvironment : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public SkyrimRelease Release { get; set; }

        [Parameter(ParameterSetName = "passthru")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            SkyrimConfig.Environment = GameEnvironment.Typical.Skyrim(Release);
            if (PassThru.IsPresent)
            {
                WriteObject(SkyrimConfig.TryGetEnvironment());
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "SkyrimGame")]
    [OutputType(typeof(IGameEnvironment<ISkyrimMod, ISkyrimModGetter>))]
    public class GetSkyrimGameEnvironment : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(SkyrimConfig.TryGetEnvironment());
        }
    }

    [Cmdlet(VerbsCommon.Get, "ModLoadOrder")]
    [OutputType(typeof(ISkyrimModGetter))]
    public class GetSkyrimModLoadOrder : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var env = SkyrimConfig.TryGetEnvironment();
            WriteObject(env.LoadOrder.ToArray(), true);
        }
    }

    [Cmdlet(VerbsCommon.Get, "ModPriorityOrder")]
    [OutputType(typeof(ISkyrimModGetter))]
    public class GetSkyrimModPriorityOrder : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            var env = SkyrimConfig.TryGetEnvironment();
            WriteObject(env.LoadOrder.PriorityOrder.ToArray(), true);
        }
    }
}