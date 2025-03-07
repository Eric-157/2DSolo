using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopMove : Enemy
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void MoveTowardsPlayer()
    {
        if (player == null) return;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
