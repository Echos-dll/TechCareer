using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LevelDesign))]
    public class LevelDesignEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            LevelDesign levelDesign = (LevelDesign)target;

            EditorGUILayout.BeginHorizontal();
            levelDesign.level = EditorGUILayout.IntField("Level Index", levelDesign.level);
            levelDesign.levelName = EditorGUILayout.TextField("Level Name", levelDesign.levelName);
            EditorGUILayout.EndHorizontal();
            
            levelDesign.spawnPoint = EditorGUILayout.Vector3Field("Spawn Point", levelDesign.spawnPoint);
            levelDesign.levelHeight = EditorGUILayout.FloatField("Level Height", levelDesign.levelHeight);
            
        }
    }
}