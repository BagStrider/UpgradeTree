using System;
using System.Collections.Generic;
using Abstractions.Lockable;
using Money;

namespace UpgradeTree.Node
{
    public class UpgradeNode : ILockable
    {
        public event Action OnFirstUpgrade;
        public event Action OnUpgrade;
        public event Action OnUpgradeComplete;
        public event Action<LockState> OnLockChanged;
        
        public int CurrentUpgradePosition => _upgradeIndex;
        public int Count => _upgrades.Count;
        
        private List<IUpgrade> _upgrades = new();
        private IUpgrade _currentUpgrade;
        private PlayerMoney _playerMoney;
        
        private int _upgradeIndex = 0;

        public UpgradeNode(PlayerMoney playerMoney)
        {
            _playerMoney = playerMoney;
        }

        public void Initialize()
        {
            _currentUpgrade = _upgrades[0];
        }
        
        public void AddUpgrade(IUpgrade upgrade)
        {
            _upgrades.Add(upgrade);
        }

        public void TryToUpgrade()
        {
            if(_currentUpgrade == null) return;
            
            if (!_playerMoney.TryToSpend(_currentUpgrade.Data.Cost)) return;
            
            _currentUpgrade?.Upgrade();
            
            if(_upgradeIndex == 0)
                OnFirstUpgrade?.Invoke();
            
            _upgradeIndex++;
            OnUpgrade?.Invoke();
            
            if (_upgradeIndex >= _upgrades.Count)
            {
                OnUpgradeComplete?.Invoke();
                return;
            }
            
            _currentUpgrade = _upgrades[_upgradeIndex];
        }

        public void Unlock()
        {
            OnLockChanged?.Invoke(LockState.Unlocked);
        }
        public void Lock()
        {
            OnLockChanged?.Invoke(LockState.Locked);
        }
    }
}