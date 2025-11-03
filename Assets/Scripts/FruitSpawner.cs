using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject watermelonPrefab;

    public float minInterval = 4f;
    public float maxInterval = 8f;

    public float spawnY = -2.5f;   // altura do chão
    public float fixedX = 10f;     // sempre nasce na direita

    private float nextTime;

    void Start()
    {
        ScheduleNext();
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            SpawnFruit();
            ScheduleNext();
        }
    }

    void SpawnFruit()
    {
        if (bananaPrefab == null && watermelonPrefab == null) return;

        // 50% banana, 50% melancia
        bool spawnBanana = Random.value > 0.5f;
        GameObject prefab = spawnBanana ? bananaPrefab : watermelonPrefab;

        Vector3 pos = new Vector3(fixedX, spawnY, 0);
        Instantiate(prefab, pos, Quaternion.identity);
    }

    void ScheduleNext()
    {
        nextTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}
