using Tools;

namespace Buttons
{
    public class ReviveButton : ButtonObject
    {
        protected override void OnButtonPressed()
        {
            EventBus.Trigger("OnReviveButtonPressed");
        }
    }
}