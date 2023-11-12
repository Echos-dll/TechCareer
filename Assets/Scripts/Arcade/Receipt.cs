using Arcade.GameResources;
using UnityEngine;

namespace Arcade
{
    [CreateAssetMenu(fileName = "New Receipt", menuName = "Arcade/Receipt")]
    public class Receipt : ScriptableObject
    {
        public ResourceItem _ResourceItem;
        public float _GenerateTime;
    }
}
