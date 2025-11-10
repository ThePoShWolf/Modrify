using System.Collections.Generic;
using Modrify.Skyrim.Engine.Internal;
using Modrify.Core;

namespace Modrify.Skyrim.Engine
{
    /// <summary>
    /// Engine facade that provides access to Skyrim mod functionality through the custom ALC
    /// </summary>
    public static class SkyrimEngine
    {
        public static object GetSkyrimMod(string modKey, bool readOnly = false)
        {
            return SkyrimMods.GetSkyrimMod(modKey, readOnly);
        }

        public static object GetSkyrimModFromPath(string path, bool readOnly = false)
        {
            return SkyrimMods.GetSkyrimModFromPath(path, readOnly);
        }

        public static object NewSkyrimMod(string modKey, string release = "SkyrimSE")
        {
            return SkyrimMods.NewSkyrimMod(modKey, release);
        }

        public static void WriteSkyrimMod(object mod, string? path = null)
        {
            SkyrimMods.WriteSkyrimMod(mod, path);
        }

        public static IEnumerable<object> GetSkyrimMajorRecords(string? modKey = null, object? mod = null, string? recordType = null)
        {
            return SkyrimRecords.GetSkyrimMajorRecords(modKey, mod, recordType);
        }

        public static IEnumerable<object> GetSkyrimWinningOverrides(string recordType, bool includeDeletedRecords = false)
        {
            return SkyrimRecords.GetSkyrimWinningOverrides(recordType, includeDeletedRecords);
        }

        public static object SetSkyrimGame(string release)
        {
            var cmdlet = new SetGameEnvironment();
            if (System.Enum.TryParse<Mutagen.Bethesda.GameRelease>(release, out var gameRelease))
            {
                cmdlet.Game = gameRelease;
                cmdlet.PassThru = true;

                // This is a simplified implementation - real cmdlet execution would be more complex
                var oldEnvironment = ModrifyConfig.Environment;
                try
                {
                    ModrifyConfig.Environment = Mutagen.Bethesda.Environments.GameEnvironment.Typical.Construct(gameRelease);
                    return ModrifyConfig.Environment;
                }
                catch
                {
                    ModrifyConfig.Environment = oldEnvironment;
                    throw;
                }
            }
            throw new System.ArgumentException($"Invalid game release: {release}");
        }

        public static object GetSkyrimGame()
        {
            return ModrifyConfig.TryGetEnvironment();
        }
    }
}