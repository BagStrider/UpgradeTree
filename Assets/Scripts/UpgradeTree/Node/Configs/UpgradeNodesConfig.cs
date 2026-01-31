using UnityEngine;

namespace UpgradeTree.Node.Configs
{
    [CreateAssetMenu(fileName = nameof(UpgradeNodesConfig), menuName = "Configs/" + nameof(UpgradeNodesConfig))]
    public class UpgradeNodesConfig : ScriptableObject
    {
        public UpgradeNodeData NodeData => _nodeData;

        [SerializeField] private UpgradeNodeData _nodeData;
    }
}