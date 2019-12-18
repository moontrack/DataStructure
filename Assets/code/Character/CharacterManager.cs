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
        Data.Instance.CharacterList.Add(Data.Instance.CharacterInfo[characterType].Copy());
    }
}
