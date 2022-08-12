using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Transform Door;
    public GameObject ChangeScene;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1231231="+other.gameObject.name);
        if (other.gameObject.name == "FPSController")
        {
            Door.DOLocalRotate(new Vector3(0, -90, 0),1f);
        }
        ChangeScene.gameObject.SetActive(true);
    }
}
