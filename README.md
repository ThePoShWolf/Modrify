[![PSMutagen](https://img.shields.io/powershellgallery/v/PSMutagen.svg?style=flat-square&label=PSMutagen "PSMutagen")](https://www.powershellgallery.com/packages/PSMutagen/)

# PSMutagen

Powered by [Mutagen](https://github.com/Mutagen-Modding/Mutagen).

PSMutagen is a PowerShell module with the goals of:

- Providing the same or similar features as whats available to scripting in xEdit
- Make mod reading, editing, overriding (etc) easily accessible at the commandline
- Expose the complete Mutagen functionality in PowerShell

I started this module after stumbling across the [Mutagen](https://github.com/Mutagen-Modding/Mutagen) .NET library. I have a strong preference for PowerShell over Pascal, so I was very excited to finally have a way to script Bethesda mods with PowerShell. My professional interests tend to bleed over into my personal interests, so of course I enjoy automation in Skyrim and Fallout 4.

As of this writing, this mod is in v0.0.2, which is its initial public release. As I have time to work with this module to convert some of the xEdit Pascal scripts and write some of my own, expect better examples and more robust code. If you have an issue, question, or wonder how to do a certain thing with this module, please feel free to open up an issue.

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

## Usage

### Setup

Start by setting your game environment, so Mutagen knows where to look:

```powershell
Set-MutaGameEnvironment -Release SkyrimSE
```

Once you've set the game environment, you will be able to use the other commands in each module.

### Reporting

PSMutagen is able to handle reporting very well. For example, if you'd like to build a spread sheet of all people NPCs with their name, race, and factions, you can do so with:

```powershell
# Get the game environment to capture the LinkCache object
$ge = Set-MutaGameEnvironment SkyrimSE -Passthru
# List out the races
$raceStrings = 'ArgonianRace','BretonRace','DarkElfRace','ElderRace','HighElfRace','ImperialRace','KhajiitRace','NordRace','OrcRace','RedguardRace'
$races = Get-SkyrimWinningOverrides -RecordType Race | ?{$raceStrings -contains $_.EditorID}
# Get the NPCs with those races
$npcs = Get-SkyrimWinningOverrides -RecordType Npc | ?{$races -contains $_.Race}
# Build the output object and export to an Excel spreadsheet
$npcs | %{
    [pscustomobject]@{
        Name = $_.Name.String
        Race = $_.Race.TryResolve($ge.LinkCache).Name.String
        Factions = ($_.Factions.Faction | %{$_.TryResolve($ge.LinkCache).Name.String}) -join ', '
    }
} | Export-Excel .\SkyrimPeople.xlsx -TableName Npcs -Autosize
```

_This may throw errors as some factions do not have a name._

This example depends on the [ImportExcel]() module for the `Export-Excel` function.

If you wanted to run that report on a specific mod, you can switch out `Get-SkyrimWinningOverrides` for `Get-SkyrimMajorRecords` and specify a mod by path or ModKey.