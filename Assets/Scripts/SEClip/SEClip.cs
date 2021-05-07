using System;
using System.Collections.Generic;
using UnityEngine;

namespace Yamara.Audio
{
    public interface ISEClipObtainable
    {
        SEClip GetClip();
    }

    [CreateAssetMenu(menuName = "Scriptable/Create SEClip")]
    [Serializable]
    public class SEClip : ScriptableObject, ISEClipObtainable
    {
        private const byte DEFAULT_PRIORITY = byte.MaxValue / 2;

        public List<AudioClip> clips;
        [SerializeField, Range(0, byte.MaxValue)]
        public byte priority = byte.MaxValue / 2;
        [SerializeField, Range(0f, 1f)]
        public float volume = 1f;
        [SerializeField, Range(0f, 0.5f)]
        public float volumeRange;
        public float pitch = 1f, pitchRange, delay;

        public SEClip(AudioClip audioClip, float volume)
        {
            new SEClip(audioClip, DEFAULT_PRIORITY, volume, 0f, 1f, 0f, 0f);
        }
        public SEClip(AudioClip audioClip, float volume, float delay)
        {
            new SEClip(audioClip, DEFAULT_PRIORITY, volume, 0f, 1f, 0f, delay);
        }
        public SEClip(AudioClip audioClip, float volume, float pitch, float delay)
        {
            new SEClip(audioClip, priority, volume, 0f, pitch, 0f, delay);
        }
        public SEClip(AudioClip audioClip, float volume, float volumeRange, float pitch, float pitchRange)
        {
            new SEClip(audioClip, DEFAULT_PRIORITY, volume, volumeRange, pitch, pitchRange, 0f);
        }
        public SEClip(AudioClip audioClip, byte priority, float volume)
        {
            new SEClip(audioClip, priority, volume, 0f, 1f, 0f, 0f);
        }
        public SEClip(AudioClip audioClip, byte priority, float volume, float delay)
        {
            new SEClip(audioClip, priority, volume, 0f, 1f, 0f, delay);
        }
        public SEClip(AudioClip audioClip, byte priority, float volume, float pitch, float delay)
        {
            new SEClip(audioClip, priority, volume, 0f, pitch, 0f, delay);
        }
        public SEClip(AudioClip audioClip, byte priority, float volume, float volumeRange, float pitch, float pitchRange)
        {
            new SEClip(audioClip, priority, volume, volumeRange, pitch, pitchRange, 0f);
        }
        public SEClip(AudioClip audioClip, byte priority, float volume, float volumeRange, float pitch, float pitchRange, float delay)
        {
            clips = new List<AudioClip>() { audioClip };
            this.priority = priority;
            this.volume = volume;
            this.volumeRange = volumeRange;
            this.pitch = pitch;
            this.pitchRange = pitchRange;
            this.delay = delay;
        }

        public SEClip(List<AudioClip> clips, float volume)
        {
            new SEClip(clips, DEFAULT_PRIORITY, volume, 0f, 1f, 0f, 0f);
        }
        public SEClip(List<AudioClip> clips, float volume, float delay)
        {
            new SEClip(clips, DEFAULT_PRIORITY, volume, 0f, 1f, 0f, delay);
        }
        public SEClip(List<AudioClip> clips, float volume, float pitch, float delay)
        {
            new SEClip(clips, priority, volume, 0f, pitch, 0f, delay);
        }
        public SEClip(List<AudioClip> clips, float volume, float volumeRange, float pitch, float pitchRange)
        {
            new SEClip(clips, DEFAULT_PRIORITY, volume, volumeRange, pitch, pitchRange, 0f);
        }
        public SEClip(List<AudioClip> clips, byte priority, float volume)
        {
            new SEClip(clips, priority, volume, 0f, 1f, 0f, 0f);
        }
        public SEClip(List<AudioClip> clips, byte priority, float volume, float delay)
        {
            new SEClip(clips, priority, volume, 0f, 1f, 0f, delay);
        }
        public SEClip(List<AudioClip> clips, byte priority, float volume, float pitch, float delay)
        {
            new SEClip(clips, priority, volume, 0f, pitch, 0f, delay);
        }
        public SEClip(List<AudioClip> clips, byte priority, float volume, float volumeRange, float pitch, float pitchRange)
        {
            new SEClip(clips, priority, volume, volumeRange, pitch, pitchRange, 0f);
        }
        public SEClip(List<AudioClip> clips, byte priority, float volume, float volumeRange, float pitch, float pitchRange, float delay)
        {
            this.clips = clips;
            this.priority = priority;
            this.volume = volume;
            this.volumeRange = volumeRange;
            this.pitch = pitch;
            this.pitchRange = pitchRange;
            this.delay = delay;
        }

        public SEClip GetClip()
        {
            return this;
        }
    }
}