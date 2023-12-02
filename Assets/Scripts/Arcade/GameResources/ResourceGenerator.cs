using System;
using UnityEngine;
using UnityEngine.UI;

namespace Arcade.GameResources
{
    public class ResourceGenerator : MonoBehaviour
    {
        [SerializeField] private Receipt _receipt;
        [SerializeField] private Transform _generatePoint;
        [SerializeField] private GameObject _timerParent;
        [SerializeField] private Image _timerImage;
        
        private Action m_currentBehaviour;

        private float m_timer;
        private float m_generateTime;
        
        public ResourceItem HoldingItem { get; set; }

        private void Start()
        {
            m_generateTime = _receipt._GenerateTime;
            
            StartGenerator();
        }

        private void Update()
        {
            m_currentBehaviour?.Invoke();
        }

        private void GenerateBehaviour()
        {
            if (m_timer < m_generateTime)
            {
                m_timer += Time.deltaTime;
                _timerImage.fillAmount = m_timer / m_generateTime;
            }
            else
            {
                GenerateItem();
                _timerParent.SetActive(false);
                m_timer = 0;
                m_currentBehaviour = IdleBehaviour;
            }
        }

        private void GenerateItem()
        {
            HoldingItem = Instantiate(_receipt._ResourceItem[0]._worldItemPrefab.GetComponent<ResourceItem>(), _generatePoint.position, Quaternion.identity);
        }

        private void StartGenerator()
        {
            _timerParent.SetActive(true);
            m_currentBehaviour = GenerateBehaviour;
        }
        
        private void IdleBehaviour()
        {
            m_currentBehaviour = null;
        }
        
        public void Restart()
        {
            StartGenerator();
        }

        public void SetReceipt(Receipt receipt)
        {
            _receipt = receipt;
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        
    }
}
