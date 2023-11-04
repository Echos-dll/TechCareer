using UnityEngine;

namespace Player
{
    public class ColliderController : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("OnCollisionEnter");
        }

        private void OnCollisionExit(Collision other)
        {
            Debug.Log("OnCollisionExit");
        }

        private void OnCollisionStay(Collision other)
        {
            Debug.Log("OnCollisionStay");
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log("OnTriggerExit");
        }

        private void OnTriggerStay(Collider other)
        {
            Debug.Log("OnTriggerStay");
        }
    }
}