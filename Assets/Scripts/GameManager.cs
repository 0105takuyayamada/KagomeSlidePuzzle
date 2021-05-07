using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField] GameObject congratulationsPanel;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    /// <summary>
    /// ゴール
    /// </summary>
    public void Complete()
    {
        congratulationsPanel.SetActive(true);

        PlayerPrefs.SetInt("Completed", 1);
        PlayerPrefs.Save();
        // ES3.Save("Completed", true);
    }
}