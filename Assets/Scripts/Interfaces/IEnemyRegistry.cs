using UnityEngine;

public interface IEnemyRegistry
{
    void Register(Transform enemy);
    void Unregister(Transform enemy);
    Transform GetNearest(Vector3 from);
}
