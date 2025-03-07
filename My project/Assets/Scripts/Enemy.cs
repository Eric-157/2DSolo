using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public static float damagePerSecond = 0f; // Shared across all enemies

    protected Transform player;
    public float speed = 2f;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (player == null) return;
        // Will be overridden in subclasses for custom movement logic
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        damagePerSecond += damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
}