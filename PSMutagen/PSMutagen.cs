using System.Management.Automation;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Environments;
using Noggog;
using System.Reflection.Metadata;
using System.Collections;
using Mutagen.Bethesda.Plugins;

namespace PSMutagen.Core
{

    public enum CopyType
    {
        AsOverride,
        AsNewRecord,
        DeepCopy
    }

    public class PSMutagenConfig
    {
        public static IGameEnvironment? Environment;

        public static IGameEnvironment TryGetEnvironment()
        {
            if (Environment == null)
            {
                throw new InvalidOperationException("Unable to determine release. Please set the game environment first by running 'Set-MutaGameEnvironment' or passing the release with the -Release parameter");
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
                    return "PSMutagen.Skyrim";
                case GameRelease.Fallout4:
                    return "PSMutagen.Fallout4";
                default:
                    throw new ArgumentException($"Game release '{Game}' is not yet supported. Please open an issue on PSMutagen's GitHub repository.");
            }
        }

        public static string ResolveModkeyPath(ModKey modkey)
        {
            return $"{TryGetEnvironment().DataFolderPath}\\{modkey}";
        }
    }

    [Cmdlet(VerbsCommon.Set, "MutaGameEnvironment")]
    [OutputType(typeof(IGameEnvironment), ParameterSetName = new string[] { "passthru" })]
    public class SetGameEnvironment : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public GameRelease Game { get; set; }

        [Parameter(ParameterSetName = "passthru")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            if (PSMutagenConfig.CheckIfModuleIsLoaded(Game))
            {
                PSMutagenConfig.Environment = GameEnvironment.Typical.Construct(Game);
                if (PassThru.IsPresent)
                {
                    WriteObject(PSMutagenConfig.TryGetEnvironment());
                }
            }
            else
            {
                string module = PSMutagenConfig.GetModuleForGameRelease(Game);
                throw new Exception($"Game release '{Game}' requires the '{module}' module to be loaded. Please load that module and try again.");
            }
        }
    }

    [Cmdlet(VerbsCommon.Get, "MutaGameEnvironment")]
    [OutputType(typeof(IGameEnvironment))]
    public class GetGameEnvironment : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(PSMutagenConfig.TryGetEnvironment());
        }
    }
}