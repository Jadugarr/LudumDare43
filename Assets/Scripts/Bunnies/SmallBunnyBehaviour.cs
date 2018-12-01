using UnityEngine;

namespace Bunnies
{
    public class SmallBunnyBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Sprite mashedBunny;

        private EventManager _eventManager = EventManager.Instance;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Level" || other.gameObject.tag == "Deathplane" || (other.gameObject.tag == "SmallBunny" &&
                                                    other.gameObject.GetComponent<Rigidbody2D>().bodyType ==
                                                    RigidbodyType2D.Static))
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<SpriteRenderer>().sprite = mashedBunny;
                _eventManager.FireEvent(EventTypes.BunnyStuck, null);
            }
        }
    }
}