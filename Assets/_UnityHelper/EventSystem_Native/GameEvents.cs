using System;
using UnityEngine;

namespace RakibUtils
{
    public static class GameEvents
    {
        //Declare Event with no argument like this
        public static event Action NoArgumentEvent;
        //Declaration done. This can be used to register events from outside this class. But we can't yet Invoke this from
        //outside of this class as it is a delegate. So we will need a static function which will invoke this event. And we 
        //can call this function from another class to invoke this event.
        //This static function is used as an invocator. Used to Invoke this event from anywhere outside this static class.
        public static void OnNoArgumentEvent() 
        {
            NoArgumentEvent?.Invoke();
        }

        #region Events with parameters
        //Declare Event with single argument like this
        public static event Action<int> SingleArgumentEvent;
        public static void OnSingleArgumentEvent(int obj)
        {
            SingleArgumentEvent?.Invoke(obj);
        }

        //Declare Event with multiple arguments like this
        public static event Action<string, int> MultipleArgumentEvent;
        public static void OnMultipleArgumentEvent(string arg1, int arg2)
        {
            MultipleArgumentEvent?.Invoke(arg1, arg2);
        }

        //Declare Event with custom class argument like this
        public static event Action<CustomArgumentDataClass> CustomClassArgumentEvent;
        public static void OnCustomClassArgumentEvent(CustomArgumentDataClass obj)
        {
            CustomClassArgumentEvent?.Invoke(obj);
        }
        #endregion
        
    }

    //Declaring a class to be used as data carrier
    public class CustomArgumentDataClass
    {
        public int arg1;
        public int arg2;
        public float arg3;

        public CustomArgumentDataClass(int arg1, int arg2, float arg3)
        {
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
        }

        public override string ToString()
        {
            return arg1 + ", " + arg2 + ", " + arg3;
        }
    }
}
