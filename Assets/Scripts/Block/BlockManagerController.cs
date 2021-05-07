using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManagerController : MonoBehaviour
{
    public void Undo()
    {
        BlockManager.Instance.Undo();
    }

    public void Save()
    {
        BlockManager.Instance.Save();
    }

    public void Load()
    {
        BlockManager.Instance.Load();
    }
}