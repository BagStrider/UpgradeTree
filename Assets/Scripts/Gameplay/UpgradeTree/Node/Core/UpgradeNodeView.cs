using System;
using TMPro;
using UnityEngine;

namespace Gameplay.UpgradeTree.Node.Core
{
    public class UpgradeNodeView : MonoBehaviour
    {
        public event Action OnClicked;
        
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private TMP_Text _costText;
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

        public void SetSoldOut()
        {
            _costText.text = "SOLDOUT";
        }
        public void SetCost(float cost)
        {
            _costText.text = $"{cost} $";
        }

        private void OnMouseDown()
        {
            OnClicked?.Invoke();
        }
    }
}