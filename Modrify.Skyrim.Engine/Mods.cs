using System;
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
using Modrify.Skyrim.Core;

namespace Modrify.Skyrim.Engine.Internal
{
    public static class SkyrimMods
    {
        public static object GetSkyrimMod(string modKey, bool readOnly = false)
        {
            var modKeyObj = new ModKey(modKey, ModType.Plugin);
            var path = SkyrimConfig.ResolveModkeyPath(modKeyObj);
            var release = SkyrimConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease();

            if (readOnly)
            {
                return SkyrimMod.CreateFromBinaryOverlay(path, release);
            }
            else
            {
                return SkyrimMod.CreateFromBinary(path, release);
            }
        }

        public static object NewSkyrimMod(string modKey, string release = "SkyrimSE")
        {
            var modKeyObj = new ModKey(modKey, ModType.Plugin);
            var releaseEnum = Enum.Parse<SkyrimRelease>(release);

            ISkyrimMod mod = new SkyrimMod(modKeyObj, releaseEnum);
            return mod;
        }

        public static void WriteSkyrimMod(object mod, string? path = null)
        {
            if (mod is not IMod skyrimMod)
                throw new ArgumentException("Object is not a valid Skyrim mod", nameof(mod));

            // Disable compression for all records
            foreach (var rec in skyrimMod.EnumerateMajorRecords())
            {
                rec.IsCompressed = false;
            }

            var outputPath = path != null
                ? new FileInfo(path)
                : new FileInfo(SkyrimConfig.ResolveModkeyPath(skyrimMod.ModKey));

            skyrimMod.WriteToBinary(outputPath);
        }
    }
}