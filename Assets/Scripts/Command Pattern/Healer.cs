using UnityEngine;

namespace Command_Pattern
{
    public class Healer : IHealthProcess
    {
        public void Process(HealthSystem target, int amount)
        {
            target.Health += amount;
            Debug.Log("Healed for " + amount + " health!");
        }

        public void UndoProcess(HealthSystem target, int amount)
        {
            target.Health -= amount;
            Debug.Log("Undo Healed process for " + amount + " health!");
        }
    }
    
    public class DamageDealer : IHealthProcess
    {
        public void Process(HealthSystem target, int amount)
        {
            target.Health -= amount;
            Debug.Log("Damage dealt " + amount + " damage!");
        }

        public void UndoProcess(HealthSystem target, int amount)
        {
            target.Health += amount;
            Debug.Log("Undo damage dealt process " + amount + " damage!");
        }
    }

    public interface IHealthProcess
    {
        public void Process(HealthSystem target, int amount);
        public void UndoProcess(HealthSystem target, int amount);
    }
}