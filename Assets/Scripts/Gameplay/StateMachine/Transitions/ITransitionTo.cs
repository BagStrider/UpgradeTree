using Gameplay.StateMachine.States;

namespace Gameplay.StateMachine.Transitions
{
    public interface ITransitionTo
    {
        IStateEnter To { get; }
    }
}