using UnityEngine;

public class CalculateMonsterSpawnPoint : MonoBehaviour
{
    [SerializeField] private MonsterSpawnerSystem spawner;
    [SerializeField] private float spawnRadius = 8f;

    private void OnEnable()
    {
        spawner.OnMonsterPreparing += StartSelectingRandomPlace;
    }

    private void OnDisable()
    {
        spawner.OnMonsterPreparing -= StartSelectingRandomPlace;
    }

    private void StartSelectingRandomPlace()
    {
        Vector2 playerPos = spawner.playerHealth.transform.position;

        // esto lo re Chatgepetie no soy matematico
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);

        float x = Mathf.Cos(randomAngle) * spawnRadius;
        float y = Mathf.Sin(randomAngle) * spawnRadius;

        spawner.Position = new Vector2(playerPos.x + x, playerPos.y + y);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(spawner.playerHealth.transform.position, spawnRadius);
    }
}

