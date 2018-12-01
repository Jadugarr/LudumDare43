using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class BunniesLeftBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bunniesLeftText;

        private EventManager _eventManager = EventManager.Instance;

        private void OnDestroy()
        {
            _eventManager.RemoveFromEvent(EventTypes.BunniesLeftChanged, OnBunniesLeftChanged);
        }

        private void Start()
        {
            _eventManager.RegisterForEvent(EventTypes.BunniesLeftChanged, OnBunniesLeftChanged);
        }

        private void OnBunniesLeftChanged(IEvent evt)
        {
            RefreshBunniesLeftText();
        }

        private void Awake()
        {
            RefreshBunniesLeftText();
        }

        private void RefreshBunniesLeftText()
        {
            _bunniesLeftText.text = "Bunnies Left: " + LevelDefinitionBehaviour.GetBunniesLeft();
        }
    }
}