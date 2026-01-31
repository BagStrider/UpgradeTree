using Money;
using Zenject;

namespace Installers
{
    public class PlayerMoneyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerMoney>().AsSingle();
        }
    }
}