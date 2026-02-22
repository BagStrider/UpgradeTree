using System;
using Gameplay.UpgradeTree.Node.Core;
using Gameplay.UpgradeTree.Node.Transitions.Core;

namespace Gameplay.UpgradeTree.Node.Transitions
{
    public class FirstTransition : ITransition
    {
        public event Action OnTransition;
        
        public UpgradeNode From => _nodeFrom;
        public UpgradeNode To => _nodeTo;

        private UpgradeNode _nodeFrom;
        private UpgradeNode _nodeTo;

        public FirstTransition(UpgradeNode nodeFrom, UpgradeNode nodeTo)
        {
            _nodeFrom = nodeFrom;
            _nodeTo = nodeTo;
        }

        public void Init()
        {
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