using System;
using System.Collections.Generic;
using Arcade;
using Arcade.GameResources;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private List<Receipt> m_receipts;
        [SerializeField] private float m_WaitTime;

        private Receipt m_currentReceipt;
        private void Start()
        {
            m_currentReceipt = m_receipts[Random.Range(0, m_receipts.Count)];
        }

        public Receipt TakeReceipt()
        {
            StartWaitTimer();
            return m_currentReceipt;
        }

        private void StartWaitTimer()
        {
            DOVirtual.DelayedCall(m_WaitTime, Leave);
        }

        public void TakeMeal()
        {
            
        }

        private void EatAndLeave()
        {
            //Give gold
            Leave();
        }

        private void Leave()
        {
            Destroy(gameObject);
        }
    }
}