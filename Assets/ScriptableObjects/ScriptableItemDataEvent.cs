using System;
using ScriptableObjects.ARPG_Inventory;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Item Data Event", menuName = "ScriptableObjects/New Item Data Event", order = 0)]
    public class ScriptableItemDataEvent : ScriptableObject
    {
        private Action<ItemData> m_action;

        public void InvokeAction(ItemData data)
        {
            m_action?.Invoke(data);
        }
        
        public void Subscribe(Action<ItemData> action)
        {
            m_action += action;
        }
        
        public void Unsubscribe(Action<ItemData> action)
        {
            m_action -= action;
        }
    }
}