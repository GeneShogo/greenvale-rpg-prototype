# Build Notes

## Milestone 1 - Player Controller and Camera

### Setup Notes

- Open `Assets/Scenes/GreenvaleAbbey.unity`.
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
