using Tools;
using UnityEngine;
using Wheel;

namespace Buttons
{
    public class ExitButton : ButtonObject
    {
        [SerializeField] private WheelSettings wheelSettings;
        
        private int _spinCount = 1;

        protected override void OnButtonPressed()
        {
            EventBus.Trigger("OnExitButtonPressed");
        }

        protected override void SubscribeEvents()
        {
            EventBus.Subscribe("OnItemSelected", OnWheelStopped);
            EventBus.Subscribe("OnReviveButtonPressed", OnReviveButton);
        }

        protected override void UnsubscribeEvents()
        {
            EventBus.Unsubscribe("OnItemSelected", OnWheelStopped);
            EventBus.Unsubscribe("OnReviveButtonPressed", OnReviveButton);
        }

        private void OnWheelStopped()
        {
            _spinCount++;
            Button.interactable = _spinCount % wheelSettings.silverSpinNumber == 0;
        }

        private void OnReviveButton()
        {
            Button.interactable = _spinCount % wheelSettings.silverSpinNumber == 0;
        }
    }
}