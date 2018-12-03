using Common;
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
            if (StaticConstants.FunModeActive)
            {
                gameObject.SetActive(false);
            }
            else
            {
                RefreshBunniesLeftText();
            }
        }

        private void RefreshBunniesLeftText()
        {
            _bunniesLeftText.text = "x " + LevelDefinitionBehaviour.GetBunniesLeft();
        }
    }
}