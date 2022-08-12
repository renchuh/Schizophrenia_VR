using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeTexture : MonoBehaviour
{
    private MeshRenderer MeshRenderer;

    
    void Awake()
    {
        MeshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnBecameInvisible()
    {
        Debug.Log("OnBecameInvisible");
        MeshRenderer.material.color = new Color(1, 1, 1, 0.01f);

    }
    
    private void OnBecameVisible()
    {
        Debug.Log("OnBecameVisible");
        if (Random.Range(-1, 1) == 0)
        {
            StartCoroutine(Change());
        }
    }
    
    private IEnumerator Change()
    {
        yield return new WaitForSeconds(0.5f);
        MeshRenderer.material.DOColor(new Color(1, 1, 1, 0.5f), 0.5f);
    }
}
