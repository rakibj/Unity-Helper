using System;
using UnityEngine;

namespace RakibUtils
{
    public class ExampleExtensionMethods : MonoBehaviour
    {
        private void Start()
        {
            transform.position = transform.position.WithX(5);
            Debug.Log(transform.position);
            
            
        }
    }
}
