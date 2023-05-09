using UnityEngine;
using UnityEngine.UI;

namespace Buttons
{
    public abstract class ButtonObject : MonoBehaviour
    {
        protected Button Button;
        
        protected void OnValidate()
        {
            Button = GetComponent<Button>();
        }
        
        protected void Awake()
        {
            Button.onClick.AddListener(OnButtonPressed);
            SubscribeEvents();
        }

        protected void OnDestroy()
        {
            Button.onClick.RemoveAllListeners();
            UnsubscribeEvents();
        }

        protected virtual void SubscribeEvents() { }
        
        protected virtual void UnsubscribeEvents() { }

        protected abstract void OnButtonPressed();
        
        
    }
}