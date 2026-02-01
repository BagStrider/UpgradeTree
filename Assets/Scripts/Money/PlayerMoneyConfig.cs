using UnityEngine;

namespace Money
{
    [CreateAssetMenu(fileName = nameof(PlayerMoneyConfig), menuName = "Configs/" + nameof(PlayerMoneyConfig))]
    public class PlayerMoneyConfig : ScriptableObject
    {
        public float CurrentMoney => _currentMoney;
        
        [SerializeField] private float _currentMoney;
    }
}