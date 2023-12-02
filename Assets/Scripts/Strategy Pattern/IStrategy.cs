using UnityEngine;

namespace Strategy_Pattern
{
    public interface IStrategy
    {
        void ExecuteBehaviour();
    }
    
    public class PhaseOne : IStrategy
    {
        public void ExecuteBehaviour()
        {
            Debug.Log("Attacking with sword");
        }
    }
    
    public class PhaseTwo : IStrategy
    {
        public void ExecuteBehaviour()
        {
            Debug.Log("Attacking with magic");
        }
    }
    
    public class PhaseThree : IStrategy
    {
        public void ExecuteBehaviour()
        {
            Debug.Log("Attacking with environment");
        }
    }
}