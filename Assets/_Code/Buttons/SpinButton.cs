using Tools;

namespace Buttons
{
    public class SpinButton : ButtonObject
    {
        protected override void SubscribeEvents()
        {
            EventBus.Subscribe("OnItemSelected", OnWheelStopped);
            EventBus.Subscribe("OnReviveButtonPressed", ActivateButton);
        }

        protected override void UnsubscribeEvents()
        {
            EventBus.Unsubscribe("OnItemSelected", OnWheelStopped);
            EventBus.Unsubscribe("OnReviveButtonPressed", ActivateButton);
        }

        protected override void OnButtonPressed()
        {
            EventBus.Trigger("OnSpinButtonPressed");
            Button.interactable = false;
        }

        private void OnWheelStopped()
        {
            Button.interactable = true;
        }

        private void ActivateButton()
        {
            Button.interactable = true;
        }
    }
}