using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    readonly private float radius = 0.2f;
    readonly private float jumpPower = 14f;

    [SerializeField] private Transform checkGround;

    public static event Action OnPlayerDied;

    private BoxCollider2D col;
    private Rigidbody2D rb;
    private LayerMask groundLayer;

    private bool isGrounded;

    private void Awake() => groundLayer = LayerMask.GetMask("Ground");

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 4.5f;
    }

    private void Update()
    {
        CheckGround();
        HandleMovement();
    }

    private void HandleMovement()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpPower;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            col.size = new(col.size.x, 0.6f);
            col.offset = new(0f, -0.2f);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            col.size = new(col.size.x, 1f);
            col.offset = new(0f, 0f);
        }
    }

    public void Die()
    {
        Debug.Log("Player Died!");
        OnPlayerDied?.Invoke();
    }

    private void CheckGround() => isGrounded = Physics2D.OverlapCircle(checkGround.position, radius, groundLayer);
}
