using UnityEngine;

namespace Bunnies
{
    public class SmallBunnyBehaviour : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Level" || (other.gameObject.tag == "SmallBunny" &&
                                                    other.gameObject.GetComponent<Rigidbody2D>().bodyType ==
                                                    RigidbodyType2D.Static))
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }
}