using UnityEngine;

namespace Bunnies
{
    public class SmallBunnyBehaviour : MonoBehaviour
    {
        [SerializeField] private Sprite mashedBunny;

        [SerializeField] private GameObject decal;

        [SerializeField] private GameObject bloodSpray;

        [SerializeField] private GameObject environmentChecker;

        [SerializeField] private float rotationSpeed;

        private bool isSticking = false;
        private EventManager _eventManager = EventManager.Instance;
        private bool shouldRotate = true;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!isSticking)
            {
                
                switch (other.gameObject.tag)
                {
                    case "Level":
                        isSticking = true;
                        Stick();
                        bloodSpray.SetActive(true);
                        decal.SetActive(true);
                        ContactPoint2D contact = other.GetContact(0);
                        var quatHit = Quaternion.FromToRotation(Vector3.up , contact.normal);
                        var quatForward = Quaternion.FromToRotation(Vector3.forward, other.transform.forward);
                        var quatC = quatHit * quatForward;
                        transform.rotation = quatC;
                        break;
                    case "SmallBunny":
                        SmallBunnyBehaviour otherBunny = other.gameObject.GetComponent<SmallBunnyBehaviour>();
                        if (otherBunny && otherBunny.isSticking)
                        {
                            isSticking = true;
                            Stick();
                            bloodSpray.SetActive(true);
                            Destroy(decal);
                        }

                        break;
                    case "Deathplane":
                        Destroy(this);
                        break;
                }
            }
        }

        private void Stick()
        {
            Destroy(environmentChecker);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<SpriteRenderer>().sprite = mashedBunny;
            gameObject.layer = 8;
            _eventManager.FireEvent(EventTypes.BunnyStuck, null);
            shouldRotate = false;
        }

        private void Update()
        {
            if (shouldRotate)
            {
                gameObject.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
            }
        }
    }
}