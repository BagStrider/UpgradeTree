using System;

namespace UpgradeTree.Node.Transitions
{
    public interface IUpgradeNodeTransition : IDisposable
    {
        public event Action OnTransition;
        public void Init();
    }
}