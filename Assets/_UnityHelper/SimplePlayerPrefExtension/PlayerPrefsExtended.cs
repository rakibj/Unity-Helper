using UnityEngine;

namespace RakibUtils
{
    public class PlayerPrefsExtended: PlayerPrefs
    {
        public static int LoadOrCreateKeyInt(string key, int defaultReturn)
        {
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetInt(key);
            else
            {
                PlayerPrefs.SetInt(key, defaultReturn);
                return defaultReturn;
            }
        }
        public static float LoadOrCreateKeyFloat(string key)
        {
            if (PlayerPrefs.HasKey(key))
                return PlayerPrefs.GetFloat(key);
            else
            {
                PlayerPrefs.SetFloat(key, 0f);
                return 0f;
            }
        }
    }
}
