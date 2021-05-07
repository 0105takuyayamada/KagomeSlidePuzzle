using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Collections;

namespace Yamara.Audio
{
    public class SEManager : SingletonMonoBehaviour<SEManager>
    {
        public static float gVolume = 0.5f;

        private static readonly int COUNT = 16;
        private static IEnumerable<AudioSource> audioSources = new List<AudioSource>();

        private void Start()
        {
            List<AudioSource> audios = new List<AudioSource>();
            for (int i = 0; i < COUNT; i++)
            {
                audios.Add(gameObject.AddComponent<AudioSource>());
                AudioSource audioSource = audios.Last();
                audioSource.priority = byte.MaxValue;

                //再生が終了したら priority を最低にする
                StartCoroutine("CheckPlayingAudio", audioSource);
            }
            audioSources = audios;
        }

        public void Play(SEClip se)
        {
            if (se.priority > audioSources.First().priority) return;
            SEPlayer.Play(audioSources.First(), se);
            audioSources = audioSources.OrderByDescending(x => x.priority);
        }

        public void Play(AudioClip se, float volume)
        {
            SEClip seClip = new SEClip(se, volume);
            if (seClip.priority > audioSources.First().priority) return;
            SEPlayer.Play(audioSources.First(), seClip);
            audioSources = audioSources.OrderByDescending(x => x.priority);
        }

        private IEnumerator CheckPlayingAudio(AudioSource audioSource)
        {
            while (true)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.priority = byte.MaxValue;
                    break;
                }
                yield return null;
            }
        }
    }
}