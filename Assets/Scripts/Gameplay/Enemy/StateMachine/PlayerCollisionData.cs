using UnityEngine;

namespace Gameplay.Enemy.StateMachine
{
    public struct PlayerCollisionData
    {
        public PlayerSystem.Core.Player Player { get; }
        public Transform Transform { get; }
        
        public PlayerCollisionData(PlayerSystem.Core.Player player, Transform transform)
        {
            Player = player;
            Transform = transform;
        }
    }
}