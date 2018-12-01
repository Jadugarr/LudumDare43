using UnityEngine;

namespace Bunnies
{
    public class BunnyController : MonoBehaviour
    {
        [SerializeField] private GameObject bunnyPrefab;
        [SerializeField] private GameObject playerBunny;

        private EventManager _eventManager = EventManager.Instance;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePos - playerBunny.transform.position).normalized;
                Vector3 newBunnyPos = new Vector3(playerBunny.transform.position.x + direction.x + 0.5f, playerBunny.transform.position.y + direction.y + 0.5f, 0);
                GameObject newBunny = GameObject.Instantiate(bunnyPrefab, newBunnyPos, bunnyPrefab.transform.rotation);
                newBunny.GetComponent<Rigidbody2D>().AddForce(direction * 1000f);
                
                _eventManager.FireEvent(EventTypes.BunnySpawned, null);
            }
        }
    }
}