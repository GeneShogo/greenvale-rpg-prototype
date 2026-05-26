\# Asset Manifest



Project: Greenvale Abbey / Greenvale RPG Prototype  

Repository: https://github.com/GeneShogo/greenvale-rpg-prototype  

Purpose: Track all third-party asset packs used in the Unity project, including source, license, import location, and usage notes.



\## Manifest Rules



\- Only use assets with a clear license.

\- Do not use World of Warcraft, Blizzard, or other copyrighted game assets.

\- Keep third-party assets under `Assets/ThirdParty/`.

\- Keep project-created prefabs, scenes, scripts, and edited game content under `Assets/\_Project/`.

\- If an asset is modified, note where the modified version lives.

\- Re-check license terms before public release or distribution.



\---



\## Quaternius - Stylized Nature MegaKit



\- Source: https://quaternius.com/packs/stylizednaturemegakit.html

\- Creator: Quaternius

\- License: CC0 License

\- License status: Free to use in personal, educational, and commercial projects

\- Verified date: 2026-05-25

\- Asset type: Environment / Nature

\- Formats available: FBX, OBJ, glTF

\- Imported to: `Assets/ThirdParty/Quaternius/Stylized Nature MegaKit/`

\- Project usage:

&#x20; - Trees

&#x20; - Bushes

&#x20; - Grass

&#x20; - Flowers

&#x20; - Rocks

&#x20; - Forest edge dressing

&#x20; - Quarry and roadside natural props

\- Greenvale usage notes:

&#x20; - Primary nature pack for Greenvale Abbey outdoor zone.

&#x20; - Use for forest edge, hilltop overlook, creek area, farm borders, quarry exterior, and general environmental dressing.

\- Modified project copies:

&#x20; - `Assets/\_Project/Prefabs/Environment/`

&#x20; - `Assets/\_Project/Prefabs/Resources/`

\- Attribution required: No, based on CC0 license.

\- Notes:

&#x20; - Keep original imported assets unchanged when possible.

&#x20; - Create gameplay-ready prefabs under `\_Project` if colliders, scripts, LODs, or interaction components are added.



\---



\## Quaternius - Medieval Village MegaKit



\- Source: https://quaternius.com/packs/medievalvillagemegakit.html

\- Creator: Quaternius

\- License: CC0 License

\- License status: Free to use in personal, educational, and commercial projects

\- Verified date: 2026-05-25

\- Asset type: Buildings / Modular Village Environment

\- Formats available: FBX, OBJ, glTF

\- Imported to: `Assets/ThirdParty/Quaternius/Medieval Village MegaKit/`

\- Project usage:

&#x20; - Village buildings

&#x20; - Abbey-style exterior pieces

&#x20; - Roofs

&#x20; - Walls

&#x20; - Floors

&#x20; - Stairs

&#x20; - Fences

&#x20; - Wagons

&#x20; - Settlement props

\- Greenvale usage notes:

&#x20; - Primary building pack for Greenvale Abbey hub, training yard, village road, farm structures, and small outbuildings.

&#x20; - Use modular parts to create original buildings rather than copying any existing Warcraft layout.

\- Modified project copies:

&#x20; - `Assets/\_Project/Prefabs/Buildings/`

&#x20; - `Assets/\_Project/Prefabs/Environment/Village/`

\- Attribution required: No, based on CC0 license.

\- Notes:

&#x20; - Use original layout and naming.

&#x20; - Do not attempt to recreate exact Northshire Abbey geometry.



\---



\## Quaternius - Fantasy Props MegaKit



\- Source: https://quaternius.com/packs/fantasypropsmegakit.html

\- Creator: Quaternius

\- License: CC0 License

\- License status: Free to use in personal, educational, and commercial projects

\- Verified date: 2026-05-25

\- Asset type: Props / Weapons / Furniture / Tools

\- Formats available: FBX, OBJ, glTF

\- Imported to: `Assets/ThirdParty/Quaternius/Fantasy Props MegaKit/`

\- Project usage:

&#x20; - Crates

&#x20; - Chests

&#x20; - Books

&#x20; - Potions

&#x20; - Candles

&#x20; - Tools

&#x20; - Weapons

&#x20; - Market props

&#x20; - Blacksmith props

&#x20; - Crafting station dressing

\- Greenvale usage notes:

&#x20; - Use for abbey interiors/exteriors, training yard props, crafting table area, quarry props, loot containers, tool racks, and NPC work areas.

&#x20; - Useful for early interaction objects and quest props.

\- Modified project copies:

&#x20; - `Assets/\_Project/Prefabs/Props/`

&#x20; - `Assets/\_Project/Prefabs/Interactables/`

&#x20; - `Assets/\_Project/Prefabs/Crafting/`

\- Attribution required: No, based on CC0 license.

\- Notes:

&#x20; - Create gameplay-prefab variants in `\_Project` for interactable chests, mining tools, crafting stations, and quest objects.



\---



\## Quaternius - Universal Animation Library 2



\- Source: https://quaternius.com/packs/universalanimationlibrary2.html

\- Creator: Quaternius

\- License: CC0 License

\- License status: Free to use in personal, educational, and commercial projects

\- Verified date: 2026-05-25

\- Asset type: Humanoid Animations

\- Formats available: Unity/Godot/Unreal-compatible humanoid animation assets; verify exact downloaded package contents

\- Imported to: `Assets/ThirdParty/Quaternius/Universal Animation Library 2/`

\- Project usage:

&#x20; - Idle animations

&#x20; - Walk/run movement

&#x20; - Combat animations

&#x20; - Tool-use animations

&#x20; - Farming/gathering-style animations

&#x20; - Death or hit reactions if available

\- Greenvale usage notes:

&#x20; - Use for player prototype locomotion, NPC idles, basic melee attacks, gathering, and mining/crafting placeholder animations.

&#x20; - Retarget to Universal Base Characters where practical.

\- Modified project copies:

&#x20; - `Assets/\_Project/Animation/`

&#x20; - `Assets/\_Project/Animators/`

&#x20; - `Assets/\_Project/Prefabs/Player/`

&#x20; - `Assets/\_Project/Prefabs/NPCs/`

\- Attribution required: No, based on CC0 license.

\- Notes:

&#x20; - Keep original animations in ThirdParty.

&#x20; - Store Animator Controllers and retargeted setup assets under `\_Project`.

&#x20; - Start with a minimal animation set: Idle, Walk, Run, Jump, Attack, Gather/Mine, Hit, Death.



\---



\## Quaternius - Universal Base Characters



\- Source: https://quaternius.com/packs/universalbasecharacters.html

\- Creator: Quaternius

\- License: CC0 License

\- License status: Free to use in personal, educational, and commercial projects

\- Verified date: 2026-05-25

\- Asset type: Humanoid Character Models

\- Formats available: Verify downloaded package contents

\- Imported to: `Assets/ThirdParty/Quaternius/Universal Base Characters/`

\- Project usage:

&#x20; - Player placeholder character

&#x20; - NPC base bodies

&#x20; - Humanoid enemy base bodies

&#x20; - Animation retargeting tests

\- Greenvale usage notes:

&#x20; - Use as the base for the first playable character and early NPC prototypes.

&#x20; - Combine with Modular Character Outfits - Fantasy for villagers, guards, workers, and quest givers.

\- Modified project copies:

&#x20; - `Assets/\_Project/Prefabs/Player/`

&#x20; - `Assets/\_Project/Prefabs/NPCs/`

&#x20; - `Assets/\_Project/Prefabs/Enemies/`

\- Attribution required: No, based on CC0 license.

\- Notes:

&#x20; - Keep base models unchanged in ThirdParty.

&#x20; - Create prefab variants under `\_Project` for gameplay characters with colliders, scripts, Animator, and interaction/combat components.



\---



\## Quaternius - Modular Character Outfits - Fantasy



\- Source: https://quaternius.com/packs/modularcharacteroutfitsfantasy.html

\- Creator: Quaternius

\- License: CC0 License

\- License status: Free to use in personal, educational, and commercial projects

\- Verified date: 2026-05-25

\- Asset type: Modular Fantasy Character Outfits

\- Formats available: Verify downloaded package contents

\- Imported to: `Assets/ThirdParty/Quaternius/Modular Character Outfits - Fantasy/`

\- Project usage:

&#x20; - Villager outfits

&#x20; - Guard outfits

&#x20; - Worker outfits

&#x20; - Adventurer outfits

&#x20; - Quest NPC outfits

&#x20; - Enemy humanoid outfit variations

\- Greenvale usage notes:

&#x20; - Use to create original Greenvale NPCs such as:

&#x20;   - Abbey Steward Maren

&#x20;   - Training Captain Rowan

&#x20;   - Field Worker Elna

&#x20;   - Quarry Scout Bren

&#x20;   - Builder Tavin

&#x20; - Use outfit/color variations to distinguish NPC roles without using Warcraft designs.

\- Modified project copies:

&#x20; - `Assets/\_Project/Prefabs/NPCs/`

&#x20; - `Assets/\_Project/Prefabs/Player/Outfits/`

&#x20; - `Assets/\_Project/Prefabs/Enemies/Humanoids/`

\- Attribution required: No, based on CC0 license.

\- Notes:

&#x20; - Use original color schemes and silhouettes.

&#x20; - Avoid making direct visual copies of Stormwind guards, Alliance soldiers, or other Warcraft faction designs.



\---



\# Current Approved Third-Party Asset Locations



```text

Assets/

&#x20; ThirdParty/

&#x20;   Quaternius/

&#x20;     Stylized Nature MegaKit/

&#x20;     Medieval Village MegaKit/

&#x20;     Fantasy Props MegaKit/

&#x20;     Universal Animation Library 2/

&#x20;     Universal Base Characters/

&#x20;     Modular Character Outfits - Fantasy/

