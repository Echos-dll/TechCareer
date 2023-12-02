using ARPG_Inventory;
using UnityEngine;

namespace ScriptableObjects.ARPG_Inventory
{
    [CreateAssetMenu(fileName = "New Item Data", menuName = "Create Item Data", order = 0)]
    public class ItemData : ScriptableObject
    {
        public Sprite _sprite;
        public ItemType _itemType;
        public string _itemName;
        public WorldItem _worldItemPrefab;
    }
}