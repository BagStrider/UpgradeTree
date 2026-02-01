using UnityEngine;
using UpgradeTree.Node.Configs;

namespace UpgradeTree.Upgrades
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