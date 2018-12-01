using UnityEngine;

namespace Bunnies
{
    public class BunnyController : MonoBehaviour
    {
        [SerializeField] private GameObject bunnyPrefab;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 bunnyPos = new Vector3(mousePos.x, mousePos.y, 0);
                GameObject newBunny = GameObject.Instantiate(bunnyPrefab, bunnyPos, bunnyPrefab.transform.rotation);
                newBunny.GetComponent<Rigidbody2D>().AddForce(new Vector2(100f, 100f));
                // test
            }
        }
    }
}