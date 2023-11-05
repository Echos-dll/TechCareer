using Player;
using UnityEngine;

namespace Collectables
{
    public class Obstacle : HealthChangerItems
    {
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("Obstacle Awake");
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HealthComponent health))
            {
                health.TakeDamage(_healthChangeAmount);
                base.OnTriggerEnter(other);
            }
            else
            {
                Debug.Log("There is no health component on this gameobject.");
            }
        }
    }
}
