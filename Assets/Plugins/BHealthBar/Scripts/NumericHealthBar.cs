using TMPro;
using UnityEngine;

namespace Plugins.BHealthBar.Scripts
{
    public class NumericHealthBar : DefaultHealthBar
    {
        [SerializeField] private TMP_Text _healthText;
        
        public void SetText(string text) => _healthText.text = text;
    }
}