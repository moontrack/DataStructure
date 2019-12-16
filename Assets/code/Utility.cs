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
    public static List<string> LoadScript(string path)
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
    public static TextAsset LoadTextAsset(string path)
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
    #endregion
}
