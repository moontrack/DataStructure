using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 5; i++) AddCharacter(CharacterType.Repeater);
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

    }
}
