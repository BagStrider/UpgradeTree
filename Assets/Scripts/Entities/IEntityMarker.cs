using UnityEngine;

namespace Entities
{
    public class EntityProvider : MonoBehaviour
    {
        private IEntity _entity;

        public void Initialize(IEntity entity) => _entity = entity;
        public IEntity Provide() => _entity;
    }
}