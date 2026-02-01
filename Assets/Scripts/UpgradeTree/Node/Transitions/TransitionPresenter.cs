using System;

namespace UpgradeTree.Node.Transitions
{
    public class TransitionPresenter : IDisposable
    {
        private IUpgradeNodeTransition _model;
        private TransitionView _view;
        private UpgradeNodeTransitionData _data;
        
        public TransitionPresenter(IUpgradeNodeTransition model, TransitionView view, UpgradeNodeTransitionData data)
        {
            _model = model;
            _view = view;
            _data = data;
        }

        public void Initialize()
        {
            _view.SetPoints(_data.From.View.transform.position, _data.To.View.transform.position);
            _view.Hide();
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