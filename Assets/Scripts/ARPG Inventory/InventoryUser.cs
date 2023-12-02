using DG.Tweening;
using ScriptableObjects;
using ScriptableObjects.ARPG_Inventory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ARPG_Inventory
{
    public class InventoryUser : MonoBehaviour
    {
        [SerializeField] private ScriptableBoolEvent _inventoryToggleEvent;
        [SerializeField] private ScriptableItemDataEvent _itemDropEvent;

        private bool m_isOpen;

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                _inventoryToggleEvent.InvokeAction(!m_isOpen);
                m_isOpen = !m_isOpen;
            }
        }
        
        private void DropItem(ItemData itemData)
        {
            WorldItem worldItem = Instantiate(itemData._worldItemPrefab, transform.position, Quaternion.identity);
            worldItem.Init(itemData);
            Vector3 randomDropPosition = Random.insideUnitSphere * 5;
            randomDropPosition.y = 0;
            worldItem.transform.DOJump(randomDropPosition, 3f, 1, 1f);
        }

        private void OnEnable()
        {
            _itemDropEvent.Subscribe(DropItem);
        }

        private void OnDisable()
        {
            _itemDropEvent.Unsubscribe(DropItem);
        }
    }
}
