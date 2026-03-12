using UnityEngine;

namespace Plugins.BHealthBar.Scripts
{
    public class DefaultHealthBar : MonoBehaviour
    {
        [SerializeField] private RectTransform _fillArea;
        [SerializeField] private RectTransform _fill;
        
        public void SetValue(float currentHealth, float maxHealth)
        {
            _fill.sizeDelta = new Vector2(_fillArea.rect.width * currentHealth / maxHealth, _fill.sizeDelta.y);
        }
    }
}