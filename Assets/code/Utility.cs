using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

#region Enum
public enum CharacterType
{
    Repeater,
}
//
public enum CharacterAction
{
    Fool,
    Cooperate,
    Null,
}
#endregion

public class Utility
{
    #region Path
    public static readonly string PATH_IMG = "Img/";
    public static readonly string PATH_PREFAB = "Prefab/";
    #endregion
    //
    #region Function
    //
    public static float Random()
    {
        float u = UnityEngine.Random.Range(0f, 1f);
        float v = UnityEngine.Random.Range(0f, 1f);
        return Mathf.Sqrt(-2 * Mathf.Log10(u)) * Mathf.Cos(2 * Mathf.PI * v);
    }
    /// <summary>
    /// 加载角色信息
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static Dictionary<CharacterType, Character> LoadCharacterInfo(string path)
    {
        try
        {
            Dictionary<CharacterType, Character> retVal = new Dictionary<CharacterType, Character>();
            var script = LoadScript(path);
            var title = script[0].Split(',');
            for (int i = 1; i < script.Count; i++)
            {
                var data = script[i].Split(',');
                if (string.IsNullOrEmpty(script[i]))
                    continue;
                Character character = new Character();
                for (int j = 0; j < title.Length; j++)
                {
                    if (string.IsNullOrEmpty(data[j]))
                        continue;
                    switch (title[j])
                    {
                        case "Name":
                            character.Name = data[j];
                            break;
                        case "Type":
                            if(data[j] == "Repeater")
                                character.Type = CharacterType.Repeater;
                            break;
                        case "SpritePath":
                            character.SpritePath = data[j];
                            break;
                    }
                }
                retVal.Add(character.Type, character);
            }
            return retVal;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }
    //
    public static Dictionary<string, string> LoadInitialStatus(string path)
    {
        try
        {
            Dictionary<string, string> retVal = new Dictionary<string, string>();
            var script = LoadScript(path);
            var title = script[0].Split(',');
            var data = script[1].Split(',');
            for (int i = 0; i < title.Length; i++)
            {
                retVal.Add(title[i], data[i]);
            }
            return retVal;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }
    }
    //
    public static Sprite LoadSprite(string path)
    {
        try
        {
            return Resources.Load<Sprite>(path);
        }
        catch (Exception ex)
        {
            Debug.Log(path);
            Debug.LogException(ex);
            return null;
        }
    }
    //
    private static List<string> LoadScript(string path)
    {
        try
        {
            TextAsset textAsset = LoadTextAsset(path);
            return Regex.Split(textAsset.text, "\r\n").ToList();
        }
        catch (Exception ex)
        {
            Debug.Log(path);
            Debug.LogException(ex);
            return null;
        }
    }
    //
    private static TextAsset LoadTextAsset(string path)
    {
        try
        {
            return Resources.Load<TextAsset>(path);
        }
        catch (Exception ex)
        {
            Debug.Log(path);
            Debug.LogException(ex);
            return null;
        }
    }
    //
    public static GameObject LoadPrefab(string path)
    {
        try
        {
            return Resources.Load<GameObject>(path);
        }
        catch (Exception ex)
        {
            Debug.Log(path);
            Debug.LogException(ex);
            return null;
        }
    }
    #endregion
}
