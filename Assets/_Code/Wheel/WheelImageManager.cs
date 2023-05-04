using Tools;
using UnityEngine;

namespace Wheel
{
    public class WheelImageManager : MonoBehaviour
    {
        [SerializeField] private SpriteLoader baseSpriteLoader;
        [SerializeField] private SpriteLoader indicatorSpriteLoader;
        [SerializeField] private GameObject safeZoneIcon;
        
        private WheelType _currentWheelType;
        
        public void TryUpdateWheelType(WheelType wheelType)
        {
            if (wheelType == _currentWheelType) return;
            
            baseSpriteLoader.TryUpdateSprite(wheelType.baseWheelSprite);
            indicatorSpriteLoader.TryUpdateSprite(wheelType.indicatorSprite);
            _currentWheelType = wheelType;
            safeZoneIcon.SetActive(wheelType.isSafeZone);
        }
    }
}