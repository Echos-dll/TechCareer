using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Border Settings")]
    [SerializeField] private float _startZPosition;
    [SerializeField] private float _endZPosition;
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;
    
    [Header("Prefabs")]
    [SerializeField] private Healer _healerPrefab;
    [SerializeField] private Obstacle _obstaclePrefab;

    [Header("Spawn Settings")] 
    [SerializeField] private float _healSpawnDistance;
    [SerializeField] private float _obstacleSpawnDistance;
    
    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        int healSpawnCount = Mathf.FloorToInt((_endZPosition - _startZPosition) / _healSpawnDistance);
        int obstacleSpawnCount = Mathf.FloorToInt((_endZPosition - _startZPosition) / _obstacleSpawnDistance);

        for (int i = 1; i <= healSpawnCount; i++)
        {
            Healer healer = Instantiate(_healerPrefab);
            Vector3 spawnPosition = new Vector3(Random.Range(_leftBorder, _rightBorder), 0, _startZPosition + _healSpawnDistance * i);
            healer.transform.position = spawnPosition;
        }
        
        for (int i = 1; i <= obstacleSpawnCount; i++)
        {
            Obstacle obstacle = Instantiate(_obstaclePrefab);
            Vector3 spawnPosition = new Vector3(Random.Range(_leftBorder, _rightBorder), 0, _startZPosition + _obstacleSpawnDistance * i);
            obstacle.transform.position = spawnPosition;
        }
    }
    
}
