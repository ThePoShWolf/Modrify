using System.Management.Automation;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Noggog;
using System.Reflection.Metadata;
using System.Collections;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Order;
using Mutagen.Bethesda.Plugins.Records;

namespace Modrify.Core
{

    public enum CopyType
    {
        AsOverride,
        AsNewRecord,
        DeepCopy
    }

    public class ModrifyConfig
    {
        public static IGameEnvironment? Environment;

        public static IGameEnvironment TryGetEnvironment()
        {
            if (Environment == null)
            {
                throw new InvalidOperationException("Unable to determine release. Please set the game environment first by running 'Set-ModrifyGame' or passing the release with the -Release parameter");
            }
            return Environment;
        }

        public static bool CheckIfModuleIsLoaded(GameRelease Game)
        {
            var sb = ScriptBlock.Create("param($Command, $Params) & $Command @Params");
            Hashtable parameters = new Hashtable
            {
                { "Name", GetModuleForGameRelease(Game) }
            };
            PSObject[] result = sb.Invoke("Get-Module", parameters).ToArray();
            return result.Length > 0;
        }

        public static string GetModuleForGameRelease(GameRelease Game)
        {
            switch (Game)
            {
                case GameRelease.SkyrimLE:
                case GameRelease.SkyrimVR:
                case GameRelease.SkyrimSE:
                case GameRelease.SkyrimSEGog:
                    return "Modrify.Skyrim";
                case GameRelease.Fallout4:
                    return "Modrify.Fallout4";
                default:
                    throw new ArgumentException($"Game release '{Game}' is not yet supported. Please open an issue on Modrify's GitHub repository.");
            }
        }

        public static string ResolveModkeyPath(ModKey modkey)
        {
            return $"{TryGetEnvironment().DataFolderPath}\\{modkey}";
        }
    }

    [Cmdlet(VerbsCommon.Set, "ModrifyGame")]
    [OutputType(typeof(IGameEnvironment), ParameterSetName = new string[] { "passthru" })]
    public class SetGameEnvironment : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public GameRelease Game { get; set; }

        [Parameter(ParameterSetName = "passthru")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            if (ModrifyConfig.CheckIfModuleIsLoaded(Game))
            {
                ModrifyConfig.Environment = GameEnvironment.Typical.Construct(Game);
                if (PassThru.IsPresent)
                {
                    WriteObject(ModrifyConfig.TryGetEnvironment());
                }
            }
            else
            {
                string module = ModrifyConfig.GetModuleForGameRelease(Game);
                throw new Exception($"Game release '{Game}' requires the '{module}' module to be loaded. Please load that module and try again.");
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "ModrifyGame")]
    [OutputType(typeof(IGameEnvironment))]
    public class GetGameEnvironment : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(ModrifyConfig.TryGetEnvironment());
        }
    }

    [Cmdlet(VerbsCommon.Get, "ModLoadOrder")]
    [OutputType(typeof(ILoadOrderGetter<IModListingGetter<IModGetter>>))]
    public class GetModLoadOrder : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(ModrifyConfig.TryGetEnvironment().LoadOrder.ToArray());
        }
    }

    [Cmdlet(VerbsCommon.Get, "ModPriorityOrder")]
    [OutputType(typeof(IEnumerable<IModListingGetter<IModGetter>>))]
    public class GetModPriorityOrder : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(ModrifyConfig.TryGetEnvironment().LoadOrder.PriorityOrder.ToArray());
        }
    }
}