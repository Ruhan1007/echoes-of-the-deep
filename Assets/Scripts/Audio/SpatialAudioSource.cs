using UnityEngine;

namespace EchoesOfTheDeep.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SpatialAudioSource : MonoBehaviour
    {
        [SerializeField] private AudioClip clip;
        [SerializeField] private bool loop = true;
        [SerializeField] private float baseVolume = 1f;
        [SerializeField] private bool activeSource = true;

        private AudioSource source;
        private float interactionGain = 1f;

        public bool IsActiveSource => activeSource;
        public AudioSource Source => source;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
            source.clip = clip;
            source.loop = loop;
            source.playOnAwake = true;
            source.spatialBlend = 1f;
            source.rolloffMode = AudioRolloffMode.Custom;
            source.volume = baseVolume;
        }

        private void OnEnable()
        {
            if (SpatialAudioManager.Instance != null)
                SpatialAudioManager.Instance.Register(this);
        }

        private void OnDisable()
        {
            if (SpatialAudioManager.Instance != null)
                SpatialAudioManager.Instance.Unregister(this);
        }

        public void SetInteractionGain(float gain)
        {
            interactionGain = gain;
            if (source != null)
                source.volume = baseVolume * interactionGain;
        }
    }
}
