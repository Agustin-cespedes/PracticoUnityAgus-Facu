using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]private float maxHealth;
    [SerializeField]private UnityEvent onDeath;
    private float currentHealth;
    public void GetDamage(float damage)
    {
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            currentHealth -= damage;
            Debug.Log($"{gameObject.name} recibió daño, su vida actual es: {currentHealth}");
        }
    }

    private void Die()
    {
        onDeath.Invoke();
    }
}
