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
        [SerializeField] private Vector3 originOffset = new Vector3(0f, 1.4f, 0f);
        [SerializeField] private float interactionDistance = 3f;
        [SerializeField] private float interactionRadius = 0.35f;
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

            RaycastHit[] hits = interactionRadius > 0f
                ? Physics.SphereCastAll(ray, interactionRadius, interactionDistance, interactionLayers, triggerInteraction)
                : Physics.RaycastAll(ray, interactionDistance, interactionLayers, triggerInteraction);
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
            Transform origin = fallbackOrigin != null ? fallbackOrigin : transform;
            Vector3 rayOrigin = origin.position + originOffset;

            if (sourceCamera != null)
            {
                return new Ray(rayOrigin, sourceCamera.transform.forward);
            }

            return new Ray(rayOrigin, origin.forward);
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
