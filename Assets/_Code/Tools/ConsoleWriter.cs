using UnityEngine;

namespace Tools
{
    public class ConsoleWriter : MonoBehaviour
    {
        //#if !UNITY_EDITOR
        static string myLog = "";
        private string output;
        private string stack;
        private const int CharLimit = 5000;
        void OnEnable()
        {
            Application.logMessageReceived += Log;
        }

        void OnDisable()
        {
            Application.logMessageReceived -= Log;
        }

        public void Log(string logString, string stackTrace, LogType type)
        {
            output = logString;
            stack = stackTrace;
            //myLog = output + "\n" + myLog;
            myLog = stackTrace + output + "\n" + myLog;
            if (myLog.Length > CharLimit)
            {
                myLog = myLog.Substring(0, CharLimit);
            }
        }

        void OnGUI()
        {
            //if (!Application.isEditor) //Do not display in editor ( or you can use the UNITY_EDITOR macro to also disable the rest)
            {
                myLog = GUI.TextArea(new Rect(10, 10, Screen.width - 10, Screen.height - 10), myLog);
            }
        }
        //#endif
    }
}