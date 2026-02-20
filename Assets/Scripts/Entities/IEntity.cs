namespace Entities
{
    public interface IEntity: IDamagable
    {
        public Health Health { get; }
    }
}