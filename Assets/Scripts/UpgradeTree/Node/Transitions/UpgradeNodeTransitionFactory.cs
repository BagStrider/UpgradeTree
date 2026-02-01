using System.Collections.Generic;
using UnityEngine;
using UpgradeTree.Node.Configs;

namespace UpgradeTree.Node.Transitions
{
    public class UpgradeNodeTransitionFactory : MonoBehaviour
    {
        public IUpgradeNodeTransition Create(UpgradeNodeTransitionData data, Dictionary<UpgradeNodeContainer, UpgradeNode> nodes)
        {
            UpgradeNode nodeFrom = nodes[data.From];
            UpgradeNode nodeTo = nodes[data.To];
            
            if(data.TransitionType == TransitionType.FirstUpgrade)
                return new FirstUpgradeNodeTransition(nodeFrom, nodeTo);
            
            if(data.TransitionType == TransitionType.MaxUpgrade)
                return new MaxUpgradeNodeTransition(nodeFrom, nodeTo);
            
            return null;
        }
    }
}