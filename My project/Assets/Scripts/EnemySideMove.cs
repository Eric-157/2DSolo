using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideMove : Enemy
{
    protected override void Start()
    {
        base.Start();  // Call base class Start method
    }

    protected override void MoveTowardsPlayer()
    {
        if (player == null) return;

        // Side-scroller typically moves along the X-axis towards the player
        // The Y-axis movement could be implemented if the enemy needs to jump or fall
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y); // Match the X, but not Y
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
