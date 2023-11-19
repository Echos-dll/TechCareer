using UnityEngine;

namespace Gate
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _range;
        
        private Vector3 m_StartingPosition;

        private void Start()
        {
            m_StartingPosition = transform.position;
        }

        private void Update()
        {
            if (Vector3.Distance(m_StartingPosition, transform.position) > _range)
            {
                Destroy(gameObject);
            }
            
            transform.Translate(Time.deltaTime * _speed * Vector3.forward);
        }
    }
}