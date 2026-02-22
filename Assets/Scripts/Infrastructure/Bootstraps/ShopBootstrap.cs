using Gameplay.Money.Configs;
using Gameplay.Money.Core;
using Zenject;

namespace Infrastructure.Bootstraps
{
    public class ShopBootstrap : IInitializable
    {
        [Inject] private MoneyModel _moneyModel;
        [Inject] private MoneyConfig _moneyConfig;
        
        public void Initialize()
        {
            _moneyModel.Set(_moneyConfig.CurrentMoney);
        }
    }
}