using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UpgradeTree.Node
{
    public class UpgradeNodeView : MonoBehaviour
    {
        public event Action OnClicked;
        
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private SpriteRenderer _image;
        [SerializeField] private Animator _animator;

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

        private void OnMouseDown()
        {
            OnClicked?.Invoke();
        }
    }
}