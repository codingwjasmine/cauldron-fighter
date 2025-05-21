using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{   
    [SerializeField]
        private float _health; // Player's health
    [SerializeField]
        private float _maxHealth; // Maximum health
    
    public float RemaingHealth
    {
        get
        {
            return _health / _maxHealth; // Calculate remaining health as a percentage
        }
    }
    public bool IsInvincible { get; set; } // Property to check if the player is invincible
    public UnityEvent OnDied;

    public UnityEvent OnDamage;
    public UnityEvent OnHealthChanged; // Event to be invoked when health is added
    
    public float CurrentHealth => _health;
    public float MaxHealth => _maxHealth;


    public void TakeDamage(float damage)
    {   
        if (_health == 0)
        {

            return;
        }

        if (IsInvincible) 
        {
            return; // If the player is invincible, ignore damage
        }
         _health -= damage; // Reduce health by damage amount
        
        OnHealthChanged?.Invoke(); // Invoke the OnHealthChanged event when health is changed

        if (_health < 0)
        {
            _health = 0; 
        }
        if (_health == 0)
        {
            OnDied?.Invoke(); // Invoke the OnDied event if health reaches zero
        }
        else
        {
            OnDamage?.Invoke(); // Invoke the OnDamage event if health is reduced but not zero
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_health == _maxHealth)
            return;
        
        _health += amountToAdd; 

        if(_health > _maxHealth)
            _health = _maxHealth; // Clamp health to maximum value
    
        OnHealthChanged?.Invoke(); // Invoke the OnHealthChanged event when health is added

    }
}