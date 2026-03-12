using Gameplay.StateMachine.States;

namespace Gameplay.StateMachine.Transitions
{
    public interface ITransitionFrom
    {
        IStateEnter From { get; }
    }
}