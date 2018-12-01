using Common;
using UnityEngine;

namespace DefaultNamespace
{
    public class EndLevelTriggerBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject LevelFinishedArea;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                StaticConstants.PlayLevelIntro = true;
                StaticConstants.AcceptPlayerInput = false;
                LevelFinishedArea.SetActive(true);
            }
        }
    }
}