using UnityEngine;
using Zenject;
using Money;

namespace Initialize
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PlayerMoneyView _moneyView;
        [SerializeField] private PlayerMoneyConfig _moneyConfig;
        
        [Inject] private PlayerMoney _playerMoney;

        private PlayerMoneyPresenter _presenter;
        
        private void Awake()
        {
            InitPlayerMoneyView();
            
        }

        private void InitPlayerMoneyView()
        {
            _presenter = new PlayerMoneyPresenter(_playerMoney, _moneyView);
            _presenter.Initialize();
            
            _playerMoney.Set(_moneyConfig.CurrentMoney);
        }
        
        private void OnDestroy()
        {
            _presenter?.Dispose();
        }
    }
}