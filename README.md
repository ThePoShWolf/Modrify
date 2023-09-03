# PSMutagen

Powered by [Mutagen](https://github.com/Mutagen-Modding/Mutagen).

PSMutagen is a PowerShell module intended to:

- Provide the same or similar features as whats available to Pascal scripts in xEdit
- Make mod reading, editing, overriding, etc easily accessible at the commandline

## Installation

PSMutagen requires [PowerShell 7+](https://github.com/powershell/powershell/releases)

PSMutagen is available in the PowerShell Gallery, so it can be installed with:

```powershell
Install-Module PSMutagen
```

## Basic usage

Start by setting your game environment:

```powershell
Set-MutaGameEnvironment -Release SkyrimSE
```