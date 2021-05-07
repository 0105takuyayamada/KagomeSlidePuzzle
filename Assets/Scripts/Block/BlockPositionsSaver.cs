using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPositionsSaver
{
    /// <summary>
    /// Easy Save 3 でのセーブ
    /// </summary>
    public void Save(List<Block> blocks, int count)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            ES3.Save("BlockPos" + i.ToString(), VectorUtil.Vector2ToInt(blocks[i].transform.position));
        }
        ES3.Save("Count", count);
    }

    /// <summary>
    /// Easy Save 3 でのロード
    /// </summary>
    public bool Load(List<Block> blocks, out int count)
    {
        count = new int();
        // データがなければ中止
        if (!ES3.KeyExists("Count")) return false;

        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].SetPosition(ES3.Load<Vector2Int>("BlockPos" + i.ToString()));
        }
        count = ES3.Load<int>("Count");
        return true;
    }

    /// <summary>
    /// PlayerPrefsでのセーブ（未検証）
    /// </summary>
    public void SaveByPlayerPrefs(List<Block> blocks, int count)
    {
        Vector2Int v;

        for (int i = 0; i < blocks.Count; i++)
        {
            v = VectorUtil.Vector2ToInt(blocks[i].transform.position);
            PlayerPrefs.SetInt("BlockPos" + i.ToString() + "x", v.x);
            PlayerPrefs.SetInt("BlockPos" + i.ToString() + "y", v.y);
        }
        PlayerPrefs.SetInt("Count", count);
        PlayerPrefs.Save();
    }

    /// <summary>
    ///  PlayerPrefsでのロード（未検証）
    /// </summary>
    public bool LoadByPlayerPrefs(List<Block> blocks, out int count)
    {
        count = new int();
        // データがなければ中止
        if (!PlayerPrefs.HasKey("Count")) return false;

        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].SetPosition(new Vector2Int(
                PlayerPrefs.GetInt("BlockPos" + i.ToString() + "x"),
                PlayerPrefs.GetInt("BlockPos" + i.ToString() + "y")
                ));
        }
        count = PlayerPrefs.GetInt("Count");

        return true;
    }
}