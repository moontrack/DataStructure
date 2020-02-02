using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    private AudioSource audiosource;

    //场景
    private GameObject o0, o1, o2, o3, o4, o5, o6, o7, tool;
    private List<GameObject> Scene = new List<GameObject>();

    //场景0
    private GameObject Scene0_0, Scene0_1;
    private List<GameObject> Scene0 = new List<GameObject>();

    //场景1
    private GameObject Scene1_0, Scene1_1_0t, Scene1_1_1c, Scene1_2_0xt, Scene1_2_1xc;
    private List<GameObject> Scene1 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //场景渲染初始化
        o0 = GameObject.Find("StartScene");
        Scene.Add(o0);
        o1 = GameObject.Find("1SinglePlay");
        Scene.Add(o1);
        o2 = GameObject.Find("2MultiplePlay");
        Scene.Add(o2);
        o3 = GameObject.Find("3SingleGame");
        Scene.Add(o3);
        o4 = GameObject.Find("4MutipleGame");
        Scene.Add(o4);
        o5 = GameObject.Find("5Evolution");
        Scene.Add(o5);
        o6 = GameObject.Find("6Fault");
        Scene.Add(o6);
        //注意，第8场景的序号为7，因为7是沙盒模式
        o7 = GameObject.Find("8Conclusion");
        Scene.Add(o7);
        tool = GameObject.Find("ToolBar");
        tool.SetActive(true);
        

        //场景0渲染初始化
        Scene0_0 = GameObject.Find("0_0");
        Scene0.Add(Scene0_0);
        Scene0_1 = GameObject.Find("0_1");
        Scene0.Add(Scene0_1);

        //场景1渲染初始化
        Scene1_0 = GameObject.Find("1_0");
        Scene1.Add(Scene1_0);
        Scene1_1_0t = GameObject.Find("1_1_0t");
        Scene1.Add(Scene1_1_0t);
        Scene1_1_1c = GameObject.Find("1_1_1c");
        Scene1.Add(Scene1_1_1c);
        Scene1_2_0xt = GameObject.Find("1_2_0xt");
        Scene1.Add(Scene1_2_0xt);
        Scene1_2_1xc = GameObject.Find("1_2_1xc");
        Scene1.Add(Scene1_2_1xc);

        //声音区块
        audiosource = gameObject.AddComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>("images/sounds/bg_music");
        audiosource.clip = clip;
        audiosource.Play();

        //总按钮区块
        List<string> btnsName = new List<string>();
        btnsName.Add("MusicButton");
        for (int i = 1; i < 9; i++)
        {
            btnsName.Add("Button" + i);
        }
        foreach (string _ in btnsName)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick(btnobject);
            });
        }

        //场景0按钮
        List<string> btnsName0 = new List<string>();
        btnsName0.Add("StartButton1");
        btnsName0.Add("StartButton2");
        foreach (string _ in btnsName0)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick0(btnobject);
            });
        }
        

        //场景1按钮
        List<string> btnsName1 = new List<string>();
        btnsName1.Add("TrickButton1");
        btnsName1.Add("TrickButton2");
        btnsName1.Add("TrickButton3");
        btnsName1.Add("NextButton1");
        btnsName1.Add("CooperateButton1");
        btnsName1.Add("CooperateButton2");
        btnsName1.Add("CooperateButton3");
        btnsName1.Add("NextButton2");
        foreach (string _ in btnsName1)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick1(btnobject);
            });
        }

        //初始化激活场景，先激活场景0，在激活0中的0；以后切换场景都这么做，先激活大的，在激活小的
        OnRender(Scene, 0);
        OnRender(Scene0, 0);
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
            case "Button1":
                Debug.Log("Button1");
                OnRender(Scene,1);
                break;
            case "Button2":
                Debug.Log("Button2");
                OnRender(Scene, 2);
                break;
            case "Button3":
                Debug.Log("Button3");
                OnRender(Scene, 3);
                break;
            case "Button4":
                Debug.Log("Button4");
                OnRender(Scene, 4);
                break;
            case "Button5":
                Debug.Log("Button5");
                OnRender(Scene, 5);
                break;
            case "Button6":
                Debug.Log("Button6");
                OnRender(Scene, 6);
                break;
            case "Button7":
                Debug.Log("Button7");
                SceneManager.LoadScene("MainScene");
                break;
            case "Button8":
                Debug.Log("Button8");
                OnRender(Scene, 7);
                break;
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

    //场景0的点击处理
    public void OnClick0(GameObject sender)
    {
        switch (sender.name)
        {
            case "StartButton1":
                Debug.Log("0_0");
                OnRender(Scene0, 1);
                break;
            case "StartButton2":
                Debug.Log("0_1");
                OnRender(Scene, 1);
                OnRender(Scene1, 0);
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    //场景1的点击处理
    public void OnClick1(GameObject sender)
    {
        //Scene1_0, Scene1_1_0t, Scene1_1_1c, Scene1_2_0xt, Scene1_2_1xc;
        switch (sender.name)
        {
            case "TrickButton1":
                Debug.Log("TrickButton1");
                OnRender(Scene1, 1);
                break;
            case "CooperateButton1":
                Debug.Log("CooperateButton1");
                OnRender(Scene1, 2);
                break;
            case "TrickButton2":
                Debug.Log("TrickButton2");
                OnRender(Scene1, 3);
                break;
            case "CooperateButton2":
                Debug.Log("CooperateButton2");
                OnRender(Scene1, 4);
                break;
            case "TrickButton3":
                Debug.Log("TrickButton3");
                OnRender(Scene1, 3);
                break;
            case "CooperateButton3":
                Debug.Log("CooperateButton3");
                OnRender(Scene1, 4);
                break;
            case "NextButton1":
                Debug.Log("NextButton1");
                //OnRender(Scene1, );
                break;
            case "NextButton2":
                Debug.Log("NextButton2");
                //OnRender(Scene1, );
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    public void OnRender(List<GameObject> Scene,int index)
    {
        for(int i=0;i<Scene.Count;i++)
        {
            if (i == index) Scene[i].SetActive(true);
            else Scene[i].SetActive(false);
        }
    }
}
