using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Narrative
{
    public class StoryBeat : MonoBehaviour
    {
        [SerializeField] private string beatId;
        [SerializeField] private UnityEvent onTriggered;
        private bool triggered;

        public void Trigger()
        {
            if (triggered) return;
            triggered = true;
            onTriggered?.Invoke();
        }

        public string BeatId => beatId;
    }
}
