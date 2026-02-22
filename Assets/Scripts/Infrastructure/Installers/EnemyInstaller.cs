using Gameplay.Enemy;
using Gameplay.Enemy.Configs;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private EnemyConfig _config;
        [SerializeField] private Transform _enemySpawnParent;
        [SerializeField] private Transform _healthUIParent;
        
        public override void InstallBindings()
        {
            Container.Bind<EnemyConfig>().FromInstance(_config).AsSingle();
            Container.Bind<EnemyFactory>().AsSingle().WithArguments(_enemySpawnParent, _healthUIParent).NonLazy();
        }
    }
}