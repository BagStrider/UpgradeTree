using System.Collections.Generic;
using Gameplay.UpgradeTree.Node.Core;
using UnityEngine;

namespace Gameplay.UpgradeTree.Node.Transitions.Core
{
    public class TransitionFactory : MonoBehaviour
    {
        [SerializeField] private TransitionView _transitionViewPrefab;
        [SerializeField] private Transform _spawnParent;
        
        private List<TransitionPresenter> _presenterList = new ();
        
        public ITransition Create(TransitionData data, Dictionary<UpgradeNodeContainer, UpgradeNode> nodes)
        {
            ITransition model =  CreateModel(data, nodes);
            TransitionView view = Instantiate(_transitionViewPrefab, Vector3.zero, Quaternion.identity, _spawnParent);
            view.SetPoints(data.From.View.transform.position, data.To.View.transform.position);
            TransitionPresenter  presenter = new TransitionPresenter(model, view);
            presenter.Initialize();
                
            _presenterList.Add(presenter);
            model.Init();
            
            return model;
        }

        private ITransition CreateModel(TransitionData data, Dictionary<UpgradeNodeContainer, UpgradeNode> nodes)
        {
            UpgradeNode nodeFrom = nodes[data.From];
            UpgradeNode nodeTo = nodes[data.To];
            
            if(data.TransitionType == TransitionType.FirstUpgrade)
                return new FirstTransition(nodeFrom, nodeTo);
            
            if(data.TransitionType == TransitionType.MaxUpgrade)
                return new MaxTransition(nodeFrom, nodeTo);
            
            return null;
        }
        
        private void OnDestroy()
        {
            foreach (var presenter in _presenterList)
            {
                presenter.Dispose();
            }
        }
    }
}