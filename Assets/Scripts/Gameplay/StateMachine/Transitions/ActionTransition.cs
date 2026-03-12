using System;
using Gameplay.StateMachine.States;

namespace Gameplay.StateMachine.Transitions
{
    public class ActionTransition : ITransitionTo
    {
        public IStateEnter To { get; }
        public Action Action { get; }

        public ActionTransition(IStateEnter to, Action action)
        {
            To = to;
            Action = action;
        }
    }
}