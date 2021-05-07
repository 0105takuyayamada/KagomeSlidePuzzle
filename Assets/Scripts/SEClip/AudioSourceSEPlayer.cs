using System.Collections.Generic;
using UnityEngine;

namespace Yamara.Audio
{
    public class AudioSourceSEPlayer : MonoBehaviour
    {
        [SerializeField]
        AudioSource audioSource;

        [Space(10)]
        [SerializeField]
        public bool playOnEnable;
        [SerializeField]
        public SEClip seClip;
        [SerializeField]
        public SEClipStore seClipStore;

        ISEClipObtainable ClipObtainable;

        private void OnEnable()
        {
            if (!playOnEnable) return;
            Play();
        }

        private void Awake()
        {
            if (seClip) ClipObtainable = seClip;
            else if (seClipStore) ClipObtainable = seClipStore;
        }

        public void Play()
        {
            SEPlayer.Play(audioSource, ClipObtainable.GetClip());
        }
    }
}

