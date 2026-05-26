# Build Notes

## MCP-Assisted Abbey Hub Staging Cleanup

### Setup Notes

- `GreenvaleAbbey.unity` remains the active scene at `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- `GreenvaleBlockoutBuilder` remains locked on `--- WORLD ---`; keep `autoGenerateInEditMode` and `allowRegeneration` disabled.
- `Abbey_Art_Pass_01` remains under `--- WORLD --- / Abbey_Hub`.
- `Disabled_Failed_Building_Attempts` exists under `Abbey_Art_Pass_01`.
- Failed building groups are disabled under that staging parent:
  - `Main_Hall_Kitbash`
  - `Tower_Landmark_Kitbash`
- Useful non-building dressing remains active:
  - `Entrance_Approach`
  - `Entrance_Props`
  - `Nature_Set_Dressing`
- `Abbey_Main_Blockout` and `BellTower_Blockout` are active as temporary readable placeholders.
- `Abbey_Building_Replacement_Anchor` now sits directly under `Abbey_Hub`, with drop markers for future manual asset placement.
- `Abbey Steward Maren` is active near the front approach and still has `NPCDialogue`.

### Testing Steps

1. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
2. Confirm `--- WORLD --- / Abbey_Hub / Abbey_Art_Pass_01` still exists.
3. Confirm `Disabled_Failed_Building_Attempts` contains disabled `Main_Hall_Kitbash` and `Tower_Landmark_Kitbash`.
4. Confirm `Abbey_Main_Blockout` and `BellTower_Blockout` are visible.
5. Confirm `Abbey_Building_Replacement_Anchor` is under `Abbey_Hub` and contains `MainBuilding_DropHere`, `Tower_DropHere`, and `Entrance_DropHere`.
6. Press Play, walk to the abbey entrance approach, and press E near `Abbey Steward Maren`.
7. Confirm the dialogue opens and closes, then verify player movement still works.
8. Check the Console for compile errors.

### Unity Editor Actions Required

- No blockout regeneration is required.
- Do not run or unlock `GreenvaleBlockoutBuilder`.
- When choosing a future building asset, drop it at `Abbey_Building_Replacement_Anchor / MainBuilding_DropHere`, then align the tower and entrance using the sibling marker objects.

## Cleanup - Abbey Hub Art Pass 01 Manual Replacement Prep

### Setup Notes

- `Abbey_Art_Pass_01` is preserved under `--- WORLD --- / Abbey_Hub`.
- The failed gray massing objects are disabled, not deleted:
  - `Hall_Massing_MainBody`
  - `Hall_Massing_Roof`
  - `Tower_Massing_Shaft`
- The original `Abbey_Main_Blockout` and `BellTower_Blockout` are restored as temporary placement references.
- `Abbey_Building_Replacement_Anchor` now lives directly under `Abbey_Hub`.
- The anchor contains:
  - `MainBuilding_DropHere`
  - `Tower_DropHere`
  - `Entrance_DropHere`
- Useful entrance props, path stones, trees, bushes, rocks, and grass remain for scene context.
- `GreenvaleBlockoutBuilder` remains locked.

### Testing Steps

1. Let Unity compile the updated `AbbeyHubArtPass01Placer`.
2. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
3. Expand `--- WORLD --- / Abbey_Hub / Abbey_Art_Pass_01`.
4. Confirm the gray massing objects are disabled.
5. Confirm `Abbey_Hub / Abbey_Building_Replacement_Anchor` and its three drop markers exist.
6. Confirm `Abbey_Main_Blockout` and `BellTower_Blockout` are visible as temporary references.
7. Enter Play Mode and verify the player can walk around the entrance and interact with `Abbey Steward Maren`.

### Unity Editor Actions Required

- Save the scene after cleanup applies.
- If cleanup does not apply automatically, select `Abbey_Hub` and run the context menu `Prepare Abbey Hub For Manual Building Replacement`.
- Later, manually drop a selected building asset at `MainBuilding_DropHere`, a tower asset at `Tower_DropHere`, and align the entry at `Entrance_DropHere`.

## Repair - Abbey Hub Art Pass 01 Scale and Readability

### Setup Notes

- `AbbeyHubArtPass01Placer` now includes a one-time readability repair for `Abbey_Art_Pass_01`.
- The repair adds large project-owned massing primitives under `Main_Hall_Kitbash` so the hall reads clearly from Scene view and Play Mode.
- Existing Quaternius modular wall, roof, door, prop, and nature pieces are retained as dressing.
- Large trees, rocks, bushes, and fences are moved outward from the front of the hall.
- `Abbey Steward Maren` is moved near the abbey entrance and remains active with `NPCDialogue`.
- `GreenvaleBlockoutBuilder` remains locked; do not enable `autoGenerateInEditMode` or `allowRegeneration`.

### Testing Steps

1. Let Unity compile the updated `AbbeyHubArtPass01Placer` script.
2. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
3. Confirm `--- WORLD --- / Abbey_Hub / Abbey_Art_Pass_01 / Main_Hall_Kitbash` contains `Hall_Massing_MainBody` and `Hall_Massing_Roof`.
4. Confirm the hall is larger than the player/NPC and reads as the primary Abbey Hub object.
5. Confirm trees and rocks are on the sides/back rather than blocking the front.
6. Enter Play Mode and walk to the entrance.
7. Press E near `Abbey Steward Maren` and confirm dialogue still opens.

### Unity Editor Actions Required

- Save the scene after the repair has applied.
- If the repair does not apply automatically, select `Abbey_Hub` and run the `AbbeyHubArtPass01Placer` context menu `Repair Abbey Art Pass 01 Readability`.

## Manual Asset Replacement Pass 1 - Abbey Hub First Art Pass

### Setup Notes

- Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- `Abbey_Hub` has an `AbbeyHubArtPass01Placer` component.
- On first editor reload, the placer creates `Abbey_Art_Pass_01` under `--- WORLD --- / Abbey_Hub` if that parent is missing.
- The placer instantiates selected imported Quaternius FBX assets and then marks itself generated.
- `GreenvaleBlockoutBuilder` remains locked: keep `autoGenerateInEditMode` disabled and `allowRegeneration` disabled.
- The art pass disables only `Abbey_Main_Blockout` and `BellTower_Blockout` after creating the art parent.

### Testing Steps

1. Let Unity compile the new `AbbeyHubArtPass01Placer` script.
2. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
3. Expand `--- WORLD --- / Abbey_Hub` and confirm `Abbey_Art_Pass_01` exists.
4. Confirm `Abbey_Art_Pass_01` contains a main hall kitbash, tower landmark, entrance props, path stones, and nature dressing.
5. Confirm `Abbey_Main_Blockout` and `BellTower_Blockout` are preserved but disabled.
6. Press Play and verify player movement, camera follow, interaction raycast, and `Abbey Steward Maren` dialogue still work.

### Unity Editor Actions Required

- Save the scene after the art pass has generated.
- If the art pass does not appear, select `Abbey_Hub` and use the `AbbeyHubArtPass01Placer` context menu `Create Abbey Art Pass 01`.
- Manually inspect scale, rotations, and collisions; this is a rough first pass.

## Milestone 3.5 - Lock Blockout and Prepare for Asset Replacement

### Setup Notes

- The Greenvale blockout is now locked for manual editing.
- `GreenvaleBlockoutBuilder` remains on `--- WORLD ---`, but it no longer auto-generates when the scene opens.
- Entering Play Mode does not regenerate or reset blockout objects.
- Existing generated blockout objects should remain in the scene for the human to edit or replace manually.
- `autoGenerateInEditMode` should remain disabled.
- `allowRegeneration` should remain disabled unless a deliberate full rebuild is needed.

### Manual Regeneration

Only regenerate intentionally:

1. Select `--- WORLD ---`.
2. On `GreenvaleBlockoutBuilder`, enable `allowRegeneration`.
3. Enter `REBUILD_GREENVALE_BLOCKOUT` in `regenerationConfirmation`.
4. Use the component context menu `Build Greenvale Blockout`.
5. Disable `allowRegeneration` again after the rebuild.

Regeneration can reset named blockout placeholders back to builder-authored positions and scales, so do not run it after replacing placeholders with Quaternius assets unless that reset is intended.

### Testing Steps

1. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
2. Confirm the blockout hierarchy remains present under `--- WORLD ---`.
3. Confirm `GreenvaleBlockoutBuilder` has `autoGenerateInEditMode` disabled and `allowRegeneration` disabled.
4. Enter Play Mode and confirm the blockout does not reset.
5. Verify player movement, camera follow, interaction raycast, and `Abbey Steward Maren` dialogue still work.

### Unity Editor Actions Required

- Save the scene after confirming the locked builder settings.
- Keep future Quaternius replacements under project-created prefabs or scene objects in `Assets/_Project/`.
- Keep original third-party source assets under `Assets/ThirdParty/`.

## Milestone 3 - Greenvale Abbey Blockout Framework

### Setup Notes

- Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- The `--- WORLD ---` object has a `GreenvaleBlockoutBuilder` component.
- The builder originally created/verified the blockout hierarchy, visible marker primitives, placeholder geometry, and blockout materials. As of Milestone 3.5 it is locked and manual-only.
- Generated blockout materials are stored under `Assets/_Project/Materials/Blockout/`.
- The active scene path remains `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- The builder can reparent `Ground_TestPlane` under `Terrain_Blockout` without changing its world position when manually regenerated.
- `PlayerSpawnPoint`, `PlayerSceneBootstrap`, and `Abbey Steward Maren` are preserved.

### Testing Steps

1. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
2. Select `--- WORLD ---` and confirm `GreenvaleBlockoutBuilder` is enabled.
3. If the hierarchy has not generated yet, follow the Milestone 3.5 manual regeneration steps.
4. Confirm these child groups exist under `--- WORLD ---`: `Landmark_Markers`, `Terrain_Blockout`, `Roads_And_Paths`, `Abbey_Hub`, `Training_Yard`, `Forest_Edge`, `Farm_Field`, `Quarry_Road`, `Quarry_Entrance`, `Base_Plot`, `Creek_Or_Pond`, `Hilltop_Overlook`, and `Set_Dressing_Placeholders`.
5. Confirm the named landmark markers and placeholder blockouts are visible in the scene.
6. Press Play and verify movement, camera follow, and `Abbey Steward Maren` dialogue still work.

### Unity Editor Actions Required

- Let Unity compile the `GreenvaleBlockoutBuilder` script.
- Save the scene after manually generating or editing blockout objects.
- Replace placeholder primitives manually with Quaternius assets later, keeping third-party source assets under `Assets/ThirdParty/` and project prefabs under `Assets/_Project/`.

## Milestone 2 - Interaction and NPC Dialogue

### Setup Notes

- Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- `Abbey Steward Maren` is placed under `--- TEST OBJECTS ---` and has an `NPCDialogue` component.
- The dialogue system builds a simple standard Unity UI panel at runtime through `DialogueUIManager`.
- TextMeshPro is not listed in `Packages/manifest.json`, so this milestone uses standard Unity UI `Text` from `com.unity.ugui`.
- The dialogue panel shows the NPC name, dialogue body, and a Close button.
- Interaction casts from the player/eye position in the camera's facing direction, so the inspector distance is measured from the player rather than from the third-person camera.
- Keyboard controls:
  - E: interact with the NPC; also closes an open dialogue after the opening frame.
  - Escape: close dialogue.

### Testing Steps

1. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
2. Press Play.
3. Walk to `Abbey Steward Maren`.
4. Aim the camera/player interaction ray at the NPC within interaction distance.
5. Press E.
6. Confirm the dialogue UI opens with `Abbey Steward Maren` and the placeholder dialogue text.
7. Press E, press Escape, or click Close to dismiss the panel.
8. Confirm player movement and camera control resume after closing.

### Unity Editor Actions Required

- Allow Unity to reimport/compile the new scripts.
- Confirm `ProjectSettings/EditorBuildSettings.asset` lists `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- Tune `NPCDialogue` text, `InteractionRaycaster` distance, or `InteractionRaycaster` radius in the inspector if playtest spacing changes.

## Milestone 1 - Player Controller and Camera

### Setup Notes

- Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- The scene has a `PlayerSceneBootstrap` component on `--- GAMEPLAY ---`.
- On play, the bootstrap finds `PlayerSpawnPoint`, creates a simple capsule player, adds a `CharacterController`, and wires `Main Camera` to follow the player.
- Input uses Unity's Input System package directly:
  - WASD: move
  - Left Shift or Right Shift: sprint
  - Space: jump
  - Mouse: rotate camera
  - E: interact
  - Escape: unlock cursor

### Testing Steps

1. Open the GreenvaleAbbey scene in Unity.
2. Press Play.
3. Confirm the player capsule appears at `PlayerSpawnPoint`.
4. Use WASD to move relative to the camera.
5. Hold Shift while moving to confirm sprint speed.
6. Press Space while grounded to confirm jump behavior.
7. Move the mouse to confirm the camera orbits/follows the player.
8. Face `Player_Start_Marker` within interaction range and press E.
9. Confirm the Unity Console logs an interaction message from `DebugInteractable`.

### Unity Editor Actions Required

- Review/tune inspector values on `PlayerSceneBootstrap` if the spawn point or camera references change.
- If replacing the runtime capsule with a prefab later, add `ThirdPersonPlayerController`, `CharacterController`, and `InteractionRaycaster` to that prefab and assign the camera references.
- No third-party assets were added for this milestone.
