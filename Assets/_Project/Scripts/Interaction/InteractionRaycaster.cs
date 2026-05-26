using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GreenvaleAbbey.Interaction
{
    public sealed class InteractionRaycaster : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private Camera sourceCamera;
        [SerializeField] private Transform fallbackOrigin;
        [SerializeField] private float interactionDistance = 3f;
        [SerializeField] private LayerMask interactionLayers = ~0;
        [SerializeField] private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

        [Header("Input")]
        [SerializeField] private Key interactKey = Key.E;
        [SerializeField] private bool interactOnKeyPress = true;

        [Header("Debug")]
        [SerializeField] private bool drawDebugRay = true;

        private IInteractable currentInteractable;

        public event Action<IInteractable> FocusChanged;

        public IInteractable CurrentInteractable => currentInteractable;
        public float InteractionDistance => interactionDistance;

        private void Reset()
        {
            sourceCamera = Camera.main;
            fallbackOrigin = transform;
        }

        private void Awake()
        {
            if (sourceCamera == null)
            {
                sourceCamera = Camera.main;
            }

            if (fallbackOrigin == null)
            {
                fallbackOrigin = transform;
            }
        }

        private void Update()
        {
            IInteractable detected = FindInteractable();
            SetCurrentInteractable(detected);

            if (interactOnKeyPress && detected != null && WasInteractPressed())
            {
                detected.Interact(gameObject);
            }
        }

        public void SetSourceCamera(Camera camera)
        {
            sourceCamera = camera;
        }

        private IInteractable FindInteractable()
        {
            Ray ray = BuildRay();

            if (drawDebugRay)
            {
                Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.yellow);
            }

            RaycastHit[] hits = Physics.RaycastAll(ray, interactionDistance, interactionLayers, triggerInteraction);
            if (hits.Length == 0)
            {
                return null;
            }

            Array.Sort(hits, (left, right) => left.distance.CompareTo(right.distance));

            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.transform.IsChildOf(transform))
                {
                    continue;
                }

                IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
                if (interactable != null)
                {
                    return interactable;
                }
            }

            return null;
        }

        private Ray BuildRay()
        {
            if (sourceCamera != null)
            {
                return new Ray(sourceCamera.transform.position, sourceCamera.transform.forward);
            }

            Transform origin = fallbackOrigin != null ? fallbackOrigin : transform;
            return new Ray(origin.position + Vector3.up * 1.5f, origin.forward);
        }

        private bool WasInteractPressed()
        {
            Keyboard keyboard = Keyboard.current;
            return keyboard != null && keyboard[interactKey].wasPressedThisFrame;
        }

        private void SetCurrentInteractable(IInteractable detected)
        {
            if (ReferenceEquals(currentInteractable, detected))
            {
                return;
            }

            currentInteractable = detected;
            FocusChanged?.Invoke(currentInteractable);
        }
    }
}
