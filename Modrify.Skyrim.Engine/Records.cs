using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins.Records;
using Noggog;
using System.Reflection.Metadata;
using Modrify.Skyrim.Core;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Plugins.Aspects;

namespace Modrify.Skyrim.Engine.Internal
{
    public static class SkyrimRecords
    {
        public static IEnumerable<object> GetSkyrimMajorRecords(string? modKey = null, object? mod = null, string? recordType = null)
        {
            ISkyrimModGetter? skyrimMod = null;

            if (mod != null)
            {
                skyrimMod = mod as ISkyrimModGetter;
                if (skyrimMod == null)
                    throw new ArgumentException("Provided mod is not a valid Skyrim mod", nameof(mod));
            }
            else if (!string.IsNullOrEmpty(modKey))
            {
                var modKeyObj = new ModKey(modKey, ModType.Plugin);
                var path = SkyrimConfig.ResolveModkeyPath(modKeyObj);
                var release = SkyrimConfig.TryGetEnvironment().GameRelease.ToSkyrimRelease();
                skyrimMod = SkyrimMod.CreateFromBinaryOverlay(path, release);
            }
            else
            {
                throw new ArgumentException("Either ModKey or Mod must be provided");
            }

            var records = skyrimMod.EnumerateMajorRecords();

            if (!string.IsNullOrEmpty(recordType))
            {
                records = records.Where(r => r.GetType().Name.Contains(recordType));
            }

            return records.Cast<object>();
        }

        public static IEnumerable<object> GetSkyrimWinningOverrides(string recordType, bool includeDeletedRecords = false)
        {
            var env = SkyrimConfig.TryGetEnvironment();
            var loadOrder = env.LoadOrder;

            // This is a simplified implementation - the real implementation would need
            // to properly handle the winning override logic from the original cmdlet
            var results = new List<object>();

            foreach (var modListing in loadOrder.PriorityOrder)
            {
                if (modListing.Mod == null) continue;

                var records = modListing.Mod.EnumerateMajorRecords()
                    .Where(r => r.GetType().Name.Contains(recordType));

                if (!includeDeletedRecords)
                {
                    records = records.Where(r => !r.IsDeleted);
                }

                results.AddRange(records.Cast<object>());
            }

            return results;
        }

        public static IEnumerable<object> GetSkyrimWinningContextOverrides(string recordType, bool includeDeletedRecords = false)
        {
            var env = SkyrimConfig.TryGetEnvironment();
            var linkCache = env.LinkCache;

            // This is a simplified implementation - would need proper winning context logic
            var results = new List<object>();

            // Implementation would go here based on the original cmdlet logic

            return results;
        }

        // Additional methods for record manipulation could be added here
        // For now, focusing on the main cmdlets used in the facade
    }
}