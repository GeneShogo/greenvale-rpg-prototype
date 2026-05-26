# Changelog

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
