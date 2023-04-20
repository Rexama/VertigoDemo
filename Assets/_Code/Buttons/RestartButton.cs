using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Code.Buttons
{
    public class RestartButton : MonoBehaviour
    {
        private Button _restartButton;
        private void OnValidate()
        {
            TryCacheComponents();
            AddListeners();
        }
        
        private void Awake()
        {
            TryCacheComponents();
            AddListeners();
        }

        private void TryCacheComponents()
        {
            if (_restartButton != null) return;
            _restartButton = GetComponent<Button>();
        }

        private void AddListeners()
        {
            _restartButton.onClick.RemoveAllListeners();
            _restartButton.onClick.AddListener(OnRestartButtonPressed);
        }
        
        private void OnRestartButtonPressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}