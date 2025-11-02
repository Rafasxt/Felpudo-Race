using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BarrelEnemy : MonoBehaviour
{
    public float rollSpeed = 2.5f;
    public int damage = 1;

    private Rigidbody2D rb;
    private bool hasTouchedGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        // depois que encostou no chão, manter movimento para a esquerda
        if (hasTouchedGround)
        {
            rb.linearVelocity = new Vector2(-rollSpeed, rb.linearVelocity.y);
        }

        // destruir se sair da tela
        if (transform.position.x < -10f)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // usando LAYER
        if (!hasTouchedGround && collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            hasTouchedGround = true;
        }

        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth ph = collision.collider.GetComponent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
