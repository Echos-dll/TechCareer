using Arcade.GameResources;
using ScriptableObjects;
using UnityEngine;

namespace Arcade
{
    public class ResourceShop : MonoBehaviour
    {
        [SerializeField] private IntegerValue _coinValue;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerInteraction player)) return;
            
            if (player.HoldingItem != null)
            {
                SellItem(player.HoldingItem);
            }
        }
        
        private void SellItem(ResourceItem item)
        {
            Debug.Log($"Sold item for {item._goldValue} gold");
            _coinValue.Value += item._goldValue;
            Destroy(item.gameObject);
        }
    }
}