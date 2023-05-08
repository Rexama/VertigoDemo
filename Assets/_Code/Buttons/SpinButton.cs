using Tools;

namespace Buttons
{
    public class SpinButton : ButtonObject
    {
        protected override void SubscribeEvents()
        {
            EventBus.Subscribe("OnItemSelected", ActivateButton);
            EventBus.Subscribe("OnReviveButtonPressed", ActivateButton);
        }

        protected override void UnsubscribeEvents()
        {
            EventBus.Unsubscribe("OnItemSelected", ActivateButton);
            EventBus.Unsubscribe("OnReviveButtonPressed", ActivateButton);
        }

        protected override void OnButtonPressed()
        {
            EventBus.Trigger("OnSpinButtonPressed");
            Button.interactable = false;
        }
        
        private void ActivateButton()
        {
            Button.interactable = true;
        }
    }
}