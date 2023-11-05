using System;
using UnityEngine;

namespace Player
{
    public class HealthComponent : MonoBehaviour
    {
        public IntegerValue health;
    
        public void TakeDamage(int damage)
        {
            Debug.Log($"Damage taken amount: {damage}");
            int newHealth = health.value - damage;
            health.SetValue(newHealth);
            
            if (health.value <= 0)
            {
                //Fail condition
                Destroy(gameObject);
            }
        }
    
        public void Heal(int healAmount)
        {
            if (health.value >= 3)
            {
                Debug.Log($"Health.value is full: {healAmount}");
                return;
            }
            
            int newHealth = health.value + healAmount;
            health.SetValue(newHealth);
            Debug.Log($"Healed amount: {healAmount}");
            //health.value += healAmount;
        }
    }
}
