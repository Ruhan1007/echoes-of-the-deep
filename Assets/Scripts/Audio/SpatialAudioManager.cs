using System.Collections.Generic;
using UnityEngine;

namespace EchoesOfTheDeep.Audio
{
    public class SpatialAudioManager : MonoBehaviour
    {
        public static SpatialAudioManager Instance { get; private set; }

        [SerializeField] private int maxActiveSources = 8;
        [SerializeField] private float isolatedVolume = 1.8f;
        [SerializeField] private float normalVolume = 1f;
        [SerializeField] private AnimationCurve distanceIsolation = AnimationCurve.EaseInOut(0, 1, 1, 0);

        private readonly List<SpatialAudioSource> sources = new();
        private SpatialAudioSource isolated;

        private void Awake()
        {
            Instance = this;
        }

        public void Register(SpatialAudioSource source)
        {
            if (source != null && !sources.Contains(source))
                sources.Add(source);
        }

        public void Unregister(SpatialAudioSource source) => sources.Remove(source);

        public void IsolateNear(Vector3 listenerPosition, Vector3 direction, float coneDegrees = 55f)
        {
            SpatialAudioSource best = null;
            float bestScore = -1f;

            foreach (var source in sources)
            {
                if (source == null || !source.IsActiveSource) continue;

                Vector3 toSource = (source.transform.position - listenerPosition).normalized;
                float angle = Vector3.Angle(direction, toSource);
                if (angle > coneDegrees) continue;

                float score = 1f - angle / coneDegrees;
                score *= 1f / (1f + Vector3.Distance(listenerPosition, source.transform.position));

                if (score > bestScore)
                {
                    bestScore = score;
                    best = source;
                }
            }

            SetIsolated(best);
        }

        public void ClearIsolation() => SetIsolated(null);

        private void SetIsolated(SpatialAudioSource next)
        {
            isolated = next;

            foreach (var source in sources)
            {
                if (source == null) continue;
                float target = source == isolated ? isolatedVolume : normalVolume * 0.35f;
                source.SetInteractionGain(target);
            }
        }

        public int GetActiveSourceCount() => Mathf.Min(sources.Count, maxActiveSources);
    }
}
