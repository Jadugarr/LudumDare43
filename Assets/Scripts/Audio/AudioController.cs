using UnityEngine;

namespace Audio
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioClip[] bunnyStuckClips;

        private EventManager _eventManager = EventManager.Instance;
        private AudioSource _audioSource;

        private void Start()
        {
            _eventManager.RegisterForEvent(EventTypes.BunnyStuck, OnBunnyStuck);
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnBunnyStuck(IEvent evt)
        {
            AudioClip clipToPlay = bunnyStuckClips[Random.Range(0, bunnyStuckClips.Length)];
            _audioSource.clip = clipToPlay;
            _audioSource.Play();
        }
    }
}