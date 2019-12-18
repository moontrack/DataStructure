using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class Character : MonoBehaviour
{
    private Coroutine exitOutcor;
    //
    public string Name;
    public CharacterType Type;
    private float curDir;
    private int moveNum = 0;
    public float MoveSpeed = 1f;
    public float waitTime = 1f;
    public GameObject character;
    public GameObject CharacterLayer;
    #region Path
    public string SpritePath;
    #endregion
    #region Status
    //属性有 犯错率，对方上一次的操作，总共对局次数，是否可以进行对局，是否发现可以对局的人，当前的钱数，探测半径，进行对局半径
    private float mistakeRate;
    private CharacterAction LastOppAction = CharacterAction.Null;
    private int gameNumber = 0;
    private bool canPlayGame = false;
    private bool isFindTarget = false;
    private int curMoney = 0;
    private float visibleRange = 0f;
    private float gameRange = 0f;
    //
    public float MistakeRate { get => mistakeRate; set => mistakeRate = value; }
    public CharacterAction LastOppAction1 { get => LastOppAction; set => LastOppAction = value; }
    public int GameNumber { get => gameNumber; set => gameNumber = value; }
    public bool CanPlayGame { get => canPlayGame; set => canPlayGame = value; }
    public bool IsFindTarget { get => isFindTarget; set => isFindTarget = value; }
    public int CurMoney { get => curMoney; set => curMoney = value; }
    public float VisibleRange { get => visibleRange; set => visibleRange = value; }
    public float GameRange { get => gameRange; set => gameRange = value; }
    #endregion
    public Character Copy()
    {
        Character retVal = new Character();
        retVal.Name = this.Name;
        retVal.Type = this.Type;
        retVal.Init();
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
        canPlayGame = false;
        isFindTarget = false;
        curMoney = 0;
        visibleRange = 0f;
        gameRange = 0f;
        CharacterLayer = GameObject.Find("CharacterLayer");
        character = Instantiate(Utility.LoadPrefab("Prefab/Character"), CharacterLayer.transform);
        character.transform.localPosition = new Vector3(
            Random.Range(-CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2, CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2),
            Random.Range(-CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2, CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2),
            0);
    }
    /// <summary>
    /// 控制角色移动
    /// </summary>
    public void Move()
    {
        if (moveNum > 1000)
        {
            curDir = curDir + Utility.Random();
            moveNum = Random.Range(250, 750); 
        }
        else
            moveNum += 1;
        //
        if (character.transform.localPosition.x > CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2 ||
            character.transform.localPosition.x < -CharacterLayer.GetComponent<RectTransform>().sizeDelta.x / 2 ||
            character.transform.localPosition.y > CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2 ||
            character.transform.localPosition.y < -CharacterLayer.GetComponent<RectTransform>().sizeDelta.y / 2)
            curDir -= Mathf.PI;
        //
        character.transform.localPosition = Vector3.MoveTowards(character.transform.localPosition, character.transform.localPosition + (Vector3.right * Mathf.Cos(curDir) + Vector3.up * Mathf.Sin(curDir)) * MoveSpeed, MoveSpeed / 10f);
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
    /// 退场
    /// </summary>
    public void ExitGame()
    {
        exitOutcor = StartCoroutine(MoveOut(GetExitTarget(), MoveSpeed * 3));
    }
    //
    private IEnumerator MoveOut(Vector3 targetPos, float speed)
    {
        yield return new WaitForSeconds(waitTime);
        float time = (targetPos - character.transform.localPosition).magnitude / speed * Time.deltaTime;
        float curTime = 0f;
        while(curTime < time)
        {
            character.transform.localPosition = Vector3.Lerp(character.transform.localPosition, targetPos, speed);
            curTime += Time.deltaTime;
            yield return null;
        }
        character.transform.localPosition = targetPos;
        Destroy(character);
        yield break;
    }
    //
    private Vector3 GetExitTarget()
    {
        return Vector3.Lerp(Vector3.zero, character.transform.localPosition, character.transform.parent.GetComponent<RectTransform>().sizeDelta.magnitude);
    }
}