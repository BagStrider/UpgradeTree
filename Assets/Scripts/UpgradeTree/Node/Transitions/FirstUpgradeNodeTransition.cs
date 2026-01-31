using System;

namespace UpgradeTree.Node.Transitions
{
    public class FirstUpgradeNodeTransition : IUpgradeNodeTransition, IDisposable
    {
        private UpgradeNode _nodeFrom;
        private UpgradeNode _nodeTo;

        public FirstUpgradeNodeTransition(UpgradeNode nodeFrom, UpgradeNode nodeTo)
        {
            _nodeFrom = nodeFrom;
            _nodeTo = nodeTo;
        }

        public void Init()
        {
            _nodeFrom.OnFirstUpgrade += OnFirtsUpgradeHandle;
        }

        private void OnFirtsUpgradeHandle()
        {
            _nodeTo.Unlock();
        }

        public void Dispose()
        {
            _nodeFrom.OnFirstUpgrade -= OnFirtsUpgradeHandle;
        }
    }
}