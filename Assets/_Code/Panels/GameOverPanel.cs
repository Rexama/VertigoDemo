using _Code.Buttons;
using _Code.Data;
using _Code.Wheel;
using UnityEngine;

namespace _Code.Panels
{
    public class GameOverPanel : MonoBehaviour
    {
        private Transform _panel;

        private void Awake()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent += OnWheelSpinComplete;
            ReviveButton.OnReviveButtonPressedEvent += OnReviveButtonPressed;

            _panel = transform.GetChild(0);
        }

        private void OnDisable()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent -= OnWheelSpinComplete;
            ReviveButton.OnReviveButtonPressedEvent -= OnReviveButtonPressed;
        }

        private void OnWheelSpinComplete(ItemData itemData)
        {
            if (itemData.ItemType == ItemType.C4)
            {
                _panel.gameObject.SetActive(true);
            }
        }

        private void OnReviveButtonPressed()
        {
            _panel.gameObject.SetActive(false);
        }
    }
}