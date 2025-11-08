using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject barrelPrefab;       // Barril (tem que ter Rigidbody2D e cair no chão)

    [Header("Área de spawn no mundo (X)")]
    public float xMin = 2f;
    public float xMax = 9f;

    [Header("Altura do drop (Y)")]
    public float dropY = 3.5f;

    [Header("Tempo entre spawns")]
    public float minDelay = 2.0f;
    public float maxDelay = 4.0f;

    [Header("Espaçamento")]
    public float minDistanceBetween = 1.5f;   // mínimo entre X do último barril
    public float overlapRadius = 0.4f;        // checagem simples de sobreposição local

    [Header("Opcional")]
    public Transform spawnPoint;  // se não setar, usa this.transform

    float timer;
    float nextDelay;
    float lastSpawnX = 9999f;

    void OnEnable()
    {
        ScheduleNext();
    }

    void Update()
    {
        // NÃO SPAWNAR quando o jogo acaba ou na fase final (últimos 3s)
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IsGameEnded()) return;
            if (GameManager.Instance.IsEndingPhase) return;
        }

        if (barrelPrefab == null)
            return;

        timer += Time.deltaTime;
        if (timer >= nextDelay)
        {
            TrySpawn();
            ScheduleNext();
        }
    }

    void ScheduleNext()
    {
        timer = 0f;
        nextDelay = Random.Range(minDelay, maxDelay);
    }

    void TrySpawn()
    {
        Transform sp = spawnPoint != null ? spawnPoint : transform;

        // escolhe X dentro do range
        float x = Random.Range(xMin, xMax);
        if (Mathf.Abs(x - lastSpawnX) < minDistanceBetween)
        {
            // empurra um pouco para evitar grudados
            x += Mathf.Sign(Random.Range(-1f, 1f)) * minDistanceBetween;
            x = Mathf.Clamp(x, Mathf.Min(xMin, xMax), Mathf.Max(xMin, xMax));
        }

        Vector3 pos = new Vector3(x, dropY, sp.position.z);

        // anti-sobreposição simples
        if (Physics2D.OverlapCircle(pos, overlapRadius, LayerMask.GetMask("Enemy")) != null)
            return;

        GameObject go = Instantiate(barrelPrefab, pos, Quaternion.identity);
        go.tag = "Enemy"; // garanta que o prefab também tenha essa tag
        lastSpawnX = x;
    }
}