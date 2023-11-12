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
            MethodWaiter();
        }
        
        
        //Don't use async task if its not necessary
        private async Task MethodWaiter()
        {
            await Method1();
            Debug.Log("Method 1 finished");
        }
        
        private async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Debug.Log(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });
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