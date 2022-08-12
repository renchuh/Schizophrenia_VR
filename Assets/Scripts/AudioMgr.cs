using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.Characters.FirstPerson;

public class AudioMgr : MonoBehaviour
{
    public GameStart GameStart;
    private AudioSource _audioSource;
    public GameObject OpenDoor;
    public FirstPersonController _Controller;
    public MouseLook _MouseLook;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(AudioPlayFinished(_audioSource.clip.length, () =>
        {
            // if(_Controller)
            //     _Controller.enabled = true;
            if (OpenDoor)
            {
                OpenDoor.SetActive(true);
            }
            if (_MouseLook)
                _MouseLook.enabled = true;
            if (GameStart)
                GameStart.IsCanCtrl = true;
        }));
    }
    private IEnumerator AudioPlayFinished(float time, UnityAction callback)
    {   
        yield return new WaitForSeconds(time);
        //声音播放完毕后之下往下的代码  
        # region   声音播放完成后执行的代码
        print("声音播放完毕，继续向下执行"); 
        callback?.Invoke();
        #endregion
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
