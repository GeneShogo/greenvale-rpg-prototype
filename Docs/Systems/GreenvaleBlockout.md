# Greenvale Abbey Blockout Framework

Milestone 3 adds an organized starter-zone blockout framework to `Assets/_Project/Scenes/GreenvaleAbbey.unity`.

The goal is not a finished decorated zone. It is a readable spatial framework for a Northshire-inspired classic fantasy starter-zone layout without recreating Northshire Abbey exactly.

## Scene Structure

`GreenvaleBlockoutBuilder` is attached to the `--- WORLD ---` root. In edit mode, it creates/verifies these child groups:

- `Landmark_Markers`
- `Terrain_Blockout`
- `Roads_And_Paths`
- `Abbey_Hub`
- `Training_Yard`
- `Forest_Edge`
- `Farm_Field`
- `Quarry_Road`
- `Quarry_Entrance`
- `Base_Plot`
- `Creek_Or_Pond`
- `Hilltop_Overlook`
- `Set_Dressing_Placeholders`

The existing `Ground_TestPlane` is reparented under `Terrain_Blockout` while keeping its world position.

## Landmark Markers

The builder creates visible sphere markers for:

- `AbbeyHub_Marker`
- `TrainingYard_Marker`
- `ForestEdge_Marker`
- `FarmField_Marker`
- `QuarryRoad_Marker`
- `QuarryEntrance_Marker`
- `BasePlot_Marker`
- `CreekOrPond_Marker`
- `HilltopOverlook_Marker`
- `ScavengerCamp_Marker`
- `PlayerStart_Marker`

These are layout markers, not final gameplay objects.

## Placeholder Objects

The builder creates simple primitives for:

- `Abbey_Main_Blockout`
- `BellTower_Blockout`
- `Training_Yard_Fence_Blockout`
- `Farm_Field_Blockout`
- `Quarry_Road_Blockout`
- `Quarry_Entrance_Blockout`
- `Base_Plot_Blockout`
- `Forest_Edge_Tree_Placeholders`
- `Creek_Or_Pond_Blockout`
- `Hilltop_Overlook_Blockout`
- `ScavengerCamp_Blockout`
- `Road_Path_Blockouts`

The placeholders intentionally stay simple so the human can evaluate scale and replace them by hand.

## Blockout Materials

The builder creates neutral materials under `Assets/_Project/Materials/Blockout/`:

- `MAT_Blockout_Abbey`
- `MAT_Blockout_Road`
- `MAT_Blockout_Forest`
- `MAT_Blockout_Water`
- `MAT_Blockout_Quarry`
- `MAT_Blockout_BasePlot`

These are only for readability during blockout.

## Replacing With Quaternius Assets

Later, replace placeholders manually with licensed Quaternius assets from `Assets/ThirdParty/Quaternius/`.

Recommended workflow:

1. Keep the parent group structure under `--- WORLD ---`.
2. Duplicate or prefab project-ready replacements under `Assets/_Project/Prefabs/`.
3. Replace one placeholder group at a time.
4. Keep the original placeholder object disabled or nearby until scale and collision are verified.
5. Do not use copyrighted maps, names, quest text, icons, music, or recreated layouts from other games.

## Player And NPC Preservation

Milestone 3 does not move `PlayerSpawnPoint` or `Abbey Steward Maren`. The existing player bootstrap, camera follow, interaction raycast, and NPC dialogue flow remain the functional test path.
