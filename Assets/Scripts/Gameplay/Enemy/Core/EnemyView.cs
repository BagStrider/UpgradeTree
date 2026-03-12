using Plugins.BHealthBar.Scripts;
using UnityEngine;

namespace Gameplay.Enemy.Core
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

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