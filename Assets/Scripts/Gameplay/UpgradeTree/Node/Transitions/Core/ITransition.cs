using System;
using Gameplay.UpgradeTree.Node.Core;

namespace Gameplay.UpgradeTree.Node.Transitions.Core
{
    public interface ITransition : IDisposable
    {
        public event Action OnTransition;
        
        public UpgradeNode From { get; }
        public UpgradeNode To { get; }
        public void Init();
    }
}