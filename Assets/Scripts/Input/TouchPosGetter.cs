using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPosGetter
{
    Camera cam;
    bool isPhone;

    public TouchPosGetter()
    {
        cam = Camera.main;
        isPhone = Application.platform == RuntimePlatform.Android
                || Application.platform == RuntimePlatform.IPhonePlayer;
    }

    /// <summary>
    /// Worldのタップorマウス座標
    /// </summary>
    public Vector2 GetWorldPos()
    {
        return cam.ScreenToWorldPoint(GetScreenPos());
    }

    /// <summary>
    /// タップ座標かマウス座標を取得
    /// </summary>
    /// <returns></returns>
    private Vector3 GetScreenPos()
    {
        if (isPhone && Input.touchCount > 0) return Input.GetTouch(0).position;
        else return Input.mousePosition;
    }
}