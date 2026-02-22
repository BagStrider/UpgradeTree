using Gameplay.Money.Core;
using UnityEngine;
using Zenject;

namespace Gameplay.UpgradeTree.Node.Core
{
    public class UpgradeNodeFactory : MonoBehaviour
    {
        [Inject] private MoneyModel _moneyModel;
        
        public UpgradeNode Create()
        {
            return new UpgradeNode(_moneyModel);
        }
    }
}