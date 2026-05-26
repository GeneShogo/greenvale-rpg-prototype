using UnityEngine;
using UnityEngine.InputSystem;

namespace GreenvaleAbbey.Player
{
    public sealed class ThirdPersonCameraFollow : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 targetOffset = new Vector3(0f, 1.5f, 0f);

        [Header("Camera")]
        [SerializeField] private float distance = 5f;
        [SerializeField] private float minPitch = -25f;
        [SerializeField] private float maxPitch = 70f;
        [SerializeField] private float cameraSensitivity = 0.12f;
        [SerializeField] private float followSharpness = 18f;
        [SerializeField] private bool lockCursorOnStart = true;

        private float yaw;
        private float pitch = 25f;

        public float CameraSensitivity => cameraSensitivity;

        private void Start()
        {
            Vector3 euler = transform.eulerAngles;
            yaw = euler.y;
            pitch = NormalizePitch(euler.x);

            if (lockCursorOnStart)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        private void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            UpdateLookAngles();
            UpdateCameraPosition();
            UpdateCursorUnlock();
        }

        public void SetTarget(Transform followTarget)
        {
            target = followTarget;
        }

        private void UpdateLookAngles()
        {
            Mouse mouse = Mouse.current;
            if (mouse == null)
            {
                return;
            }

            Vector2 lookDelta = mouse.delta.ReadValue();
            yaw += lookDelta.x * cameraSensitivity;
            pitch -= lookDelta.y * cameraSensitivity;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        }

        private void UpdateCameraPosition()
        {
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            Vector3 focusPoint = target.position + targetOffset;
            Vector3 desiredPosition = focusPoint - (rotation * Vector3.forward * distance);

            transform.position = Vector3.Lerp(
                transform.position,
                desiredPosition,
                1f - Mathf.Exp(-followSharpness * Time.deltaTime));
            transform.rotation = rotation;
        }

        private void UpdateCursorUnlock()
        {
            Keyboard keyboard = Keyboard.current;
            if (keyboard != null && keyboard.escapeKey.wasPressedThisFrame)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        private static float NormalizePitch(float eulerX)
        {
            return eulerX > 180f ? eulerX - 360f : eulerX;
        }
    }
}
