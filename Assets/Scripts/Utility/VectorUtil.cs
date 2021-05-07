using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorUtil
{
    private static Vector2 v2;
    private static Vector2Int v2i;

    public static Vector2 IntToVector2(Vector2Int vector2Int)
    {
        v2.x = vector2Int.x;
        v2.y = vector2Int.y;
        return v2;
    }

    public static Vector2Int Vector2ToInt(Vector2 vector2)
    {
        v2i.x = Mathf.FloorToInt(vector2.x + 0.5f);
        v2i.y = Mathf.FloorToInt(vector2.y + 0.5f);
        return v2i;
    }
}