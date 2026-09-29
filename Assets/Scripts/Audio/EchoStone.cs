using UnityEngine;
using UnityEngine.Events;

namespace EchoesOfTheDeep.Audio
{
    public class EchoStone : MonoBehaviour
    {
        [SerializeField] private AudioClip capturedEcho;
        [SerializeField] private float playbackCooldown = 1.2f;
        [SerializeField] private UnityEvent onPlayed;

        private float nextPlayTime;

        public bool HasEcho => capturedEcho != null;

        public void Capture(AudioClip clip)
        {
            capturedEcho = clip;
        }

        public void PlayEcho()
        {
            if (!HasEcho || Time.time < nextPlayTime) return;

            nextPlayTime = Time.time + playbackCooldown;
            GameObject audioObject = new GameObject("EchoPlayback");
            audioObject.transform.position = transform.position;

            AudioSource source = audioObject.AddComponent<AudioSource>();
            source.clip = capturedEcho;
            source.spatialBlend = 1f;
            source.Play();

            Destroy(audioObject, capturedEcho.length + 0.25f);
            onPlayed?.Invoke();
        }
    }
}
