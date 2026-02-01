using Money;
using UnityEngine;
using Zenject;

namespace UpgradeTree.Node
{
    public class UpgradeNodeFactory : MonoBehaviour
    {
        [Inject] private PlayerMoney _playerMoney;
        
        public UpgradeNode Create()
        {
            return new UpgradeNode(_playerMoney);
        }
    }
}