[![Modrify](https://img.shields.io/powershellgallery/v/Modrify.svg?style=flat-square&label=Modrify "Modrify")](https://www.powershellgallery.com/packages/Modrify/)

# Modrify

Powered by [Mutagen](https://github.com/Mutagen-Modding/Mutagen).

Modrify is a PowerShell module with the goals of:

- Providing the same or similar features as whats available using Pascal in xEdit
- Make mod reading, editing, overriding (etc) easily accessible at the commandline
- Expose Mutagen's functionality in PowerShell
- Create patchers, like Synthesis, but in PowerShell

This is not intended to compete with or slight xEdit or Synthesis. This is written purely out of my desire to work through PowerShell.

I started this module after stumbling across the [Mutagen](https://github.com/Mutagen-Modding/Mutagen) .NET library. I have a strong preference for PowerShell over Pascal, so I was very excited to finally have a way to script Bethesda mods with PowerShell. My professional interests tend to bleed over into my personal interests, so of course I enjoy automation in the Bethesda games that I play.

As I have time to work with this module to convert some of the xEdit Pascal scripts and write some of my own, expect better examples and more robust code. If you have an issue, question, or wonder how to do a certain thing with this module, please feel free to open up an issue.

## Installation

Modrify, and its submodules, require [PowerShell 7.3+](https://github.com/powershell/powershell/releases) and will not work in any earlier version of PowerShell (7.2-) or Windows PowerShell (PowerShell 5.1-). You can test your PowerShell version with:

```powershell
$PSVersionTable
```

Modrify, and its submodules, are available in the PowerShell Gallery, so they can be installed with:

```powershell
Install-Module Modrify
```

Since module dependency has been configured, if you install a submodule, it will automatically install the root module as well.

The current list of submodules:

- `Modrify.Skyrim`: [![Modrify.Skyrim](https://img.shields.io/powershellgallery/v/Modrify.Skyrim.svg?style=flat-square&label=Modrify.Skyrim "Modrify.Skyrim")](https://www.powershellgallery.com/packages/Modrify.Skyrim/)
- `Modrify.Fallout4`: [![Modrify.Fallout4](https://img.shields.io/powershellgallery/v/Modrify.Fallout4.svg?style=flat-square&label=Modrify.Fallout4 "Modrify.Fallout4")](https://www.powershellgallery.com/packages/Modrify.Fallout4/)

This list is based on support by the underlying library ([Mutagen](https://github.com/Mutagen-Modding/Mutagen)) as well as implementation here into this module. If you don't see a specific Bethesda game in this list, check Mutagen first. If Mutagen supports it, open an issue here and I will look at implementation.

## Usage

### Setup

Start by setting your game environment, so Mutagen knows where to look:

```powershell
Set-ModrifyGame -Release SkyrimSE
```

Once you've set the game environment, you will be able to use the other commands in each module.

### Getting data

Modrify is able to retrieve data about your load order or specific mods very well. For example, if you'd like to build a spreadsheet of all people NPCs with their name, race, and factions, you can do so with:

```powershell
# Get the game environment to capture the LinkCache object
$ge = Set-ModrifyGame SkyrimSE -Passthru
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
        Factions = ($_.Factions.Faction | %{$_.TryResolve($ge.LinkCache).EditorID}) -join ', '
    }
} | Export-Excel .\SkyrimPeople.xlsx -TableName Npcs -Autosize
```

_This may throw errors trying to resolve factions, I'm not yet sure why. It still works._

This example depends on the [ImportExcel](https://github.com/dfinke/ImportExcel) module for the `Export-Excel` function.

If you wanted to run that report on a specific mod, you can switch out `Get-SkyrimWinningOverrides` for `Get-SkyrimMajorRecords` and specify a mod by path or ModKey.

### Creating patches

This module can be used for creating patches. For example, if you needed to add a specific keyword to some armors:

```powershell
$ge = Set-ModrifyGame SkyrimSE -Passthru
# Create a new mod in memory
$newMod = New-SkyrimMod -ModKey 'MyPatch.esp'
# Make the new mod light (esl)
# This will be easier in the future
$newmod.ModHeader.Flags = [Mutagen.Bethesda.Skyrim.SkyrimModHeader+HeaderFlag]::LightMaster
# Get the keyword to add
$keyword = Get-SkyrimMajorRecords -ModKey 'Skyrim.esm' -RecordType Keyword | ?{$_.EditorID -eq 'ArmorClothing'}
# Get the armors to add keywords to and copy them as override to the new mod
# You could filter for specific armors using Where-Object (?)
$armors = Get-SkyrimMajorRecords -ModKey 'Skyrim.esm' -RecordType Armor | Copy-SkyrimRecordAsOverride -Mod $newmod
# Add the keyword
$armors | Add-SkyrimKeyword $keyword
# Write the patch to disk
Write-SkyrimMod $newMod -Path "$($ge.DataFolderPath)\$($newMod.ModKey)"
```

## Contributing

The easiest way to contribute is to submit issues and provide detailed information about the bug or suggestion that you have.

If you are the coding type, please feel free to fork, commit changes, and submit a PR.

### Building Modrify

Building Modrify requires .NET 7 and PowerShell 7.3+ with the `InvokeBuild` module installed. All other dependencies should be automatically resolved.

In the root of the repository, run:

```powershell
Invoke-Build -Task ModuleBuild
```

This will invoke the build script which will clean up the build folder (if it exists), run a dotnet clean -> restore -> publish, build the PowerShell manifest, and then collect all the required files in the `./build` folder. Once complete, you should be able to import any one of the modules with:

```powershell
Import-Module .\build\Modrify
Import-Module .\build\Modrify.Skyrim
```