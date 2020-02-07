using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    #region Declaration
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

    //场景2
    private GameObject Scene2_0, Scene2_1, Scene2_2;
    private List<GameObject> Scene2 = new List<GameObject>();

    private int RoundNum, ClickNum;
    private List<int> Choose = new List<int>();
    private bool PlayerYellowFlag;

    private Text TextScore1, TextScore2, TextRoundNum, TextFinalScore;
    private int ScorePerRound1, ScorePerRound2, TotalScore;

    private Image Player2, Payoff;
    private Sprite spPlayer, spPayoff;

    //场景3
    private GameObject Scene3_0, Scene3_1, Scene3_2, Scene3_3, Scene3_4, Scene3_5, Scene3_6, Scene3_7, Scene3_8, Scene3_9, Scene3_10, Scene3_11, Scene3_12;
    private List<GameObject> Scene3 = new List<GameObject>();

    private int ChoiceNumScene3;
    private Text TextName1, TextName2;

    //场景4
    private GameObject Scene4_0, Scene4_1, Scene4_2, Scene4_3, Scene4_4, Scene4_5;
    private List<GameObject> Scene4 = new List<GameObject>();

    private int ChoiceNumScene4;
    private Text TextName3, TextName4, TextName5;
    private Text TextBox1;

    private Button Button1Scene4, Button2Scene4, Button3Scene4;
    private Button NextButton22;//让22点击以后失效
    private Text NextButton24;//更换24的内容

    private int NextButton24ClickNum;

    private Animator ani1, ani2;

    private int ClickNumScene4;
    private Image imgTemp;

    //场景6
    private bool Correct6_6, Correct6_7;
    private Text Text1, Text2, Text3, Text4, Text5, Text6, SliderNumber;
    private Slider Slider1;
    private GameObject Scene6_0, Scene6_1, Scene6_2, Scene6_3, Scene6_4, Scene6_5, Scene6_6_0, Scene6_6_1, Scene6_6_2, Scene6_6_3, Scene6_7_0, Scene6_7_1, Scene6_7_2,
        Scene6_7_3, Scene6_8_0, Scene6_8_1;
    private List<GameObject> Scene6 = new List<GameObject>();

    //场景8
    private GameObject Scene8_0, Scene8_1, Scene8_2, Scene8_3;
    private List<GameObject> Scene8 = new List<GameObject>();

    #endregion Declaration

    // Start is called before the first frame update
    void Start()
    {
        #region iniScene
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

        //场景2渲染初始化Scene2_0, Scene2_1;
        Scene2_0 = GameObject.Find("2_0");
        Scene2.Add(Scene2_0);
        Scene2_1 = GameObject.Find("2_1");
        Scene2.Add(Scene2_1);
        Scene2_2 = GameObject.Find("2_2");
        Scene2.Add(Scene2_2);

        //场景3渲染初始化
        Scene3_0 = GameObject.Find("3_0");
        Scene3.Add(Scene3_0);
        Scene3_1 = GameObject.Find("3_1");
        Scene3.Add(Scene3_1);
        Scene3_2 = GameObject.Find("3_2");
        Scene3.Add(Scene3_2);
        Scene3_3 = GameObject.Find("3_3");
        Scene3.Add(Scene3_3);
        Scene3_4 = GameObject.Find("3_4");
        Scene3.Add(Scene3_4);
        Scene3_5 = GameObject.Find("3_5");
        Scene3.Add(Scene3_5);
        Scene3_6 = GameObject.Find("3_6");
        Scene3.Add(Scene3_6);
        Scene3_7 = GameObject.Find("3_7");
        Scene3.Add(Scene3_7);
        Scene3_8 = GameObject.Find("3_8");
        Scene3.Add(Scene3_8);
        Scene3_9 = GameObject.Find("3_9");
        Scene3.Add(Scene3_9);
        Scene3_10 = GameObject.Find("3_10");
        Scene3.Add(Scene3_10);
        Scene3_11 = GameObject.Find("3_11");
        Scene3.Add(Scene3_11);
        Scene3_12 = GameObject.Find("3_12");
        Scene3.Add(Scene3_12);

        //场景4渲染初始化
        Scene4_0 = GameObject.Find("4_0");
        Scene4.Add(Scene4_0);
        Scene4_1 = GameObject.Find("4_1");
        Scene4.Add(Scene4_1);
        Scene4_2 = GameObject.Find("4_2");
        Scene4.Add(Scene4_2);
        Scene4_3 = GameObject.Find("4_3");
        Scene4.Add(Scene4_3);
        Scene4_4 = GameObject.Find("4_4");
        Scene4.Add(Scene4_4);
        Scene4_5 = GameObject.Find("4_5");
        Scene4.Add(Scene4_5);

        //场景6渲染初始化
        Scene6_0 = GameObject.Find("6_0");
        Scene6.Add(Scene6_0);
        Scene6_1 = GameObject.Find("6_1");
        Scene6.Add(Scene6_1);
        Scene6_2 = GameObject.Find("6_2");
        Scene6.Add(Scene6_2);
        Scene6_3 = GameObject.Find("6_3");
        Scene6.Add(Scene6_3);
        Scene6_4 = GameObject.Find("6_4");
        Scene6.Add(Scene6_4);
        Scene6_5 = GameObject.Find("6_5");
        Scene6.Add(Scene6_5);
        //6
        Scene6_6_0 = GameObject.Find("6_6_0");
        Scene6.Add(Scene6_6_0);
        //7
        Scene6_6_1 = GameObject.Find("6_6_1");
        Scene6.Add(Scene6_6_1);
        //8
        Scene6_6_2 = GameObject.Find("6_6_2");
        Scene6.Add(Scene6_6_2);
        //9
        Scene6_6_3 = GameObject.Find("6_6_3");
        Scene6.Add(Scene6_6_3);
        //10
        Scene6_7_0 = GameObject.Find("6_7_0");
        Scene6.Add(Scene6_7_0);
        //11
        Scene6_7_1 = GameObject.Find("6_7_1");
        Scene6.Add(Scene6_7_1);
        //12
        Scene6_7_2 = GameObject.Find("6_7_2");
        Scene6.Add(Scene6_7_2);
        //13
        Scene6_7_3 = GameObject.Find("6_7_3");
        Scene6.Add(Scene6_7_3);
        //14
        Scene6_8_0 = GameObject.Find("6_8_0");
        Scene6.Add(Scene6_8_0);
        //15
        Scene6_8_1 = GameObject.Find("6_8_1");
        Scene6.Add(Scene6_8_1);

        //场景8渲染初始化
        Scene8_0 = GameObject.Find("8_0");
        Scene8.Add(Scene8_0);
        Scene8_1 = GameObject.Find("8_1");
        Scene8.Add(Scene8_1);
        Scene8_2 = GameObject.Find("8_2");
        Scene8.Add(Scene8_2);
        Scene8_3 = GameObject.Find("8_3");
        Scene8.Add(Scene8_3);

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

        //场景2按钮
        List<string> btnsName2 = new List<string>();
        btnsName2.Add("TrickButton4");
        btnsName2.Add("CooperateButton4");
        btnsName2.Add("NextButton3");
        btnsName2.Add("NextButton4");
        foreach (string _ in btnsName2)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick2(btnobject);
            });
        }

        //场景二文本显示初始化TextScore1, TextScore2, TextRoundNum;
        TextScore1 = GameObject.Find("Score1").GetComponent<Text>();
        TextScore2 = GameObject.Find("Score2").GetComponent<Text>();
        TextRoundNum = GameObject.Find("RoundNum").GetComponent<Text>();
        TextFinalScore = GameObject.Find("FinalScore").GetComponent<Text>();
        Player2 = GameObject.Find("imgPlayer4").GetComponent<Image>();
        //这里很有意思，只有通过绝对路径才能找到
        Payoff = GameObject.Find("Canvas/2MultiplePlay/2_1/imgPayoff").GetComponent<Image>();
        TextScore1.text = "0";
        TextScore2.text = "0";
        TextRoundNum.text = "第1/5个对手" +
            "你的总分0";
        
        //场景2数据初始化
        RoundNum = 1;
        ClickNum = 0;
        PlayerYellowFlag = false;//开始没有被骗
        ScorePerRound1 = 0;//开始的时候玩家积分为0
        ScorePerRound2 = 0;//开始的时候电脑积分为0
        TotalScore = 0;

        //场景3按钮
        List<string> btnsName3 = new List<string>();
        btnsName3.Add("ChoiceButton1");
        btnsName3.Add("ChoiceButton2");
        btnsName3.Add("ChoiceButton3");
        btnsName3.Add("ChoiceButton4");
        btnsName3.Add("ChoiceButton5");
        btnsName3.Add("NextButton5");
        btnsName3.Add("NextButton6");
        btnsName3.Add("NextButton7");
        btnsName3.Add("NextButton8");
        btnsName3.Add("NextButton9");
        btnsName3.Add("NextButton10");
        btnsName3.Add("NextButton11");
        btnsName3.Add("NextButton12");
        btnsName3.Add("NextButton13");
        btnsName3.Add("NextButton14");
        btnsName3.Add("NextButton15");
        btnsName3.Add("NextButton16");
        foreach (string _ in btnsName3)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick3(btnobject);
            });
        }

            //这里有3个按钮需要特殊处理，因为要控制是否可以点击
        Button1Scene4 = GameObject.Find("NextButton18").GetComponent<Button>();
        Button2Scene4 = GameObject.Find("NextButton19").GetComponent<Button>();
        Button3Scene4 = GameObject.Find("NextButton20").GetComponent<Button>();

        Button1Scene4.interactable = true;
        Button2Scene4.interactable = false;
        Button3Scene4.interactable = false;

        //场景3文本显示初始化
        TextName1 = GameObject.Find("Name1").GetComponent<Text>();
        TextName2 = GameObject.Find("Name2").GetComponent<Text>();
        TextName1.text = "复读机";
        TextName2.text = "复读机";
        
        //场景3数据初始化
        //1--复读机，2-万年小粉红，3-千年老油条，4-黑帮老铁，5-福尔摩星
        ChoiceNumScene3 = 0;


        //场景4按钮
        List<string> btnsName4 = new List<string>();
        btnsName4.Add("NextButton17");
        btnsName4.Add("NextButton18");
        btnsName4.Add("NextButton19");
        btnsName4.Add("NextButton20");
        btnsName4.Add("ChoiceButton6");
        btnsName4.Add("ChoiceButton7");
        btnsName4.Add("ChoiceButton8");
        btnsName4.Add("NextButton21");
        btnsName4.Add("NextButton22");
        btnsName4.Add("NextButton23");
        btnsName4.Add("NextButton24");
        foreach (string _ in btnsName4)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick4(btnobject);
            });
        }

            //点击NextButton22以后再显示23,且禁用22
        NextButton22 = GameObject.Find("NextButton22").GetComponent<Button>();
        //更换24内容
        NextButton24 = GameObject.Find("NextButton24/Text").GetComponent<Text>();

        //场景4文本显示初始化
        TextName3 = GameObject.Find("Name3").GetComponent<Text>();
        TextName3.text = "hello world";
        TextName4 = GameObject.Find("Name4").GetComponent<Text>();
        TextName5 = GameObject.Find("Name5").GetComponent<Text>();
        TextName5.text = "";

        TextBox1 = GameObject.Find("TextBox1").GetComponent<Text>();

        ani1 = GameObject.Find("AnimationBox").GetComponent<Animator>();
        ani2 = GameObject.Find("AnimationBox2").GetComponent<Animator>();

        imgTemp = GameObject.Find("Canvas/4MutipleGame/4_4/imgTemp").GetComponent<Image>();
        imgTemp.enabled = true;

        //场景4数据初始化
            //1--万年小粉红，2-千年老油条，3-复读机
        ChoiceNumScene4 = 0;
            //动画按钮点击数量
        ClickNumScene4 = 0;
            //按钮24的点击次数，用来切换画面
        NextButton24ClickNum = 0;


        //场景6按钮
        List<string> btnsName6 = new List<string>();
        btnsName6.Add("NextButton6_0");
        btnsName6.Add("NextButton6_1");
        btnsName6.Add("NextButton6_2");
        btnsName6.Add("NextButton6_3");
        btnsName6.Add("NextButton6_4");
        btnsName6.Add("NextButton6_5");
        btnsName6.Add("NextButton6_6_1");
        btnsName6.Add("NextButton6_6_2");
        btnsName6.Add("NextButton6_6_3");
        btnsName6.Add("NextButton6_7_1");
        btnsName6.Add("NextButton6_7_2");
        btnsName6.Add("NextButton6_7_3");
        btnsName6.Add("NextButton6_8_0");
        btnsName6.Add("NextButton6_8_1");
        btnsName6.Add("ChoiceButton6_6_0_1");
        btnsName6.Add("ChoiceButton6_6_0_2");
        btnsName6.Add("ChoiceButton6_6_0_3");
        btnsName6.Add("ChoiceButton6_6_0_4");
        btnsName6.Add("ChoiceButton6_6_0_5");
        btnsName6.Add("ChoiceButton6_7_0_1");
        btnsName6.Add("ChoiceButton6_7_0_2");
        btnsName6.Add("ChoiceButton6_7_0_3");
        btnsName6.Add("ChoiceButton6_7_0_4");
        btnsName6.Add("ChoiceButton6_7_0_5");
        foreach (string _ in btnsName6)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick6(btnobject);
            });
        }

        //场景六文本显示初始化
        Text1 = GameObject.Find("Text1").GetComponent<Text>();
        Text2 = GameObject.Find("Text2").GetComponent<Text>();
        Text3 = GameObject.Find("Text3").GetComponent<Text>();
        Text4 = GameObject.Find("Text4").GetComponent<Text>();
        Text5 = GameObject.Find("Text5").GetComponent<Text>();
        Text6 = GameObject.Find("Text6").GetComponent<Text>();
        SliderNumber = GameObject.Find("SliderNumber").GetComponent<Text>();
        SliderNumber.text = "0";
        Text4.text = "<color=#A8D0FF>复读鸭</color>";
        Text5.text = "<color=#9ce354>一根筋</color>";
        Text6.text = "<color=#9ce354>一根筋</color>";
        //6_8_1 滑动条
        Slider1 = GameObject.Find("Slider1").GetComponent<Slider>();
        //6_6场景是否选到正确选项
        Correct6_6 = false;
        //6_7场景是否选到正确选项
        Correct6_7 = false;

        //场景8按钮
        List<string> btnsName8 = new List<string>();
        btnsName8.Add("NextButton25");
        btnsName8.Add("NextButton26");
        btnsName8.Add("NextButton27");
        foreach (string _ in btnsName8)
        {
            GameObject btnobject = GameObject.Find(_);
            Button btn = btnobject.GetComponent<Button>();
            btn.onClick.AddListener(delegate ()
            {
                this.OnClick8(btnobject);
            });
        }
        #endregion iniScene

        //初始化激活场景，先激活场景0，在激活0中的0；以后切换场景都这么做，先激活大的，在激活小的
        //OnRender(Scene, 0);
        //OnRender(Scene0, 0);

        OnRender(Scene, 0);
        OnRender(Scene0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region ToolBar
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
    #endregion ToolBar
    #region Scene0
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
    #endregion Scene0
    #region Scene1
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
                OnRender(Scene, 2);
                OnRender(Scene2, 0);
                iniScene2();
                break;
            case "NextButton2":
                Debug.Log("NextButton2");
                OnRender(Scene, 2);
                OnRender(Scene2, 0);
                iniScene2();
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    #endregion Scene1
    #region Scene2
    //场景2初始化
    public void iniScene2()
    {
        //场景2数据初始化
        RoundNum = 1;
        ClickNum = 0;
        PlayerYellowFlag = false;//开始没有被骗
        ScorePerRound1 = 0;//开始的时候玩家积分为0
        ScorePerRound2 = 0;//开始的时候电脑积分为0
        TotalScore = 0;
    }

    //场景2的点击处理
    public void OnClick2(GameObject sender)
    {
        switch (sender.name)
        {
            case "TrickButton4":
                Debug.Log("TrickButton4");
                Choose.Add(0);
                ClickNum += 1;
                Solve2(0);                
                break;
            case "CooperateButton4":
                Debug.Log("CooperateButton4");
                Choose.Add(1);
                ClickNum += 1;
                Solve2(1);               
                break;
            case "NextButton3":
                Debug.Log("NextButton3");
                OnRender(Scene2, 1);
                break;
            case "NextButton4":
                Debug.Log("NextButton4");
                //进入场景3
                OnRender(Scene, 3);
                OnRender(Scene3, 0);
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    
    //场景2的运算,0代表欺骗，1代表合作
    public void Solve2(int act)
    {
        switch (RoundNum)
        {
            case 1:
                Debug.Log("in case1");
                JudgeResult(act, PlayerBlue());               
                break;
            case 2:
                Debug.Log("in case2");
                JudgeResult(act, PlayerPurple());
                break;
            case 3:
                Debug.Log("in case3");
                JudgeResult(act, PlayerPink());
                break;
            case 4:
                Debug.Log("in case4");
                JudgeResult(act, PlayerYellow());
                break;
            case 5:
                Debug.Log("in case5");
                JudgeResult(act, PlayerOrange());
                break;
            default:
                Debug.Log("none");
                break;
        }

        if (RoundNum == 5 && ClickNum == 5)
        {
            //进入下一场景
            OnRender(Scene2, 2);
            TextFinalScore.text = TotalScore.ToString();
        }
        else if (ClickNum == 5)
        {
            ClickNum = 0;
            RoundNum += 1;
            TotalScore += ScorePerRound1;
            ScorePerRound1 = ScorePerRound2 = 0;
            switch (RoundNum)
            {
                case 2:
                    spPlayer = Resources.Load("Images/ui/PlayerPurple", typeof(Sprite)) as Sprite;
                    Player2.sprite = spPlayer;
                    break;
                case 3:
                    spPlayer = Resources.Load("Images/ui/PlayerPink", typeof(Sprite)) as Sprite;
                    Player2.sprite = spPlayer;
                    break;
                case 4:
                    spPlayer = Resources.Load("Images/ui/PlayerYellow", typeof(Sprite)) as Sprite;
                    Player2.sprite = spPlayer;
                    break;
                case 5:
                    spPlayer = Resources.Load("Images/ui/PlayerOrange", typeof(Sprite)) as Sprite;
                    Player2.sprite = spPlayer;
                    break;
                default:
                    Debug.Log("none");
                    break;
            }
            Scene2ShowScore();

            //这里应当放一段动画，要不最后一次显示不出来
            //System.Threading.Thread.Sleep(1000);这样不行
        }
    }
    #region PlayerStrategyScene2
    public int PlayerBlue()
    {
        if (ClickNum == 1)
        {
            return 1;
        }
        else
        {
            return Choose[ClickNum - 2];
        }
    }
    public int PlayerPink()
    {
        return 1;
    }
    public int PlayerPurple()
    {
        return 0;
    }
    public int PlayerYellow()
    {
        if (ClickNum == 1)
        {
            return 1;
        }
        else if(PlayerYellowFlag == true)
        {
            return 0;
        }
        else
        {
            if( Choose[ClickNum - 1] == 0)
            {
                PlayerYellowFlag = true;
            }
        }
        return 1;
    }
    public int PlayerOrange()
    {
        if (ClickNum == 1)
        {
            return 1;
        }
        else if(ClickNum == 2)
        {
            return 0;
        }
        else if (ClickNum == 3)
        {
            return 1;
        }
        else if (ClickNum == 4)
        {
            return 1;
        }
        else
        {
            if(Choose[3]==0)
            {
                PlayerBlue();
            }
            else
            {
                PlayerPurple();
            }
        }
        return 1;
    }
    #endregion PlayerStrategyScene2
    public void JudgeResult(int Player1,int Player2)
    {
        if(Player1 == 0 && Player2 == 0)
        {
            //两者都欺骗，不加分
            ScorePerRound1 += 0;
            ScorePerRound2 += 0;
            Payoff.sprite = Resources.Load("Images/ui/payoffs7", typeof(Sprite)) as Sprite;
        }
        else if(Player1 == 0 && Player2 == 1)
        {
            //玩家欺骗，电脑合作，玩家+3，电脑-1
            ScorePerRound1 += 3;
            ScorePerRound2 -= 1;
            Payoff.sprite = Resources.Load("Images/ui/payoffs5", typeof(Sprite)) as Sprite;
        }
        else if (Player1 == 1 && Player2 == 0)
        {
            //玩家合作，电脑欺骗，玩家-1，电脑+3
            ScorePerRound1 -= 1;
            ScorePerRound2 += 3;
            Payoff.sprite = Resources.Load("Images/ui/payoffs6", typeof(Sprite)) as Sprite;
        }
        else
        {
            //都合作，都+2
            ScorePerRound1 += 2;
            ScorePerRound2 += 2;
            Payoff.sprite = Resources.Load("Images/ui/payoffs4", typeof(Sprite)) as Sprite;
            //还有一种写法Payoff.sprite = Resources.Load<Sprite>("Images/ui/payoffs4"）
        }
        Scene2ShowScore();
    }
    public void Scene2ShowScore()
    {
        TextScore1.text = ScorePerRound1.ToString();
        TextScore2.text = ScorePerRound2.ToString();
        TextRoundNum.text = "第" + RoundNum + "/5个对手" +
            "你的总分" + TotalScore;
    }
    #endregion Scene2
    #region Scene3
    public void OnClick3(GameObject sender)
    {
        switch (sender.name)
        {
            case "ChoiceButton1":
                Debug.Log("ChoiceButton1");
                ChoiceNumScene3 = 1;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton2":
                Debug.Log("ChoiceButton2");
                ChoiceNumScene3 = 2;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton3":
                Debug.Log("ChoiceButton3");
                ChoiceNumScene3 = 3;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton4":
                Debug.Log("ChoiceButton4");
                ChoiceNumScene3 = 4;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton5":
                Debug.Log("ChoiceButton5");
                ChoiceNumScene3 = 5;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "NextButton5":
                Debug.Log("NextButton5");
                OnRender(Scene3, 2);
                break;
            case "NextButton6":
                Debug.Log("NextButton6");
                OnRender(Scene3, 3);
                break;
            case "NextButton7":
                Debug.Log("NextButton7");
                OnRender(Scene3, 4);
                break;
            case "NextButton8":
                Debug.Log("NextButton8");
                OnRender(Scene3, 5);
                break;
            case "NextButton9":
                Debug.Log("NextButton9");
                OnRender(Scene3, 6);
                break;
            case "NextButton10":
                Debug.Log("NextButton10");
                OnRender(Scene3, 7);
                break;
            case "NextButton11":
                Debug.Log("NextButton11");
                OnRender(Scene3, 8);
                break;
            case "NextButton12":
                Debug.Log("NextButton12");
                OnRender(Scene3, 9);
                break;
            case "NextButton13":
                Debug.Log("NextButton13");
                OnRender(Scene3, 10);
                break;
            case "NextButton14":
                Debug.Log("NextButton14");
                OnRender(Scene3, 11);
                break;
            case "NextButton15":
                Debug.Log("NextButton15");
                OnRender(Scene3, 12);
                break;
            case "NextButton16":
                Debug.Log("NextButton16");
                OnRender(Scene, 4);
                OnRender(Scene4, 0);
                break;
            default:
                Debug.Log("none");
                break;
        }
    }

    public void Scene3ShowChoiceNmae()
    {
        switch (ChoiceNumScene3)
        {
            case 1:
                Debug.Log("in case 1 Scene3");
                TextName1.text = "<color=#007FFF>复读机</color>";
                TextName2.text = "<color=#007FFF>复读机!</color>" + "  恭喜你答对啦!!!";
                break;
            case 2:
                Debug.Log("in case 2 Scene3");
                TextName1.text = "<color=#FF6EC7>万年小粉红</color>";
                TextName2.text = "<color=#007FFF>复读机!</color>" + "  (对不住啦，<color=#FF6EC7>万年小粉红</color>。)";
                break;
            case 3:
                Debug.Log("in case 3 Scene3");
                TextName1.text = "<color=#9932CD>千年老油条</color>";
                TextName2.text = "<color=#007FFF>复读机!</color>" + "  (对不住啦，<color=#9932CD>千年老油条</color>。)";
                break;
            case 4:
                Debug.Log("in case 4 Scene3");
                TextName1.text = "<color=yellow>黑帮老铁</color>";
                TextName2.text = "<color=#007FFF>复读机!</color>" + "  (对不住啦，<color=yellow>黑帮老铁</color>。)";
                break;
            case 5:
                Debug.Log("in case 5 Scene3");
                TextName1.text = "<color=#D98719>福尔摩星儿</color>";
                TextName2.text = "<color=#007FFF>复读机!</color>" + "  (对不住啦，<color=#D98719>福尔摩星儿</color>。)";
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    #endregion Scene3
    #region Scene4
    public void OnClick4(GameObject sender)
    {
        switch (sender.name)
        {
            case "ChoiceButton6":
                Debug.Log("ChoiceButton6");
                ChoiceNumScene4 = 1;
                Scene4ShowChoiceNmae();
                OnRender(Scene4, 2);
                break;
            case "ChoiceButton7":
                Debug.Log("ChoiceButton7");
                ChoiceNumScene4 = 2;
                Scene4ShowChoiceNmae();
                OnRender(Scene4, 2);
                break;
            case "ChoiceButton8":
                Debug.Log("ChoiceButton8");
                ChoiceNumScene4 = 3;
                Scene4ShowChoiceNmae();
                OnRender(Scene4, 2);
                break;
            case "NextButton17":
                Debug.Log("NextButton17");
                OnRender(Scene4, 1);
                break;
            case "NextButton18":
                Debug.Log("NextButton18");
                ClickNumScene4 += 1;
                Scene4Evlution();
                ani1.SetInteger("AnimationNum", ClickNumScene4);
                Button1Scene4.interactable = false;
                Button2Scene4.interactable = true;
                break;
            case "NextButton19":
                Debug.Log("NextButton19");
                ClickNumScene4 += 1;
                Scene4Evlution();
                ani1.SetInteger("AnimationNum", ClickNumScene4);
                Button2Scene4.interactable = false;
                Button3Scene4.interactable = true;
                break;
            case "NextButton20":
                Debug.Log("NextButton20");
                ClickNumScene4 += 1;
                Scene4Evlution();
                ani1.SetInteger("AnimationNum", ClickNumScene4);
                Button3Scene4.interactable = false;
                Button1Scene4.interactable = true;
                break;
            case "NextButton21":
                Debug.Log("NextButton21");
                OnRender(Scene4, 4);
                break;
            case "NextButton22":
                Debug.Log("NextButton22");
                TextName5.text = "（注意：有少数<color=yellow>黑帮老铁</color>可能会一直留下来，因为除了<color=yellow>黑帮老铁</color>和<color=#007FFF>复读机</color>之外所有人都被消灭了，他们两个会达成平局。）\n\n" +
                "所以，看起来博弈论的道理好像在告诉我们这些事情：像<color=#007FFF>复读机</color>这样「己所不欲勿施于人」的人生哲学不仅仅是道德层面上的真理，同时也是科学上的真理。然而...";
                ani2.SetTrigger("isClicked");
                NextButton22.interactable = false;
                imgTemp.enabled = false;
                break;
            case "NextButton23":
                Debug.Log("NextButton23");
                OnRender(Scene4, 5);
                TextBox1.text = "看看你周围，这个世界上简直充满了无赖。\n\n"+

                "如果在这个重复的信任游戏中，<color=#007FFF>复读机</color>使用的是这种甚至连一战战壕里的士兵都独立地「进化」出来了的这种被称作「互惠宽容」的强大策略，那么，为什么，这个世界上有那么多不信任别人，以及不值得信任的人？是什么使得「不信任」这种病毒得以如此广泛地传播呢？\n\n" +

                "有一个线索其实就藏在这句话本身「在这个重复的信任游戏中」。到目前为止，我们都只在讨论<b>玩家的变化</b>：但是，如果我们讨论一下这个<b>博弈游戏本身的变化</b>呢？有没有想过，导致不信任的...";

                break;
            case "NextButton24":
                Debug.Log("NextButton24");
                NextButton24ClickNum += 1;
                if(NextButton24ClickNum == 1)
                {
                    NextButton24.text = "而且，如果报酬发生变化...";
                    TextBox1.text = "如果不进行足够多轮的比赛，（这里是五轮或者更少）老油条就会处于绝对的优势\n\n" +

                    "1985年的调查显示，当美国人被问到他们有多少亲密朋友的时候，最常见的回答是「三个」。而在2014年，这个数字是「零」。现在，我们拥有越来越少不同阶级，不同种族，不同经济状况，不同政治理念的朋友，原因只是因为我们所拥有的朋友数量变少了，仅此而已。而且，刚刚你自己也发现了一个道理，<b>人与人之间越来越少的「重复互动」，所带来的影响就是不信任的加剧扩散。</b>\n\n" +

                    "（不不，大众传媒不算是重复互动：必须是<b>个人与个人</b>之间进行的<b>双向</b>互动才行）";
                }
                else if(NextButton24ClickNum == 2)
                {
                    NextButton24.text = "犯错!!!";
                    TextBox1.text = "同样的事情发生了：当「双赢」的报酬被降低，老油条开始处于优势地位。对于这种现象，博弈论里面有两个很恰当的概念可以参考：\n\n"+

                    "<b>「零和游戏」</b>，指的是游戏的双方都悲观的相信己方得到的东西<b>必然</b>来自与对方的失去，反之亦然。\n\n" +

                    "<b>「非零和游戏」</b>，指的是游戏双方都努力创造双赢的局面（或者至少防止双输的出现）！如果没有非零和游戏，人与人之间的信任便<b>不可能</b>得到传播。\n\n" +

                    "说到这儿，咱们来看一下第三个，也是最后一个阻止信任传播的壁垒...";
                }
                else
                {
                    //进入场景5
                }
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    public void Scene4ShowChoiceNmae()
    {
        switch (ChoiceNumScene4)
        {
            case 1:
                Debug.Log("in case 1 Scene4");
                TextName3.text = "有道理，<color=#FF6EC7>万年小粉红</color>人多力量大嘛... 好，现在看看你选的对不对：";
                break;
            case 2:
                Debug.Log("in case 2 Scene4");
                TextName3.text = "有道理，<color=#9932CD>千年老油条</color>有这么多万年小粉红可以取剥削... 好，现在看看你选的对不对：";
                break;
            case 3:
                Debug.Log("in case 3 Scene4");
                TextName3.text = "有道理，<color=#007FFF>复读机!</color>刚刚就赢了嘛，这次怎么会输呢？... 好，现在看看你选的对不对：";
                break;
            default:
                Debug.Log("none");
                break;
        }
    }

    //连续点击进化场景中三个按钮的处理
    public void Scene4Evlution()
    {
        switch (ClickNumScene4)
        {
            case 3:
                Debug.Log("text change 3 in Scene4");
                if (ChoiceNumScene4 == 1)
                    TextName3.text = "哎呀，<color=#FF6EC7>小粉红</color>被 老油条给吃了，现在场上还剩十个。 不过，我们再多玩几场试试...";
                else if (ChoiceNumScene4 == 2)
                    TextName3.text = "好吧，你赢了！这次<color=#9932CD>老油条</color>获得了胜利，数量增加了五个。 不过，我们再多玩几场试试...";
                else
                    TextName3.text = "哎呀，<color=#007FFF>复读机</color>没赢——不过至少比小粉红强一点，他们都被老油条给吃了五个了。 不过，我们再多玩几场试试...";
                break;
            case 6:
                Debug.Log("text change 6 in Scene4");
                TextName3.text = "随着<color=#FF6EC7>小粉红</color>被五个五个地吃掉，老油条越来越多...";
                break;
            case 9:
                Debug.Log("text change 9 in Scene4");
                TextName3.text = "现在，<color=#FF6EC7>小粉红</color>们全部被吃掉了。不过，等等...";
                break;
            case 12:
                Debug.Log("text change 12 in Scene4");
                TextName3.text = "对啦：老油条作茧自缚，变成了受害者！他们剥削完了天真无邪的<color=#FF6EC7>小粉红</color>之后，不得不独自面对<color=#007FFF>复读机</color>了。<color=#007FFF>复读机</color>们虽然人很好，但是他们并不傻。";
                break;
            case 15:
                Debug.Log("text change 15 in Scene4");
                TextName3.text = "仅仅重复别人动作的<color=#007FFF>复读机</color>可以与他人良好地相处，而自私的老油条们只能骗他们自己！不光如此，当他们需要对阵<color=#007FFF>复读机</color>这种只会以其人之道还治其人之身的人的时候，一定会让老油条们尝到作茧自缚的滋味。";
                break;
            case 18:
                Debug.Log("text change 18 in Scene4");
                TextName3.text = "所以，结果显然就是...";
                break;
            case 21:
                Debug.Log("text change 21 in Scene4");
                if (ChoiceNumScene4 == 1)
                    TextName4.text = "好吧，尽管你猜错了——天真善良的<color=#FF6EC7>小粉红</color>被从一开始就注定在劫难逃——最终，一种聪明的善良蔓延到了整个地球，<color=#9932CD>老油条</color>也灰飞烟灭了。 这让我想到了一句话：";
                else if (ChoiceNumScene4 == 2)
                    TextName4.text = "虽然短期内，你是对的——<color=#9932CD>老油条</color>确实赢了前几场，但最终我们看到，当他残酷剥削的本质暴露无遗的同时，也不可避免地跌入了深渊。 这让我想到了一句话：";
                else
                    TextName4.text = "所以，长期来看，你是对的——<color=#007FFF>复读机</color>赢了！<color=#9932CD>老油条</color>在短期内确实可能获得胜利，但最终我们看到，当他残酷剥削的本质暴露无遗的同时，也不可避免地跌入了深渊。 这让我想到了一句话：";
                OnRender(Scene4, 3);
                break;
            default:
                Debug.Log("none");
                break;
        }
    }

    #endregion Scene4
    #region Scene6
    public void OnClick6(GameObject sender)
    {
        switch (sender.name)
        {
            case "NextButton6_0":
                Debug.Log("Finish 6_0");
                OnRender(Scene6, 1);
                break;
            case "NextButton6_1":
                Debug.Log("Finish 6_1");
                OnRender(Scene6, 2);
                break;
            case "NextButton6_2":
                Debug.Log("Finish 6_2");
                OnRender(Scene6, 3);
                break;
            case "NextButton6_3":
                Debug.Log("Finish 6_3");
                OnRender(Scene6, 4);
                break;
            case "NextButton6_4":
                Debug.Log("Finish 6_4");
                OnRender(Scene6, 5);
                break;
            case "NextButton6_5":
                Debug.Log("Finish 6_5");
                OnRender(Scene6, 6);
                break;
            case "NextButton6_6_1":
                Debug.Log("Finish 6_6_1");
                if (Correct6_6 == true)
                {
                    OnRender(Scene6, 8);
                }
                else if (Correct6_6 == false)
                {
                    OnRender(Scene6, 9);
                }
                break;
            case "NextButton6_6_2":
                Debug.Log("Finish 6_6_2");
                OnRender(Scene6, 10);
                break;
            case "NextButton6_6_3":
                Debug.Log("Finish 6_6_3");
                OnRender(Scene6, 10);
                break;
            case "NextButton6_7_1":
                Debug.Log("Finish 6_7_1");
                if (Correct6_7 == true)
                {
                    OnRender(Scene6, 12);
                }
                else if (Correct6_7 == false)
                {
                    OnRender(Scene6, 13);
                }
                break;
            case "NextButton6_7_2":
                Debug.Log("Finish 6_6_3");
                OnRender(Scene6, 14);
                break;
            case "NextButton6_7_3":
                Debug.Log("Finish 6_6_3");
                OnRender(Scene6, 14);
                break;
            case "NextButton6_8_0":
                Debug.Log("Finish 6_8_0");
                OnRender(Scene6, 15);
                break;
            case "NextButton6_8_1":
                Debug.Log("Finish 6_8_1");
                OnRender(Scene, 7);
                break;
            case "ChoiceButton6_6_0_1":
                Debug.Log("Finish 6_6_0 with choice 1");
                Text1.text = Text3.text = "<color=#A8D0FF>复读鸭</color>";
                Correct6_6 = false;
                Text1.fontSize = 20;
                OnRender(Scene6, 7);
                break;
            case "ChoiceButton6_6_0_2":
                Debug.Log("Finish 6_6_0 with choice 2");
                Text1.text = Text2.text = "<color=#9ce354>一根筋</color>";
                Correct6_6 = true;
                Text1.fontSize = 20;
                OnRender(Scene6, 7);
                break;
            case "ChoiceButton6_6_0_3":
                Debug.Log("Finish 6_6_0 with choice 3");
                Text1.text = Text3.text = "<color=#ff5e5e>胡乱来</color>";
                Correct6_6 = false;
                Text1.fontSize = 20;
                OnRender(Scene6, 7);
                break;
            case "ChoiceButton6_6_0_4":
                Debug.Log("Finish 6_6_0 with choice 4");
                Text1.text = Text3.text = "<color=#4089dd>复读机</color>";
                Correct6_6 = false;
                Text1.fontSize = 20;
                OnRender(Scene6, 7);
                break;
            case "ChoiceButton6_6_0_5":
                Debug.Log("Finish 6_6_0 with choice 5");
                Text1.text = Text3.text = "<color=#ffd3ff>万年小粉红</color>";
                Text1.fontSize = Text3.fontSize = 12;
                Correct6_6 = false;
                OnRender(Scene6, 7);
                break;
            case "ChoiceButton6_7_0_1":
                Debug.Log("Finish 6_7_0 with choice 1");
                Text4.text = Text5.text = "<color=#A8D0FF>复读鸭</color>";
                Correct6_7 = true;
                Text1.fontSize = 20;
                OnRender(Scene6, 11);
                break;
            case "ChoiceButton6_7_0_2":
                Debug.Log("Finish 6_7_0 with choice 2");
                Text4.text = Text6.text = "<color=#9ce354>一根筋</color>";
                Correct6_7 = false;
                Text1.fontSize = 20;
                OnRender(Scene6, 11);
                break;
            case "ChoiceButton6_7_0_3":
                Debug.Log("Finish 6_7_0 with choice 3");
                Text4.text = Text6.text = "<color=#ff5e5e>胡乱来</color>";
                Correct6_7 = false;
                Text1.fontSize = 20;
                OnRender(Scene6, 11);
                break;
            case "ChoiceButton6_7_0_4":
                Debug.Log("Finish 6_7_0 with choice 4");
                Text4.text = Text6.text = "<color=#4089dd>复读机</color>";
                Correct6_7 = false;
                Text1.fontSize = 20;
                OnRender(Scene6, 11);
                break;
            case "ChoiceButton6_7_0_5":
                Debug.Log("Finish 6_7_0 with choice 5");
                Text4.text = Text6.text = "<color=#52537f>千年老油条</color>";
                Text1.fontSize = Text3.fontSize = 12;
                Correct6_7 = false;
                OnRender(Scene6, 11);
                break;
            default:
                Debug.Log("None");
                break;
        }
    }
    #endregion Scene6
    #region Scene8
    public void OnClick8(GameObject sender)
    {
        switch (sender.name)
        {
            case "NextButton25":
                Debug.Log("NextButton25");
                OnRender(Scene8, 1);
                break;
            case "NextButton26":
                Debug.Log("NextButton26");
                OnRender(Scene8, 2);
                break;
            case "NextButton27":
                Debug.Log("NextButton27");
                OnRender(Scene8, 3);
                break;
            default:
                Debug.Log("none");
                break;
        }
    }
    #endregion Scene8

    //控制场景的显示
    public void OnRender(List<GameObject> Scene,int index)
    {
        for(int i=0;i<Scene.Count;i++)
        {
            if (i == index) Scene[i].SetActive(true);
            else Scene[i].SetActive(false);
        }
    }
}
