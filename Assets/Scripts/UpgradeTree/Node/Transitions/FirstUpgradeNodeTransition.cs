using System;
using UnityEngine;

namespace UpgradeTree.Node.Transitions
{
    public class FirstUpgradeNodeTransition : IUpgradeNodeTransition
    {
        public event Action OnTransition;
        
        private UpgradeNode _nodeFrom;
        private UpgradeNode _nodeTo;

        public FirstUpgradeNodeTransition(UpgradeNode nodeFrom, UpgradeNode nodeTo)
        {
            _nodeFrom = nodeFrom;
            _nodeTo = nodeTo;
        }

        public void Init()
        {
            Debug.Log($"NodeFrom hash: {_nodeFrom.GetHashCode()}");
            _nodeFrom.OnFirstUpgrade += OnFirstUpgradeHandle;
        }

        private void OnFirstUpgradeHandle()
        {
            _nodeTo.Unlock();
            OnTransition?.Invoke();
        }

        public void Dispose()
        {
            _nodeFrom.OnFirstUpgrade -= OnFirstUpgradeHandle;
        }
    }
}