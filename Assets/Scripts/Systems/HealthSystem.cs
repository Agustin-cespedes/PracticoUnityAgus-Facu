using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IDamageable
{
    public event Action OnDeath;
    
    private float currentHealth;
    
    public void Initialize(float maxHealth)=> currentHealth = maxHealth;
    
    
    public void TakeDamage(float damage)
    {
        if (currentHealth - damage <= 0)
        {
            OnDeath?.Invoke();
        }
        else
        {
            currentHealth -= damage;
            Debug.Log($"{gameObject.name} recibió daño, su vida actual es: {currentHealth}");
        }
    }
    
}
