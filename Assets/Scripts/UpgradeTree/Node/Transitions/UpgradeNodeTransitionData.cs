using System;
using UnityEngine;
using UpgradeTree.Node.Configs;

namespace UpgradeTree.Node.Transitions
{
    [Serializable]
    public class UpgradeNodeTransitionData
    {
        public UpgradeNodeContainer To => _nodeContainerTo;
        public UpgradeNodeContainer From => _nodeContainerFrom;
        public TransitionType TransitionType => _transitionType;
        
        [SerializeField] private UpgradeNodeContainer _nodeContainerFrom;
        [SerializeField] private UpgradeNodeContainer _nodeContainerTo;
        [SerializeField] private TransitionType _transitionType;
    }
}