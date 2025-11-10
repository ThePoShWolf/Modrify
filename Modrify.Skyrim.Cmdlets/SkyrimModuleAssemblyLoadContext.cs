using System.Reflection;
using System.Runtime.Loader;

namespace Modrify.Skyrim.Cmdlets
{
    internal class SkyrimModuleAssemblyLoadContext : AssemblyLoadContext
    {
        private readonly string _dependencyDirPath;

        public SkyrimModuleAssemblyLoadContext(string dependencyDirPath)
        {
            _dependencyDirPath = dependencyDirPath;
        }

        protected override Assembly? Load(AssemblyName assemblyName)
        {
            // Handle framework assembly version redirects
            if (assemblyName.Name == "System.Text.Encoding.CodePages")
            {
                // Redirect to the version already loaded in PowerShell
                var loadedAssembly = System.AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "System.Text.Encoding.CodePages");
                if (loadedAssembly != null)
                {
                    return loadedAssembly;
                }
            }

            // We do the simple logic here of
            // looking for an assembly of the given name
            // in the configured dependency directory
            string assemblyPath = Path.Combine(
                _dependencyDirPath,
                $"{assemblyName.Name}.dll");

            if (File.Exists(assemblyPath))
            {
                // The ALC must use inherited methods to load assemblies
                // Assembly.Load*() won't work here
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }
    }
}