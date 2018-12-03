using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace Common
{
    public class GameController : MonoBehaviour
    {
        private static GameController _gameController;

        private PlayableDirector _playableDirector;

        private void Start()
        {
            if (_gameController == null)
            {
                _gameController = this;
                SceneManager.sceneLoaded += OnNewSceneLoaded;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnNewSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            _playableDirector = FindObjectOfType<PlayableDirector>();

            if (_playableDirector != null && StaticConstants.PlayLevelIntro)
            {
                _playableDirector.Play();
                StaticConstants.PlayLevelIntro = false;
                StaticConstants.AcceptPlayerInput = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Scene currentScene = SceneManager.GetActiveScene();

                if ((currentScene.name == "Level1" ||
                    currentScene.name == "Level2" ||
                    currentScene.name == "Level3") && StaticConstants.AcceptPlayerInput)
                {
                    SceneManager.LoadScene(currentScene.name);
                }
            }
        }
    }
}