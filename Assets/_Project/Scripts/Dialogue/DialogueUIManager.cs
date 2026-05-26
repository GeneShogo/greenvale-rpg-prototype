using GreenvaleAbbey.Interaction;
using GreenvaleAbbey.Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace GreenvaleAbbey.Dialogue
{
    public sealed class DialogueUIManager : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject dialoguePanel;
        [SerializeField] private Text npcNameText;
        [SerializeField] private Text dialogueBodyText;
        [SerializeField] private Button closeButton;

        [Header("Input")]
        [SerializeField] private Key closeKey = Key.Escape;
        [SerializeField] private Key continueKey = Key.E;
        [SerializeField] private bool pausePlayerInput = true;

        private ThirdPersonPlayerController pausedPlayerController;
        private ThirdPersonCameraFollow pausedCameraFollow;
        private InteractionRaycaster pausedRaycaster;
        private int openedFrame = -1;

        public static DialogueUIManager Instance { get; private set; }
        public bool IsOpen => dialoguePanel != null && dialoguePanel.activeSelf;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            EnsureUI();
            HideImmediate();
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }

        private void Update()
        {
            if (!IsOpen || Time.frameCount == openedFrame)
            {
                return;
            }

            Keyboard keyboard = Keyboard.current;
            if (keyboard != null && (keyboard[closeKey].wasPressedThisFrame || keyboard[continueKey].wasPressedThisFrame))
            {
                CloseDialogue();
            }
        }

        public static DialogueUIManager CreateDefault()
        {
            DialogueUIManager existing = Instance;
            if (existing != null)
            {
                return existing;
            }

            GameObject managerObject = new GameObject("Dialogue UI Manager");
            return managerObject.AddComponent<DialogueUIManager>();
        }

        public void ShowDialogue(NPCDialogue dialogue, GameObject interactor)
        {
            if (dialogue == null)
            {
                return;
            }

            EnsureUI();
            npcNameText.text = dialogue.NpcName;
            dialogueBodyText.text = dialogue.DialogueText;
            dialoguePanel.SetActive(true);
            openedFrame = Time.frameCount;

            if (pausePlayerInput)
            {
                PausePlayer(interactor);
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void CloseDialogue()
        {
            HideImmediate();
            ResumePlayer();
            openedFrame = -1;
        }

        private void EnsureUI()
        {
            if (dialoguePanel != null && npcNameText != null && dialogueBodyText != null && closeButton != null)
            {
                closeButton.onClick.RemoveListener(CloseDialogue);
                closeButton.onClick.AddListener(CloseDialogue);
                return;
            }

            BuildDefaultUI();
        }

        private void BuildDefaultUI()
        {
            EnsureEventSystem();

            if (canvas == null)
            {
                GameObject canvasObject = new GameObject("Dialogue Canvas", typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
                canvas = canvasObject.GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;

                CanvasScaler scaler = canvasObject.GetComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1920f, 1080f);
                scaler.matchWidthOrHeight = 0.5f;
            }

            dialoguePanel = CreatePanel(canvas.transform);
            npcNameText = CreateText("NPC Name", dialoguePanel.transform, 24, FontStyle.Bold, TextAnchor.UpperLeft);
            dialogueBodyText = CreateText("Dialogue Body", dialoguePanel.transform, 18, FontStyle.Normal, TextAnchor.UpperLeft);
            closeButton = CreateCloseButton(dialoguePanel.transform);
            closeButton.onClick.AddListener(CloseDialogue);
        }

        private static void EnsureEventSystem()
        {
            if (EventSystem.current != null)
            {
                return;
            }

            GameObject eventSystemObject = new GameObject("EventSystem", typeof(EventSystem), typeof(InputSystemUIInputModule));
            EventSystem.current = eventSystemObject.GetComponent<EventSystem>();
        }

        private static GameObject CreatePanel(Transform parent)
        {
            GameObject panel = new GameObject("Dialogue Panel", typeof(RectTransform), typeof(Image));
            panel.transform.SetParent(parent, false);

            RectTransform rect = panel.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.12f, 0.05f);
            rect.anchorMax = new Vector2(0.88f, 0.28f);
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            Image image = panel.GetComponent<Image>();
            image.color = new Color(0.08f, 0.07f, 0.06f, 0.92f);

            return panel;
        }

        private static Text CreateText(string name, Transform parent, int fontSize, FontStyle style, TextAnchor alignment)
        {
            GameObject textObject = new GameObject(name, typeof(RectTransform), typeof(Text));
            textObject.transform.SetParent(parent, false);

            Text text = textObject.GetComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
            text.fontSize = fontSize;
            text.fontStyle = style;
            text.alignment = alignment;
            text.color = Color.white;
            text.horizontalOverflow = HorizontalWrapMode.Wrap;
            text.verticalOverflow = VerticalWrapMode.Overflow;

            RectTransform rect = textObject.GetComponent<RectTransform>();
            rect.anchorMin = name == "NPC Name" ? new Vector2(0.04f, 0.66f) : new Vector2(0.04f, 0.22f);
            rect.anchorMax = name == "NPC Name" ? new Vector2(0.78f, 0.9f) : new Vector2(0.78f, 0.64f);
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            return text;
        }

        private static Button CreateCloseButton(Transform parent)
        {
            GameObject buttonObject = new GameObject("Close Button", typeof(RectTransform), typeof(Image), typeof(Button));
            buttonObject.transform.SetParent(parent, false);

            RectTransform rect = buttonObject.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.81f, 0.24f);
            rect.anchorMax = new Vector2(0.96f, 0.62f);
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            Image image = buttonObject.GetComponent<Image>();
            image.color = new Color(0.22f, 0.2f, 0.17f, 1f);

            Button button = buttonObject.GetComponent<Button>();
            button.targetGraphic = image;
            Text label = CreateText("Close Label", buttonObject.transform, 18, FontStyle.Bold, TextAnchor.MiddleCenter);
            label.text = "Close";

            RectTransform labelRect = label.GetComponent<RectTransform>();
            labelRect.anchorMin = Vector2.zero;
            labelRect.anchorMax = Vector2.one;
            labelRect.offsetMin = Vector2.zero;
            labelRect.offsetMax = Vector2.zero;

            return button;
        }

        private void HideImmediate()
        {
            if (dialoguePanel != null)
            {
                dialoguePanel.SetActive(false);
            }
        }

        private void PausePlayer(GameObject interactor)
        {
            if (interactor == null)
            {
                return;
            }

            pausedPlayerController = interactor.GetComponent<ThirdPersonPlayerController>();
            pausedRaycaster = interactor.GetComponent<InteractionRaycaster>();
            pausedCameraFollow = Camera.main != null ? Camera.main.GetComponent<ThirdPersonCameraFollow>() : null;

            if (pausedPlayerController != null)
            {
                pausedPlayerController.enabled = false;
            }

            if (pausedCameraFollow != null)
            {
                pausedCameraFollow.enabled = false;
            }

            if (pausedRaycaster != null)
            {
                pausedRaycaster.enabled = false;
            }
        }

        private void ResumePlayer()
        {
            if (pausedPlayerController != null)
            {
                pausedPlayerController.enabled = true;
            }

            if (pausedCameraFollow != null)
            {
                pausedCameraFollow.enabled = true;
            }

            if (pausedRaycaster != null)
            {
                pausedRaycaster.enabled = true;
            }

            pausedPlayerController = null;
            pausedCameraFollow = null;
            pausedRaycaster = null;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
