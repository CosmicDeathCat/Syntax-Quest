using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerPrefsDB))]

public class PlayerPrefsDBEditor : Editor
{
    public SerializedProperty enableGridOverlay;

    private void OnEnable()
    {
        enableGridOverlay = serializedObject.FindProperty("enableGridOverlay");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(enableGridOverlay); // Use EditorGUILayout.PropertyField to draw the property field

        serializedObject.ApplyModifiedProperties();

        if (GUI.changed)
        {
            PlayerPrefsDB.instance.PlayerPrefsPlus.Set(Prefs.EnableGridOverlay, enableGridOverlay.boolValue); // Use the name of the property instead of Prefs.EnableGridOverlay
        }
        
    }
}
