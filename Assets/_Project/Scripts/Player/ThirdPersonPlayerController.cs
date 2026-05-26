using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace GreenvaleAbbey.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class ThirdPersonPlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed = 4.5f;
        [SerializeField] private float sprintSpeed = 7.5f;
        [SerializeField] private float rotationSharpness = 14f;

        [Header("Jumping and Gravity")]
        [SerializeField] private float jumpForce = 6f;
        [SerializeField] private float gravity = -20f;
        [SerializeField] private float groundedStickForce = -2f;

        [Header("References")]
        [SerializeField] private Transform cameraTransform;

        private CharacterController characterController;
        private float verticalVelocity;

        public float MovementSpeed => movementSpeed;
        public float SprintSpeed => sprintSpeed;
        public float JumpForce => jumpForce;
        public float Gravity => gravity;

        private void Reset()
        {
            characterController = GetComponent<CharacterController>();
            AssignMainCamera();
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();

            if (cameraTransform == null)
            {
                AssignMainCamera();
            }
        }

        private void Update()
        {
            Vector2 moveInput = ReadMoveInput();
            bool isSprinting = IsSprintHeld();

            Vector3 moveDirection = BuildCameraRelativeMove(moveInput);
            RotateToward(moveDirection);
            ApplyJumpAndGravity();

            float speed = isSprinting ? sprintSpeed : movementSpeed;
            Vector3 velocity = moveDirection * speed;
            velocity.y = verticalVelocity;

            characterController.Move(velocity * Time.deltaTime);
        }

        public void SetCameraTransform(Transform targetCamera)
        {
            cameraTransform = targetCamera;
        }

        private Vector2 ReadMoveInput()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard == null)
            {
                return Vector2.zero;
            }

            Vector2 input = Vector2.zero;
            input.x = ReadAxis(keyboard.aKey, keyboard.dKey);
            input.y = ReadAxis(keyboard.sKey, keyboard.wKey);
            return Vector2.ClampMagnitude(input, 1f);
        }

        private static float ReadAxis(KeyControl negative, KeyControl positive)
        {
            float value = 0f;

            if (negative.isPressed)
            {
                value -= 1f;
            }

            if (positive.isPressed)
            {
                value += 1f;
            }

            return value;
        }

        private bool IsSprintHeld()
        {
            Keyboard keyboard = Keyboard.current;
            return keyboard != null && (keyboard.leftShiftKey.isPressed || keyboard.rightShiftKey.isPressed);
        }

        private Vector3 BuildCameraRelativeMove(Vector2 moveInput)
        {
            if (moveInput.sqrMagnitude <= 0.001f)
            {
                return Vector3.zero;
            }

            Transform reference = cameraTransform != null ? cameraTransform : transform;
            Vector3 forward = reference.forward;
            Vector3 right = reference.right;

            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            return Vector3.ClampMagnitude((forward * moveInput.y) + (right * moveInput.x), 1f);
        }

        private void RotateToward(Vector3 moveDirection)
        {
            if (moveDirection.sqrMagnitude <= 0.001f)
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                1f - Mathf.Exp(-rotationSharpness * Time.deltaTime));
        }

        private void ApplyJumpAndGravity()
        {
            if (characterController.isGrounded && verticalVelocity < 0f)
            {
                verticalVelocity = groundedStickForce;
            }

            Keyboard keyboard = Keyboard.current;
            if (characterController.isGrounded && keyboard != null && keyboard.spaceKey.wasPressedThisFrame)
            {
                verticalVelocity = jumpForce;
            }

            verticalVelocity += gravity * Time.deltaTime;
        }

        private void AssignMainCamera()
        {
            Camera mainCamera = Camera.main;
            cameraTransform = mainCamera != null ? mainCamera.transform : null;
        }
    }
}
