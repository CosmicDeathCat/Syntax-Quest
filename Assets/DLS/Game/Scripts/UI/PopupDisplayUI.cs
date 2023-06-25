using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLS.Dialogue;
using DLS.Game.Scripts.Messages;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.Prompts;
using DLS.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DLS.Game.Scripts.UI
{
    public class PopupDisplayUI : MonoBehaviour
    {
        public static PopupDisplayUI instance;

        [SerializeField] private GameObject confirmDialog, optionsDialog, textDialog;

        [SerializeField] private TMP_Text confimPopupText, optionsPopupText, textPopupText;

        [SerializeField] private Button confirmButton,
            cancelButton,
            option1Button,
            option2Button,
            option3Button,
            option4Button,
            okButton;

        public GameObject ConfirmDialog
        {
            get => confirmDialog;
            set => confirmDialog = value;
        }

        public GameObject OptionsDialog
        {
            get => optionsDialog;
            set => optionsDialog = value;
        }

        public GameObject TextDialog
        {
            get => textDialog;
            set => textDialog = value;
        }

        public TMP_Text PopupText
        {
            get => confimPopupText;
            set => confimPopupText = value;
        }

        public TMP_Text OptionsPopupText
        {
            get => optionsPopupText;
            set => optionsPopupText = value;
        }

        public TMP_Text tTextPopupText
        {
            get => textPopupText;
            set => textPopupText = value;
        }

        public Button ConfirmButton
        {
            get => confirmButton;
            set => confirmButton = value;
        }

        public Button CancelButton
        {
            get => cancelButton;
            set => cancelButton = value;
        }

        public Button Option1Button
        {
            get => option1Button;
            set => option1Button = value;
        }

        public Button Option2Button
        {
            get => option2Button;
            set => option2Button = value;
        }

        public Button Option3Button
        {
            get => option3Button;
            set => option3Button = value;
        }

        public Button Option4Button
        {
            get => option4Button;
            set => option4Button = value;
        }

        public Button OkButton
        {
            get => okButton;
            set => okButton = value;
        }

        private EventSystem eventSystem;


        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                eventSystem = FindObjectOfType<EventSystem>();
            }
        }

        public void ShowOptionsPopup(string text, List<QuizOption> options)
        {
            optionsDialog.gameObject.SetActive(true);
            MessageSystem.MessageManager.SendImmediate(MessageChannels.GameFlow, new PauseMessage(true));
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(false));

            // Shuffle the options
            System.Random rng = new System.Random();
            options = options.OrderBy(a => rng.Next()).ToList();

            // Adding the options text to the question prompt
            StringBuilder sb = new StringBuilder(text);
            for (int i = 0; i < options.Count; i++)
            {
                sb.Append($"\n{i+1}. {options[i].Text}");
            }
            // Set the text
            optionsPopupText.text = sb.ToString();

            eventSystem.SetSelectedGameObject(option1Button.gameObject);

            // Configure the buttons
            
            option1Button.onClick.AddListener(() => { PopupDisplayUI.instance.ShowConfirmPopup(options[0].IsAnswer ? "CORRECT!" : "INCORRECT!", () => { }); });
            option1Button.onClick.AddListener(HideOptionsDialog);
            option1Button.gameObject.SetActive(true);

            if (options.Count >= 2)
            {
                option2Button.onClick.AddListener(() => { PopupDisplayUI.instance.ShowConfirmPopup(options[1].IsAnswer ? "CORRECT!" : "INCORRECT!", () => { }); });
                option2Button.onClick.AddListener(HideOptionsDialog);
                option2Button.gameObject.SetActive(true);
            }

            if (options.Count >= 3)
            {
                option3Button.onClick.AddListener(() => { PopupDisplayUI.instance.ShowConfirmPopup(options[2].IsAnswer ? "CORRECT!" : "INCORRECT!", () => { }); });
                option3Button.onClick.AddListener(HideOptionsDialog);
                option3Button.gameObject.SetActive(true);
            }

            if (options.Count >= 4)
            {
                option4Button.onClick.AddListener(() => { PopupDisplayUI.instance.ShowConfirmPopup(options[3].IsAnswer ? "CORRECT!" : "INCORRECT!", () => { }); });
                option4Button.onClick.AddListener(HideOptionsDialog);
                option4Button.gameObject.SetActive(true);
            }
        }


        public void ShowTextPopup(string text, UnityAction okAction = null)
        {
            textDialog.gameObject.SetActive(true);
            MessageSystem.MessageManager.SendImmediate(MessageChannels.GameFlow, new PauseMessage(true));
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(false));
            textPopupText.text = text;
            eventSystem.SetSelectedGameObject(okButton.gameObject);
            if (okButton != null)
            {
                okButton.onClick.AddListener(okAction);
                okButton.onClick.AddListener(HideTextDialog);
            }
        }

        public void ShowConfirmPopup(string text, UnityAction confirmAction = null, UnityAction cancelAction = null)
        {
            confirmDialog.gameObject.SetActive(true);
            MessageSystem.MessageManager.SendImmediate(MessageChannels.GameFlow, new PauseMessage(true));
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(false));
            confimPopupText.text = text;
            eventSystem.SetSelectedGameObject(confirmButton.gameObject);
            if (confirmAction != null)
            {
                confirmButton.onClick.AddListener(confirmAction);
                confirmButton.onClick.AddListener(HideConfrimDialog);
                confirmButton.gameObject.SetActive(true);
            }
            else
            {
                confirmButton.gameObject.SetActive(false);
            }

            if (cancelAction != null)
            {
                cancelButton.onClick.AddListener(cancelAction);
                cancelButton.onClick.AddListener(HideConfrimDialog);
                cancelButton.gameObject.SetActive(true);
            }
            else
            {
                cancelButton.gameObject.SetActive(false);
            }
        }

        public void HideAllDialogs()
        {
            confirmDialog.SetActive(false);
            optionsDialog.SetActive(false);
            confirmButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
            option1Button.onClick.RemoveAllListeners();
            option2Button.onClick.RemoveAllListeners();
            option3Button.onClick.RemoveAllListeners();
            option4Button.onClick.RemoveAllListeners();
            MessageSystem.MessageManager.SendImmediate(MessageChannels.GameFlow, new PauseMessage(false));
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(true));
        }

        public void HideConfrimDialog()
        {
            confirmDialog.SetActive(false);
            confirmButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
            MessageSystem.MessageManager.SendImmediate(MessageChannels.GameFlow, new PauseMessage(false));
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(true));
        }

        public void HideOptionsDialog()
        {
            optionsDialog.SetActive(false);
            option1Button.onClick.RemoveAllListeners();
            option2Button.onClick.RemoveAllListeners();
            option3Button.onClick.RemoveAllListeners();
            option4Button.onClick.RemoveAllListeners();
        }

        public void HideTextDialog()
        {
            textDialog.SetActive(false);
            okButton.onClick.RemoveAllListeners();
            MessageSystem.MessageManager.SendImmediate(MessageChannels.GameFlow, new PauseMessage(false));
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(true));
        }
    }
}