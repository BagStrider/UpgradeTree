using Gameplay.Money.Core;
using Zenject;

namespace Infrastructure.Installers
{
    public class PlayerMoneyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyModel>().AsSingle();
        }
    }
}