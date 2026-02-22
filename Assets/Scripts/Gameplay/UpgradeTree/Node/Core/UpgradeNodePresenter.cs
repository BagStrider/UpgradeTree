using System;
using Core.Base;
using Gameplay.UpgradeTree.Node.Configs;

namespace Gameplay.UpgradeTree.Node.Core
{
    public class UpgradeNodePresenter: IDisposable
    {
        private UpgradeNode _model;
        private UpgradeNodeView _view;
        private UpgradeNodesConfig _config;

        public UpgradeNodePresenter(UpgradeNode model, UpgradeNodeView view, UpgradeNodesConfig config)
        {
            _model = model;
            _view = view;
            _config = config;
        }

        public void Initialize()
        {
            _view.SetImage(_config.Icon);
            _view.SetCounter(_model.CurrentUpgradePosition, _model.Count);
            _view.SetCost(_model.CurrentUpgradeCost);
            
            _model.OnUpgrade += OnUpgradeHandle;
            _model.OnMaxUpgrade += OnMaxUpgradeHandle;
            _model.OnLockChanged += OnLockChanged;
            _view.OnClicked += OnViewClickedHandle;
        }

        private void OnUpgradeHandle()
        {
            _view.SetCounter(_model.CurrentUpgradePosition, _model.Count);
            _view.SetCost(_model.CurrentUpgradeCost);
        }
        private void OnMaxUpgradeHandle()
        {
            _view.SetSoldOut();
        }
        private void OnViewClickedHandle()
        {
            _model.TryToUpgrade();
        }
        private void OnLockChanged(LockState state)
        {
            if(state == LockState.Locked) _view.Hide();
            if(state == LockState.Unlocked) _view.Show();
        }

        public void Dispose()
        {
            _model.OnUpgrade -= OnUpgradeHandle;
            _model.OnLockChanged -= OnLockChanged;
            _model.OnMaxUpgrade -= OnMaxUpgradeHandle;
            _view.OnClicked -= OnViewClickedHandle;
        }
    }
}