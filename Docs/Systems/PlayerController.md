# Player Controller System

Milestone 1 adds a small third-person gameplay stack for the GreenvaleAbbey scene.

## Runtime Setup

`PlayerSceneBootstrap` lives on `--- GAMEPLAY ---` in `Assets/Scenes/GreenvaleAbbey.unity`.

On play it:

- Finds the existing `PlayerSpawnPoint`.
- Creates a simple capsule named `Greenvale Player`.
- Adds a `CharacterController`.
- Adds `ThirdPersonPlayerController`.
- Adds `InteractionRaycaster`.
- Adds `ThirdPersonCameraFollow` to `Main Camera` if needed.
- Assigns the camera and player references.

## Movement

`ThirdPersonPlayerController` reads WASD through Unity's Input System keyboard API. Movement is camera-relative, so W moves in the camera's forward direction on the horizontal plane. The player smoothly rotates toward the movement direction.

Inspector tuning fields:

- `movementSpeed`
- `sprintSpeed`
- `rotationSharpness`
- `cameraTransform`

## Sprint

Holding Left Shift or Right Shift switches movement from `movementSpeed` to `sprintSpeed`.

## Jump And Gravity

Jumping uses Space while the `CharacterController` is grounded. Vertical motion is controlled by `jumpForce`, `gravity`, and `groundedStickForce`.

Inspector tuning fields:

- `jumpForce`
- `gravity`
- `groundedStickForce`

## Camera

`ThirdPersonCameraFollow` follows a target transform from a configurable offset and distance. Mouse movement updates yaw and pitch, then the camera follows the desired position smoothly in `LateUpdate`.

Inspector tuning fields:

- `target`
- `targetOffset`
- `distance`
- `minPitch`
- `maxPitch`
- `cameraSensitivity`
- `followSharpness`
- `lockCursorOnStart`

## Interaction Raycast

`InteractionRaycaster` casts from the assigned camera forward. If no camera is assigned, it falls back to the player transform. It detects colliders whose object or parent implements `IInteractable`.

Inspector tuning fields:

- `sourceCamera`
- `fallbackOrigin`
- `interactionDistance`
- `interactionLayers`
- `triggerInteraction`
- `interactKey`
- `interactOnKeyPress`
- `drawDebugRay`

When the raycast focus changes, `FocusChanged` fires with the current `IInteractable`. Pressing E calls `Interact(GameObject interactor)` on the detected target.

`DebugInteractable` is attached at runtime to `Player_Start_Marker` by the bootstrap so interaction can be tested immediately.
