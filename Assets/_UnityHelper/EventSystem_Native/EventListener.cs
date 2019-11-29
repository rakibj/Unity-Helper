using System;
using UnityEngine;

namespace RakibUtils
{
    public class EventListener : MonoBehaviour
    {
        private void OnEnable()
        {
            //Register to event declared on GameEvents and raised/invoked on EventInvoker
            GameEvents.NoArgumentEvent += OnNoArgumentEventListener;
            GameEvents.SingleArgumentEvent += OnSingleArgumentEventListener;
            GameEvents.MultipleArgumentEvent += OnMultipleArgumentEventListener;
            GameEvents.CustomClassArgumentEvent += OnCustomClassArgumentEventListener;
        }
        private void OnDisable()
        {
            //Unregister to event declared on GameEvents and raised/invoked on EventInvoker
            GameEvents.NoArgumentEvent -= OnNoArgumentEventListener;
            GameEvents.SingleArgumentEvent -= OnSingleArgumentEventListener;
            GameEvents.MultipleArgumentEvent -= OnMultipleArgumentEventListener;
            GameEvents.CustomClassArgumentEvent -= OnCustomClassArgumentEventListener;
        }

        //This function will be called as event response
        private void OnNoArgumentEventListener()
        {
            Debug.Log("NoArgument Event Received from class " + this.name + " . Data received: No data");
        }
        
        private void OnSingleArgumentEventListener(int obj)
        {
            Debug.Log("SingleArgument Event Received from class " + this.name + " . Data received: " + obj);
        }
        private void OnMultipleArgumentEventListener(string arg1, int arg2)
        {
            Debug.Log("MultipleArgument Event Received from class " + this.name + " . Data received: " + arg1  + ", " + arg2);
        }
        private void OnCustomClassArgumentEventListener(CustomArgumentDataClass obj)
        {
            Debug.Log("CustomClassArgument Event Received from class " + this.name + " . Data received: " + obj );
        }

    }
}
