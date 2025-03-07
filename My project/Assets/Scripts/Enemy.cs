using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;

    private int damagePerSecond = 0;
    private float goopCount = 0;
    private bool gooped = true;

    protected Transform player;
    public float speed = 2f;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        else if (goopCount > 0 && gooped == true)
        {
            gooped = false;
            StartCoroutine(DamageOverTime());
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (player == null) return;
        // Will be overridden in subclasses for custom movement logic
    }

    IEnumerator DamageOverTime()
    {
        while (goopCount > 0)
        {
            health -= damagePerSecond;
            yield return new WaitForSeconds(1.0f);
        }
        gooped = true;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            damagePerSecond += 1;
            goopCount++;
            Destroy(collision.gameObject);
        }
    }
}