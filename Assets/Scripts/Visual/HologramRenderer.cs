using UnityEngine;
using UnityEngine.Video;

namespace EchoesOfTheDeep.Visual
{
    public class HologramRenderer : MonoBehaviour
    {
        [SerializeField] private VideoPlayer videoPlayer;
        [SerializeField] private CanvasGroup fadeGroup;
        [SerializeField] private float fadeSpeed = 3f;

        private bool visible;

        public void Reveal()
        {
            visible = true;
            if (videoPlayer != null && !videoPlayer.isPlaying)
                videoPlayer.Play();
        }

        public void Hide()
        {
            visible = false;
            if (videoPlayer != null && videoPlayer.isPlaying)
                videoPlayer.Pause();
        }

        private void Update()
        {
            if (fadeGroup == null) return;
            float target = visible ? 1f : 0f;
            fadeGroup.alpha = Mathf.MoveTowards(fadeGroup.alpha, target, fadeSpeed * Time.deltaTime);
        }
    }
}
