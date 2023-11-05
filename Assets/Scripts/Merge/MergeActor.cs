using System;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Merge
{
    [SelectionBase]
    public class MergeActor : MonoBehaviour
    {
        [SerializeField] private int _actorIndex;
        [SerializeField] private MaterialSettings _materialSettings;
        [SerializeField] private Renderer _renderer;
        
        private Rigidbody m_rigidbody;
        private Color defaultColor;
        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            
        }
        
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent(out MergeActor _))
            {
               m_rigidbody.AddForce(Random.insideUnitSphere * 10f, ForceMode.Force);
            }
        }
        
        public void Init(int index)
        {
            _actorIndex = index;
            SetMaterial();
        }

        private void SetMaterial()
        {
            _renderer.material = _materialSettings._materials[_actorIndex];
        }
    }
}
