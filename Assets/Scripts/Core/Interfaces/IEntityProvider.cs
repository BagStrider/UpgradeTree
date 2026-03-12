namespace Core.Interfaces
{
    public interface IEntityProvider
    {
        public void Initialize(IEntity entity);
        public IEntity Provide();
    }
}