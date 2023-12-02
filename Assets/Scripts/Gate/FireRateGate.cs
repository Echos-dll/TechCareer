using UnityEngine;

namespace Gate
{
    public class FireRateGate : GateBehaviour
    {
        protected override void UpdateCurrentText()
        {
            Debug.Log("Deneme");
            _currentValueText.text = "Fire Rate\n" + (Mathf.Sign(CurrentTextValue) >= 0 ? "+" : "") + CurrentTextValue;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            
            if(other.TryGetComponent(out Shooter shooter))
            {
                shooter.FireRate += CurrentValue;
            }
        }
    }
}