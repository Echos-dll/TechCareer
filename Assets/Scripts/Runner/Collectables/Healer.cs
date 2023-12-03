using Collectables;
using Player;
using UnityEngine;

namespace Runner.Collectables
{
    public class Healer : HealthChangerItems
    {
        protected override void Awake()
        {
            Debug.Log("Healer Awake");
            base.Awake();
        }
    
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out HealthComponent health))
            {
                health.Heal(_healthChangeAmount);
                base.OnTriggerEnter(other);
            }
            else
            {
                Debug.Log("There is no health component on this gameobject.");
            }
        }
    }
}