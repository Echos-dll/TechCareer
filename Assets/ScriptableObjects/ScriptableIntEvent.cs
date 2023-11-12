using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Int Event", menuName = "ScriptableObjects/New Int Event", order = 0)]
    public class ScriptableIntEvent : ScriptableObject
    {
        private Action<int> action;

        public void InvokeAction(int value)
        {
            action?.Invoke(value);
        }
        
        public void Subscribe(Action<int> action)
        {
            this.action += action;
        }
        
        public void Unsubscribe(Action<int> action)
        {
            this.action -= action;
        }
    }
}