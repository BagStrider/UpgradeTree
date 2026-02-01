using System;

namespace UpgradeTree.Node.Transitions
{
    public class MaxUpgradeNodeTransition : IUpgradeNodeTransition
    {
        public event Action OnTransition;
        
        private UpgradeNode _nodeFrom;
        private UpgradeNode _nodeTo;

        public MaxUpgradeNodeTransition(UpgradeNode nodeFrom, UpgradeNode nodeTo)
        {
            _nodeFrom = nodeFrom;
            _nodeTo = nodeTo;
        }


        public void Init()
        {
            _nodeFrom.OnMaxUpgrade += OnMaxMaxUpgradeHandle;
        }

        private void OnMaxMaxUpgradeHandle()
        {
            _nodeTo.Unlock();
            OnTransition?.Invoke();
        }

        public void Dispose()
        {
            _nodeFrom.OnFirstUpgrade -= OnMaxMaxUpgradeHandle;
        }
    }
}