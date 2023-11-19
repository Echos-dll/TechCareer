using TMPro;
using UnityEngine;

namespace Gate
{
    public abstract class GateBehaviour : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TextMeshPro _currentValueText;
        [SerializeField] private TextMeshPro _changeValueText;
        
        [Header("Settings")]
        [SerializeField] private int _changeValue;
        
        private int m_currentValue;

        public int CurrentValue
        {
            get
            {
                return m_currentValue;
            }
            set
            {
                m_currentValue = value;
                UpdateCurrentText();
            }
        }
        
        protected int ChangeValue => _changeValue;

        protected virtual void Start()
        {
            UpdateChangeText();
            UpdateCurrentText();
        }

        private void UpdateChangeText()
        {
            _changeValueText.text = (Mathf.Sign(_changeValue) >= 0 ? "+" : "-") + _changeValueText;
        }
        
        private void UpdateCurrentText()
        {
            _currentValueText.text = (Mathf.Sign(m_currentValue) >= 0 ? "+" : "-") + m_currentValue;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet _))
            {
                CurrentValue += ChangeValue;
            }
        }
    }
}
