using System;
using ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ScriptableIntEvent))]
    public class ScriptableIntEditor : UnityEditor.Editor
    {
        public int value;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ScriptableIntEvent scriptableIntEvent = (ScriptableIntEvent)target;

            value = EditorGUILayout.IntField("Value", value);
            
            if (GUILayout.Button("Invoke"))
            {
                scriptableIntEvent.InvokeAction(value);
            }
        }
    }
}