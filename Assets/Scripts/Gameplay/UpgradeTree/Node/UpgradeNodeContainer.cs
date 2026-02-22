using Gameplay.UpgradeTree.Node.Configs;
using Gameplay.UpgradeTree.Node.Core;
using UnityEngine;

namespace Gameplay.UpgradeTree.Node
{
    public class UpgradeNodeContainer : MonoBehaviour
    {
        public UpgradeNodesConfig Config => _config;
        public UpgradeNodeView View => _view;
        
        [SerializeField] private UpgradeNodesConfig _config;
        [SerializeField] private UpgradeNodeView _view;
    }
}