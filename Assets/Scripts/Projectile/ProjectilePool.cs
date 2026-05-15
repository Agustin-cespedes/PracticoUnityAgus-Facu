using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour, IProjectilePool
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private int poolSize = 20;

    private Queue<Projectile> _pool;

    private void Awake()
    {
        _pool = new Queue<Projectile>(poolSize);

        for (int i = 0; i < poolSize; i++)
        {
            Projectile p = Instantiate(projectilePrefab, transform);
            p.gameObject.SetActive(false);
            p.OnProjectileExpired.AddListener(Return);
            _pool.Enqueue(p);
        }
    }

    public Projectile Get()
    {
        if (_pool.Count > 0)
            return _pool.Dequeue();

        Projectile extra = Instantiate(projectilePrefab, transform);
        extra.gameObject.SetActive(false);
        extra.OnProjectileExpired.AddListener(Return);
        return extra;
    }

    public void Return(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        _pool.Enqueue(projectile);
    }
}
