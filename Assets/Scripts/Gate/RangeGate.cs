using UnityEngine;

namespace Gate
{
    public class RangeGate : GateBehaviour
    {
        protected override void UpdateCurrentText()
        {
            _currentValueText.text = "Range\n" + (Mathf.Sign(CurrentTextValue) >= 0 ? "+" : "") + CurrentTextValue;
        }
        
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