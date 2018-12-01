using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] bunnyStuckClips;
        [SerializeField] private AudioClip[] bunnySpawnedClips;
        [SerializeField] private AudioClip playerJumpedClip;

        private EventManager _eventManager = EventManager.Instance;
        private AudioSource _audioSource;

        private void Start()
        {
            _eventManager.RegisterForEvent(EventTypes.BunnyStuck, OnBunnyStuck);
            _eventManager.RegisterForEvent(EventTypes.BunnySpawned, OnBunnySpawned);
            _eventManager.RegisterForEvent(EventTypes.PlayerJumped, OnPlayerJumped);
            _audioSource = GetComponent<AudioSource>();
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