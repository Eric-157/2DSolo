using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopMove : Enemy
{

    
    //Extends Enemy.cs, for non-movement code check there
    /*
    protected override void Start()
    {
        base.Start();
    }
    */

    protected override void MoveTowardsPlayer()
    {
        if(!interiorManager.interior){
            if (player == null) return;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            if(!spriteRenderer.enabled){
                spriteRenderer.enabled = true;
            }
        }
        else{
            spriteRenderer.enabled = false;
        }
        
    }
}
