# Changelog

## 2026-05-25 - Milestone 1: Player Controller and Camera

- Added a simple third-person player controller using `CharacterController`.
- Added camera-relative WASD movement, sprint, jump, gravity, and smooth player rotation.
- Added a third-person camera follow script with mouse look and configurable sensitivity.
- Added `IInteractable`, an interaction raycaster, and a debug interactable for scene testing.
- Added a scene bootstrap to spawn the player at `PlayerSpawnPoint`, wire the main camera, and enable the interaction test target.
- Updated project documentation for setup, testing, and milestone implementation notes.
