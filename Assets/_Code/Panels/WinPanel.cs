using Tools;
using UnityEngine;

namespace Panels
{
    public class WinPanel : MonoBehaviour
    {
        [SerializeField] private Transform winPanel;

        private void Awake()
        {
            EventBus.Subscribe("OnExitButtonPressed", ActivatePanel);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnExitButtonPressed", ActivatePanel);
        }

        private void ActivatePanel()
        {
            winPanel.gameObject.SetActive(true);
        }
    }
}