using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BarrelEnemy : MonoBehaviour
{
    public float rollSpeed = 2.5f;
    public int damage = 1;
    public string groundLayerName = "Ground";

    private Rigidbody2D rb;
    private Animator anim;
    private bool hasTouchedGround = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.gravityScale = 2f;
        rb.freezeRotation = true;

        if (anim != null)
            anim.enabled = false; // liga s� no ch�o
    }

    void FixedUpdate()
    {
        if (hasTouchedGround)
        {
            rb.linearVelocity = new Vector2(-rollSpeed, rb.linearVelocity.y);
        }

        if (transform.position.x < -10f)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // tocou no ch�o
        if (!hasTouchedGround && collision.collider.gameObject.layer == LayerMask.NameToLayer(groundLayerName))
        {
            hasTouchedGround = true;
            if (anim != null)
                anim.enabled = true;
        }

        // tocou no player
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth ph = collision.collider.GetComponent<PlayerHealth>();
            if (ph != null)
                ph.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
