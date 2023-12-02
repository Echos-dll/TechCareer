using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Strategy_Pattern
{
    public class Boss : MonoBehaviour
    {
        private IStrategy m_currentStrategy;
        
        public void SetStrategy(IStrategy strategy)
        {
            m_currentStrategy = strategy;
        }

        private PhaseOne m_phaseOne;
        private PhaseTwo m_phaseTwo;
        private PhaseThree m_phaseThree;

        private void Awake()
        {
            m_phaseOne = new PhaseOne();
            m_phaseTwo = new PhaseTwo();
            m_phaseThree = new PhaseThree();
        }

        private void Start()
        {
            SetStrategy(m_phaseOne);
        }

        private void Update()
        {
            m_currentStrategy.ExecuteBehaviour();
        }

        [Button]
        private void SetStrategyToPhaseOne()
        {
            SetStrategy(m_phaseOne);
        }
        
        [Button]
        private void SetStrategyToPhaseTwo()
        {
            SetStrategy(m_phaseTwo);
        }
        
        [Button]
        private void SetStrategyToPhaseThree()
        {
            SetStrategy(m_phaseThree);
        }
    }
}