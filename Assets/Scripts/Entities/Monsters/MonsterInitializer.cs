using UnityEngine;

public class MonsterInitializer : MonoBehaviour
{
    [SerializeField]private MonstersData monsterData;

    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private MonsterMovementSystem movementSystem;
    
    private void Start()
    {
        healthSystem.Initialize(monsterData.MaxHealth);
        movementSystem.Initialize(monsterData.Speed);
    }
}
