using System;
using Core.Base;

namespace Gameplay.Enemy.Core
{
    public class EnemyPresenter : IDisposable
    {
        private EnemyModel _model;
        private EnemyView _view;
        private EntityProvider _entityProvider;

        public EnemyPresenter(EnemyModel model, EnemyView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _view.HealthView.Set(_model.Health.Value, _model.Health.MaxValue);
            _view.HealthView.SetText(_model.Health.Value.ToString());
            
            _model.Health.OnValueChanged += OnHealthChangedHandle;
            _model.Health.OnDeath += OnDeathHandle;

            _entityProvider = _view.GetComponent<EntityProvider>();
            _entityProvider.Initialize(_model);
        }

        private void OnHealthChangedHandle(float value)
        {
            _view.HealthView.Set(value, _model.Health.MaxValue);
            _view.HealthView.SetText(_model.Health.Value.ToString());
            //_view.PlayHitAnimation();
        }
        private void OnDeathHandle()
        {
            //_view.PlayDeathAnimation();
        }

        public void Dispose()
        {
            _model.Health.OnValueChanged -= OnHealthChangedHandle;
            _model.Health.OnDeath -= OnDeathHandle;
        }
    }
}