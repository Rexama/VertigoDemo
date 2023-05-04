using UnityEngine;

namespace Wheel
{
    [CreateAssetMenu(fileName = "WheelData", menuName = "Data/WheelType", order = 0)]
    public class WheelType : ScriptableObject
    {
        [Header("Sprites")]
        public Sprite baseWheelSprite;
        public Sprite indicatorSprite;
        
        [Header("Reward Counts")]
        public int minRewardCount;
        public int maxRewardCount;
        
        [Header("Counter Number Color")]
        public Color counterNumberColor;

        [Header("Is Safe Zone")]
        public bool isSafeZone;

        public int GetRandomRewardCount()
        {
            return Random.Range(minRewardCount, maxRewardCount + 1);
        }
    }
}