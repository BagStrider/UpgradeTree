using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Plugins.BHealthBar.Scripts
{
    public class NumericIconHealthBar : DefaultHealthBar
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Image _icon;

        public void SetText(string text) => _healthText.text = text;
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
    }
}