using UnityEngine;

public class EnemyRegistrant : MonoBehaviour
{
    private void Start()
    {
        EnemyRegistry.Instance?.Register(transform);
    }

    private void OnDestroy()
    {
        EnemyRegistry.Instance?.Unregister(transform);
    }
}
