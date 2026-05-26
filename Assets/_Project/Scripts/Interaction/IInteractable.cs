using UnityEngine;

namespace GreenvaleAbbey.Interaction
{
    public interface IInteractable
    {
        string InteractionPrompt { get; }

        void Interact(GameObject interactor);
    }
}
