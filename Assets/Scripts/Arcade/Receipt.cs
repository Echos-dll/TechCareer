using Arcade.GameResources;
using ScriptableObjects.ARPG_Inventory;
using UnityEngine;

namespace Arcade
{
    [CreateAssetMenu(fileName = "New Receipt", menuName = "Arcade/Receipt")]
    public class Receipt : ScriptableObject
    {
        public ItemData[] _ResourceItem;
        public float _GenerateTime;
    }
}
