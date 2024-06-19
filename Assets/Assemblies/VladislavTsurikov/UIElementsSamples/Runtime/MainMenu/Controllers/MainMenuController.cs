using UnityEngine;
using UnityEngine.UIElements;

namespace VladislavTsurikov.UIElementsSamples.Runtime.MainMenu
{
    /// <summary>
    /// This class is used to manage the main menu in Unity using the UI Toolkit.
    /// The event `clicked` for each button is invoked when the player clicks the button with the left mouse button
    /// or presses the Enter key while the button is focused.
    /// </summary>
    [ExecuteInEditMode]
    public class MainMenuController : MonoBehaviour
    {
        public UIDocument UIDocument;

        public Button ContinueButton;
        public Button LoadGameButton;
        public Button OptionsButton;
        public Button ExtrasButton;
        public Button QuitGameButton;

        private void OnEnable()
        {
            if (!UIDocument.isActiveAndEnabled || UIDocument.rootVisualElement == null)
            {
                return;
            }
            
            var root = UIDocument.rootVisualElement;

            ContinueButton = root.Q<Button>(nameof(ContinueButton));
            LoadGameButton = root.Q<Button>(nameof(LoadGameButton));
            OptionsButton = root.Q<Button>(nameof(OptionsButton));
            ExtrasButton = root.Q<Button>(nameof(ExtrasButton));
            QuitGameButton = root.Q<Button>(nameof(QuitGameButton));

            ContinueButton.clicked += OnContinueButtonClick;
            LoadGameButton.clicked += OnLoadGameButtonClick;
            OptionsButton.clicked += OnOptionsButtonClick;
            ExtrasButton.clicked += OnExtrasButtonClick;
            QuitGameButton.clicked += OnQuitGameButtonClick;
        }

        private void OnDisable()
        {
            if (ContinueButton != null) ContinueButton.clicked -= OnContinueButtonClick;
            if (LoadGameButton != null) LoadGameButton.clicked -= OnLoadGameButtonClick;
            if (OptionsButton != null) OptionsButton.clicked -= OnOptionsButtonClick;
            if (ExtrasButton != null) ExtrasButton.clicked -= OnExtrasButtonClick;
            if (QuitGameButton != null) QuitGameButton.clicked -= OnQuitGameButtonClick;
        }

        private void OnContinueButtonClick()
        {
            Debug.Log("Continue Button Clicked");
        }

        private void OnLoadGameButtonClick()
        {
            Debug.Log("Load Game Button Clicked");
        }

        private void OnOptionsButtonClick()
        {
            Debug.Log("Options Button Clicked");
        }

        private void OnExtrasButtonClick()
        {
            Debug.Log("Extras Button Clicked");
        }

        private void OnQuitGameButtonClick()
        {
            Debug.Log("Quit Game Button Clicked");
        }
    }
}
