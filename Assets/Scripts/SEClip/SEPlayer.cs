using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Yamara.Audio
{
    public static class SEPlayer
    {
        public static void Play(AudioSource audioSource, SEClip se)
        {
            audioSource.clip = se.clips[Random.Range(0, se.clips.Count - 1)];
            audioSource.priority = se.priority;
            audioSource.volume = se.volume + Random.Range(-se.volumeRange, se.volumeRange) * SEManager.gVolume;
            audioSource.pitch = se.pitch + Random.Range(-se.pitchRange, se.pitchRange);
            audioSource.PlayDelayed(se.delay);
        }

        public static void Play(AudioSource audioSource, float pitchRange, float delay)
        {
            audioSource.pitch = 1f + Random.Range(-pitchRange, pitchRange);
            audioSource.PlayDelayed(delay);
        }

        public static void Play(AudioSource audioSource, AudioClip clip, float pitchRange, float delay)
        {
            audioSource.clip = clip;
            audioSource.pitch = 1f + Random.Range(-pitchRange, pitchRange);
            audioSource.PlayDelayed(delay);
        }

        public static void Play(AudioSource audioSource, List<AudioClip> clips, float pitchRange, float delay)
        {
            audioSource.clip = clips[Random.Range(0, clips.Count - 1)];
            audioSource.pitch = 1f + Random.Range(-pitchRange, pitchRange);
            audioSource.PlayDelayed(delay);
        }
    }
}