using Core.Base;
using Core.Interfaces;
using Gameplay.Enemy.Configs;

namespace Gameplay.Enemy.Core
{
    public class EnemyModel : IEntity
    {
        public Health Health => _health;
    
        private Health _health;

        public EnemyModel(EnemyConfig config)
        {
            _health = new Health(config.Health, config.MaxHealth);
        }

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);
        }
    }
}