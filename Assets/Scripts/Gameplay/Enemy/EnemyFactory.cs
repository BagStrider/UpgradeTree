using BagHealthBar.Scripts;
using Gameplay.Enemy.Configs;
using Gameplay.Enemy.Core;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemy
{
    public class EnemyFactory
    {
        private DiContainer _container;
        private Transform _enemySpawnParent;
        private Transform _healthUIParent;
        
        public EnemyFactory(DiContainer container, Transform enemySpawnParent,  Transform healthUIParent)
        {
            _container = container;
            _enemySpawnParent = enemySpawnParent;
            _healthUIParent = healthUIParent;
        }
        
        public EnemyModel Create(EnemyConfig config, Vector3 position = default)
        {
            EnemyModel model = new EnemyModel(config);
            
            EnemyView view = _container.InstantiatePrefabForComponent<EnemyView>(config.ViewPrefab, _enemySpawnParent);
            HealthBarUI healthView = _container.InstantiatePrefabForComponent<HealthBarUI>(config.HealthViewPrefab, _healthUIParent);
            view.gameObject.transform.position = position;
            view.Initialize(healthView, _healthUIParent);

            EnemyPresenter presenter = new EnemyPresenter(model, view);
            presenter.Initialize();
            
            return model;
        }
    }
}