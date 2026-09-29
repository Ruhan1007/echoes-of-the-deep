using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Narrative
{
    public class StoryFragment : MonoBehaviour
    {
        [SerializeField] private string fragmentId;
        [TextArea]
        [SerializeField] private string subtitle;
        [SerializeField] private UnityEvent onRevealed;

        public bool Revealed { get; private set; }

        public void Reveal()
        {
            if (Revealed) return;
            Revealed = true;
            onRevealed?.Invoke();
        }

        public string GetId() => fragmentId;
        public string GetSubtitle() => subtitle;
    }
}
