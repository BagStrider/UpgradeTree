using TMPro;
using UnityEngine;

namespace BagHealthBar.Scripts
{
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private RectTransform _fillArea;
        [SerializeField] private RectTransform _fill;
        
        public void SetText(string text)
        {
            _healthText.text = text;
        }

        public void Set(float currentHealth, float maxHealth)
        {
            _fill.sizeDelta = new Vector2(_fillArea.rect.width * currentHealth / maxHealth, _fill.sizeDelta.y);
        }
    }
}