using UnityEngine;

namespace Common
{
    public class TimelineBehaviour: MonoBehaviour
    {
        public void LevelIntroFinished()
        {
            StaticConstants.AcceptPlayerInput = true;
        }
    }
}