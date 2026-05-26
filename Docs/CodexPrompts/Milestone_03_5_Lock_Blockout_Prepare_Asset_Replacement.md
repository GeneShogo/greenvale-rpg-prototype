# Milestone 03.5 Prompt Summary - Lock Blockout and Prepare for Asset Replacement

Project: Greenvale RPG Prototype  
Engine: Unity URP  
Milestone: Milestone 3.5 - Lock Blockout and Prepare for Asset Replacement

Lock down the generated Greenvale Abbey blockout so future manual edits and Quaternius asset replacements are not accidentally overwritten by `GreenvaleBlockoutBuilder`.

Acceptance goals:

- Keep the active scene path as `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
- Do not delete or move generated blockout objects.
- Disable automatic regeneration on scene open and Play Mode entry.
- Keep the builder available only as an intentional manual tool.
- Add safeguards such as `autoGenerateInEditMode = false`, `allowRegeneration = false`, and a confirmation token.
- Preserve `PlayerSpawnPoint`, player bootstrap, camera, interaction raycast, and `Abbey Steward Maren` dialogue.
- Update changelog, build notes, and blockout system documentation.
