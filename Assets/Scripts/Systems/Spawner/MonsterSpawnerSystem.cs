using System;
using System.Collections;
using UnityEngine;

public class MonsterSpawnerSystem : MonoBehaviour
{
    [SerializeField] private MonsterFabric concreteFactory;
    [SerializeField] public HealthSystem playerHealth;
    
    private IMonsterFactory _monsterFactory;
    
    private Coroutine _spawnCoroutine;
    
    public float spawnInterval = 1f;
    
    public event Action OnMonsterPreparing;

    public string MonsterToSpawnName { get; set; }
    public Vector2 Position { get; set; }
    
    private void Awake()
    {
        _monsterFactory = concreteFactory;
    }

    private void Start()
    {
        StartSpawning();
    }

    private void OnEnable()
    {
        playerHealth.OnDeath += StopSpawning;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= StopSpawning;
    }
    
    
    
    private void StopSpawning()
    {
        StopCoroutine(_spawnCoroutine);
    }
    
    private void StartSpawning()
    {
        _spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            OnMonsterPreparing?.Invoke();
            _monsterFactory.CreateMonster(MonsterToSpawnName, Position);
            yield return new WaitForSeconds(spawnInterval);
        } 
    }
    
    
}
