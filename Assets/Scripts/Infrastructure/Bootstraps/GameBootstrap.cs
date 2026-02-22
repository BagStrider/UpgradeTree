using Gameplay.Enemy;
using Gameplay.Enemy.Configs;
using Gameplay.Enemy.Core;
using UnityEngine;
using Zenject;

namespace Infrastructure.Bootstraps
{
    public class GameBootstrap : IInitializable
    {
        [Inject] private EnemyFactory _factory;
        [Inject] private EnemyConfig _config;
        
        public void Initialize()
        {
            InitEnemy();
        }

        private void InitEnemy()
        {
            EnemyModel enemy = _factory.Create(_config, new Vector3(3, 0,0));
        }
    }
}