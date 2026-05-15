using UnityEngine;

public class MonsterInitializer : MonoBehaviour
{
    [SerializeField]private MonstersData monsterData;

    private void Awake()
    {
        GetComponent<HealthSystem>().Initialize(monsterData.MaxHealth);
        GetComponent<MonsterMovementSystem>().Initialize(monsterData.Speed);
    }
}
