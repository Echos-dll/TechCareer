using UnityEngine;

namespace Merge
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MergeArea _mergeArea;
        
        private Camera m_mainCamera;

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
            Ray ray = m_mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (!Physics.Raycast(ray, out RaycastHit hit, m_mainCamera.farClipPlane)) return;
            
            if (!hit.collider.TryGetComponent(out MergeActor actor)) return;
            
            _mergeArea.PlaceActor(actor);
        }
    }
}