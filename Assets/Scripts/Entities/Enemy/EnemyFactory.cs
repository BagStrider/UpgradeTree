using BagHealthBar.Scripts;
using UnityEngine;
using Zenject;

namespace Entities.Enemy
{
    public class EnemyFactory
    {
        private DiContainer _container;
        private Transform _enemySpawnTransform;
        private Transform _healthUITransform;
        
        public EnemyFactory(DiContainer container, Transform enemySpawnTransform,  Transform healthUITransform)
        {
            _container = container;
            _enemySpawnTransform = enemySpawnTransform;
            _healthUITransform = healthUITransform;
        }
        
        public EnemyModel Create(EnemyConfig config, Vector3 position = default)
        {
            EnemyModel model = new EnemyModel(config);
            
            EnemyView view = _container.InstantiatePrefabForComponent<EnemyView>(config.ViewPrefab, _enemySpawnTransform);
            HealthBarUI healthView = _container.InstantiatePrefabForComponent<HealthBarUI>(config.HealthViewPrefab, _healthUITransform);
            view.gameObject.transform.position = position;
            view.Initialize(healthView, _healthUITransform);

            EnemyPresenter presenter = new EnemyPresenter(model, view);
            presenter.Initialize();
            
            return model;
        }
    }
}