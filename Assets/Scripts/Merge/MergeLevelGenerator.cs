using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Merge
{
    public class MergeLevelGenerator : MonoBehaviour
    {
        [SerializeField] private MergeActor _actorPrefab;
        [SerializeField] private List<SpawnData> _spawnData;
        [SerializeField] private Vector2 _spawnAreaX;
        [SerializeField] private Vector2 _spawnAreaY;

        private ObjectPool<MergeActor> m_actorPool;
        
        public ObjectPool<MergeActor> ActorPool => m_actorPool;

        private void Awake()
        {
            m_actorPool = new ObjectPool<MergeActor>(_actorPrefab, 50, transform);
        }

        private void Start()
        {
            GenerateLevel();
        }

        private void GenerateLevel()
        {
            for (int i = 0; i < _spawnData.Count; i++)
            {
                for (int j = 0; j < _spawnData[i]._spawnCount; j++)
                {
                    MergeActor actor = m_actorPool.Get();
                    actor.Init(_spawnData[i]._actorIndex);
                    actor.transform.position = GetSpawnPosition();
                    actor.gameObject.SetActive(true);
                }
            }
        }
        
        private Vector3 GetSpawnPosition()
        {
            Vector3 spawnPosition = Vector3.zero;
            spawnPosition.x = Random.Range(_spawnAreaX.x, _spawnAreaX.y);
            spawnPosition.y = 5;
            spawnPosition.z = Random.Range(_spawnAreaY.x, _spawnAreaY.y);
            return spawnPosition;
        }
    }

    [Serializable]
    public struct SpawnData
    {
        public int _actorIndex;
        public int _spawnCount;
    }
}