using UnityEngine;

public class LevelDesign : MonoBehaviour
{
    public int level;
    public Vector3 spawnPoint;
    public string levelName;
    public float levelHeight;
    public IntegerValue integerTest;
    
    [ContextMenu("Reset Level Height")]
    private void ResetLevelHeight()
    {
        levelHeight = level;
    }
}
