using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeUpdater : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float size;

    float aspect;

    private void Update()
    {
        aspect = (float)Screen.height / (float)Screen.width;
        _camera.orthographicSize = aspect * size;
    }
}