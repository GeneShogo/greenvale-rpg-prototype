# Greenvale Abbey Blockout Framework

Milestone 3 adds an organized starter-zone blockout framework to `Assets/_Project/Scenes/GreenvaleAbbey.unity`.

The goal is not a finished decorated zone. It is a readable spatial framework for a Northshire-inspired classic fantasy starter-zone layout without recreating Northshire Abbey exactly.

## Scene Structure

`GreenvaleBlockoutBuilder` is attached to the `--- WORLD ---` root. It is now locked for manual editing and does not rebuild automatically when the scene opens or when entering Play Mode.

The existing generated blockout hierarchy should contain these child groups:

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

The existing `Ground_TestPlane` may be reparented under `Terrain_Blockout` by the builder during intentional regeneration while keeping its world position.

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

## Safe Manual Editing

Treat the current blockout objects as editable scene placeholders. Move, scale, disable, or replace them by hand as needed.

Keep these safeguards in place on `GreenvaleBlockoutBuilder`:

- `autoGenerateInEditMode`: disabled
- `allowRegeneration`: disabled
- `regenerationConfirmation`: blank

These settings prevent accidental rebuilds from overwriting manual edits.

## Manual Regeneration

Only regenerate if you intentionally want the builder to restore named placeholders to its authored positions and scales.

To regenerate:

1. Select `--- WORLD ---`.
2. Enable `allowRegeneration`.
3. Enter `REBUILD_GREENVALE_BLOCKOUT` in `regenerationConfirmation`.
4. Use the component context menu `Build Greenvale Blockout`.
5. Disable `allowRegeneration` and clear `regenerationConfirmation` afterward.

Do not regenerate after replacing placeholders with Quaternius assets unless resetting those objects is intended.

## Replacing With Quaternius Assets

Later, replace placeholders manually with licensed Quaternius assets from `Assets/ThirdParty/Quaternius/`.

Recommended workflow:

1. Keep the parent group structure under `--- WORLD ---`.
2. Duplicate or prefab project-ready replacements under `Assets/_Project/Prefabs/`.
3. Replace one placeholder group at a time.
4. Keep the original placeholder object disabled or nearby until scale and collision are verified.
5. Leave `GreenvaleBlockoutBuilder` locked so manual replacements are not overwritten.
6. Do not use copyrighted maps, names, quest text, icons, music, or recreated layouts from other games.

## Abbey Hub Art Pass 01

The first asset replacement pass targets only `--- WORLD --- / Abbey_Hub`.

`AbbeyHubArtPass01Placer` is attached to `Abbey_Hub` and creates `Abbey_Art_Pass_01` if it is missing. It instantiates a small kitbash from already imported Quaternius assets:

- Medieval Village MegaKit for wall, roof, door, stair, fence, and tower pieces.
- Fantasy Props MegaKit for bench, barrel, crate, lantern, and banner dressing.
- Stylized Nature MegaKit for trees, bushes, rocks, grass, and approach stones.

After creation, the pass disables only the replaced abbey-specific blockout objects:

- `Abbey_Main_Blockout`
- `BellTower_Blockout`

The blockout objects are preserved in the hierarchy as scale references. The placer should be treated as a setup helper; after the scene is saved, future art edits should happen manually under `Abbey_Art_Pass_01`.

## Player And NPC Preservation

Milestone 3 does not move `PlayerSpawnPoint` or `Abbey Steward Maren`. The existing player bootstrap, camera follow, interaction raycast, and NPC dialogue flow remain the functional test path.
