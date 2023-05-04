using UnityEngine;

namespace Tools
{
    public class ScreenShotManager : MonoBehaviour
    {

        private int _screenShotIndex = 1;
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                ScreenCapture.CaptureScreenshot("Screenshot"+_screenShotIndex+".png");
                _screenShotIndex++;
            }
        }
    
        public void TakeScreenshot()
        {
            ScreenCapture.CaptureScreenshot("TestImage.png");
        }
    }
}