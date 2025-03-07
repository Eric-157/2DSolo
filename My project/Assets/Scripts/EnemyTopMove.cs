using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopMove : Enemy
{
    protected override void Start()
    {
        base.Start();  // Call base class Start method
    }

    protected override void MoveTowardsPlayer()
    {
        if (player == null) return;

        // Moves freely in all directions towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
