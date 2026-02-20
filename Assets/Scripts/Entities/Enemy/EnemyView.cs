using BagHealthBar.Scripts;
using UnityEngine;

namespace Entities.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        public HealthBarUI HealthView => _healthView;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private HealthBarUI _healthView;

        public void Initialize(HealthBarUI healthView, Transform healthViewParent)
        {
            _healthView = healthView;
            _healthView.transform.position = UnityEngine.Camera.main.WorldToScreenPoint(transform.position + new Vector3(0f, 1f, 0f));
        }
        
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
    }
}