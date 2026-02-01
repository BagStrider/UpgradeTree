using UnityEngine;
using UpgradeTree.Node;
using UpgradeTree.Node.Configs;
using UpgradeTree.Upgrades;

namespace UpgradeTree
{
    public class UpgradeFactory : MonoBehaviour
    {
        public IUpgrade CreateUpgrade(UpgradeData data)
        {
            if (data.Type == UpgradeType.Damage)
                return CreateDamageUpgrade(data);
            
            return null;
        }

        private IUpgrade CreateDamageUpgrade(UpgradeData data)
        {
            return new DamageUpgrade(data);
        }
    }
}