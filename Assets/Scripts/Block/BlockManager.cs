using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Yamara.Audio;

public class BlockManager : SingletonMonoBehaviour<BlockManager>
{
    public const float UNDO_DURATION = 0.05f;
    const string BLOCK_TAG_NAME = "Block";

    private int count;
    [SerializeField] Text countText;
    [SerializeField] Button prevButton;
    [SerializeField] BlockAudioPlayer audioPlayer;

    List<Block> blocks = new List<Block>(16);

    Stack<Block> historyBlocks = new Stack<Block>(2048);
    Stack<Vector2Int> historyPoses = new Stack<Vector2Int>(2048);

    public Block SpotBlock { get; private set; }
    public void SetSpotBlock(Block b) { SpotBlock = b; }
    public Block PickBlock { get; private set; }
    public void SetPickBlock(Block b)
    {
        PickBlock = b;
        if (b != null) audioPlayer.PlayPickClip();
    }

    public bool Undoing { get; private set; }

    BlockPositionsSaver positionsSaver = new BlockPositionsSaver();

    private void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(BLOCK_TAG_NAME);
        foreach (GameObject obj in gameObjects)
        {
            blocks.Add(obj.GetComponent<Block>());
        }
    }

    private void Update()
    {
        if (PickBlock) audioPlayer.PlayMoveClip(PickBlock.DeltaMagnitude);
        else audioPlayer.PlayMoveClip(0f);
    }

    /// <summary>
    /// 変更を記録
    /// </summary>
    /// <param name="block">動かしたブロック</param>
    /// <param name="pos">動かす前の座標</param>
    public void Record(Block block, Vector2Int pos)
    {
        historyBlocks.Push(block);
        historyPoses.Push(pos);

        count++;
        countText.text = count.ToString();

        prevButton.interactable = true;
    }

    /// <summary>
    /// 一手戻す
    /// </summary>
    public void Undo()
    {
        if (Undoing || historyBlocks.Count <= 0) return;

        historyBlocks.Pop().MoveUndo(historyPoses.Pop());

        count--;
        countText.text = count.ToString();
        if (historyBlocks.Count == 0) prevButton.interactable = false;

        Undoing = true;
        DOVirtual.DelayedCall(UNDO_DURATION, () => Undoing = false);
    }
    
    /// <summary>
    /// セーブ
    /// </summary>
    public void Save()
    {
        positionsSaver.Save(blocks, count);
        // PlayerPrefs でセーブする場合
        // positionsSaver.SaveByPlayerPrefs(blocks, count);
    }

    /// <summary>
    /// ロード
    /// </summary>
    public void Load()
    {
        int tempCount;

        if (!positionsSaver.Load(blocks, out tempCount))
        // PlayerPrefs でロードする場合
        // if (!positionsSaver.LoadByPlayerPrefs(blocks, out tempCount))
        {
            Debug.Log("セーブデータがありませんでした");
            return;
        }

        count = tempCount;
        countText.text = count.ToString();

        prevButton.interactable = false;
        historyBlocks.Clear();
        historyPoses.Clear();
    }
}