using UnityEngine;
using UnityEngine.Events;

public class DisparadorAutomatico : MonoBehaviour, IWeapon
{
    [SerializeField] private ProjectilePool projectilePool;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;

    public UnityEvent OnFired;

    private IProjectilePool Pool => projectilePool;
    private Transform _currentTarget;
    private float _timer;

    public void SetTarget(Transform target)
    {
        _currentTarget = target;
        _timer = 0f;
    }

    private void Update()
    {
        if (_currentTarget == null) return;

        _timer += Time.deltaTime;

        if (_timer >= 1f / fireRate)
        {
            _timer = 0f;
            Fire(_currentTarget);
        }
    }

    public void Fire(Transform target)
    {
        Projectile p = Pool.Get();
        p.transform.position = firePoint.position;

        Vector2 dir = ((Vector2)target.position - (Vector2)firePoint.position).normalized;
        p.Launch(dir);

        OnFired.Invoke();
    }
}
