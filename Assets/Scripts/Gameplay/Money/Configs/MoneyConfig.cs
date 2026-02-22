using UnityEngine;

namespace Gameplay.Money.Configs
{
    [CreateAssetMenu(fileName = nameof(MoneyConfig), menuName = "Configs/" + nameof(MoneyConfig))]
    public class MoneyConfig : ScriptableObject
    {
        public float CurrentMoney => _currentMoney;
        
        [SerializeField] private float _currentMoney;
    }
}