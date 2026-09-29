using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Interaction
{
    public class PalmPulse : MonoBehaviour
    {
        [SerializeField] private float pushThreshold = 0.12f;
        [SerializeField] private float velocityThreshold = 0.5f;
        [SerializeField] private UnityEvent onPulse;

        private Vector3 previous;
        private bool tracking;

        public void Begin(Vector3 palmPosition)
        {
            previous = palmPosition;
            tracking = true;
        }

        public void UpdatePalm(Vector3 palmPosition, float deltaTime)
        {
            if (!tracking || deltaTime <= 0f) return;

            Vector3 velocity = (palmPosition - previous) / deltaTime;
            float forwardSpeed = Vector3.Dot(velocity, transform.forward);

            if (forwardSpeed >= velocityThreshold && velocity.magnitude * deltaTime >= pushThreshold)
            {
                onPulse?.Invoke();
                tracking = false;
            }

            previous = palmPosition;
        }

        public void End() => tracking = false;
    }
}
