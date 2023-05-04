using Buttons;
using Tools;
using UnityEngine;

namespace Panels
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Transform winPanel;

        private void Awake()
        {
            EventBus.Subscribe("OnExitButtonPressed", OpenPanel);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnExitButtonPressed", OpenPanel);
        }

        private void OpenPanel()
        {
            winPanel.gameObject.SetActive(true);
        }
    }
}