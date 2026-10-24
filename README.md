# AutoDualPerks

**AutoDualPerks** is a lightweight, crash-free mod for **Mount & Blade II: Bannerlord** (v1.4.8+) that automatically unlocks both perk options for the player character whenever skill level requirements are met.

## Features

- **Automatic Dual Perks**: When reaching a perk milestone (25, 50, 75, etc.), the player character receives both perk options automatically.
- **Retroactive Unlocking**: Upon loading any existing save or starting a new campaign, all previously reached perk tiers are evaluated and missing perks are granted immediately.
- **Silent & Clean**: Runs completely in the background without spamming the chat log or displaying intrusive popups.
- **Visual UI Parity**: Includes Harmony patches for `PerkVM` so both perk icons remain highlighted, selected, and active in the Character Development screen (`C` menu).
- **Zero Heavy Dependencies**: Completely independent of MCM, ButterLib, or UIExtenderEx. No risk of breaking when third-party libraries update. Safe for saves.

## Requirements

- Mount & Blade II: Bannerlord (v1.4.8+)
- [Harmony](https://github.com/BUTR/Bannerlord.Harmony)

## Installation

1. Download the latest release or clone the repository.
2. Place the `AutoDualPerks` folder into your Bannerlord `Modules` directory:
   `...\Mount & Blade II Bannerlord\Modules\AutoDualPerks\`
3. Enable **Auto Dual Perks** in the Bannerlord Launcher below the official modules (`StoryMode`, `CustomBattle`, `NavalDLC`).

## Building from Source

```bash
dotnet build -c Release
```

## License

MIT License
