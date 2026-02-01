using UpgradeTree.Node.Configs;

namespace UpgradeTree.Upgrades
{
    public interface IUpgrade
    {
        public UpgradeData Data { get; }
        
        public void Upgrade();
    }
}