using UnityEngine;

namespace UpgradeTree.Node.Configs
{
    [CreateAssetMenu(fileName = nameof(UpgradeNodeViewConfig), menuName = nameof(UpgradeNodeViewConfig), order = 1)]
    public class UpgradeNodeViewConfig : ScriptableObject
    {
        public Sprite Icon => _icon;
        
        [SerializeField] private Sprite _icon;
    }
}