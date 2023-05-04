using UnityEngine.SceneManagement;

namespace Buttons
{
    public class RestartButton : ButtonObject
    {
        protected override void OnButtonPressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}