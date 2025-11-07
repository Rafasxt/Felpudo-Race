using UnityEngine;
public class FruitSpawner : MonoBehaviour
{
    public GameObject bananaPrefab;
    public GameObject watermelonPrefab;
    public Transform spawnPoint; 

    [Header("Frequência")]
    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 2.8f;

    [Header("Tamanho frutas")]
    public float fruitTargetWorldHeight = 0.9f;

    [Header("Anti-grude")]
    public float separationRadius = 2.0f;
    public LayerMask avoidLayers; 

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
        if (!bananaPrefab || !watermelonPrefab) return;

        Vector3 pos = (spawnPoint ? spawnPoint.position : transform.position);

        if (Physics2D.OverlapCircle(pos, separationRadius, avoidLayers) != null) return;

        GameObject prefab = (Random.Range(0, 2) == 0) ? bananaPrefab : watermelonPrefab;
        var go = Instantiate(prefab, pos, Quaternion.identity);

        
        var sr = go.GetComponentInChildren<SpriteRenderer>();
        if (sr && sr.sprite)
        {
            go.transform.localScale = Vector3.one;
            float h = sr.bounds.size.y;
            if (h > 0.0001f)
            {
                float k = fruitTargetWorldHeight / h;
                go.transform.localScale = new Vector3(k, k, 1f);
            }
        }
    }
}
