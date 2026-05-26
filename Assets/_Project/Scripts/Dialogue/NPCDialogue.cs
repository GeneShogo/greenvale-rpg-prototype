using GreenvaleAbbey.Interaction;
using UnityEngine;

namespace GreenvaleAbbey.Dialogue
{
    public sealed class NPCDialogue : MonoBehaviour, IInteractable
    {
        [Header("Dialogue")]
        [SerializeField] private string npcName = "Abbey Steward Maren";
        [TextArea(3, 6)]
        [SerializeField] private string dialogueText = "Welcome to Greenvale Abbey. Start with the basics: learn the grounds, speak with the training captain, and keep your eyes on the quarry road.";
        [SerializeField] private string interactionPrompt = "Talk";

        public string InteractionPrompt => interactionPrompt;
        public string NpcName => npcName;
        public string DialogueText => dialogueText;

        public void Interact(GameObject interactor)
        {
            DialogueUIManager manager = DialogueUIManager.Instance;
            if (manager == null)
            {
                manager = DialogueUIManager.CreateDefault();
            }

            manager.ShowDialogue(this, interactor);
        }
    }
}
