using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOrHide : MonoBehaviour
{
    private bool IsShowing = true;
    private float ChangedTime;
    public Vector2 TimeRange = new Vector2(2, 4);
    void Start()
    {
        StartCoroutine(ChangeActive());
    }

    IEnumerator ChangeActive()
    {
        yield return new WaitForSeconds(Random.Range(TimeRange.x, TimeRange.y));
        IsShowing = !IsShowing;
        transform.GetChild(0).gameObject.SetActive(IsShowing);
        StartCoroutine(ChangeActive());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
