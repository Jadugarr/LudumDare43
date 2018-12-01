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

        private void Start()
        {
            gameButton.onClick.AddListener(OnGameButtonClicked);
            exitButton.onClick.AddListener(OnExitButtonClicked);
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
            SceneManager.LoadScene("_templateLevel");
        }
    }
}