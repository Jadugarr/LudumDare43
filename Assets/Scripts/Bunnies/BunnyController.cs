using UnityEngine;

namespace Bunnies
{
    public class BunnyController : MonoBehaviour
    {
        [SerializeField] private GameObject bunnyPrefab;
        [SerializeField] private GameObject playerBunny;

        [SerializeField, Range(500, 3000)] private int _bunnySpawnForce;
        [SerializeField, Range(300, 1000)] private int _bunnySpawnKnockback;

        private EventManager _eventManager = EventManager.Instance;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePos - playerBunny.transform.position).normalized;
                Vector3 newBunnyPos = new Vector3(playerBunny.transform.position.x + direction.x + (1f * direction.x),
                    playerBunny.transform.position.y + direction.y + (1f * direction.y), 0);
                GameObject newBunny = GameObject.Instantiate(bunnyPrefab, newBunnyPos, bunnyPrefab.transform.rotation);
                newBunny.GetComponent<Rigidbody2D>().AddForce(direction * _bunnySpawnForce);
                
                playerBunny.GetComponent<Rigidbody2D>().AddForce(-direction * _bunnySpawnKnockback);

                _eventManager.FireEvent(EventTypes.BunnySpawned, null);
            }
        }
    }
}