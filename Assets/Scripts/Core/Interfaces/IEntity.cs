using Core.Base;

namespace Core.Interfaces
{
    public interface IEntity: IDamagable
    {
        public Health Health { get; }
    }
}