using System.Collections.Generic;
using Gameplay.UpgradeTree.Node;
using Gameplay.UpgradeTree.Node.Core;
using Gameplay.UpgradeTree.Node.Transitions.Core;
using UnityEngine;

namespace Gameplay.UpgradeTree
{
    public class UpgradeTreeTransitions : MonoBehaviour
    {
        [SerializeField] private TransitionFactory _transitionFactory;
        [SerializeField] private List<TransitionData> _transitionsData = new();
        
        public void CreateTransitions(Dictionary<UpgradeNodeContainer, UpgradeNode> nodes)
        {
            foreach (TransitionData data in _transitionsData)
            {
                _transitionFactory.Create(data, nodes);
            }
        }
    }
}