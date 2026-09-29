using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Interaction
{
    public class PinchPull : MonoBehaviour
    {
        [SerializeField] private float pullDistance = 0.16f;
        [SerializeField] private Transform handle;
        [SerializeField] private UnityEvent onReveal;

        private Vector3 start;
        private bool grabbed;

        public void BeginPinch(Vector3 pinchPosition)
        {
            start = pinchPosition;
            grabbed = true;
        }

        public void UpdatePinch(Vector3 pinchPosition)
        {
            if (!grabbed) return;

            float distance = Vector3.Distance(start, pinchPosition);
            if (distance >= pullDistance)
            {
                grabbed = false;
                onReveal?.Invoke();
            }
        }

        public void EndPinch() => grabbed = false;
    }
}
