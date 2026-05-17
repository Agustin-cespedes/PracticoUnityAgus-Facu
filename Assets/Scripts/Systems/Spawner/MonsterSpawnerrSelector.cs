using UnityEngine;


public class MonsterSpawnerrSelector : MonoBehaviour
{
    [SerializeField]private string[] monsterNames;
    
    
    [SerializeField] private MonsterSpawnerSystem spawner;

    private void OnEnable()
    {
        spawner.OnMonsterPreparing += StartSelectingMonsters;
    }
    private void OnDisable()
    {
        spawner.OnMonsterPreparing -= StartSelectingMonsters;    
    }

private void StartSelectingMonsters()
{
    spawner.MonsterToSpawnName = monsterNames[UnityEngine.Random.Range(0, monsterNames.Length)];
}
}
