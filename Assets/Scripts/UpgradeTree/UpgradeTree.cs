using System.Collections.Generic;
using UnityEngine;
using UpgradeTree.Node;
using UpgradeTree.Node.Configs;

namespace UpgradeTree
{
    public class UpgradeTree : MonoBehaviour
    {
        [SerializeField] private List<UpgradeNodeContainer> _nodesContainers = new();
        [SerializeField] private UpgradeFactory _upgradeFactory;
        [SerializeField] private UpgradeNodeFactory _nodeFactory;
        
        private void Awake()
        {
            foreach (UpgradeNodeContainer container in _nodesContainers)
            {
                UpgradeNode node = _nodeFactory.Create();
                UpgradeNodePresenter nodePresenter = new UpgradeNodePresenter(node, container.View, container.Config);
                
                foreach (UpgradeData upgradesData in container.Config.Upgrades)
                {
                    node.AddUpgrade(_upgradeFactory.CreateUpgrade(upgradesData));
                }
                
                node.Initialize();
                nodePresenter.Initialize();
            }
        }
    }
}