using System;

namespace Core.Base
{
    public class Health
    {
        public event Action OnDeath;
        public event Action<float> OnValueChanged;
    
        public float Value => _health;
        public float MaxValue => _maxHealth;
    
        private float _health;
        private float _maxHealth;

        public Health(float currentHealth, float maxHealth)
        {
            _health = currentHealth;
            _maxHealth = maxHealth;
        }
        
        public void Decrease(float value)
        {
            if(value <= 0 ) return;
        
            _health -= value;
        
            OnValueChanged?.Invoke(_health);
        
            if(_health <= 0) OnDeath?.Invoke();
        }

        public void Increase(float value)
        {
            if(value <= 0 ) return;
        
            _health += value;
        
            if(_health > _maxHealth) _health = _maxHealth;
        
            OnValueChanged?.Invoke(_health);
        }
    }
}