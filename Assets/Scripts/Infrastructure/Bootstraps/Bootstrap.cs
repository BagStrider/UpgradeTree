using Core.Base;
using UnityEngine;
using Zenject;

namespace Infrastructure.Bootstraps
{
    public class Bootstrap : MonoBehaviour
    {
        [Inject] private SceneLoader _sceneLoader;
        
        public void Awake()
        {
            _sceneLoader.LoadScene("Game");
        }
    }
}