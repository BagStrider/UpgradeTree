using System.Collections.Generic;
using Gameplay.UpgradeTree.Node;
using Gameplay.UpgradeTree.Node.Core;
using Gameplay.UpgradeTree.Upgrades.Core;
using UnityEngine;

namespace Gameplay.UpgradeTree
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
                UpgradeNodePresenter presenter = new UpgradeNodePresenter(node, container.View, container.Config);
                
                foreach (UpgradeData data in container.Config.Upgrades)
                {
                    node.AddUpgrade(_upgradeFactory.Create(data));
                }
                
                node.Initialize();
                presenter.Initialize();
                
                node.Lock();
                
                _nodeDictioanry.Add(container, node);
            }

            _transitions.CreateTransitions(_nodeDictioanry);
            
            _nodeDictioanry[_nodesContainers[0]].Unlock();
        }
    }
}