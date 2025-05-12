using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 10f;
    public float health;

    private int damagePerSecond = 0;
    private float goopCount = 0;
    private bool gooped = true;
    private int boolTimer;

    protected Transform player;
    public float speed = 2f;
    public InteriorManager interiorManager;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        GameObject[] system = GameObject.FindGameObjectsWithTag("System");
        interiorManager = system[0].GetComponent<InteriorManager>();


        //override by SideMove and TopMove scripts
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = maxHealth;
        boolTimer = 60;
    }

    void FixedUpdate()
    {
        MoveTowardsPlayer();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        DamageOverTime();
    }

    protected virtual void MoveTowardsPlayer()
    {
        //override by SideMove and TopMove scripts
        if (player == null) return;
    }

//will keep this around if shit explodes
/*
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
    */

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //damagePerSecond isnt needed to be kept track of bc goopCount keeps track of the same thing (ie: damage per tick)
            //damagePerSecond += 1;
            goopCount++;
            Destroy(collision.gameObject);
        }
    }

    void DamageOverTime()
    {
            //hopefull gooped as a bool inst needed
            if (goopCount > 0)
            {
                //Gooped is a one time bool for now, just ensures that the coroutine doesn't stack. Will be more important when goop retrieval is implemented.
                gooped = false;
                //just deals damage over a set time same as ienumator but chips it away
                health -= goopCount/60;

                RemoveGoop();
            }  
    }

    void RemoveGoop(){
        //used to remove damage over a set time, same concept as the ienumator but not needing to manage the bullshit
        if(boolTimer >= 0){
            boolTimer--;
        }
        else{
            goopCount--;
            boolTimer = 60;
        }
    }
}