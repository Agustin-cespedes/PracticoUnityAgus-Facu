using System.Collections;
using UnityEngine;

public abstract class MonsterBase : MonoBehaviour, IDamageable
{
    protected HealthSystem health;
    protected float speed;
    
    private Transform playerTransform;
    private Coroutine followPlayerRoutine;
    private Vector2 direction;
    
    protected abstract void SpawnParticles();

    protected void Awake()
    {
        health = GetComponent<HealthSystem>();
    }

    public void TakeDamage(float amount)
    {
     health?.GetDamage(amount);   
    }
    
    public void Initialize(Transform target, float speedP)
    {
        playerTransform = target;
        speed = speedP;
        StartMovement();
    }

    protected void StartMovement()
    {
        followPlayerRoutine = StartCoroutine(FollowPlayerRoutine());
    }

    protected void StopMovement()
    {
        StopCoroutine(followPlayerRoutine);
    }

    IEnumerator FollowPlayerRoutine()
    {
        while (true){
            direction = ((Vector2)playerTransform.position - (Vector2)transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            yield return null;
        }
    }

    public virtual void Die()
    {
        StopMovement();
        Destroy(gameObject);
    }
}
