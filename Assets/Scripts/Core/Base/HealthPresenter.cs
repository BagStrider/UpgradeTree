using System;
using Plugins.BHealthBar.Scripts;
using Zenject;

namespace Core.Base
{
    public class HealthPresenter : IInitializable, IDisposable
    {
        private Health _model;
        private DefaultHealthBar _view;

        public HealthPresenter(Health model, DefaultHealthBar view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _model.OnValueChanged += OnHealthChangedHandle;
        }

        private void OnHealthChangedHandle(float value)
        {
            _view.SetValue(value, _model.MaxValue);
        }

        public void Dispose()
        {
            _model.OnValueChanged -= OnHealthChangedHandle;
        }
    }
}