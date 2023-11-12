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
            int newHealth = health.Value - damage;
            health.SetValue(newHealth);
            
            if (health.Value <= 0)
            {
                //Fail condition
                Destroy(gameObject);
            }
        }
    
        public void Heal(int healAmount)
        {
            if (health.Value >= 3)
            {
                Debug.Log($"Health.value is full: {healAmount}");
                return;
            }
            
            int newHealth = health.Value + healAmount;
            health.SetValue(newHealth);
            Debug.Log($"Healed amount: {healAmount}");
            //health.value += healAmount;
        }
    }
}
