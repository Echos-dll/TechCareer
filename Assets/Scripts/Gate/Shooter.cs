using System;
using UnityEngine;

namespace Gate
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private bool _usePool;
        [SerializeField] private float _fireRate;

        public float FireRate
        {
            get
            {
                return _fireRate;
            } 
            set
            {
                _fireRate = value;
                
            }
        }

        public float Range { get; set; } = 5;

        private float m_Timer;
        private ObjectPool<Bullet> m_BulletPool;
        
        private void Awake()
        {
            m_BulletPool = new ObjectPool<Bullet>(_bulletPrefab, 100);
        }

        private void Start()
        {
            m_Timer = 0;   
        }

        private void Update()
        {
            if (m_Timer > GetFireRate())
            {
                Shoot();
            }
            else
            {
                m_Timer += Time.deltaTime;
            }
        }

        private void Shoot()
        {
            if (_usePool)
            {
                Bullet bullet = m_BulletPool.Get();
                bullet.transform.LookAt(_shootingPoint.position + _shootingPoint.transform.forward);
                bullet.Init(Range, m_BulletPool);
                bullet.gameObject.SetActive(true);
                m_Timer = 0;
            }
            else
            {
                Bullet bullet = Instantiate(_bulletPrefab, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
                bullet.transform.LookAt(_shootingPoint.position + _shootingPoint.transform.forward);
                bullet.Init(Range);
                m_Timer = 0;
            }
        }
        
        private float GetFireRate()
        {
            return 1f / FireRate;
        }
    }
}