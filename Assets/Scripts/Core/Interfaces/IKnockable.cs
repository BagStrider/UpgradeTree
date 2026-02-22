using UnityEngine;

namespace Core.Interfaces
{
    public interface IKnockable
    {
        public void Knockback(Vector3 direction, float knockbackForce);
    }
}