using Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuBehaviour : MonoBehaviour
    {
        [SerializeField] private Button gameButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button funModeButton;

        private void Start()
        {
            gameButton.onClick.AddListener(OnGameButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
            funModeButton.onClick.AddListener(OnFunModeButtonClicked);
        }

        private void OnFunModeButtonClicked()
        {
            StaticConstants.FunModeActive = true;
            SceneManager.LoadScene("Level1");
        }

        private void OnExitButtonClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private void OnGameButtonClicked()
        {
            StaticConstants.FunModeActive = false;
            SceneManager.LoadScene("Level1");
        }
    }
}