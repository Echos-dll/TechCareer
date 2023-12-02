using ScriptableObjects.ARPG_Inventory;
using UnityEngine;

namespace ARPG_Inventory
{
    public class WorldItem : MonoBehaviour
    {
        [SerializeField] private ItemData _itemData;

        public void Init(ItemData itemData)
        {
            _itemData = itemData;
        }
        public ItemData GetItemData()
        {
            return _itemData;
        }
    }
}