using UnityEngine;

namespace Bunnies
{
    public class SmallBunnyBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Sprite mashedBunny;

        [SerializeField]
        private GameObject decal;

        [SerializeField]
        private GameObject bloodSpray;

        private bool isSticking = false;
        private EventManager _eventManager = EventManager.Instance;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isSticking)
            {
                isSticking = true;
                switch (other.gameObject.tag)
                {
                    case "Level":
                        Stick();
                        bloodSpray.SetActive(true);
                        decal.SetActive(true);
                        break;
                    case "SmallBunny":
                        Stick();
                        bloodSpray.SetActive(true);
                        Destroy(decal);
                        break;
                    case "Deathplane":
                        Destroy(this);
                        break;
                    default:
                        isSticking = false;
                        break;
                }
            }
        }

        private void Stick()
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<SpriteRenderer>().sprite = mashedBunny;
            _eventManager.FireEvent(EventTypes.BunnyStuck, null);
        }
    }
}