using Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class GameOverAreaBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _restartLevelButton;
        [SerializeField] private Button _quitGameButton;

        private void Start()
        {
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
            StaticConstants.AcceptPlayerInput = true;
        }
    }
}