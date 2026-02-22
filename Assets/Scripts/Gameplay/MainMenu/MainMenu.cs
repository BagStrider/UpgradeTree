using Core.Base;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        [Inject] private SceneLoader _sceneLoader;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnStartClickedHandle);
            _exitButton.onClick.AddListener(OnExitClickedHandle);
        }

        private void OnStartClickedHandle() => _sceneLoader.LoadScene("Shop");
        private void OnExitClickedHandle()
        {
            _sceneLoader.ExitGame();
        }
    
        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnStartClickedHandle);
            _exitButton.onClick.RemoveListener(OnExitClickedHandle);
        }
    }
}
