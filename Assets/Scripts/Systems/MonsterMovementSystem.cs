using UnityEngine;
using System.Collections;
public class MonsterMovementSystem : MonoBehaviour
{
    private float _speed;
    private Coroutine followRoutine;
    private HealthSystem health;
    [SerializeField] private Transform target;
    
    public void Initialize(float Speed)=> _speed = Speed;
    
    private void Awake()
    {
        health = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        StartFollow();
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
            transform.position += (Vector3)(direction * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
