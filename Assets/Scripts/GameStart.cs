using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStart : MonoBehaviour
{
    GUIStyle ss;
    public float x= 300f;
    public Transform Key;
    public bool IsPressE =false;
    private float KeyDaulftY;
    public bool lsPressW = false;
    public Transform BookPoints;
    public float DelayTime = 5f;
    public Transform MoveTarget;
    public bool IsShowText = false;
    public bool IsPressedR = false;
    public Transform Txt_Up;
    public Transform Txt_Down;
    public AudioClip Audio_Key;
    public AudioSource audioSource;
    public FirstPersonController fpc;
    public bool IsCanCtrl = false;
    // Start is called before the first frame update
    void Start()
    {
        ss = new GUIStyle();
        ss.normal.background = null;
        ss.normal.textColor = Color.white;
        ss.fontSize = 60;
        KeyDaulftY = Key.localPosition.y;
    }

    private void OnGUI()
    {
        //GUI.Label(new Rect(x, 0, 300, 300), "please press E to pick up the key",ss);
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsCanCtrl) return;
        if (Input.GetKeyDown(KeyCode.R) && !IsPressedR)
        {
            IsPressedR = true;
            fpc.enabled = false;
            fpc.transform.DOMove(MoveTarget.position, 1f).OnComplete(()=> {
                Txt_Up.gameObject.SetActive(true);
                IsShowText = true;
                Camera.main.transform.DOLookAt(Key.position, 0.2f);
            });
        }


        if (Input.GetKeyDown(KeyCode.E)&&!IsPressE&& IsShowText)
        {
            IsPressE = true;
            Key.DOMoveY(KeyDaulftY + 0.5f, 1f).OnComplete(()=> {
                Txt_Down.gameObject.SetActive(true);
                Txt_Up.gameObject.SetActive(false);
                audioSource.clip = Audio_Key;
                audioSource.Play();
            });
        }
        if(Input.GetKeyDown(KeyCode.W) && IsPressE && !lsPressW)
        {
            lsPressW = true;
            Key.DOMoveY(KeyDaulftY, 1f).OnComplete(()=> {
                StartCoroutine(MoveToBookPoints());
                Txt_Down.gameObject.SetActive(false);
                audioSource.Stop();
                fpc.enabled = true;
            });
        }
    }

    IEnumerator MoveToBookPoints()
    {
        yield return new WaitForSeconds(DelayTime);
        Key.DOMove(BookPoints.position, 1f).OnStart(()=> { Key.GetComponentInChildren<MeshRenderer>().enabled = false; })
            .OnComplete(()=> {
                Key.GetComponentInChildren<MeshRenderer>().enabled = true;
            });

    }
}
