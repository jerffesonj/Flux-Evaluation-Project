using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CharacterColorCreation : EditorWindow
{
    public static CharacterColor characterColor;

    public static Color body = Color.white;
    public static Color arms = Color.white;
    public static Color legs = Color.white;

    [MenuItem("Window/Character Color Creation")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(CharacterColorCreation));
    }

    void OnGUI()
    {
        characterColor = FindObjectOfType<CharacterColor>();

        GUIStyle styles = new GUIStyle();
        styles.alignment = TextAnchor.MiddleCenter;
        styles.fontSize = 18;
        styles.normal.textColor = Color.white;

        GUILayout.Space(10);

        GUILayout.Label("Select the player color", styles);
        GUILayout.Space(20);

        body = EditorGUILayout.ColorField("Body Color", body);
        arms = EditorGUILayout.ColorField("Arms Color", arms);
        legs = EditorGUILayout.ColorField("Legs Color", legs);

        GUILayout.Space(15);

        if (GUILayout.Button("Create Scriptable Color"))
        {
            Debug.Log("Click");
            CreateMyAsset();
        }
    }

    public static void CreateMyAsset()
    {
        ColorScriptable asset = CreateInstance<ColorScriptable>();

        AssetDatabase.CreateAsset(asset, "Assets/Character Color Scriptables/Character Color (" + GetNumberOfAssetsOnFolder() + ").asset");
        
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
        asset.SetColors(body,arms,legs);
        characterColor.colors.Add(asset);
        EditorUtility.SetDirty(asset);
    }

    static int GetNumberOfAssetsOnFolder()
    {
        //string[] objs = AssetDatabase.FindAssets("Assets/Character Color Scriptables/");
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

