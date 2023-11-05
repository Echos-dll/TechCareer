using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LerpDeneme : MonoBehaviour
    {
        [SerializeField] private float startValue;
        [SerializeField] private float endValue;
        [Range(0,1f)]
        [SerializeField] private float lerpAmount;

        public float CurrentValue;

        private void Update()
        {
            lerpAmount += Time.deltaTime / 10;
            lerpAmount %= 1;
            CurrentValue = Mathf.Lerp(startValue, endValue, lerpAmount);
        }
    }
}