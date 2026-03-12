using System;
using System.Collections.Generic;
using Gameplay.StateMachine.States;
using Gameplay.StateMachine.Transitions;
using UnityEngine;

namespace Gameplay.StateMachine
{
    public class StateMachineBase
    {
        private List<PredicateTransition> _anyPredicateTransitions = new();
        private List<ActionTransition> _anyActionTransitions = new();
        
        private Dictionary<Type, StateNode> _nodes = new();
        
        private StateNode _currentNode;

        public void SetCurrentState(IStateEnter state)
        {
            ChangeNode(state);
        }
        
        public void Update()
        {
            CheckTransitions();
            
            if(_currentNode == null) return;
            
            if(_currentNode.State is IStateUpdate state)
                state.Update();
        }

        public void FixedUpdate()
        {
            if (_currentNode == null) return;

            if(_currentNode.State is IStateFixedUpdate state)
                state.FixedUpdate();
        }

        public void AddState(IStateEnter state)
        {
            GetNode(state, false);
        }

        public void AddTransition(IStateEnter from, IStateEnter to, Func<bool> predicate)
        {
            GetNode(from).AddTransition(to, predicate);
        }
        public void AddTransition(IStateEnter from, IStateEnter to, Action action)
        {
            GetNode(from).AddTransition(to, action);
        }
        public void AddTransition(IStateEnter to, Func<bool> predicate)
        {
            _anyPredicateTransitions.Add(new PredicateTransition(to, predicate));
        }
        public void AddTransition(IStateEnter to, Action action)
        {
            _anyActionTransitions.Add(new ActionTransition(to, action));
        }

        private void ChangeNode(IStateEnter state)
        {
            var node =  GetNode(state);
            
            if(_currentNode == node) return;
            if(_currentNode?.State is IStateExit exitState) 
                exitState.Exit();

            _currentNode = node;
            _currentNode.State.Enter();
        }

        private void CheckTransitions()
        {
            foreach (var transition in _anyPredicateTransitions)
            {
                if (transition.Predicate())
                {
                    ChangeNode(transition.To);
                    return;
                }
                
            }
            
            if(_currentNode == null) return;
            
            foreach (var transition in _currentNode.PredicateTransitions)
            {
                if (transition.Predicate())
                {
                    ChangeNode(transition.To);
                    return;
                }
            }
        }

        private StateNode GetNode(IStateEnter state, bool logger = true)
        {
            Type stateType = state.GetType();

            if (_nodes.TryGetValue(stateType, out var node))
            {
                return node;
            }
            
            StateNode newNode = new StateNode(state);
            _nodes.Add(stateType, newNode);
            
            if(logger)
                Debug.LogWarning($"Node not  found {stateType} \nCreating new Node");
            
            return newNode;
        }
    }
}