using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AddressablesExamples
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private AssetReference _levelPrefab;
        [SerializeField] private AssetLabelReference _levelLabel;
        [SerializeField] private bool _byLabel;
        
        private AsyncOperationHandle m_handle;
        private AsyncOperationHandle<IList<GameObject>> m_labelHandle;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LoadLevel();
            }

            if (m_handle.IsValid())
            {
                Debug.Log(m_handle.PercentComplete);
            }
            
            if (m_labelHandle.IsValid())
            {
                Debug.Log(m_labelHandle.PercentComplete);
            }
        }

        private void LoadLevel()
        {
            if (_byLabel)
            {
                m_labelHandle = Addressables.LoadAssetsAsync<GameObject>(_levelLabel, Callback);
                
                m_labelHandle.Completed += OnLoadLevelByLabelCompleted;
            }
            else
            {
                m_handle = _levelPrefab.LoadAssetAsync<GameObject>();

                m_handle.Completed += OnLoadLevelCompleted;
            }
            
        }
        
        private void Callback(GameObject gobj)
        {
            Instantiate(gobj, transform);
        }

        private void OnLoadLevelByLabelCompleted(AsyncOperationHandle<IList<GameObject>> obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log("Successss");
            }
            else if (obj.Status == AsyncOperationStatus.Failed)
            {
                Debug.Log("Failed");
            }
        }

        private void OnLoadLevelCompleted(AsyncOperationHandle obj)
        {
            if (obj.Status == AsyncOperationStatus.Succeeded)
            {
                Instantiate(_levelPrefab.Asset, transform);
                Debug.Log("Success");
            }
            else if (obj.Status == AsyncOperationStatus.Failed)
            {
                Debug.Log("Failed");
            }
        }
    }
}
