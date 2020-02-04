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

    private int ChoiceNum;
    private Text TextName1, TextName2;

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

        //场景二文本显示初始化
        TextName1 = GameObject.Find("Name1").GetComponent<Text>();
        TextName2 = GameObject.Find("Name2").GetComponent<Text>();
        TextName1.text = "复读机";
        TextName2.text = "复读机";
        //场景3数据初始化
        //1--复读机，2-万年小粉红，3-千年老油条，4-黑帮老铁，5-福尔摩星
        ChoiceNum = 0;



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
                ChoiceNum = 1;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton2":
                Debug.Log("ChoiceButton2");
                ChoiceNum = 2;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton3":
                Debug.Log("ChoiceButton3");
                ChoiceNum = 3;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton4":
                Debug.Log("ChoiceButton4");
                ChoiceNum = 4;
                Scene3ShowChoiceNmae();
                OnRender(Scene3, 1);
                break;
            case "ChoiceButton5":
                Debug.Log("ChoiceButton5");
                ChoiceNum = 5;
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
                //进入场景4
                
                break;
            default:
                Debug.Log("none");
                break;
        }

    }

    public void Scene3ShowChoiceNmae()
    {
        switch (ChoiceNum)
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
