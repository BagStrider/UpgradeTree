using Gameplay.Money.Configs;
using Gameplay.Money.Core;
using Infrastructure.Bootstraps;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class ShopInstaller : MonoInstaller
    {
        [SerializeField] private MoneyConfig _moneyConfig;
        [SerializeField] private MoneyView _moneyView;
        
        public override void InstallBindings()
        {
            Container.Bind<MoneyConfig>().FromInstance(_moneyConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<MoneyPresenter>().AsSingle().WithArguments(_moneyView);
            
            Container.BindInterfacesAndSelfTo<ShopBootstrap>().AsSingle().NonLazy();
        }
    }
}