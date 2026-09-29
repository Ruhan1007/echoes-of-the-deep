using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Audio
{
    public class HarmonicLock : MonoBehaviour
    {
        [System.Serializable]
        public struct RingTarget
        {
            public float targetDegrees;
            public float tolerance;
        }

        [SerializeField] private RingTarget[] rings = new RingTarget[3];
        [SerializeField] private Transform door;
        [SerializeField] private float openHeight = 2.2f;
        [SerializeField] private float openSpeed = 1.5f;
        [SerializeField] private UnityEvent onSolved;

        private bool solved;

        public void SetRing(int index, float angle)
        {
            if (solved || index < 0 || index >= rings.Length) return;
            if (CheckSolved()) Solve();
        }

        public bool CheckSolved()
        {
            // Individual TwoHandRotate components call SetRing after updating their ring.
            // Replace this with direct ring-angle reads when assigning your scene objects.
            return false;
        }

        public void Solve()
        {
            if (solved) return;
            solved = true;
            onSolved?.Invoke();
        }

        private void Update()
        {
            if (!solved || door == null) return;
            Vector3 target = door.position + Vector3.up * openHeight;
            door.position = Vector3.MoveTowards(door.position, target, openSpeed * Time.deltaTime);
        }
    }
}
