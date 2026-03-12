using UnityEngine;
using UnityEngine.UI;

namespace Plugins.BHealthBar.Scripts
{
    public class IconHealthBar : DefaultHealthBar
    {
        [SerializeField] private Image _icon;
        
        public void SetIcon(Sprite icon) => _icon.sprite = icon;
    }
}