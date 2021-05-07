using System.Collections.Generic;
using UnityEngine;

namespace Yamara.Audio
{
    public class SEClipPlayer : MonoBehaviour
    {
        [Space(10)]
        [SerializeField]
        public SEClip se;
        [SerializeField]
        public List<AudioClip> clips;

        [SerializeField, Range(0, byte.MaxValue)]
        public byte priority = byte.MaxValue / 2;
        [SerializeField, Range(0f, 1f)]
        public float volume;
        [SerializeField, Range(0f, 0.5f)]
        public float volumeRange;
        [SerializeField]
        public float pitch, pitchRange, delay;
        [SerializeField]
        public bool actOnAwake;

        private void OnEnable()
        {
            if (actOnAwake) Play();
        }

        void Awake()
        {
            if (se == null) se = new SEClip(clips, priority, volume, volumeRange, pitch, pitchRange, delay);
        }

        public void Play()
        {
            if (se)
            {
                SEManager.Instance.Play(se);
                return;
            }

            SEManager.Instance.Play(new SEClip(clips, priority, volume, volumeRange, pitch, pitchRange, delay));
        }
    }
}