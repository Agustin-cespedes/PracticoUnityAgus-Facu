using UnityEngine;
using UnityEngine.Events;

public class PlayerAiming : MonoBehaviour
{
    [SerializeField] private EnemyRegistry enemyRegistry;
    [SerializeField] private Transform weaponPivot;

    public UnityEvent<Transform> OnTargetAcquired;

    private IEnemyRegistry Registry => enemyRegistry;
    private Transform _currentTarget;

    private void Update()
    {
        Transform nearest = Registry.GetNearest(transform.position);

        if (nearest != _currentTarget)
        {
            _currentTarget = nearest;
            OnTargetAcquired.Invoke(_currentTarget);
        }

        if (_currentTarget != null && weaponPivot != null)
        {
            Vector2 dir = (_currentTarget.position - weaponPivot.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weaponPivot.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
