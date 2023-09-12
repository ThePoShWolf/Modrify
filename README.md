[![PSMutagen](https://img.shields.io/powershellgallery/v/PSMutagen.svg?style=flat-square&label=PSMutagen "PSMutagen")](https://www.powershellgallery.com/packages/PSMutagen/)

# PSMutagen

Powered by [Mutagen](https://github.com/Mutagen-Modding/Mutagen).

PSMutagen is a PowerShell module with the goals of:

- Providing the same or similar features as whats available to scripting in xEdit
- Make mod reading, editing, overriding (etc) easily accessible at the commandline
- Expose the complete Mutagen functionality in PowerShell

I started this module after stumbling across the [Mutagen](https://github.com/Mutagen-Modding/Mutagen) .NET library. I have a strong preference for PowerShell over Pascal, so I was very excited to finally have a way to script Bethesda mods with PowerShell. My professional interests tend to bleed over into my personal interests, so of course I enjoy automation in Skyrim and Fallout 4.

As of this writing, this mod is in v0.1.0, which is its initial public release. Expect better examples as I convert some of the small patches I've made to PSMutagen scripts. Along the way I will also convert the xEdit examples to PSMutagen.

If you have an issue, question, or wonder how to do a certain thing with this module, please feel free to open up an issue.

## Installation

PSMutagen, and its submodules, require [PowerShell 7.3+](https://github.com/powershell/powershell/releases) and will not work in any earlier version of PowerShell (7.2-) or Windows PowerShell (PowerShell 5.1-). You can test your PowerShell version with:

```powershell
$PSVersionTable
```

PSMutagen, and its submodules, are available in the PowerShell Gallery, so they can be installed with:

```powershell
Install-Module PSMutagen
```

Since module dependency has been configured, if you install a submodule, it will automatically install the root module as well.

The current list of submodules:

- `PSMutagen.Skyrim`: [![PSMutagen.Skyrim](https://img.shields.io/powershellgallery/v/PSMutagen.Skyrim.svg?style=flat-square&label=PSMutagen.Skyrim "PSMutagen.Skyrim")](https://www.powershellgallery.com/packages/PSMutagen.Skyrim/)
- `PSMutagen.Fallout4`: [![PSMutagen.Fallout4](https://img.shields.io/powershellgallery/v/PSMutagen.Fallout4.svg?style=flat-square&label=PSMutagen.Fallout4 "PSMutagen.Fallout4")](https://www.powershellgallery.com/packages/PSMutagen.Fallout4/)

This list is based on support by the underlying library ([Mutagen](https://github.com/Mutagen-Modding/Mutagen)) as well as implementation here into this module. If you don't see a specific Bethesda game in this list, check Mutagen first. If Mutagen supports it, open an issue here and I will look at implementation.

## Basic usage

Start by setting your game environment, so Mutagen knows where to look:

```powershell
Set-MutaGameEnvironment -Release SkyrimSE
```

Once you've set the game environment, you will be able to use the other commands in each module.