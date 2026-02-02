using System.Collections.Generic;
using UnityEngine;
using UpgradeTree.Node.Configs;

namespace UpgradeTree.Node.Transitions
{
    public class UpgradeTreeTransitions : MonoBehaviour
    {
        public List<UpgradeNodeTransitionData> Transitions => _transitionsData;
        
        [SerializeField] private UpgradeNodeTransitionFactory _transitionFactory;
        [SerializeField] private List<UpgradeNodeTransitionData> _transitionsData = new();
        [SerializeField] private TransitionView _transitionViewPrefab;
        [SerializeField] private Transform _spawnParent;

        private List<TransitionPresenter> _transitionPresenters = new ();
        
        public void CreateTransitions(Dictionary<UpgradeNodeContainer, UpgradeNode> nodes)
        {
            foreach (UpgradeNodeTransitionData transitionData in _transitionsData)
            {
                IUpgradeNodeTransition transition = _transitionFactory.Create(transitionData, nodes);
                
                TransitionView transitionView = Instantiate(_transitionViewPrefab, Vector3.zero, Quaternion.identity, _spawnParent);
                
                TransitionPresenter  presenter = new TransitionPresenter(transition, transitionView, transitionData);
                presenter.Initialize();
                
                _transitionPresenters.Add(presenter);
                transition.Init();
                Debug.Log("Transition created");
            }
        }

        private void OnDestroy()
        {
            foreach (var presenter in _transitionPresenters)
            {
                presenter.Dispose();
            }
        }
    }
}