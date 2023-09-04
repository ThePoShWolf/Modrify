# PSMutagen

Powered by [Mutagen](https://github.com/Mutagen-Modding/Mutagen).

PSMutagen is a PowerShell module intended to:

- Provide the same or similar features as whats available to Pascal scripts in xEdit
- Make mod reading, editing, overriding (etc) easily accessible at the commandline

## Installation

PSMutagen, and its submodules, require [PowerShell 7+](https://github.com/powershell/powershell/releases) and will not work in Windows PowerShell. You can test your PowerShell version with:

```powershell
$PSVersionTable
```

PSMutagen, and its submodules, are available in the PowerShell Gallery, so they can be installed with:

```powershell
Install-Module PSMutagen
```

Since module dependency is enabled, if you install a submodule, it will automatically install the root module as well.

The current list of submodules:

- `PSMutagen.Skyrim`
- `PSmutagen.Fallout4`

## Basic usage

Start by setting your game environment:

```powershell
Set-MutaGameEnvironment -Release SkyrimSE
```