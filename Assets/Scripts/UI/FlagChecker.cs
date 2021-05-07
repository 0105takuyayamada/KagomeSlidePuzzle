using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlagChecker : MonoBehaviour
{
    [SerializeField] bool actOnAwake;
    [SerializeField] string flagName;
    [SerializeField] UnityEvent Event;

    void Start()
    {
        if (actOnAwake) CheckFlag(flagName);
    }

    public void CheckFlag(string name)
    {
        if (PlayerPrefs.HasKey(name) && PlayerPrefs.GetInt(name) != 0) Event.Invoke();
        // if (ES3.KeyExists(name) && ES3.Load<bool>(name)) Event.Invoke();
    }
}