# Changelog

## 2026-05-26 - Cleanup: Abbey Hub Art Pass 01 Manual Replacement Prep

- Converted the failed Abbey Hub automatic building kitbash into a temporary staging setup.
- Disabled gray primitive massing objects instead of deleting them.
- Restored the original abbey blockout pieces as temporary building references.
- Added `Abbey_Building_Replacement_Anchor` with `MainBuilding_DropHere`, `Tower_DropHere`, and `Entrance_DropHere` markers.
- Kept useful entrance props, path pieces, nature dressing, `Abbey Steward Maren`, and locked blockout builder settings.

## 2026-05-26 - Repair: Abbey Hub Art Pass 01 Scale and Readability

- Updated `AbbeyHubArtPass01Placer` to repair the generated Abbey Hub art pass with a larger readable hall mass, larger roof mass, and clearer tower silhouette.
- Moved trees, rocks, bushes, fences, and props away from the hall frontage so the building remains the dominant visual.
- Added a simple entrance apron and moved `Abbey Steward Maren` near the entrance while preserving `NPCDialogue`.
- Kept `GreenvaleBlockoutBuilder` locked and did not run blockout regeneration.

## 2026-05-26 - Manual Asset Replacement Pass 1: Abbey Hub First Art Pass

- Added an `AbbeyHubArtPass01Placer` one-shot edit-mode placer to the `Abbey_Hub` scene object.
- Set up `Abbey_Art_Pass_01` generation using imported Quaternius Medieval Village, Fantasy Props, and Stylized Nature assets.
- Preserved the locked `GreenvaleBlockoutBuilder` settings and existing gameplay/NPC systems.
- Documented the Abbey Hub art pass assets, replacement approach, and manual polish needs.

## 2026-05-26 - Milestone 3.5: Lock Blockout and Prepare for Asset Replacement

- Locked `GreenvaleBlockoutBuilder` so it no longer regenerates on scene open or Play Mode entry.
- Added manual regeneration safeguards with `allowRegeneration` and a confirmation token.
- Preserved existing blockout objects, player spawn, player bootstrap, camera, interaction raycast, and `Abbey Steward Maren` dialogue setup.
- Updated blockout documentation for safe manual editing and Quaternius replacement workflow.

## 2026-05-26 - Milestone 3: Greenvale Abbey Blockout Framework

- Added a `GreenvaleBlockoutBuilder` component to the `--- WORLD ---` scene root.
- Added an edit-mode blockout framework that creates/verifies landmark parent groups, visible markers, simple placeholder primitives, road/path blockouts, and blockout materials.
- Preserved `PlayerSpawnPoint`, player bootstrap behavior, interaction raycast, and `Abbey Steward Maren` dialogue setup.
- Updated build notes and added blockout system documentation.

## 2026-05-25 - Milestone 2: Interaction and NPC Dialogue

- Added an `NPCDialogue` interactable component for simple data-ready NPC conversations.
- Added a runtime `DialogueUIManager` that displays NPC name, dialogue text, and close controls using standard Unity UI.
- Added `Abbey Steward Maren` as a test NPC in the GreenvaleAbbey scene with original placeholder dialogue.
- Updated the GreenvaleAbbey scene build settings path.
- Added documentation for NPC dialogue setup, testing, and milestone prompt context.

## 2026-05-25 - Milestone 1: Player Controller and Camera

- Added a simple third-person player controller using `CharacterController`.
- Added camera-relative WASD movement, sprint, jump, gravity, and smooth player rotation.
- Added a third-person camera follow script with mouse look and configurable sensitivity.
- Added `IInteractable`, an interaction raycaster, and a debug interactable for scene testing.
- Added a scene bootstrap to spawn the player at `PlayerSpawnPoint`, wire the main camera, and enable the interaction test target.
- Updated project documentation for setup, testing, and milestone implementation notes.
