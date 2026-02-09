using Enemy;
using Entities.Enemy;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private EnemyView _view;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyConfig>().FromInstance(_config).AsSingle();
            Container.Bind<EnemyView>().FromInstance(_view).AsSingle();
        }
    }
}