using System;
using Gameplay.StateMachine.States;

namespace Gameplay.StateMachine.Transitions
{
    public class PredicateTransition : ITransitionTo
    {
        public Func<bool> Predicate { get;}
        public IStateEnter To { get; }

        public PredicateTransition(IStateEnter to, Func<bool> predicate)
        {
            To = to;
            Predicate = predicate;
        }
    }
}