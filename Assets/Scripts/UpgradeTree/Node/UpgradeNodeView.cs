using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UpgradeTree.Node
{
    public class UpgradeNodeView : MonoBehaviour
    {
        public event Action OnClicked;
        
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Image _image;
        [SerializeField] private Animator _animator;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClickedHandle);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClickedHandle);
        }


        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void PlayUpgradeAnimation()
        {
            //_animator.Play();
        }
        
        public void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }
        public void SetCounter(int currentCount, int maxCount)
        {
            _countText.text = $"{currentCount}/{maxCount}";
        }

        private void OnClickedHandle()
        {
            OnClicked?.Invoke();
        }
    }
}