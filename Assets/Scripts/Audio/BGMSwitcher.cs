using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSwitcher : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        if (!PlayerPrefs.HasKey("BGM"))
        {
            PlayerPrefs.SetInt("BGM", 1);
            PlayerPrefs.Save();
        }

        if (PlayerPrefs.GetInt("BGM") == 1)
        {
            audioSource.Play();
        }
    }

    public void Switch()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            PlayerPrefs.SetInt("BGM", 0);
            PlayerPrefs.Save();
        }
        else
        {
            audioSource.Play();
            PlayerPrefs.SetInt("BGM", 1);
            PlayerPrefs.Save();
        }
    }
}