using System;
using Zenject;

namespace Gameplay.Money.Core
{
    public class MoneyPresenter : IInitializable, IDisposable
    {
        private MoneyModel _model;
        private MoneyView _view;

        public MoneyPresenter(MoneyModel model, MoneyView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _model.OnMoneyChanged += OnMoneyChangedHandle;
        }

        private void OnMoneyChangedHandle(float value)
        {
            _view.SetMoney(value);
        }

        public void Dispose()
        {
            _model.OnMoneyChanged -= OnMoneyChangedHandle;
        }
    }
}