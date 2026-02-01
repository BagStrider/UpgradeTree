using UnityEngine;

namespace UpgradeTree.Node.Transitions
{
    public class TransitionView : MonoBehaviour
    {
        [SerializeField] private LineRenderer _lineRenderer;

        public void SetPoints(Vector3 start, Vector3 end)
        {
            _lineRenderer.SetPosition(0, start);
            _lineRenderer.SetPosition(1, end);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
