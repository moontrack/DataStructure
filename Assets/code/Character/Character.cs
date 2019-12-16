using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
public class MainCharacter : MonoBehaviour
{
    public string Name;
    public CharacterType Type;
    //Status
    private float mistakeRate;
    public float MistakeRate { get => mistakeRate; set => mistakeRate = value; }
    public virtual CharacterAction GetAction()
    {
        return CharacterAction.Null;
    }
}
//
public class Repeater : MainCharacter
{
    public override CharacterAction GetAction()
    {
        //补全
        return CharacterAction.Fool;
    }
}