using Entities.Enemy;
using Zenject;

namespace Initialize
{
    public class GameplayBootstrap : IInitializable
    {
        [Inject] private EnemyFactory _factory;
        [Inject] private EnemyConfig _config;
        
        public void Initialize()
        {
            InitEnemy();
        }

        private void InitEnemy()
        {
            EnemyModel enemy = _factory.Create(_config);
        }
    }
}