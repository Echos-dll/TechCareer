using UnityEngine;

namespace Collectables
{
    public abstract class HealthChangerItems : CollectableItem
    {
        [SerializeField] protected int _healthChangeAmount;
    }
}