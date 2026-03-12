using Gameplay.Combat;
using Gameplay.Player;
using Gameplay.Player.Configs;
using Gameplay.PlayerSystem;
using Gameplay.PlayerSystem.Core;
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
        [SerializeField] private PlayerProvider _provider;
        
        private Player _player;
        private PlayerStats _playerStats;
        
        public override void InstallBindings()
        {
            BindPlayerModules();
            Container.BindInterfacesAndSelfTo<GameBootstrap>().AsSingle().NonLazy();
        }

        private void BindPlayerModules()
        {
            _player = new Player(_playerStatsConfig);
            _playerStats = new PlayerStats(_playerStatsConfig);
            _provider.Initialize(_player);
            
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
            Container.Bind<PlayerMovement>().FromInstance(_playerMovement).AsSingle();
            Container.Bind<EntityDetector>().FromInstance(_entityDetector).AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerCombat>().AsSingle().NonLazy();
        }
    }
}