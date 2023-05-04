using UnityEngine;

namespace Wheel
{
    [CreateAssetMenu(fileName = "WheelSettings", menuName = "Data/WheelSettings", order = 0)]
    public class WheelSettings : ScriptableObject
    {
        [Header("Wheels")]
        public WheelType bronzeWheel;
        public WheelType silverWheel;
        public WheelType goldWheel;
        
        [Header("Special Spin Numbers")]
        public int silverSpinNumber;
        public int goldSpinNumber;
        
        [Header("Wheel Spin Settings")]
        public int itemCount = 8;
        public int minCycleCount = 2;
        public int maxCycleCount = 3;
        public float spinDuration = 4;
        public float delayAfterSpin = 0.3f;
        public int wheelDegree = 360;
        
        
        public WheelType GetWheelTypeWithSpinCount(int spinNumber)
        {
            if (spinNumber % goldSpinNumber == 0)
            {
                return goldWheel;
            }
            else if (spinNumber % silverSpinNumber == 0)
            {
                return silverWheel;
            }
            else
            {
                return bronzeWheel;
            }
        }
    }
}