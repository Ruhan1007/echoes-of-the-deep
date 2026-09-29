using UnityEngine;

namespace EchoesOfTheDeep.Visual
{
    public class SoundReactiveArchitecture : MonoBehaviour
    {
        [SerializeField] private Transform[] elements;
        [SerializeField] private float scaleAmount = 0.06f;
        [SerializeField] private float responseSpeed = 5f;
        [SerializeField] private float simulatedAudio = 0.25f;

        private Vector3[] baseScales;

        private void Awake()
        {
            baseScales = new Vector3[elements.Length];
            for (int i = 0; i < elements.Length; i++)
                if (elements[i] != null) baseScales[i] = elements[i].localScale;
        }

        public void SetAudioEnergy(float energy)
        {
            simulatedAudio = Mathf.Clamp01(energy);
        }

        private void Update()
        {
            float pulse = 1f + simulatedAudio * scaleAmount;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == null) continue;
                Vector3 target = baseScales[i] * pulse;
                elements[i].localScale = Vector3.Lerp(elements[i].localScale, target, Time.deltaTime * responseSpeed);
            }
        }
    }
}
