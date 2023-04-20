using _Code.Data;
using _Code.Tools;
using UnityEngine;

namespace _Code.Wheel
{
    public class WheelImageManager : MonoBehaviour
    {
        private SpriteLoader _baseSpriteLoader;
        private SpriteLoader _indicatorSpriteLoader;

        private WheelType _currentWheelType = WheelType.Bronze;

        private void OnValidate()
        {
            TryCacheComponents();
        }

        private void Awake()
        {
            TryCacheComponents();
        }

        private void TryCacheComponents()
        {
            if (_baseSpriteLoader != null) return;

            _baseSpriteLoader = transform.GetChild(0).GetComponent<SpriteLoader>();
            _indicatorSpriteLoader = transform.GetChild(1).GetComponent<SpriteLoader>();
        }

        public void TryUpdateWheelType(WheelType wheelType)
        {
            if (wheelType == _currentWheelType) return;

            if (wheelType == WheelType.Bronze)
            {
                _baseSpriteLoader.UpdateSprite("UI_spin_bronze_base");
                _indicatorSpriteLoader.UpdateSprite("UI_spin_bronze_indicator");
            }
            else if (wheelType == WheelType.Silver)
            {
                _baseSpriteLoader.UpdateSprite("UI_spin_silver_base");
                _indicatorSpriteLoader.UpdateSprite("UI_spin_silver_indicator");
            }
            else if (wheelType == WheelType.Golden)
            {
                _baseSpriteLoader.UpdateSprite("UI_spin_golden_base");
                _indicatorSpriteLoader.UpdateSprite("UI_spin_golden_indicator");
            }

            _currentWheelType = wheelType;
        }
    }
}