using UpgradeTree.Node.Configs;

namespace UpgradeTree
{
    public interface IUpgrade
    {
        public UpgradeData Data { get; }
        
        public void Upgrade();
    }
}