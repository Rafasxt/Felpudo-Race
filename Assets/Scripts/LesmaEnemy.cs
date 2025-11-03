using UnityEngine;

public class SnailEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public int damage = 1;
    public float destroyX = -10f;

    void Update()
    {
        // anda sempre pra esquerda
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        // se sair da tela
        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
