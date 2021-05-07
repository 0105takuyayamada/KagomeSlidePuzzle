using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadSingle()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetSceneAt(0).name, LoadSceneMode.Single);
    }

    public void ReloadAdditive()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetSceneAt(0).name, LoadSceneMode.Additive);
    }

    public void LoadSingle(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
    }

    public void LoadAdditive(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }
}