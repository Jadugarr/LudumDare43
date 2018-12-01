using UnityEngine;

namespace Bunnies
{
    public class SmallBunnyBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Sprite mashedBunny;

        [SerializeField]
        private GameObject decal;

        private EventManager _eventManager = EventManager.Instance;

        private void OnCollisionEnter2D(Collision2D other)
        {
            switch (other.gameObject.tag)
            {
                case "Level":
                    Stick();
                    GameObject decalObject = Instantiate(decal, this.transform);
                    break;
                case "SmallBunny":
                    Stick();
                    break;
                case "Deathplane":
                    Destroy(this);
                    break;
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