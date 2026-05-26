# Build Notes

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
