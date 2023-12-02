using System;
using ScriptableObjects;
using ScriptableObjects.ARPG_Inventory;
using UnityEngine;

namespace ARPG_Inventory
{
    public class WorldItemPicker : MonoBehaviour
    {
        [SerializeField] private LayerMask _worldItemLayer;
        [SerializeField] private ScriptableItemDataEvent _itemPickEvent;

        private RaycastHit[] results = new RaycastHit[1];
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
                if (Physics.RaycastNonAlloc(ray, results, Camera.main.farClipPlane, _worldItemLayer) > 0)
                {
                    if (results[0].collider.TryGetComponent(out WorldItem worldItem))
                    {
                        PickItem(worldItem.GetItemData());
                        Destroy(worldItem.gameObject);
                    }
                }
            }
        }

        private void PickItem(ItemData itemData)
        {
            _itemPickEvent.InvokeAction(itemData);
        }
    }
}