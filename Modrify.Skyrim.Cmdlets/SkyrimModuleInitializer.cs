using System.Management.Automation;
using System.Reflection;
using System.Runtime.Loader;

namespace Modrify.Skyrim.Cmdlets
{
    public class SkyrimModuleResolveEventHandler : IModuleAssemblyInitializer, IModuleAssemblyCleanup
    {
        // Get the path of the dependency directory.
        // In this case we find it relative to the Modrify.Skyrim.Cmdlets.dll location
        private static readonly string s_dependencyDirPath = Path.GetFullPath(
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "",
                "lib"));

        private static readonly SkyrimModuleAssemblyLoadContext s_dependencyAlc = new(s_dependencyDirPath);

        public void OnImport()
        {
            // Add the Resolving event handler here
            AssemblyLoadContext.Default.Resolving += ResolveEngine;
            AssemblyLoadContext.Default.Resolving += ResolveFrameworkAssemblies;
        }

        public void OnRemove(PSModuleInfo psModuleInfo)
        {
            // Remove the Resolving event handler here
            AssemblyLoadContext.Default.Resolving -= ResolveEngine;
            AssemblyLoadContext.Default.Resolving -= ResolveFrameworkAssemblies;
        }

        private static Assembly? ResolveEngine(
            AssemblyLoadContext defaultAlc,
            AssemblyName assemblyToResolve)
        {
            // We only want to resolve the Modrify.Skyrim.Engine.dll assembly here.
            // Because this will be loaded into the custom ALC,
            // all of *its* dependencies will be resolved
            // by the logic we defined for that ALC's implementation.
            //
            // Note that we are safe in our assumption that the name is enough
            // to distinguish our assembly here,
            // since it's unique to our module.
            // There should be no other Modrify.Skyrim.Engine.dll on the system.
            if (assemblyToResolve.Name?.Equals("Modrify.Skyrim.Engine") != true)
            {
                return null;
            }

            // Allow our ALC to handle the directory discovery concept
            //
            // This is where Modrify.Skyrim.Engine.dll is loaded into our custom ALC
            // and then passed through into PowerShell's ALC,
            // becoming the bridge between both
            return s_dependencyAlc.LoadFromAssemblyName(assemblyToResolve);
        }

        private static Assembly? ResolveFrameworkAssemblies(AssemblyLoadContext context, AssemblyName assemblyToResolve)
        {
            // Handle framework assemblies that might have version conflicts
            var frameworkAssemblies = new[]
            {
                "System.Text.Encoding.CodePages",
                "System.Collections.Immutable",
                "System.Memory"
            };

            if (assemblyToResolve.Name != null &&
                frameworkAssemblies.Contains(assemblyToResolve.Name, StringComparer.OrdinalIgnoreCase))
            {
                // Try to find the assembly that's already loaded in the current context
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var loadedAssembly in loadedAssemblies)
                {
                    if (string.Equals(loadedAssembly.GetName().Name, assemblyToResolve.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return loadedAssembly;
                    }
                }

                // If not found in loaded assemblies, try to load from GAC or runtime
                try
                {
                    return Assembly.Load(new AssemblyName(assemblyToResolve.Name));
                }
                catch
                {
                    // If all else fails, return null to let the default resolution continue
                    return null;
                }
            }

            return null;
        }
    }
}