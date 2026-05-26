using GreenvaleAbbey.Interaction;
using GreenvaleAbbey.Player;
using UnityEngine;

namespace GreenvaleAbbey.Bootstrap
{
    public sealed class PlayerSceneBootstrap : MonoBehaviour
    {
        [Header("Scene References")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Camera gameplayCamera;

        [Header("Player")]
        [SerializeField] private string playerName = "Greenvale Player";
        [SerializeField] private float controllerHeight = 1.8f;
        [SerializeField] private float controllerRadius = 0.35f;

        [Header("Interaction Test")]
        [SerializeField] private bool addDebugInteractableToStartMarker = true;
        [SerializeField] private string startMarkerName = "Player_Start_Marker";

        private void Awake()
        {
            if (playerSpawnPoint == null)
            {
                GameObject spawn = GameObject.Find("PlayerSpawnPoint");
                playerSpawnPoint = spawn != null ? spawn.transform : transform;
            }

            if (gameplayCamera == null)
            {
                gameplayCamera = Camera.main;
            }

            ThirdPersonPlayerController player = FindAnyObjectByType<ThirdPersonPlayerController>();
            if (player == null)
            {
                player = CreatePlayer();
            }

            WireCamera(player.transform);
            WireInteraction(player.gameObject);
            AddDebugInteractable();
        }

        private ThirdPersonPlayerController CreatePlayer()
        {
            GameObject playerObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            playerObject.name = playerName;
            playerObject.transform.SetPositionAndRotation(playerSpawnPoint.position, playerSpawnPoint.rotation);

            CapsuleCollider capsuleCollider = playerObject.GetComponent<CapsuleCollider>();
            if (capsuleCollider != null)
            {
                Destroy(capsuleCollider);
            }

            CharacterController characterController = playerObject.AddComponent<CharacterController>();
            characterController.height = controllerHeight;
            characterController.radius = controllerRadius;
            characterController.center = Vector3.zero;

            return playerObject.AddComponent<ThirdPersonPlayerController>();
        }

        private void WireCamera(Transform playerTransform)
        {
            if (gameplayCamera == null)
            {
                return;
            }

            ThirdPersonCameraFollow cameraFollow = gameplayCamera.GetComponent<ThirdPersonCameraFollow>();
            if (cameraFollow == null)
            {
                cameraFollow = gameplayCamera.gameObject.AddComponent<ThirdPersonCameraFollow>();
            }

            cameraFollow.SetTarget(playerTransform);

            ThirdPersonPlayerController playerController = playerTransform.GetComponent<ThirdPersonPlayerController>();
            if (playerController != null)
            {
                playerController.SetCameraTransform(gameplayCamera.transform);
            }
        }

        private void WireInteraction(GameObject playerObject)
        {
            InteractionRaycaster raycaster = playerObject.GetComponent<InteractionRaycaster>();
            if (raycaster == null)
            {
                raycaster = playerObject.AddComponent<InteractionRaycaster>();
            }

            raycaster.SetSourceCamera(gameplayCamera);
        }

        private void AddDebugInteractable()
        {
            if (!addDebugInteractableToStartMarker)
            {
                return;
            }

            GameObject marker = GameObject.Find(startMarkerName);
            if (marker != null && marker.GetComponent<DebugInteractable>() == null)
            {
                marker.AddComponent<DebugInteractable>();
            }
        }
    }
}
