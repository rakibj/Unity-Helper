using System;
using UnityEngine;

namespace RakibUtils
{
    public class EventInvoker : MonoBehaviour
    {
        //Events declared in GameEvents will be invoked here
        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 300, 50), "Raise No argument Event"))
                GameEvents.OnNoArgumentEvent();

            if (GUI.Button(new Rect(10, 70, 300, 30), "Raise 1 argument Event"))
                GameEvents.OnSingleArgumentEvent(1);
            
            if (GUI.Button(new Rect(10, 130, 300, 30), "Raise 2 argument Event"))
                GameEvents.OnMultipleArgumentEvent("multiple", 2);

            if (GUI.Button(new Rect(10, 190, 300, 30), "Raise custom class argument Event"))
                GameEvents.OnCustomClassArgumentEvent(new CustomArgumentDataClass(1,2,2.2f));
        }
    }
}
