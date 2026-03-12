using Gameplay.StateMachine.States;
using UnityEngine;

namespace Gameplay.Enemy.StateMachine
{
    public class EnemyFollowState : IStateEnter, IStateUpdate
    {
        private Transform _playerTransform;
        
        public EnemyFollowState(Transform  playerTransform)
        {
            _playerTransform =  playerTransform;
        }
        
        public void Enter()
        {
        }

        public void Update()
        {
        }
    }
}