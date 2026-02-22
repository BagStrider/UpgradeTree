using Gameplay.UpgradeTree.Upgrades.Core;

namespace Gameplay.UpgradeTree.Upgrades
{
    public class DamageUpgrade: IUpgrade
    {
        public UpgradeData Data => _data;

        private UpgradeData _data;

        public DamageUpgrade(UpgradeData data)
        {
            _data = data;
        }
        
        public void Upgrade()
        {
            
        }
    }
}