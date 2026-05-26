# Abbey Hub Art Pass 01

## Scope

This pass creates a rough first art replacement for only `--- WORLD --- / Abbey_Hub` in `Assets/_Project/Scenes/GreenvaleAbbey.unity`.

The goal is an original fantasy abbey hub kitbash, not a final decorated zone and not a recreation of any copyrighted starter area.

## Assets Used

Medieval Village MegaKit:

- `Wall_Plaster_Door_Round.fbx`
- `Wall_Plaster_Straight.fbx`
- `Wall_Plaster_Window_Wide_Round.fbx`
- `Wall_UnevenBrick_Straight.fbx`
- `Wall_UnevenBrick_Window_Thin_Round.fbx`
- `Roof_RoundTiles_4x6.fbx`
- `Roof_Tower_RoundTiles.fbx`
- `Door_1_Round.fbx`
- `Stairs_Exterior_Straight.fbx`
- `Prop_WoodenFence_Single.fbx`

Fantasy Props MegaKit:

- `Bench.fbx`
- `Barrel.fbx`
- `Crate_Wooden.fbx`
- `Lantern_Wall.fbx`
- `Banner_1.fbx`

Stylized Nature MegaKit:

- `CommonTree_1.fbx`
- `CommonTree_3.fbx`
- `Bush_Common_Flowers.fbx`
- `Bush_Common.fbx`
- `Rock_Medium_1.fbx`
- `Grass_Common_Short.fbx`
- `RockPath_Round_Wide.fbx`
- `RockPath_Round_Thin.fbx`

## Placement

`AbbeyHubArtPass01Placer` creates `Abbey_Art_Pass_01` under `Abbey_Hub` with these child groups:

- `Main_Hall_Kitbash`
- `Tower_Landmark_Kitbash`
- `Entrance_Approach`
- `Entrance_Props`
- `Nature_Set_Dressing`

The layout keeps the hall near the original abbey blockout footprint, adds a taller tower element, places a simple approach path, and adds light entrance/nature dressing.

## Blockout Handling

Disabled after generation:

- `Abbey_Main_Blockout`
- `BellTower_Blockout`

These objects are preserved as references and can be re-enabled for scale comparison.

## NPC Handling

`Abbey Steward Maren` was initially not moved by the first pass. During cleanup, she is moved near the temporary entrance area and remains active with `NPCDialogue`.

## Manual Polish Needed

- Verify imported model scale in the Unity editor.
- Adjust rotations and overlaps by eye.
- Add or tune colliders only where needed.
- Verify `Abbey Steward Maren` remains reachable after any future building replacement.
- Replace any rough kitbash pieces with cleaner prefabs once an abbey style is chosen.

## Scale And Readability Repair

The first generated pass did not read clearly as a building because the Medieval Village wall pieces were small, flat modular slices and nearby nature props dominated the view.

The repair updates `AbbeyHubArtPass01Placer` to:

- Reset `Main_Hall_Kitbash` to scale 1.
- Add `Hall_Massing_MainBody` as a large rectangular hall volume.
- Add `Hall_Massing_Roof` as a larger visible roof volume.
- Keep the Medieval Village wall, door, window, and roof pieces as visual dressing on top of the mass.
- Add `Tower_Massing_Shaft` to make the landmark tower read from a distance.
- Move large trees, rocks, bushes, fences, and props away from the hall entrance.
- Add `Hall_Entrance_Apron_Clearance` to make the walk-up area visually clear.
- Move `Abbey Steward Maren` near the repaired entrance without disabling `NPCDialogue`.

This still uses modular pieces rather than a complete building model because no suitable complete Medieval Village building prefab/model was found in the imported pack.

## Manual Replacement Cleanup

The automatic building kitbash was still not visually acceptable as an abbey. The pass has been converted into a temporary staging setup for a human-selected building replacement.

Cleanup behavior:

- Keeps `Abbey_Art_Pass_01` under `--- WORLD --- / Abbey_Hub`.
- Creates `Disabled_Failed_Building_Attempts` under `Abbey_Art_Pass_01`.
- Moves `Main_Hall_Kitbash` and `Tower_Landmark_Kitbash` under `Disabled_Failed_Building_Attempts` and disables them.
- Preserves the disabled kitbash children instead of deleting the modular wall, roof, door, and tower pieces.
- Keeps entrance props, path stones, trees, bushes, rocks, grass, and small non-building dressing active if they do not block movement.
- Keeps `Abbey_Main_Blockout` and `BellTower_Blockout` active as the temporary readable abbey placeholder.
- Moves `Abbey_Building_Replacement_Anchor` directly under `Abbey_Hub` so future building placement is not nested inside the failed art pass.
- Keeps `Abbey Steward Maren` active and moves her to the clear front approach near the entrance.

Replacement markers:

- `MainBuilding_DropHere`: local position `(0, 0, 0.25)`.
- `Tower_DropHere`: local position `(1.55, 0, 0.95)`.
- `Entrance_DropHere`: local position `(0, 0, -2.2)`.

Use these markers to manually place a better building asset later. Keep the locked blockout builder disabled and do not regenerate the full blockout during manual replacement.
