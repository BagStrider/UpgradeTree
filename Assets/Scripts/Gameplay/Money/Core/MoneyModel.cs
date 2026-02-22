using System;

namespace Gameplay.Money.Core
{
    public class MoneyModel
    {
        public event Action<float> OnMoneyChanged;

        public float Value => _money;
        
        private float _money;

        public bool TryToSpend(float amount)
        {
            if(amount > _money) return false;
            
            _money -= amount;
            OnMoneyChanged?.Invoke(_money);
            
            return true;
        }

        public void Set(float value)
        {
            if (value <0) return; 

            _money = value;
            
            OnMoneyChanged?.Invoke(_money);
        }
    }
}