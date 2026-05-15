using System.Collections.Generic;
using UnityEngine;

public class EnemyRegistry : MonoBehaviour, IEnemyRegistry
{
    public static EnemyRegistry Instance { get; private set; }

    private readonly List<Transform> _enemies = new List<Transform>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Register(Transform enemy)
    {
        if (!_enemies.Contains(enemy))
            _enemies.Add(enemy);
    }

    public void Unregister(Transform enemy)
    {
        _enemies.Remove(enemy);
    }

    public Transform GetNearest(Vector3 from)
    {
        Transform nearest = null;
        float minDist = float.MaxValue;

        for (int i = _enemies.Count - 1; i >= 0; i--)
        {
            if (_enemies[i] == null)
            {
                _enemies.RemoveAt(i);
                continue;
            }

            float dist = Vector3.SqrMagnitude(_enemies[i].position - from);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = _enemies[i];
            }
        }

        return nearest;
    }
}
