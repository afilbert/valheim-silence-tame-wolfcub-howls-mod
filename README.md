# Valheim - Silence Tame Wolf Cub Howls Mod

**_Works with Ashlands Update!_**

This is inspired by [Keezys_Better_Wolves mod](https://github.com/marqgray/valheim-better-wolves), and tweaks the approach to allow hunting with tamed wolves without the loss of enemy wolf howls.

### Problem

* Both adult and young enemy wolves will howl constantly whenever they're in earshot.
* Adult tame wolves will not howl, but their young offspring will.
* Breeding tame wolves shouldn't come at the cost of peace and quiet.

### Solution

* This mod will only silence howls if there are young _tame_ wolves within 30 meters.
* This allows exploring/hunting beyond the homestead without changing enemy wolf behavior.

While tame wolves won't attack one of their own, they're handy companions in most exploring/hunting situations. So having them present shouldn't also silence enemy wolves.

### Chickens

Chickens hadn't yet been introduced to the game when this mod was first developed. After cultivating a large and well-fed chicken population, they started strutting their stuff and making more and more love. Every time chickens make love (and maybe when laying eggs), an `sfx_love` audio clip plays that's the sound of a chicken crowing. That got annoying, quickly. So I build in support to turn it off. Optionally enjoy!

### Config

Configuration now allows:

* EnableToggleFlag, default: true
* SilenceAdultsFlag, default: false
* SilenceChickens, default: false
* SilenceRangeValue, default: 30f

Built with [BepInEx](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)

![wolfcub-no-howl](https://user-images.githubusercontent.com/523157/208265769-713d5c15-0c8e-4a8f-bdb1-219b065deb19.png)

[Image credit](https://www.reddit.com/r/NatureIsFuckingLit/comments/g7hkrh/a_baby_wolf_pup/)

### Releases

Releases in github repo are packaged for Thunderstore Mod Manager.

* 0.1.0 Add config to silence chicken crowing
* 0.0.7 Drop requirement for [Official BepInEx ConfigurationManager](https://valheim.thunderstore.io/package/Azumatt/Official_BepInEx_ConfigurationManager/) from Thunderstore manifest.json to allow flexibility
* 0.0.6 Target latest BepInEx version 5.4.2105
* 0.0.5 Update for latest version of BepInEx
* 0.0.4 Update for latest version of BepInEx and ConfigurationManager
* 0.0.3 Add config and ability to silence adult wolves
* 0.0.2 Update README and set latest BepInEx version
* 0.0.1 Initial publication
