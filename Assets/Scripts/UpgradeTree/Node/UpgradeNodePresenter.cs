using System;
using Abstractions;
using Abstractions.Lockable;
using UpgradeTree.Node.Configs;

namespace UpgradeTree.Node
{
    public class UpgradeNodePresenter: IDisposable
    {
        private UpgradeNode _node;
        private UpgradeNodeView _view;
        private UpgradeNodeViewConfig _viewConfig;

        public UpgradeNodePresenter(UpgradeNode node, UpgradeNodeView view, UpgradeNodeViewConfig viewConfig)
        {
            _node = node;
            _view = view;
            _viewConfig = viewConfig;
        }

        public void Initialize()
        {
            _view.SetImage(_viewConfig.Icon);
            _view.SetCounter(_node.CurrentUpgradePosition, _node.Count);
            
            _node.OnUpgrade += OnUpgradeHandle;
            _node.OnUpgradeComplete += OnUpgradeCompleteHandle;
            _node.OnLockChanged += OnLockChanged;
            _view.OnClicked += OnViewClickedHandle;
        }

        private void OnUpgradeHandle()
        {
            _view.SetCounter(_node.CurrentUpgradePosition, _node.Count);
        }
        private void OnUpgradeCompleteHandle()
        {
            //SoldOut bla bla bla
        }
        private void OnViewClickedHandle()
        {
            _node.TryToUpgrade();
        }

        private void OnLockChanged(LockState state)
        {
            if(state == LockState.Locked) _view.Hide();
            if(state == LockState.Unlocked) _view.Show();
        }

        public void Dispose()
        {
            _node.OnUpgrade -= OnUpgradeHandle;
            _node.OnLockChanged -= OnLockChanged;
            _node.OnUpgradeComplete -= OnUpgradeCompleteHandle;
            _view.OnClicked -= OnViewClickedHandle;
        }
    }
}