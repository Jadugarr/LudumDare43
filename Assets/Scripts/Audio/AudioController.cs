using UnityEngine;
using UnityEngine.SceneManagement;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] bunnyStuckClips;
        [SerializeField] private AudioClip[] bunnySpawnedClips;
        [SerializeField] private AudioClip playerJumpedClip;
        [SerializeField] private AudioClip mainMenuMusic;
        [SerializeField] private AudioClip levelMusic;
        [SerializeField] private AudioSource musicSource;

        private AudioClip currentBGMClip;

        private EventManager _eventManager = EventManager.Instance;
        private AudioSource _audioSource;

        private AudioController _audioController;

        private void Start()
        {
            if (_audioController == null)
            {
                _audioController = this;
                DontDestroyOnLoad(this);
                
                _eventManager.RegisterForEvent(EventTypes.BunnyStuck, OnBunnyStuck);
                _eventManager.RegisterForEvent(EventTypes.BunnySpawned, OnBunnySpawned);
                _eventManager.RegisterForEvent(EventTypes.PlayerJumped, OnPlayerJumped);
                _audioSource = GetComponent<AudioSource>();
                SceneManager.sceneLoaded += OnSceneLoaded;

                musicSource.clip = mainMenuMusic;
                musicSource.Play();
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnSceneLoaded(Scene loadedScene, LoadSceneMode loadMode)
        {
            if (loadedScene.name == "MainMenu")
            {
                if (currentBGMClip != mainMenuMusic)
                {
                    musicSource.clip = mainMenuMusic;
                    currentBGMClip = mainMenuMusic;
                    musicSource.Play();
                }
            }
            else
            {
                if (currentBGMClip != levelMusic)
                {
                    musicSource.clip = levelMusic;
                    currentBGMClip = levelMusic;
                    musicSource.Play();
                }
            }
        }

        private void OnDestroy()
        {
            _eventManager.RemoveFromEvent(EventTypes.BunnyStuck, OnBunnyStuck);
            _eventManager.RemoveFromEvent(EventTypes.BunnySpawned, OnBunnySpawned);
            _eventManager.RemoveFromEvent(EventTypes.PlayerJumped, OnPlayerJumped);
        }

        private void OnPlayerJumped(IEvent evt)
        {
            _audioSource.clip = playerJumpedClip;
            _audioSource.Play(0);
        }

        private void OnBunnySpawned(IEvent evt)
        {
            AudioClip clipToPlay = bunnySpawnedClips[Random.Range(0, bunnySpawnedClips.Length)];
            _audioSource.clip = clipToPlay;
            _audioSource.Play(0);
        }

        private void OnBunnyStuck(IEvent evt)
        {
            AudioClip clipToPlay = bunnyStuckClips[Random.Range(0, bunnyStuckClips.Length)];
            _audioSource.clip = clipToPlay;
            _audioSource.Play(0);
        }
    }
}