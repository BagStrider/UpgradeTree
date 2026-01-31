using System;

namespace Money
{
    public class PlayerMoneyPresenter : IDisposable
    {
        private PlayerMoney _model;
        private PlayerMoneyView _view;

        public PlayerMoneyPresenter(PlayerMoney model, PlayerMoneyView view)
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