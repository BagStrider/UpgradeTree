using UnityEngine;

namespace UpgradeTree
{
    [CreateAssetMenu(fileName = nameof(UpgradeConfig), menuName = nameof(UpgradeConfig), order = 0)]
    public class UpgradeConfig : ScriptableObject
    {
        public float Cost => _cost;
        
        [SerializeField, Min(0f)] private float _cost;
    }
}