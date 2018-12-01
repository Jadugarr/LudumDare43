using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class LevelFinishedAreaBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _nextLevelButton;
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _quitGameButton;

        [SerializeField] private string _nextLevelName;

        private void Start()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            _restartLevelButton.onClick.AddListener(OnRestartLevelButtonClicked);
            _quitGameButton.onClick.AddListener(OnQuitGameClicked);
        }

        private void OnQuitGameClicked()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private void OnRestartLevelButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnNextLevelClicked()
        {
            SceneManager.LoadScene(_nextLevelName);
        }
    }
}