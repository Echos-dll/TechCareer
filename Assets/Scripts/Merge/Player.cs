using System;
using UnityEngine;

namespace Merge
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MergeArea _mergeArea;
        
        private Camera m_mainCamera;

        private Ray ray;

        private void Awake()
        {
            m_mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SelectionRay();
            }
        }

        private void SelectionRay()
        {
            ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (!Physics.Raycast(ray, out RaycastHit hit, m_mainCamera.farClipPlane)) return;
            
            if (!hit.collider.TryGetComponent(out MergeActor actor)) return;
            
            _mergeArea.PlaceActor(actor);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (m_mainCamera == null) return;
            ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
            Gizmos.DrawRay(ray.origin, ray.direction * m_mainCamera.farClipPlane);
        }
    }
}