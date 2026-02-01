using System.Collections.Generic;
using UnityEngine;
using UpgradeTree.Node;
using UpgradeTree.Node.Configs;
using UpgradeTree.Node.Transitions;
using UpgradeTree.Upgrades;

namespace UpgradeTree
{
    public class UpgradeTree : MonoBehaviour
    {
        [SerializeField] private List<UpgradeNodeContainer> _nodesContainers = new();
        [SerializeField] private UpgradeFactory _upgradeFactory;
        [SerializeField] private UpgradeNodeFactory _nodeFactory;
        [SerializeField] private UpgradeTreeTransitions _transitions;
        
        private Dictionary<UpgradeNodeContainer, UpgradeNode> _nodeDictioanry = new();
        
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
                
                node.Lock();
                
                _nodeDictioanry.Add(container, node);
            }

            _transitions.CreateTransitions(_nodeDictioanry);
            
            _nodeDictioanry[_nodesContainers[0]].Unlock();
        }
    }
}