using Tools;
using UnityEngine;

namespace Panels
{
    public class GameOverPanel : MonoBehaviour
    {
        [SerializeField] private Transform gameOverPanel;

        private void Awake()
        {
            EventBus.Subscribe("OnBombSelected",ActivateGameOverPanel);
            EventBus.Subscribe("OnReviveButtonPressed", DeactivateGameOverPanel);
        }

        private void OnDestroy()
        {
            EventBus.Unsubscribe("OnBombSelected",ActivateGameOverPanel);
            EventBus.Unsubscribe("OnReviveButtonPressed", DeactivateGameOverPanel);
        }

        private void ActivateGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }

        private void DeactivateGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(false);
        }
    }
}