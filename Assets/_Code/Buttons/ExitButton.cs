using System;
using _Code.Data;
using _Code.Wheel;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class ExitButton : MonoBehaviour
    {
        
        public static event Action OnExitButtonPressedEvent;
        
        private Button _exitButton;
        private int _spinCount = 1;

        private void OnValidate()
        {
            TryCacheComponents();
            AddListeners();
        }

        private void Awake()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent += OnWheelStopped;
            ReviveButton.OnReviveButtonPressedEvent += OnRestartButton;
            
            TryCacheComponents();
            AddListeners();
        }

        private void OnDisable()
        {
            WheelSpinManager.OnWheelSpinCompleteEvent -= OnWheelStopped;
            ReviveButton.OnReviveButtonPressedEvent -= OnRestartButton;
        }

        private void TryCacheComponents()
        {
            if (_exitButton != null) return;
            _exitButton = GetComponent<Button>();
        }

        private void AddListeners()
        {
            _exitButton.onClick.RemoveAllListeners();
            _exitButton.onClick.AddListener(OnExitButtonPressed);
        }
        
        private void OnWheelStopped(ItemData itemData)
        {
            _spinCount++;
            
            if(itemData.ItemType != ItemType.C4)
              _exitButton.interactable = _spinCount % 5 == 0;
            
        }
        
        private void OnExitButtonPressed()
        {
            OnExitButtonPressedEvent?.Invoke();
        }
        
        private void OnRestartButton()
        {
            _exitButton.interactable = _spinCount % 5 == 0;
        }

    }
}