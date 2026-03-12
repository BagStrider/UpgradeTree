using System;
using Core.Base;
using Core.Interfaces;
using Gameplay.Enemy.Configs;
using Gameplay.Enemy.Core;
using Plugins.BHealthBar.Scripts;
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
            Health health = new Health(config.MaxHealth, config.MaxHealth);
            DefaultHealthBar healthView = _container.InstantiatePrefabForComponent<DefaultHealthBar>(config.HealthViewPrefab, _healthUIParent);
            HealthPresenter healthPresenter = new HealthPresenter(health, healthView);
            
            EnemyModel model = new EnemyModel(health);
            EnemyView view = _container.InstantiatePrefabForComponent<EnemyView>(config.ViewPrefab, _enemySpawnParent);
            EnemyPresenter enemyPresenter = new EnemyPresenter(model, health, view);
            view.gameObject.transform.position = position;
            
            if (view.TryGetComponent<IEntityProvider>(out var  entityProvider))
            {
                entityProvider.Initialize(model);
            }
            
            if (healthView.TryGetComponent<UIObjectFollower>(out var follower))
            {
                follower.SetTarget(view.transform);
            }
            
            healthPresenter.Initialize();
            enemyPresenter.Initialize();
            
            return model;
        }
    }
}