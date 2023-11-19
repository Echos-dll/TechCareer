using UnityEngine;

namespace Gate
{
    public class RangeGate : GateBehaviour
    {
        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            
            if(other.TryGetComponent(out Shooter shooter))
            {
                shooter.Range += CurrentValue;
            }
        }
    }
}