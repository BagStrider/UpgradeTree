using Gameplay.StateMachine;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemy.StateMachine
{
    public class EnemyStatemachine : IInitializable
    {
        private StateMachineBase _stateMachine;
        
        private Transform _playerTransform;
        
        public EnemyStatemachine(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void Initialize()
        {
            _stateMachine = new StateMachineBase();

            var followState = new EnemyFollowState(_playerTransform);
            var attackState = new EnemyAttackState();
            
            _stateMachine.AddState(followState);
            _stateMachine.AddState(attackState);
            
            _stateMachine.AddTransition(followState, attackState, CheckForAttack);
            _stateMachine.AddTransition(attackState, CheckForAttack);
            
            _stateMachine.SetCurrentState(followState);
        }
        
        private bool CheckForAttack()
        {
            return true;
        }
    }
}