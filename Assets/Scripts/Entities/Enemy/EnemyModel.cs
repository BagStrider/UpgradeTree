namespace Entities.Enemy
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