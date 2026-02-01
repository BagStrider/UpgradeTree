using System.Collections.Generic;
using UnityEngine;

namespace UpgradeTree.Node.Configs
{
    [CreateAssetMenu(fileName = nameof(UpgradeNodesConfig), menuName = "Configs/" + nameof(UpgradeNodesConfig))]
    public class UpgradeNodesConfig : ScriptableObject
    {
        public Sprite Icon => _icon;
        public List<UpgradeData> Upgrades => _upgrades;
        
        [SerializeField] private Sprite _icon;
        [SerializeField] private List<UpgradeData> _upgrades = new ();
    }
}