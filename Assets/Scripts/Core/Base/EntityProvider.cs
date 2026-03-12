using Core.Interfaces;
using UnityEngine;

namespace Core.Base
{
    public class EntityProvider : MonoBehaviour, IEntityProvider
    {
        private IEntity _entity;

        public void Initialize(IEntity entity) => _entity = entity;
        public IEntity Provide() => _entity;
    }
}