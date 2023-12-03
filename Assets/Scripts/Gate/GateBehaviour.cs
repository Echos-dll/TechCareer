using System;
using Collectables;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Gate
{
    public abstract class GateBehaviour : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected TextMeshPro _currentValueText;
        [SerializeField] protected TextMeshPro _changeValueText;
        [SerializeField] private Renderer _gateRenderer;
        [SerializeField] private Color _positiveColor;
        [SerializeField] private Color _negativeColor;
         
        [Header("Settings")]
        [SerializeField, OnValueChanged("UpdateChangeText")] private int _changeValue;
        [SerializeField] protected float _gateMultiplier;
        
        private float m_currentValue;
        //private int m_currentChangeValue;
        private Tween m_colorChangeTween;

        protected float CurrentValue
        {
            get
            {
                return m_currentValue * _gateMultiplier;
            }
            set
            {
                m_currentValue = value;
                UpdateCurrentText();
            }
        }
        
        protected int CurrentTextValue
        {
            get
            {
                return Mathf.RoundToInt(m_currentValue);
            }
        }
        
        protected int ChangeValue
        {
            get
            {
                return _changeValue;
            }
            set
            {
                _changeValue = value;
                UpdateChangeText();
            }
        }

        protected virtual void Start()
        {
            CurrentValue = -5;
            UpdateChangeText();
            UpdateCurrentText();
            _gateRenderer.material.color = CurrentTextValue >= 0 ? _positiveColor : _negativeColor;
        }

        private void UpdateChangeText()
        {
            _changeValueText.text = (Mathf.Sign(ChangeValue) >= 0 ? "+" : "-") + ChangeValue;
        }

        private void UpdateMaterial()
        {
            Color targetColor = CurrentTextValue >= 0 ? _positiveColor : _negativeColor;
            if (m_colorChangeTween == null && _gateRenderer.material.color != targetColor)
            {
                m_colorChangeTween = _gateRenderer.material.DOColor(targetColor, .5f);
                //_gateRenderer.material.Lerp(_gateRenderer.material, targetMaterial, .5f);
            }
            //_gateRenderer.material = CurrentTextValue >= 0 ? _positiveMaterial : _negativeMaterial;
        }

        protected abstract void UpdateCurrentText();

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet _))
            {
                CurrentValue = m_currentValue + ChangeValue;
                UpdateMaterial();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Collider box = GetComponent<BoxCollider>();
            Gizmos.DrawWireCube(box.bounds.center, box.bounds.size);
        }
    }
}
