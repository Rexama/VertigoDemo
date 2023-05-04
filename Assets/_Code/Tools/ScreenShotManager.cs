using UnityEngine;

namespace Tools
{
    public class ScreenShotManager : MonoBehaviour
    {

        private int screenShotIndex = 1;
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                ScreenCapture.CaptureScreenshot("Screenshot"+screenShotIndex+".png");
                screenShotIndex++;
            }
        }
    
        public void TakeScreenshot()
        {
            ScreenCapture.CaptureScreenshot("TestImage.png");
        }
    }
}