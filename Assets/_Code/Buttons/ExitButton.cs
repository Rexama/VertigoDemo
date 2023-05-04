using Tools;

namespace Buttons
{
    public class ExitButton : ButtonObject
    {
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
            Button.interactable = _spinCount % 5 == 0;
        }

        private void OnReviveButton()
        {
            Button.interactable = _spinCount % 5 == 0;
        }
    }
}