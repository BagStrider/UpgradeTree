using System;
using UnityEngine;
using UpgradeTree.Upgrades;

namespace UpgradeTree.Node.Configs
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