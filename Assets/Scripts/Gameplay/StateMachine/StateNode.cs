using System;
using System.Collections.Generic;
using Gameplay.StateMachine.States;
using Gameplay.StateMachine.Transitions;

namespace Gameplay.StateMachine
{
    public class StateNode
    {
        public IStateEnter State { get;}
        public List<PredicateTransition> PredicateTransitions { get;}
        public List<ActionTransition> ActionTransitions { get;}
        
        public StateNode(IStateEnter state)
        {
            State = state;
        }

        public void AddTransition(IStateEnter to, Func<bool> predicate)
        {
            PredicateTransitions.Add(new  PredicateTransition(to, predicate));
        }
        
        public void AddTransition(IStateEnter to, Action  action)
        {
            ActionTransitions.Add(new ActionTransition(to, action));
        }
    }
}