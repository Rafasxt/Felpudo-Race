using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject barrelPrefab;

    [Header("Tempo")]
    public float minSpawnTime = 1.6f;
    public float maxSpawnTime = 3.0f;

    [Header("Faixa de X")]
    public float minX = 4.8f;
    public float maxX = 11.5f;

    [Header("Y")]
    public float spawnY = 4.8f;   
    public float groundY = -4.0f; 

    [Header("Anti-grude")]
    public float separationRadius = 2.4f; 
    public int maxAttempts = 8;
    public LayerMask enemyLayer;

    float timer;

    void Start() { timer = Random.Range(minSpawnTime, maxSpawnTime); }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            TrySpawn();
            timer = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    void TrySpawn()
    {
        if (!barrelPrefab) return;

        for (int i = 0; i < maxAttempts; i++)
        {
            float x = Random.Range(minX, maxX);
            Vector2 check = new Vector2(x, groundY);

            if (Physics2D.OverlapCircle(check, separationRadius, enemyLayer) != null) continue;

            Instantiate(barrelPrefab, new Vector3(x, spawnY, 0f), Quaternion.identity);
            return;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(minX, spawnY, 0), new Vector3(maxX, spawnY, 0));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(minX, groundY, 0), new Vector3(maxX, groundY, 0));
    }
}
