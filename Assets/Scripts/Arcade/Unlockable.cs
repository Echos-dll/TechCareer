using System;
using Arcade.GameResources;
using ScriptableObjects;
using TMPro;
using UnityEngine;

namespace Arcade
{
    public class Unlockable : MonoBehaviour
    {
        [Header("Unlockable Settings")]
        [SerializeField] private int _unlockableId;
        [SerializeField] private int _unlockingId;
        [SerializeField] private int _cost;
        [SerializeField] private float _stayTime;
        [SerializeField] private float _buyTime;

        [Header("References")]
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Collider _collider;
        [SerializeField] private GameObject _model;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private ResourceGenerator _resourceGeneratorPrefab;
        [SerializeField] private Receipt _receipt;

        [Header("Events")] 
        [SerializeField] private ScriptableIntEvent _onUnlocked;
        
        [Header("Values")]
        [SerializeField] private IntegerValue _coinValue;


        private Action m_currentBehaviour;
        private float m_timer;
        private float m_currentPercent;
        private int m_currentCost;
        private int m_previousCost;

        private void Start()
        {
            m_currentCost = _cost;
            m_previousCost = m_currentCost;
            UpdateText();
        }

        private void Update()
        {
            m_currentBehaviour?.Invoke();
        }

        private void LoadingBehaviour()
        {
            if (m_timer < _stayTime)
            {
                m_timer += Time.deltaTime;
            }
            else
            {
                StartToBuy();
            }
        }

        private void BuyingBehaviour()
        {
            if (_coinValue.Value < m_currentCost)
            {
                Debug.Log("HERE");
                IdleBehaviour();
            }
            
            if (m_timer < _buyTime)
            {
                m_timer += Time.deltaTime;
                SpendCoin();
            }
            else
            {
                Buy();
                m_timer = 0;
            }
        }

        private void SpendCoin()
        {
            Debug.Log($"Timer: {m_timer}");
            m_currentPercent = m_timer / _buyTime;
            m_currentCost = (int) Mathf.Lerp(_cost, 0, m_currentPercent);
            _coinValue.Value -= m_previousCost - m_currentCost;
            m_previousCost = m_currentCost;
            UpdateText();
        }
        
        private void Buy()
        {
            ResourceGenerator newGenerator = Instantiate(_resourceGeneratorPrefab, _spawnPoint.position, Quaternion.identity);
            newGenerator.SetReceipt(_receipt);
            _onUnlocked.InvokeAction(_unlockingId);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInteraction _))
            {
                StartToLoad();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerInteraction _))
            {
                IdleBehaviour();
            }
        }

        private void IdleBehaviour()
        {
            Debug.Log("Idle");
            m_timer = 0;
            m_currentBehaviour = null;
        }
        
        private void StartToLoad()
        {                
            Debug.Log("Start to load");
            m_currentBehaviour = LoadingBehaviour;
        }

        private void StartToBuy()
        {
            Debug.Log("Start to buy");
            m_timer = _buyTime * m_currentPercent;
            m_currentBehaviour = BuyingBehaviour;
        }

        private void UpdateText()
        {
            _costText.text = m_currentCost.ToString();
        }

        private void CheckUnlock(int id)
        {
            bool isActive = id == _unlockableId;
            
            _model.SetActive(isActive);
            _collider.enabled = isActive;
        }

        private void OnEnable()
        {
            _onUnlocked.Subscribe(CheckUnlock);
        }

        private void OnDisable()
        {
            _onUnlocked.Unsubscribe(CheckUnlock);
        }
    }
}
