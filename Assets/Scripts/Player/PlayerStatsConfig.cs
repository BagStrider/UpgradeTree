using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Data/" + nameof(PlayerStatsConfig), fileName = nameof(PlayerStatsConfig), order = 0)]
    public class PlayerStatsConfig : ScriptableObject
    {
        public float AttackSpeed => _additionalAttacks;
        public float Damage => _damage;
        public float DamageMultiplier => _damageMultiplier;
        public float AdditionalAttacks => _additionalAttacks;
        
        [SerializeField] private float _attackSpeed;
        [SerializeField] private float _damage;
        [SerializeField] private float _damageMultiplier;
        [SerializeField] private float _additionalAttacks;
    }
}