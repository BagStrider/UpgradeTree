using System;

namespace Gameplay.UpgradeTree.Node.Transitions.Core
{
    public class TransitionPresenter : IDisposable
    {
        private ITransition _model;
        private TransitionView _view;
        
        public TransitionPresenter(ITransition model, TransitionView view)
        {
            _model = model;
            _view = view;
        }

        public void Initialize()
        {
            _model.OnTransition += OnTransitionHandle;
        }

        private void OnTransitionHandle()
        {
            _view.Show();
        }

        public void Dispose()
        {
            _model.OnTransition -= OnTransitionHandle;
            _model.Dispose();
        }
    }
}