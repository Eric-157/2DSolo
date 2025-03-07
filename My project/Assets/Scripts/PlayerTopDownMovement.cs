using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject projectilePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normalize to prevent diagonal speed boost
        movement = movement.normalized;
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void FixedUpdate()
    {
        // Apply movement
        rb.velocity = movement * moveSpeed;
    }

    void ShootProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
