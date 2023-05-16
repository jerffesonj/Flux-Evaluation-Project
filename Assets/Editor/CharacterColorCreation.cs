using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CharacterColorCreation : EditorWindow
{
    public Color body = Color.white;
    public Color arms = Color.white;
    public Color legs = Color.white;

    private static string scriptablePath = "Assets/Character Color Scriptables/";
    private CharacterColor characterColor;

    [MenuItem("Character Color/Character Color Creation")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(CharacterColorCreation));
    }

    void OnGUI()
    {
        characterColor = FindObjectOfType<CharacterColor>();

        GUIStyle header = HeaderStyle();

        GUILayout.Space(10);

        GUILayout.Label("Select the player color", header);

        GUILayout.Space(20);

        body = EditorGUILayout.ColorField("Body Color", body);
        arms = EditorGUILayout.ColorField("Arms Color", arms);
        legs = EditorGUILayout.ColorField("Legs Color", legs);

        GUILayout.Space(15);

        if (GUILayout.Button("Create new Character Color"))
        {
            CreateMyAsset();
        }
    }

    private GUIStyle HeaderStyle()
    {
        GUIStyle header = new GUIStyle();
        header.alignment = TextAnchor.MiddleCenter;
        header.fontSize = 18;
        header.normal.textColor = Color.white;
        return header;
    }

    private void CreateMyAsset()
    {
        ColorScriptable asset = CreateInstance<ColorScriptable>();

        string assetName = Path.Combine("Character Color (", GetNumberOfAssetsOnFolder().ToString(), ")");
        string assetFileType = ".asset";

        AssetDatabase.CreateAsset(asset, Path.Combine(scriptablePath, assetName, assetFileType));

        //Updates the colors selected to the scriptable created
        asset.SetColors(body, arms, legs);

        //Automatically adds to the characters colors list
        characterColor.colors.Add(asset);

        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    int GetNumberOfAssetsOnFolder()
    {
        string[] objs = Directory.GetFiles("Assets/Character Color Scriptables/");
        int num = 0;
        foreach (string obj in objs)
        {
            if (obj.IndexOf(".meta") < 0)
            {
                Debug.Log(obj);
                num += 1;
            }
        }
        return num + 1;
    }
}