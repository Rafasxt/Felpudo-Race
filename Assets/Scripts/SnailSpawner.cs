using UnityEngine;

public class SnailSpawner : MonoBehaviour
{
    public GameObject snailPrefab;
    public float minInterval = 3f;
    public float maxInterval = 6f;

    float nextTime;

    void Start()
    {
        SetNext();
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            Instantiate(snailPrefab, transform.position, Quaternion.identity);
            SetNext();
        }
    }

    void SetNext()
    {
        nextTime = Time.time + Random.Range(minInterval, maxInterval);
    }
}
