using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Gameloops
{
    public class BuildVersionProcessor : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            var buildNumberStringIos = PlayerSettings.iOS.buildNumber;
            buildNumberStringIos = ProcessInputString(buildNumberStringIos);

            var buildNumberStringAndroid = PlayerSettings.Android.bundleVersionCode.ToString();
            var buildNumber = GetHigherValueString(buildNumberStringIos, buildNumberStringAndroid);

            PlayerSettings.iOS.buildNumber = buildNumber;
            PlayerSettings.Android.bundleVersionCode = int.Parse(buildNumber);
            
            
            
            Debug.Log("Processed Build Number: " + buildNumber);
        }


        string ProcessInputString(string input)
        {
            // Get the current date and time
            DateTime currentDate = DateTime.Now;

            // Format the date as YYMMDD
            string formattedDate = currentDate.ToString("yyMMdd");

            // Try to parse the input string as an integer
            if (int.TryParse(input, out int intValue))
            {
                // Extract the date part as an integer
                int inputDate = intValue / 100;

                // Check if the extracted date is the same as today's date
                if (inputDate == int.Parse(formattedDate))
                {
                    // If yes, increment the two-digit number and return the result as a string
                    int incrementedValue = (intValue % 100) + 1;
                    return (inputDate * 100 + incrementedValue).ToString();
                }
            }

            // If the conversion is not successful or the date doesn't match, return today's formatted date appended with 01 as a string
            return formattedDate + "01";
        }
        
        string GetHigherValueString(string str1, string str2)
        {
            int value1, value2;

            // Using int.TryParse to handle possible conversion failures
            if (int.TryParse(str1, out value1) && int.TryParse(str2, out value2))
            {
                // Compare the integer values
                if (value1 >= value2)
                {
                    return str1;
                }
                else if (value2 > value1)
                {
                    return str2;
                }
            }
            return "One or both of the input strings are not valid integers.";
        }
    }
}
