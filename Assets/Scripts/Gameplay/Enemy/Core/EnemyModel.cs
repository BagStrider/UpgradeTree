using Core.Base;
using Core.Interfaces;

namespace Gameplay.Enemy.Core
{
    public class EnemyModel : IEntity
    {
        private Health _health;

        public EnemyModel(Health health)
        {
            _health = health;
        }

        public void TakeDamage(float damage)
        {
            _health.Decrease(damage);
        }
    }
}