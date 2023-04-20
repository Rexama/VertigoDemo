using _Code.Buttons;
using UnityEngine;

namespace _Code.Panels
{
    public class WinPanel : MonoBehaviour
    {
        private Transform _panel;

        private void Awake()
        {
            _panel = transform.GetChild(0);
            ExitButton.OnExitButtonPressedEvent += OpenPanel;
        }

        private void OnDestroy()
        {
            ExitButton.OnExitButtonPressedEvent -= OpenPanel;
        }

        private void OpenPanel()
        {
            _panel.gameObject.SetActive(true);
        }
    }
}