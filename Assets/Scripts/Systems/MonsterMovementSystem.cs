using UnityEngine;
using System.Collections;
public class MonsterMovementSystem : MonoBehaviour
{
    private float speed;
    private Coroutine followRoutine;
    private HealthSystem health;
    [SerializeField] private Transform target;
    
    public void Initialize(float Speed)=> Speed = speed;
    
    void Awake()
    {
        health = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    { 
        health.OnDeath += StopFollow;
    }

    private void OnDisable()
    { 
        health.OnDeath -= StopFollow;
    }
    public void StartFollow()
    {
        followRoutine = StartCoroutine(FollowRoutine());
    }
    
    private void StopFollow() 
    {
        this.enabled = false;
        StopCoroutine(followRoutine);
    }
    
    private IEnumerator FollowRoutine()
    {
        while (true)
        {
            Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
            yield return null;
        }
    }
}
