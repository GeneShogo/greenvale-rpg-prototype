# NPC Dialogue System

Milestone 2 adds a simple NPC dialogue flow on top of the Milestone 1 `IInteractable` and `InteractionRaycaster` setup.

## Components

`NPCDialogue` implements `IInteractable`. It exposes:

- `npcName`
- `dialogueText`
- `interactionPrompt`

When the player presses E while the interaction raycast is focused on the NPC, `NPCDialogue.Interact` opens the dialogue UI.

`DialogueUIManager` owns the dialogue panel. If no manager exists in the scene, the first interaction creates one at runtime. The default panel uses standard Unity UI because TextMeshPro is not currently listed in `Packages/manifest.json`.

The default UI includes:

- NPC name text
- Dialogue body text
- Close button
- E and Escape close key support

## Player Control

While dialogue is open, the UI manager temporarily disables:

- `ThirdPersonPlayerController`
- `ThirdPersonCameraFollow`
- `InteractionRaycaster`

When the dialogue closes, those components are re-enabled and the cursor is locked again so player movement resumes.

## Test NPC

`Abbey Steward Maren` is placed in `Assets/_Project/Scenes/GreenvaleAbbey.unity` under `--- TEST OBJECTS ---`.

Placeholder dialogue:

`Welcome to Greenvale Abbey. Start with the basics: learn the grounds, speak with the training captain, and keep your eyes on the quarry road.`

## Test Flow

1. Open `Assets/_Project/Scenes/GreenvaleAbbey.unity`.
2. Press Play.
3. Walk to `Abbey Steward Maren`.
4. Face the NPC within interaction distance. Distance is measured from the player/eye ray origin, not from the third-person camera.
5. Press E to open dialogue.
6. Confirm the UI shows the NPC name and dialogue text.
7. Close with E, Escape, or the Close button.
8. Confirm movement and camera control resume.

## Future Quest Integration

The system is intentionally data-ready but small. Future quest work can replace the single `dialogueText` field with a dialogue asset, quest state lookup, or branching dialogue node while keeping the same `IInteractable` entry point.
