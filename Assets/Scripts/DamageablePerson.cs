using System;
using UnityEngine;

public class DamageablePerson : MonoBehaviour
{
    public event Action<int, int> HealthChanged;
    public event Action Died;    

    [field: SerializeField] public int MaxHealth { get; protected set; } = 100;
    public int Health { get; protected set; }
    public bool IsDead { get; protected set; }

    public virtual void TakeHit(int damageValue)
    {
        damageValue = Mathf.Clamp(damageValue, 0, Health);
        Health -= damageValue;

        if (Health == 0)
            Die();

        HealthChanged?.Invoke(Health, MaxHealth);
    }

    public virtual void Heal(int healingValue)
    {
        healingValue = Mathf.Clamp(healingValue, 0, MaxHealth - Health);
        Health += healingValue;

        HealthChanged?.Invoke(Health, MaxHealth);
    }

    public virtual void Revive()
    {
        IsDead = false;
        Health = MaxHealth;
        
        HealthChanged?.Invoke(Health, MaxHealth);
    }

    protected virtual void Die()
    {
        IsDead = true;

        Died?.Invoke();
    }
}
