using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class Character : MonoBehaviour
{
    private Coroutine exitCor;
    private Coroutine enterCor;
    //
    public string Name;
    public CharacterType Type;
    private float curDir;
    private int moveNum = 0;
    public float MoveSpeed = 1f;
    public GameObject TargetCharacter;
    public GameObject CharacterLayer;
    #region Path
    public string SpritePath;
    #endregion
    #region Status
    //属性有 犯错率，对方上一次的操作，总共对局次数，是否开始移动，是否发现可以对局的人，是否正在进行博弈，当前的钱数，探测半径，进行对局半径
    private float mistakeRate;
    private CharacterAction LastOppAction = CharacterAction.Null;
    private int gameNumber = 0;
    private bool isMoving = false;
    private bool isFindTarget = false;
    private bool isPlayingGame = false;
    private int curMoney = 0;
    private float visibleRange = 500f;
    private float gameRange = 50;
    //
    public float MistakeRate { get => mistakeRate; set => mistakeRate = value; }
    public CharacterAction LastOppAction1 { get => LastOppAction; set => LastOppAction = value; }
    public int GameNumber { get => gameNumber; set => gameNumber = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool IsFindTarget { get => isFindTarget; set => isFindTarget = value; }
    public bool IsPlayingGame { get => isPlayingGame; set => isPlayingGame = value; }
    public int CurMoney { get => curMoney; set => curMoney = value; }
    public float VisibleRange { get => visibleRange; set => visibleRange = value; }
    public float GameRange { get => gameRange; set => gameRange = value; }
    #endregion
    private void Start()
    {
        EnterGame();
    }
    public Character Copy()
    {
        Character retVal = new Character();
        retVal.Name = this.Name;
        retVal.Type = this.Type;
        retVal.CharacterLayer = GameObject.Find("CharacterLayer");
        return retVal;
    }
    /// <summary>
    /// 复制数据 不改变内存位置
    /// </summary>
    /// <param name="retVal"></param>
    /// <returns></returns>
    public Character CopyData(Character retVal)
    {
        retVal.Name = this.Name;
        retVal.Type = this.Type;
        retVal.CharacterLayer = GameObject.Find("CharacterLayer");
        Init();
        return retVal;
    }
    /// <summary>
    /// 初始化函数
    /// </summary>
    private void Init()
    {
        curDir = Random.Range(0f, 2f * Mathf.PI);
        moveNum = Random.Range(250, 750);
        LastOppAction = CharacterAction.Null;
        gameNumber = 0;
        isMoving = false;
        isFindTarget = false;
        curMoney = 0;
        visibleRange = 500f;
        gameRange = 0f;
    }
    /// <summary>
    /// 控制角色行为
    /// </summary>
    public void Do()
    {
        Move();
    }
    /// <summary>
    /// 控制角色移动 
    /// </summary>
    public void Move()
    {
        if (IsMoving)
        {
            TargetCharacter = FindTargetCharacter();
            IsFindTarget = TargetCharacter != null;
            if (!IsFindTarget)
            {
                #region NormalMove
                if (moveNum > 1000)
                {
                    float rand = Utility.Random();
                    curDir = curDir + rand;
                    moveNum = Random.Range(250, 750);
                }
                else
                    moveNum += 1;
                //
                if (transform.localPosition.x > CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2 ||
                    transform.localPosition.x < -CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2 ||
                    transform.localPosition.y > CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2 ||
                    transform.localPosition.y < -CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2)
                    curDir -= Mathf.PI;
                //
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, transform.localPosition + (Vector3.right * Mathf.Cos(curDir) + Vector3.up * Mathf.Sin(curDir)), MoveSpeed / 4f);
                #endregion
            }
            else
            {
                #region DirectionMove
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, TargetCharacter.transform.localPosition, MoveSpeed / 4f);
                if ((transform.localPosition - TargetCharacter.transform.localPosition).magnitude < gameRange)
                {
                    this.IsMoving = false;
                    this.IsPlayingGame = true;
                    TargetCharacter.GetComponent<Character>().IsMoving = false;
                    TargetCharacter.GetComponent<Character>().IsPlayingGame = true;
                }
                #endregion
            }
        }
    }
    /// <summary>
    /// 获得角色这回合的行动
    /// </summary>
    /// <returns></returns>
    public CharacterAction GetAction()
    {
        return CharacterAction.Null;
    }
    /// <summary>
    /// 进场
    /// </summary>
    public void EnterGame()
    {
        Vector3 targetPos = new Vector3( 
            Random.Range(-CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2, CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2),
            Random.Range(-CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2, CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2),
            0);
        Vector3 startPos = GetFarTarget(targetPos);
        transform.localPosition = startPos;
        enterCor = StartCoroutine(Utility.MoveTo(gameObject, startPos, targetPos, delegate { IsMoving = true; }, MoveSpeed / 2.5f));
    }
    /// <summary>
    /// 退场
    /// </summary>
    public void ExitGame()
    {
        //exitOutcor = StartCoroutine(MoveOut(GetExitTarget(), MoveSpeed * 3));
        exitCor = StartCoroutine(Utility.MoveTo(gameObject, transform.localPosition, GetExitTarget(), delegate { Destroy(gameObject); }, MoveSpeed / 2f));
    }
    //
    private Vector3 GetExitTarget()
    {
        return GetFarTarget(transform.localPosition);
    }
    //
    private Vector3 GetFarTarget(Vector3 curPos)
    {
        return curPos.normalized * CharacterLayer.GetComponent<RectTransform>().sizeDelta.magnitude / 2;
    }
    //
    private GameObject FindTargetCharacter()
    {
        GameObject go = null;
        float minDis = VisibleRange;
        foreach (var item in Data.Instance.CharacterList)
        {
            if (item == this || item.IsMoving == false)
                continue;
            if ((item.transform.localPosition - this.transform.localPosition).magnitude < minDis) 
            {
                minDis = (item.transform.localPosition - this.transform.localPosition).magnitude;
                go = item.gameObject;
            }
        }
        return go;
    }
}