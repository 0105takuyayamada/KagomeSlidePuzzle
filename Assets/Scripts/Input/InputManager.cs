using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    const float AXIS_MAGNITUDE_THRESHOLD = 0.2f;

    Vector2 axis;
    bool pushed;

    private void Update()
    {
        OperateMoveBlockByButton();
        OperateUndoByButton();
    }

    /// <summary>
    /// ボタンでブロック移動
    /// </summary>
    private void OperateMoveBlockByButton()
    {
        axis.x = Input.GetAxis("Horizontal");
        axis.y = Input.GetAxis("Vertical");

        if (pushed)
        {
            if (axis.magnitude < AXIS_MAGNITUDE_THRESHOLD) pushed = false;
            return;
        }
        
        if (axis.magnitude >= AXIS_MAGNITUDE_THRESHOLD
            && BlockManager.Instance.SpotBlock)
        {
            BlockManager.Instance.SpotBlock.MoveAxis(axis);
            pushed = true;
        }
    }

    /// <summary>
    /// ボタンで一手戻す
    /// </summary>
    private void OperateUndoByButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BlockManager.Instance.Undo();
        }
    }
}