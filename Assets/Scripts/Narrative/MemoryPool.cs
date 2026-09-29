using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Narrative
{
    public class MemoryPool : MonoBehaviour
    {
        [SerializeField] private Renderer waterRenderer;
        [SerializeField] private Animator memoryAnimator;
        [SerializeField] private float sensitivity = 2f;
        [SerializeField] private UnityEvent onMemoryChanged;

        private Material waterMaterial;

        private void Awake()
        {
            if (waterRenderer != null)
                waterMaterial = waterRenderer.material;
        }

        public void Disturb(Vector3 handPosition, float intensity)
        {
            intensity = Mathf.Clamp01(intensity * sensitivity);

            if (waterMaterial != null)
                waterMaterial.SetFloat("_RippleStrength", intensity);

            if (memoryAnimator != null)
                memoryAnimator.SetFloat("Ripple", intensity);

            onMemoryChanged?.Invoke();
        }
    }
}
