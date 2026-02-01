using UpgradeTree.Node.Configs;

namespace UpgradeTree.Upgrades
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