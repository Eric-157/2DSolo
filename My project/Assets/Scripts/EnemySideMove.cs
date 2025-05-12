using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideMove : Enemy
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
        if (player == null) return;
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
