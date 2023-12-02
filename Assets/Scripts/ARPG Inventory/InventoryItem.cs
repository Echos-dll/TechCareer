using Editor;
using ScriptableObjects;
using ScriptableObjects.ARPG_Inventory;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ARPG_Inventory
{
    public class InventoryItem : MonoBehaviour, 
        IPointerEnterHandler, 
        IPointerExitHandler,
        IPointerDownHandler, 
        IPointerUpHandler
    {
        [SerializeField] private ItemData _itemData;
        [SerializeField] private ScriptableItemDataEvent _itemDropEvent;
        [SerializeField] private Image _image;
        
        private bool m_isDragging;
        private Vector3 m_originalPosition;
        private bool m_isEquipped;
        private EquipmentSlot m_equipmentSlot;
        private GameObject m_inventory;
        
        private void Update()
        {
            if (m_isDragging)
            {
                transform.position = Input.mousePosition;
            }
        }

        public void Init(ItemData itemData, Image inventory)
        {
            _itemData = itemData;
            _image.sprite = itemData._sprite;
            m_inventory = inventory.gameObject;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _image.color = Color.red;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = Color.white;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //Start to follow mouse
            if (m_isEquipped)
            {
                m_equipmentSlot.RemoveItem();
                transform.parent = m_inventory.transform;
            }
            else
            {
                m_originalPosition = transform.position;
            }
            
            m_isDragging = true;
            _image.raycastTarget = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_isDragging = false;

            GameObject hoveredObject = TechCareerUtils.UIRaycast(eventData);
            
            if (TechCareerUtils.IsOverUI())
            {
                if (hoveredObject.transform.parent.TryGetComponent(out EquipmentSlot equipmentSlot))
                {
                    if (_itemData._itemType == equipmentSlot.GetItemType())
                    {
                        equipmentSlot.SetItem(this);
                        m_isEquipped = true;
                        _image.raycastTarget = true;
                        m_equipmentSlot = equipmentSlot;
                    }
                    else
                    {
                        transform.position = m_originalPosition;
                        transform.parent = m_inventory.transform;
                        m_isEquipped = false;
                        _image.raycastTarget = true;
                    }
                }
                else
                {
                    transform.position = m_originalPosition;
                    transform.parent = m_inventory.transform;
                    m_isEquipped = false;
                    _image.raycastTarget = true;
                }
            }
            else
            {
                _itemDropEvent.InvokeAction(_itemData);
                Destroy(gameObject);
            }
        }
    }
}