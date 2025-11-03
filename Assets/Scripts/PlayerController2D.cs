using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController2D : MonoBehaviour
{
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    [Header("Movimento opcional")]
    public float baseMoveSpeed = 0f;   // deixa 0 pro player ficar parado
    private float currentMoveSpeed;
    private float boostTimer = 0f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentMoveSpeed = baseMoveSpeed;
    }

    void Update()
    {
        // checar chão
        if (groundCheck != null)
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        else
            isGrounded = true;

        // pulo
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isGrounded)
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // contagem do boost
        if (boostTimer > 0)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0)
                currentMoveSpeed = baseMoveSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);

    }

    // 🍌 banana usa isso
    public void ApplySpeedBoost(float newSpeed, float duration)
    {
        currentMoveSpeed = newSpeed;
        boostTimer = duration;
    }
}
