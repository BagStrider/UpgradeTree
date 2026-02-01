using System;
using Abstractions.Lockable;
using UnityEngine;
using UpgradeTree.Node.Configs;

namespace UpgradeTree.Node
{
    public class UpgradeNodePresenter: IDisposable
    {
        private UpgradeNode _node;
        private UpgradeNodeView _view;
        private UpgradeNodesConfig _config;

        public UpgradeNodePresenter(UpgradeNode node, UpgradeNodeView view, UpgradeNodesConfig config)
        {
            _node = node;
            _view = view;
            _config = config;
        }

        public void Initialize()
        {
            _view.SetImage(_config.Icon);
            _view.SetCounter(_node.CurrentUpgradePosition, _node.Count);
            _view.SetCost(_node.CurrentUpgradeCost);
            
            _node.OnUpgrade += OnUpgradeHandle;
            _node.OnMaxUpgrade += OnMaxUpgradeHandle;
            _node.OnLockChanged += OnLockChanged;
            _view.OnClicked += OnViewClickedHandle;
        }

        private void OnUpgradeHandle()
        {
            _view.SetCounter(_node.CurrentUpgradePosition, _node.Count);
            _view.SetCost(_node.CurrentUpgradeCost);
        }
        private void OnMaxUpgradeHandle()
        {
            _view.SetSoldOut();
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
            _node.OnMaxUpgrade -= OnMaxUpgradeHandle;
            _view.OnClicked -= OnViewClickedHandle;
        }
    }
}