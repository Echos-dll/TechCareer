using UnityEngine;

namespace Gate
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootingPoint;
        public float FireRate { get; set; } = 1;
        public float Range { get; set; } = 5;

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
            }
        }

        private void Shoot()
        {
            Bullet bullet = Instantiate(_bulletPrefab, _shootingPoint.transform.position, _shootingPoint.transform.rotation);
            bullet.transform.LookAt(_shootingPoint.position + _shootingPoint.transform.forward);
            bullet.Init(Range);
            m_Timer = 0;
        }
        
        private float GetFireRate()
        {
            return 1f / FireRate;
        }
    }
}