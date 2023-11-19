using System;
using UnityEngine;

namespace Gate
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootingPoint;
        public int FireRate { get; set; } = 1;
        public int Range { get; set; }

        private float m_Timer;
        
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
                m_Timer = 0;
            }
        }

        private void Shoot()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
            bullet.transform.LookAt(transform.forward);
        }
        
        private float GetFireRate()
        {
            return 1f / FireRate;
        }
    }
}