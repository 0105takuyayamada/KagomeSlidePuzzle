using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KagomeBlock : Block
{
    [SerializeField] Vector2Int goalPosition;

    public override void MoveEnd()
    {
        base.MoveEnd();

        // ゴール判定
        if (afterPos == goalPosition)
        {
            GameManager.Instance.Complete();
        }
    }
}