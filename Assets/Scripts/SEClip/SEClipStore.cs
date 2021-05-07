using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yamara.Audio
{
    [Serializable]
    public class SEClipStore : MonoBehaviour, ISEClipObtainable
    {
        SEClip clip;

        [SerializeField]
        bool updateValue;

        [SerializeField]
        public List<AudioClip> clips = new List<AudioClip> { null };
        [SerializeField, Range(0, byte.MaxValue)]
        public byte priority = byte.MaxValue / 2;
        [SerializeField, Range(0f, 1f)]
        public float volume = 1f;
        [SerializeField, Range(0f, 0.5f)]
        public float volumeRange;
        [SerializeField]
        public float pitch = 1f, pitchRange, delay;

        private void UpdateValue()
        {
            clip = new SEClip(clips, priority, volume, volumeRange, pitch, pitchRange, delay);
        }

        public SEClip GetClip()
        {
            return clip;
        }
    }
}