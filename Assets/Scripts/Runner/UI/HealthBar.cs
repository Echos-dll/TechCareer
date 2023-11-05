using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private IntegerValue health;
        [SerializeField] private Image[] _healthBoxes;

        private void UpdateHealthUI()
        {
            for (int i = 0; i < _healthBoxes.Length; i++)
            {                
                Image image = _healthBoxes[i];

                if (i <= health.value - 1)
                {
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                }
            }
        }

        private void OnEnable()
        {
            health.SubscribeToValueChanged(UpdateHealthUI);
        }

        private void OnDisable()
        {
            health.UnsubscribeToValueChanged(UpdateHealthUI);
        }
    }
}
