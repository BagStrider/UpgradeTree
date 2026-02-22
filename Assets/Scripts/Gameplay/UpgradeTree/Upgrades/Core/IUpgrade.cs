namespace Gameplay.UpgradeTree.Upgrades.Core
{
    public interface IUpgrade
    {
        public UpgradeData Data { get; }
        
        public void Upgrade();
    }
}