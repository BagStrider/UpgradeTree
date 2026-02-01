using UnityEngine;

namespace UpgradeTree.Node.Configs
{
    public class UpgradeNodeContainer : MonoBehaviour
    {
        public UpgradeNodesConfig Config => _config;
        public UpgradeNodeView View => _view;
        
        [SerializeField] private UpgradeNodesConfig _config;
        [SerializeField] private UpgradeNodeView _view;
    }
}