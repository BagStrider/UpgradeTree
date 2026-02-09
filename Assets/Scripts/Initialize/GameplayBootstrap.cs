using Enemy;
using Entities.Enemy;
using Player;
using Zenject;

namespace Initialize
{
    public class GameplayBootstrap : IInitializable
    {
        [Inject] private EnemyConfig _enemyConfig;
        [Inject] private EnemyView _view;
        [Inject] private PlayerStats _playerStats;
        
        public void Initialize()
        {
            InitEnemy();
        }

        private void InitEnemy()
        {
            EnemyModel enemyModel = new EnemyModel(_enemyConfig);
            EnemyPresenter enemyPresenter = new EnemyPresenter(enemyModel, _view, _playerStats);
            enemyPresenter.Initialize();
        }
    }
}