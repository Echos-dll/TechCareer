using System;
using UnityEngine;

namespace Gate
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _range;
        
        private Vector3 m_StartingPosition;
        private ObjectPool<Bullet> m_Pool;

        private void Start()
        {
            m_StartingPosition = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(m_StartingPosition, transform.position) > _range)
            {
                if (m_Pool == null)
                {
                    Destroy(gameObject);
                }
                else
                {
                    m_Pool.Return(this);
                }
            }
            
            transform.Translate(Time.deltaTime * _speed * Vector3.forward);
        }

        public void Init(float range, ObjectPool<Bullet> pool)
        {
            _range = range;
            m_Pool = pool;
        }
        
        public void Init(float range)
        {
            _range = range;
        }
    }
}