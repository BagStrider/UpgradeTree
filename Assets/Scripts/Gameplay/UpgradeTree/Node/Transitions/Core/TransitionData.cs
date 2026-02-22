using System;
using UnityEngine;

namespace Gameplay.UpgradeTree.Node.Transitions.Core
{
    [Serializable]
    public class TransitionData
    {
        public UpgradeNodeContainer To => _nodeContainerTo;
        public UpgradeNodeContainer From => _nodeContainerFrom;
        public TransitionType TransitionType => _transitionType;
        
        [SerializeField] private UpgradeNodeContainer _nodeContainerFrom;
        [SerializeField] private UpgradeNodeContainer _nodeContainerTo;
        [SerializeField] private TransitionType _transitionType;
    }
}