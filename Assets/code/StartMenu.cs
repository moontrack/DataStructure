using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class StartMenu : MonoBehaviour
{
    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        //声音区块
        audiosource = gameObject.AddComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>("images/sounds/bg_music");
        audiosource.clip = clip;
        audiosource.Play();

        //按钮区块
        List<string> btnsName = new List<string>();
        btnsName.Add("MusicButton");
        btnsName.Add("StartButton");
        foreach(string _ in btnsName)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick(btnobject);
            });

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 控制开始界面按钮
    /// </summary>
    public void OnClick(GameObject sender)
    {
        switch(sender.name)
        {
            case "MusicButton":
                {
                    Debug.Log("MusicButton");
                    if (audiosource.isPlaying)
                    {
                        audiosource.Stop();
                    }
                    else
                    {
                        audiosource.Play();
                    }
                    break;
                }
            case "StartButton":
                Debug.Log("StartButton");
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
}
