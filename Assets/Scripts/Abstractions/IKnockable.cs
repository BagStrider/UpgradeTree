using UnityEngine;

namespace Abstractions
{
    public interface IKnockable
    {
        public void Knockback(Vector3 direction, float knockbackForce);
    }
}