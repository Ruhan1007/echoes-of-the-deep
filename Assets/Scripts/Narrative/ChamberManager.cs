using System;
using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Narrative
{
    public class ChamberManager : MonoBehaviour
    {
        public enum Chamber
        {
            Descent = 0,
            Gallery = 1,
            HarmonicLock = 2,
            MemoryPool = 3,
            EchoChamber = 4
        }

        [Serializable]
        public class ChamberEntry
        {
            public Chamber id;
            public GameObject root;
            public UnityEvent onEnter;
        }

        [SerializeField] private ChamberEntry[] chambers;
        [SerializeField] private Chamber startingChamber = Chamber.Descent;
        [SerializeField] private UnityEvent onExperienceComplete;

        public Chamber Current { get; private set; }

        private void Start()
        {
            Enter(startingChamber);
        }

        public void Enter(Chamber next)
        {
            Current = next;

            foreach (var chamber in chambers)
            {
                if (chamber.root != null)
                    chamber.root.SetActive(chamber.id == next);

                if (chamber.id == next)
                    chamber.onEnter?.Invoke();
            }
        }

        public void Next()
        {
            if ((int)Current >= chambers.Length - 1)
            {
                onExperienceComplete?.Invoke();
                return;
            }

            Enter((Chamber)((int)Current + 1));
        }
    }
}
