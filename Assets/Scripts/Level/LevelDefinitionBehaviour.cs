using UnityEngine;

namespace DefaultNamespace
{
    public class LevelDefinitionBehaviour : MonoBehaviour
    {
        [SerializeField] public int StartingBunnies;
        [SerializeField] public int ReplenishmentRate;

        private static int _bunniesLeft;
        public static int BunnyReplenishmentRate;

        private static EventManager _eventManager = EventManager.Instance;
        
        private void Start()
        {
            SetBunniesLeft(StartingBunnies);
            BunnyReplenishmentRate = ReplenishmentRate;
        }

        public static void SetBunniesLeft(int bunniesLeft)
        {
            _bunniesLeft = bunniesLeft;
            _eventManager.FireEvent(EventTypes.BunniesLeftChanged, null);
        }

        public static int GetBunniesLeft()
        {
            return _bunniesLeft;
        }
    }
}