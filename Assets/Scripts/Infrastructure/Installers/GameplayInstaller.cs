using Gameplay.Combat;
using Gameplay.Player;
using Gameplay.Player.Configs;
using Infrastructure.Bootstraps;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStatsConfig _playerStatsConfig;
        [SerializeField] private EntityDetector _entityDetector;
        [SerializeField] private PlayerMovement _playerMovement;
        
        private PlayerStats _playerStats;
        
        public override void InstallBindings()
        {
            BindPlayerModules();
            Container.BindInterfacesAndSelfTo<GameBootstrap>().AsSingle().NonLazy();
        }

        private void BindPlayerModules()
        {
            _playerStats = new PlayerStats(_playerStatsConfig);
            Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
            Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle();
            Container.Bind<EntityDetector>().FromInstance(_entityDetector).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerCombat>().AsSingle().NonLazy();
        }
    }
}