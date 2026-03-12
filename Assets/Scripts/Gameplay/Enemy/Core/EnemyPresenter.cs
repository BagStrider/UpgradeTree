using System;
using Core.Base;

namespace Gameplay.Enemy.Core
{
    public class EnemyPresenter : IDisposable
    {
        private EnemyModel _model;
        private EnemyView _view;
        private Health _health;

        public EnemyPresenter(EnemyModel model, Health health, EnemyView view)
        {
            _model = model;
            _view = view;
            _health = health;
        }

        public void Initialize()
        {
            _health.OnDeath += OnDeathHandle;
        }
        
        private void OnDeathHandle()
        {
            //_view.PlayDeathAnimation();
        }

        public void Dispose()
        {
            _health.OnDeath -= OnDeathHandle;
        }
    }
}