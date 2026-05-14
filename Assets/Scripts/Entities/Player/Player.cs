using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    private HealthSystem health;

    private void Awake()
    {
        health = GetComponent<HealthSystem>(); 
    } 
    
    public void TakeDamage(float amount)
    {
        health?.GetDamage(amount);
    }
}
