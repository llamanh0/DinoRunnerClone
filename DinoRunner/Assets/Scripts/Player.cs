using UnityEngine;

public class Player : MonoBehaviour
{
    readonly private float radius = 0.2f;
    readonly private float jumpPower = 15f;

    [SerializeField] private Transform checkGround;

    private BoxCollider2D col;
    private Rigidbody2D rb;
    private LayerMask groundLayer;

    private bool isGrounded;

    private void Awake() => groundLayer = LayerMask.GetMask("Ground");

    private void Start()
    {
        col = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGround();
        HandleMovement();
    }

    private void HandleMovement()
    {
        Up();
        Down();
    }

    private void Up()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void Down()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            col.size = new(0.6f, 0.6f);
            col.offset = new(0f, -0.2f);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            col.size = new(0.6f, 1f);
            col.offset = new(0f, 0f);
        }
    }

    private void CheckGround() => isGrounded = Physics2D.OverlapCircle(checkGround.position, radius, groundLayer);
}
