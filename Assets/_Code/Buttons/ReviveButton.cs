using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class ReviveButton : MonoBehaviour
    {
        
        private Button _reviveButton;
        public static event Action OnReviveButtonPressedEvent;

        private void OnValidate()
        {
            TryCacheComponents();
            AddListeners();
        }
        private void Awake()
        {
            TryCacheComponents();
            AddListeners();
        }

        private void TryCacheComponents()
        {
            if (_reviveButton != null) return;
            _reviveButton = GetComponent<Button>();
        }

        private void AddListeners()
        {
            _reviveButton.onClick.RemoveAllListeners();
            _reviveButton.onClick.AddListener(OnReviveButtonPressed);
        }
        
        private void OnReviveButtonPressed()
        {
            OnReviveButtonPressedEvent?.Invoke();
        }
    }
}