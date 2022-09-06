using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BookMgr : MonoBehaviour
{

    public List<BookInfo> Books = new List<BookInfo>();

    public List<Transform> Levels = new List<Transform>();

    public int MaxLevel = 3;
    // Start is called before the first frame update

    private void Awake()
    {
        StartCoroutine(ChangedBooks());
    }

    IEnumerator ChangedBooks()
    {
        for (var i = 0; i < Books.Count; i++)
        {
            var book = Books[i];
            var level = book.LevelChanged(MaxLevel);
            var lP = book.transform.localPosition;
            book.transform.localPosition = new Vector3(lP.x, Levels[level].localPosition.y, lP.z);
        }

        yield return new WaitForSeconds(Random.Range(2, 8));
        StartCoroutine(ChangedBooks());
    }
}
