using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Base
{
    public class SceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}
