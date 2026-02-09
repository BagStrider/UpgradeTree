using System;
using BagHealthBar.Scripts;
using UnityEngine;

namespace Entities.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public event Action OnClicked;
        public HealthBarUI HealthView => _healthView;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private HealthBarUI _healthView;

        public void SetSprite(Sprite sprite)
        {
            _spriteRenderer.sprite = sprite;
        }
        
        public void PlayDeathAnimation()
        {
            
        }
        public void PlayHitAnimation()
        {
            
        }

        private void OnMouseDown()
        {
            OnClicked?.Invoke();
        }
    }
}