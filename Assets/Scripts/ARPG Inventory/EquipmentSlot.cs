using ScriptableObjects.ARPG_Inventory;
using UnityEngine;

namespace ARPG_Inventory
{
    public class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType;
        
        private InventoryItem m_equippedItem;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetItem(InventoryItem item)
        {
            m_equippedItem = item;
            m_equippedItem.transform.parent = transform;
            m_equippedItem.GetComponent<RectTransform>().anchorMin = Vector2.one / 2;
            m_equippedItem.GetComponent<RectTransform>().anchorMax = Vector2.one / 2;
            m_equippedItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        
        public void RemoveItem()
        {
            m_equippedItem.transform.parent = null;
            m_equippedItem = null;
        }
        
        public ItemType GetItemType()
        {
            return _itemType;
        }
    }
}
