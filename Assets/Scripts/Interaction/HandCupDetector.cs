using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Interaction
{
    public class HandCupDetector : MonoBehaviour
    {
        [SerializeField] private Transform earAnchor;
        [SerializeField] private Transform palmAnchor;
        [SerializeField] private float maxDistance = 0.22f;
        [SerializeField] private float palmFacingThreshold = 0.25f;
        [SerializeField] private UnityEvent onCupStart;
        [SerializeField] private UnityEvent onCupEnd;

        public bool IsCupped { get; private set; }

        // Feed this from Meta XR hand-joint tracking.
        public void UpdateHandPose(Vector3 palmPosition, Vector3 palmForward, Vector3 earPosition)
        {
            if (earAnchor == null) return;

            float distance = Vector3.Distance(palmPosition, earPosition);
            float facing = Vector3.Dot(palmForward.normalized, (earPosition - palmPosition).normalized);

            bool next = distance <= maxDistance && facing >= palmFacingThreshold;

            if (next == IsCupped) return;
            IsCupped = next;

            if (IsCupped) onCupStart?.Invoke();
            else onCupEnd?.Invoke();
        }

        public void Clear()
        {
            if (!IsCupped) return;
            IsCupped = false;
            onCupEnd?.Invoke();
        }
    }
}
