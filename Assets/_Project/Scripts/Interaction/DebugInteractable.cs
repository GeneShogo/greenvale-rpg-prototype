using UnityEngine;

namespace GreenvaleAbbey.Interaction
{
    public sealed class DebugInteractable : MonoBehaviour, IInteractable
    {
        [SerializeField] private string interactionPrompt = "Inspect";
        [SerializeField] private bool logInteractions = true;

        public string InteractionPrompt => interactionPrompt;

        public void Interact(GameObject interactor)
        {
            if (!logInteractions)
            {
                return;
            }

            Debug.Log($"{interactor.name} interacted with {name}: {interactionPrompt}", this);
        }
    }
}
