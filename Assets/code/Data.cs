using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    private static Data instance;
    public static Data Instance
    { 
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<Data>();

            if (instance != null)
                return instance;

            GameObject gameInstanceGameObject = new GameObject("Data");
            instance = gameInstanceGameObject.AddComponent<Data>();

            return instance;
        }
    }
    //
    private Dictionary<CharacterType, Character> characterInfo;
    public Dictionary<CharacterType, Character> CharacterInfo
    {
        get
        {
            if (characterInfo == null)
                characterInfo = Utility.LoadCharacterInfo("Scripts/Character");
            return characterInfo;
        }
        set => CharacterInfo = value;
    }
    //
    private List<Character> characterList;
    /// <summary>
    /// 存储当前有什么角色
    /// </summary>
    public List<Character> CharacterList
    {
        get
        {
            if (characterList == null)
                characterList = new List<Character>();
            return characterList;
        }
        set => characterList = value;
    }
    //
    private Dictionary<string, string> globalStatus;
    /// <summary>
    /// 全局角色使用属性
    /// </summary>
    public Dictionary<string, string> GlobalStatus 
    { 
        get
        {
            if (globalStatus == null)
                GlobalStatus = Utility.LoadInitialStatus("Scripts/InitialStatus");
            return globalStatus;
        }
        set => globalStatus = value;
    }

}
