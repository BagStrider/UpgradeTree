using System;

namespace Money
{
    public class PlayerMoney
    {
        public event Action<float> OnMoneyChanged;
        
        private float _money;

        public bool TryToSpend(float amount)
        {
            if(amount > _money) return false;
            
            _money -= amount;
            OnMoneyChanged?.Invoke(_money);
            
            return true;
        }
    }
}