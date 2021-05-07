using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yamara.Audio;

public class BlockAudioPlayer : MonoBehaviour
{
    public const float
        FADE = 0.8f,
        MIN_PITCH = 0.8f,
        PITCH_RANGE = 0.4f;

    [SerializeField] SEClip pickClip;
    [SerializeField] AudioSource audioSource;
    float moveAudioVolume;

    /// <summary>
    /// ブロック持ち上げSE
    /// </summary>
    public void PlayPickClip()
    {
        SEManager.Instance.Play(pickClip);
    }

    /// <summary>
    /// ブロック引きずりSE
    /// </summary>
    /// <param name="moveMagnitude">移動量</param>
    public void PlayMoveClip(float moveMagnitude)
    {
        // 音を減少させる
        moveAudioVolume = Mathf.Max(moveAudioVolume * FADE, moveMagnitude);
        audioSource.volume = Mathf.Clamp(moveAudioVolume, 0f, 1f);
        // ピッチ
        audioSource.pitch =　Mathf.Max(
            MIN_PITCH + PITCH_RANGE * moveAudioVolume,
            MIN_PITCH + PITCH_RANGE);
    }
}