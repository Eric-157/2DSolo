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
        //override by SideMove and TopMove scripts
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            //Gooped is a one time bool for now, just ensures that the coroutine doesn't stack. Will be more important when goop retrieval is implemented.
            gooped = false;
            StartCoroutine(DamageOverTime());
        }
    }

    protected virtual void MoveTowardsPlayer()
    {
        //override by SideMove and TopMove scripts
        if (player == null) return;
    }

    IEnumerator DamageOverTime()
    {
        //Damage per Second, sets goop true if count is 0, currently never reaches that point, will only happen once goop retrieval is implemented.
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