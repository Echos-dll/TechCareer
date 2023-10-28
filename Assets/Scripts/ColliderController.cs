using System;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("OnCollisionStay");
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log("OnCollisionExit");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
    }
}

