# Stardew Valley Range Highlight

A Stardew Valley SMAPI mod for adding range highlighting.

## For mod users

This mod adds highlighting for the range of the following items and buildings:

* Sprinklers (including the Prismatic Sprinkler from the Prismatic Tools mod)
* Scarecrows (including the Deluxe Scarecrow)
* Bee Houses
* Junimo Huts
* Bombs (see note below)

Ranges are shown automatically when the corresponding item is equipped,
or when the cursor is over a building of the appropriate type.  Hold down one
of the configured hotkeys (see [Configuration](#configuration) below) to show ranges regardless of cursor
position or what item is equipped.  Each range type has a different
highlight color, which is also configurable (see [Configuration](#configuration) below).

See the [Screenshots](Screenshots/) directory for some examples.

#### A note on bombs

Bombs are weird.  They don't have a single range of effect, they have
three different ranges.

  * The innermost area is where the bomb can cause dirt to turn
    into hoed ground.  The default configuration is to not show
    this area, but it can be enabled.
  * The "normal" range is the area where rocks and many items are
    destroyed.  This is was the only range shown version 1.1.
  * The outermost area is where crops are destroyed, flooring is
    disrupted, and the player takes damage.  (Note that this area
    is not centered on the bomb.)  The default configuration does
    show this range, but it can be disabled.

Version 1.1 shows only the "normal" range, and only around the cursor
location when a bomb is equipped.  Starting in version 1.2, multiple
ranges are shown (if configured), and each bomb placed on the ground
and not yet exploded shows its ranges (unless disabled in configuration).

### Compatibility

Works with Stardew Valley 1.4, single player and multiplayer.
No known incompatibilities with other mods, although if another mod also
shows range highlights (e.g., UI Info Suite) then each mod will show
its own highlight.  The result is not horrible, but you probably
want to disable the other mod's range highlighting if possible (for example, by
using UI Info Suite's in-game menu to disable its range highlighting).

### Installation

Follow the usual installation proceedure for SMAPI mods:
1. Install [SMAPI](https://smapi.io)
2. Download the latest realease of this mod and unzip it into the `Mods` directory
3. Run the game using SMAPI

### Configuration

When SMAPI runs the mod for the first time it will create a `config.json`
in the mod directory.  You can edit this file to configure the hotkeys and
highlight colors.  The default configuration is summarized in the table below.

| | hotkey | highlight tint
| --- | --- | ---
| All Range Highlights | `LeftShift` | as listed below
| Sp**r**inklers | `R` | blue
| Scarecr**o**ws | `O` | green
| Bee **H**ouses | `H` | yellow
| **J**unimo Huts | `J` | white
| Bombs | (none) | red/orange

If the `hotkeysToggle` configuration property is set to `true` then the hotkeys will
behave as a toggle switch rather than needing to be held down.

You can also configure whether to show the inner and outer ranges of bombs,
and whether to show the ranges of "ticking" bombs placed on the ground.

Finally, the Show*THING*Range options allow you to turn off highlighting of *thing*
completely.  (Maybe you don't want to see it.  Maybe some other mod is already
provides highlighting.  In any case, it's not going to hurt my feelings if you
want to disable some features.)

## For mod developers

This mod provides an API for adding highlighting to items and buildings.
It then uses this API to add highlights as described above.  The API includes
functions to:
* Describe common highlight shapes
* Get the tint colors configured for this mod
* Add highlighters based on `Building` object or item name

For the full API, see [`IRangeHighlightAPI.cs`](https://github.com/jltaylor-us/StardewRangeHighlight/blob/default/RangeHighlight/IRangeHighlightAPI.cs).

For general information on how to use another mod's API in your mod,
see the [Mod Integration](https://stardewvalleywiki.com/Modding:Modder_Guide/APIs/Integrations)
page on the Stardew Valley Wiki.

_Disclaimer:_  Highlighting for bombs does not use the public API.  They're
weird, and I didn't want to make a messy API to support them without some other
use case for it.