using System;
using System.Collections.Generic;

namespace UpgradeTree.Node.Configs
{
    [Serializable]
    public class UpgradeNodeData
    {
        public UpgradeNodeViewConfig viewConfig;
        public Dictionary<UpgradeType, UpgradeConfig> upgrades = new ();
        public List<UpgradeNodeData> upgradesNodeData = new ();
    }
}