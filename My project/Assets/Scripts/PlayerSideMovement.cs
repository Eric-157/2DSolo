using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerSideMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canMoveLeft = true;
    private bool canMoveRight = true;
    public GameObject backgroundParent;
    public GameObject foregroundParent;
    private bool isForegroundActive = true;
    public float activeAlpha = 1f;
    public float inactiveAlpha = 0.5f;
    public GameObject projectilePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        if ((moveInput < 0 && canMoveLeft) || (moveInput > 0 && canMoveRight))
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }
        else // Reduce sliding when no input is given
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Foreground/Background flipper
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            ToggleLayers();
        }

        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // checks wether the collider is right or left of player then sets
            Vector2 contactPoint = collision.contacts[0].normal;
            if (contactPoint.x > 0)
            {
                canMoveLeft = false;
            }
            else if (contactPoint.x < 0)
            {
                canMoveRight = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMoveLeft = true;
            canMoveRight = true;
        }
    }

    // Foreground/Background flipper takes every child collider component of the parent object set by the variable and sets it's active state.
    private void ToggleLayers()
    {
        isForegroundActive = !isForegroundActive;
        foreach (Collider2D col in backgroundParent.GetComponentsInChildren<TilemapCollider2D>())
        {
            col.enabled = !isForegroundActive;
        }
        foreach (Collider2D col in foregroundParent.GetComponentsInChildren<TilemapCollider2D>())
        {
            col.enabled = isForegroundActive;
        }
        foreach (Collider2D col in backgroundParent.GetComponentsInChildren<BoxCollider2D>())
        {
            col.enabled = !isForegroundActive;
        }
        foreach (Collider2D col in foregroundParent.GetComponentsInChildren<BoxCollider2D>())
        {
            col.enabled = isForegroundActive;
        }
        // Alpha layer calls to showcase the foreground background switch, for now temporary.
        SetLayerAlpha(backgroundParent, !isForegroundActive ? activeAlpha : inactiveAlpha);
        SetLayerAlpha(foregroundParent, isForegroundActive ? activeAlpha : inactiveAlpha);
    }

    // Temporary alpha layer code to showcase and troubleshoot the foreground/background layers, not intended for final game.
    private void SetLayerAlpha(GameObject parent, float alpha)
    {
        foreach (SpriteRenderer sr in parent.GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = sr.color;
            color.a = alpha;
            sr.color = color;
        }
    }

    void ShootProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}