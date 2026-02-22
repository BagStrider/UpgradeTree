using System;
using UnityEngine;

namespace Gameplay.UpgradeTree.Upgrades.Core
{
    [Serializable]
    public class UpgradeData
    {
        public UpgradeType Type => _upgradeType;
        public float Cost => _cost;
        
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField, Min(0f)] private float _cost;
    }
}