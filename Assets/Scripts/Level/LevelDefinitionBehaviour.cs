using UnityEngine;

namespace DefaultNamespace
{
    public class LevelDefinitionBehaviour : MonoBehaviour
    {
        [SerializeField] public int StartingBunnies;
        [SerializeField] public int ReplenishmentRate;

        public static int BunniesLeft;
        public static int BunnyReplenishmentRate;

        private void Start()
        {
            BunniesLeft = StartingBunnies;
            BunnyReplenishmentRate = ReplenishmentRate;
        }
    }
}