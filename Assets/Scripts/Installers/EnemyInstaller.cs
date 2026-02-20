using Entities.Enemy;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private Transform _enemySpawnTransform;
        [SerializeField] private Transform _healthUIParent;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyConfig>().FromInstance(_config).AsSingle();
            Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemySpawnTransform, _healthUIParent).NonLazy();
        }
    }
}