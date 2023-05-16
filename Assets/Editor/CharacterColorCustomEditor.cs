using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(CharacterColor))]
public class CharacterColorCustomEditor : Editor
{
    SerializedProperty characterColor;

    void OnEnable()
    {
        characterColor = serializedObject.FindProperty("characterColor");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);

        if (GUILayout.Button("Open Character Color Creator"))
        {
            Debug.Log("Click");
            EditorWindow.GetWindow(typeof(CharacterColorCreation));

        }
    }
}
