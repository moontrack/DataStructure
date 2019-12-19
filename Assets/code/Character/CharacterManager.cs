using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 15; i++) AddCharacter(CharacterType.Repeater);
    }
    //
    void Update()
    {
        foreach (var item in Data.Instance.CharacterList) 
        {
            item.Move();
        }
    }
    //
    public void AddCharacter(CharacterType characterType)
    {
        GameObject go = Instantiate(Utility.LoadPrefab("Prefab/Character"), transform);
        Character newCharacter = go.GetComponent<Character>();
        newCharacter = Data.Instance.CharacterInfo[characterType].CopyData(newCharacter);
        Data.Instance.CharacterList.Add(newCharacter);
    }
    //
    public void StartGame(Character character_1, Character character_2)
    {
        CharacterAction action_1 = character_1.GetAction();
        CharacterAction action_2 = character_2.GetAction();
        if (action_1 == CharacterAction.Cooperate && action_2 == CharacterAction.Cooperate)
        {
            character_1.CurMoney += int.Parse(Data.Instance.GlobalStatus[GameStatus.ReturnMoney]) + int.Parse(Data.Instance.GlobalStatus[GameStatus.LossMoney]);
            character_2.CurMoney += int.Parse(Data.Instance.GlobalStatus[GameStatus.ReturnMoney]) + int.Parse(Data.Instance.GlobalStatus[GameStatus.LossMoney]);
            //补全对应的动画
        }
        else if (action_1 == CharacterAction.Cooperate && action_2 == CharacterAction.Fool)
        {

        }
        else if (action_1 == CharacterAction.Fool && action_2 == CharacterAction.Cooperate)
        {

        }
        else if (action_1 == CharacterAction.Fool && action_2 == CharacterAction.Fool)
        {

        }
        //
        StartCoroutine(Utility.WaitTimeToInvoke(delegate
        {
            character_1.IsPlayingGame = false;
            character_1.IsMoving = true;
            character_1.PlayedCharacter.Add(character_2);
            character_2.IsPlayingGame = false;
            character_2.IsMoving = true;
            character_2.PlayedCharacter.Add(character_1);
        },
        1f)
            );
    }
}
