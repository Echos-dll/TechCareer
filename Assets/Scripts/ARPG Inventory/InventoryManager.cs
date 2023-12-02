using System;
using ScriptableObjects;
using ScriptableObjects.ARPG_Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace ARPG_Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private ScriptableBoolEvent _inventoryToggleEvent;
        [SerializeField] private ScriptableItemDataEvent _itemPickEvent;
        [SerializeField] private Image _inventoryView;
        [SerializeField] private Image _inventory;
        [SerializeField] private InventoryItem _inventoryItemPrefab;

        private void Start()
        {
            ToggleInventory(false);
        }

        private void OnItemPicked(ItemData itemData)
        {
            InventoryItem newItem = Instantiate(_inventoryItemPrefab, _inventory.transform);
            newItem.Init(itemData, _inventory);
        }
        
        private void ToggleInventory(bool value)
        {
            _inventoryView.gameObject.SetActive(value);
        }

        private void OnEnable()
        {
            _inventoryToggleEvent.Subscribe(ToggleInventory);
            _itemPickEvent.Subscribe(OnItemPicked);
        }

        private void OnDisable()
        {
            _inventoryToggleEvent.Unsubscribe(ToggleInventory);
            _itemPickEvent.Unsubscribe(OnItemPicked);
        }
    }
}