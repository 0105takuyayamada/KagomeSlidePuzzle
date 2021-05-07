using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    const float
        MOVE_MAGNITUDE = 100f,
        SNAP_DURATION = 0.05f;
    const Ease SNAP_EASE = Ease.OutQuart;

    [SerializeField] Rigidbody2D rb;

    Vector2 diffTouchPos;
    Vector2Int beforePos;
    protected Vector2Int afterPos;

    Vector2 prevPos;
    float deltaMagnitude;
    public float DeltaMagnitude { get { return deltaMagnitude; } }

    TouchPosGetter touchPosGetter;

    private void Start()
    {
        beforePos = VectorUtil.Vector2ToInt(transform.position);
        touchPosGetter = new TouchPosGetter();
    }

    /// <summary>
    /// BlockManager の SpotBlock を更新
    /// </summary>
    public void Spot()
    {
        BlockManager.Instance.SetSpotBlock(this);
    }

    /// <summary>
    /// ブロックを掴んだ
    /// </summary>
    public void MoveStart()
    {
        if (BlockManager.Instance.Undoing) return;

        rb.isKinematic = false;

        BlockManager.Instance.SetPickBlock(this);
        diffTouchPos = touchPosGetter.GetWorldPos() - (Vector2)transform.position;
    }

    /// <summary>
    /// 移動中
    /// </summary>
    public void Move()
    {
        if (BlockManager.Instance.Undoing) return;

        rb.MovePosition(touchPosGetter.GetWorldPos() - diffTouchPos);

        deltaMagnitude = (prevPos - (Vector2)transform.position).magnitude;
        prevPos = transform.position;
    }

    /// <summary>
    /// ブロックを手放した
    /// </summary>
    public virtual void MoveEnd()
    {
        if (BlockManager.Instance.Undoing) return;

        BlockManager.Instance.SetPickBlock(null);
        // スナップ
        afterPos = VectorUtil.Vector2ToInt(transform.position);
        transform.DOMove(VectorUtil.IntToVector2(afterPos), SNAP_DURATION).SetEase(SNAP_EASE);

        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        // 動かす前と座標が違ったら記録
        if (afterPos != beforePos) BlockManager.Instance.Record(this, beforePos);
        beforePos = afterPos;
    }

    /// <summary>
    /// キー入力による移動
    /// </summary>
    /// <param name="direction">移動方向</param>
    public void MoveAxis(Vector2 direction)
    {
        if (BlockManager.Instance.Undoing) return;
        MoveStart();
        rb.velocity = direction * MOVE_MAGNITUDE;
        DOVirtual.DelayedCall(SNAP_DURATION, () => MoveEnd());
    }

    /// <summary>
    /// 一手戻す際の挙動
    /// </summary>
    /// <param name="pos">一手前の座標</param>
    public void MoveUndo(Vector2Int pos)
    {
        transform.DOKill(true);
        transform.DOMove(VectorUtil.IntToVector2(pos), BlockManager.UNDO_DURATION).SetEase(SNAP_EASE)
        .OnComplete(() =>
        {
            beforePos = VectorUtil.Vector2ToInt(transform.position);
        });
    }

    /// <summary>
    /// 位置セット
    /// </summary>
    /// <param name="pos">座標</param>
    public void SetPosition(Vector2Int pos)
    {
        transform.DOKill(true);
        transform.position = VectorUtil.IntToVector2(pos);
        beforePos = pos;
    }
}