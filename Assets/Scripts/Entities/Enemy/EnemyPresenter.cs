using System;
using Player;

namespace Entities.Enemy
{
    public class EnemyPresenter : IDisposable
    {
        private EnemyModel _model;
        private EnemyView _view;
        private PlayerStats _playerStats;

        public EnemyPresenter(EnemyModel model, EnemyView view, PlayerStats playerStats)
        {
            _model = model;
            _view = view;
            _playerStats = playerStats;
        }

        public void Initialize()
        {
            _view.HealthView.Set(_model.Health.Value, _model.Health.MaxValue);
            _view.HealthView.SetText(_model.Health.Value.ToString());
            _model.Health.OnValueChanged += OnHealthChangedHandle;
            _model.Health.OnDeath += OnDeathHandle;
            
            _view.OnClicked += OnViewClickedHandle;
        }

        private void OnViewClickedHandle()
        {
            _model.TakeDamage(_playerStats.Damage * _playerStats.DamageMultiplier);
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
            _view.OnClicked -= OnViewClickedHandle;
        }
    }
}