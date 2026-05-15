using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private float damage = 10f;

    public UnityEvent<Projectile> OnProjectileExpired;

    private Rigidbody2D _rb;
    private float _timer;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        gameObject.SetActive(true);
        _timer = lifeTime;
        _rb.linearVelocity = direction * speed;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
            Expire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
            Expire();
        }
    }

    private void Expire()
    {
        _rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
        OnProjectileExpired.Invoke(this);
    }
}
