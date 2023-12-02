using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Command_Pattern
{
    public class HealthSystem : MonoBehaviour
    {
        //[SerializeField] private ScriptableIntEvent _onHealthChanged;
        
        [SerializeField] private int _health = 100;

        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                //_onHealthChanged.InvokeAction(_health);
            }
        }
        
        private Queue<ICommand> _commandQueue = new Queue<ICommand>();
        private Stack<ICommand> _undoStack = new Stack<ICommand>();
        
        [Button]
        private void EnterHealthCommand(int amount)
        {
            ICommand command = new ChangeHealthCommand(new Healer(), this, amount);
            _commandQueue.Enqueue(command);
        }
        
        [Button]
        private void EnterDamageCommand(int amount)
        {
            ICommand command = new ChangeHealthCommand(new DamageDealer(), this, amount);
            _commandQueue.Enqueue(command);
        }
        
        [Button]
        private void ExecuteNextCommand()
        {
            if (_commandQueue.Count == 0)
            {
                Debug.LogWarning("Command queue is empty"); 
                return;
            }
            
            ICommand command = _commandQueue.Dequeue();
            command.Execute();
            _undoStack.Push(command);
        }
        
        [Button]
        private void UndoLastCommand()
        {
            if (_undoStack.Count == 0)
            {
                Debug.LogWarning("Undo stack is empty"); 
                return;
            }
            
            ICommand command = _undoStack.Pop();
            command.Undo();
        }
    }
}