using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Configuração do Barril")]
    public GameObject barrelPrefab;
    public float spawnY = 6f;

    [Header("Área de spawn (horizontal)")]
    public float minX = -2f;
    public float maxX = 8f;

    [Header("Velocidade de spawn")]
    public float minInterval = 0.4f;
    public float maxInterval = 1.8f;

    private float nextSpawnTime;

    void Start()
    {
        SetNextSpawnTime();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnBarrel();
            SetNextSpawnTime();
        }
    }

    void SpawnBarrel()
    {
        float randX = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(randX, spawnY, 0);
        Instantiate(barrelPrefab, spawnPos, Quaternion.identity);
    }

    void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}
