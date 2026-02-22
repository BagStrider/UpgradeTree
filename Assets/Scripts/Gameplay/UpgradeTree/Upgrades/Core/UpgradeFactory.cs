using UnityEngine;

namespace Gameplay.UpgradeTree.Upgrades.Core
{
    public class UpgradeFactory : MonoBehaviour
    {
        public IUpgrade Create(UpgradeData data)
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