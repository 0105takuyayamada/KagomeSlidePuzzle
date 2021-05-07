using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurner : MonoBehaviour
{
    [SerializeField] List<GameObject> pages;
    int index;

    /// <summary>
    /// 前のページを表示
    /// </summary>
    public void Prev()
    {
        Turn(-1);
    }

    /// <summary>
    /// 次のページを表示
    /// </summary>
    public void Next()
    {
        Turn(1);
    }

    /// <summary>
    /// ページ移動
    /// </summary>
    /// <param name="direction">移動量</param>
    private void Turn(int direction)
    {
        pages[index].SetActive(false);
        index = (int)Mathf.Repeat(index + direction, pages.Count);
        pages[index].SetActive(true);
    }
}