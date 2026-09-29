using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Interaction
{
    public class TwoHandRotate : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float sensitivity = 1f;
        [SerializeField] private float snapStep = 15f;
        [SerializeField] private UnityEvent<float> onAngleChanged;

        private Vector3 previousVector;
        private bool active;

        public void BeginTwoHand(Vector3 leftHand, Vector3 rightHand)
        {
            previousVector = rightHand - leftHand;
            active = true;
        }

        public void UpdateTwoHand(Vector3 leftHand, Vector3 rightHand)
        {
            if (!active || target == null) return;

            Vector3 current = rightHand - leftHand;
            float signed = Vector3.SignedAngle(previousVector, current, transform.forward);
            target.Rotate(Vector3.forward, signed * sensitivity, Space.Self);
            previousVector = current;

            float snapped = Mathf.Round(target.localEulerAngles.z / snapStep) * snapStep;
            onAngleChanged?.Invoke(Mathf.Repeat(snapped, 360f));
        }

        public void EndTwoHand() => active = false;
    }
}
