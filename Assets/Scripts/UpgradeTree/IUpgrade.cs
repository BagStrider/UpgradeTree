using System.Collections.Generic;
using UpgradeTree.Node;

namespace UpgradeTree
{
    public interface IUpgrade
    {
        public UpgradeConfig Config { get; }
        public void Upgrade();
    }



    public class UpgradeTree
    {
        private List<UpgradeNode> _nodes = new ();
        
        
        
    }
}