using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(EnemyConfig), fileName = nameof(EnemyConfig), order = 0)]
    public class EnemyConfig : ScriptableObject
    {
        public float Health => _currentHealth;
        public float MaxHealth => _maxHealth;
        public Sprite Sprite => _sprite;
        
        [Header("Health")]
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;
        
        [Header("View")]
        [SerializeField] private Sprite _sprite;
    }
}