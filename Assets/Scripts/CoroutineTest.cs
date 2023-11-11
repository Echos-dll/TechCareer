using System.Collections;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DefaultNamespace
{
    public class CoroutineTest : MonoBehaviour
    {
        private Coroutine _coroutine;
        
        [Button]
        private void StartCoroutine()
        {
            _coroutine = StartCoroutine(MyCoroutine());
            
        }
        
        private IEnumerator MyCoroutine()
        {
            Debug.Log("Coroutine started");
            yield return new WaitForSeconds(2);
            Debug.Log("Coroutine ended");
        }
        
        [Button]
        private void CancelCoroutine()
        {
            StopCoroutine(_coroutine);
        }
    }
}