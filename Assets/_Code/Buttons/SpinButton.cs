using System;
using _Code.Data;
using _Code.Wheel;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class SpinButton : MonoBehaviour
    {
        private Button _spinButton;
        public static event Action OnSpinButtonPressedEvent;

        private void OnValidate()
        {
            TryCacheComponents();
            AddListeners();
        }
        
        private void Awake()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent += OnWheelStopped;
            ReviveButton.OnReviveButtonPressedEvent += OnRevive;
            
            TryCacheComponents();
            AddListeners();
        }

        private void OnDisable()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent -= OnWheelStopped;
            ReviveButton.OnReviveButtonPressedEvent -= OnRevive;
        }

        private void TryCacheComponents()
        {
            if (_spinButton != null) return;
            _spinButton = GetComponent<Button>();
        }

        private void AddListeners()
        {
            _spinButton.onClick.RemoveAllListeners();
            _spinButton.onClick.AddListener(OnSpinButtonPressed);
        }

        private void OnSpinButtonPressed()
        {
            OnSpinButtonPressedEvent?.Invoke();
            _spinButton.interactable = false;
        }

        private void OnWheelStopped(ItemData itemData)
        {
            if (itemData.ItemType == ItemType.C4) return;
            _spinButton.interactable = true;
        }
        
        private void OnRevive()
        {
            _spinButton.interactable = true;
        }
    }
}