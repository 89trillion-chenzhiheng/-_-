using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Test))]
public class TestEditor : Editor
{
    public SerializedObject Obj;
    public SerializedProperty Type;
    public SerializedProperty TestMono;
    public SerializedProperty Str;
    public SerializedProperty Color;


    private void OnEnable()
    {
        Obj = new SerializedObject(target);
        Type = Obj.FindProperty("type");
        TestMono = Obj.FindProperty("test");
        Str = Obj.FindProperty("str");
        Color = Obj.FindProperty("color");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //Obj.Update();

        EditorGUILayout.PropertyField(Type);
        if(Type.enumValueIndex == 0)
        {
            EditorGUILayout.PropertyField(TestMono);
        }
        else if(Type.enumValueIndex == 1)
        {
            EditorGUILayout.PropertyField(Str);
        }
        else if(Type.enumValueIndex == 2)
        {
            EditorGUILayout.PropertyField(Color);
        }


        Obj.ApplyModifiedProperties();
    }
}
