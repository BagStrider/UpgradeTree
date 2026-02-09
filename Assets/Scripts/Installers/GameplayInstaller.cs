using Initialize;
using Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerStatsConfig _playerStatsConfig;
        
        private PlayerStats _playerStats;
        
        public override void InstallBindings()
        {
            _playerStats = new PlayerStats(_playerStatsConfig);
            
            Container.Bind<PlayerStats>().FromInstance(_playerStats).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplayBootstrap>().AsSingle().NonLazy();
        }
    }
}