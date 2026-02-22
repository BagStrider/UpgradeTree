using System;
using System.Collections.Generic;
using Core.Base;
using Core.Interfaces;
using Gameplay.Money.Core;
using Gameplay.UpgradeTree.Upgrades.Core;

namespace Gameplay.UpgradeTree.Node.Core
{
    public class UpgradeNode : ILockable
    {
        public event Action OnFirstUpgrade;
        public event Action OnUpgrade;
        public event Action OnMaxUpgrade;
        public event Action<LockState> OnLockChanged;
        
        public int CurrentUpgradePosition => _upgradeIndex;
        public int Count => _upgrades.Count;
        public float CurrentUpgradeCost => _currentUpgrade.Data.Cost;
        
        private List<IUpgrade> _upgrades = new();
        private IUpgrade _currentUpgrade;
        private MoneyModel _moneyModel;
        
        private int _upgradeIndex = 0;

        public UpgradeNode(MoneyModel moneyModel)
        {
            _moneyModel = moneyModel;
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

            if (!_moneyModel.TryToSpend(_currentUpgrade.Data.Cost))
            {
                return;
            }
            
            _currentUpgrade?.Upgrade();

            if (_upgradeIndex == 0)
            {
                OnFirstUpgrade?.Invoke();
            }
            
            
            _upgradeIndex++;
                        
            if (_upgradeIndex < _upgrades.Count)
                _currentUpgrade = _upgrades[_upgradeIndex];
            
            OnUpgrade?.Invoke();
            
            if (_upgradeIndex >= _upgrades.Count)
            {
                OnMaxUpgrade?.Invoke();
            }
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