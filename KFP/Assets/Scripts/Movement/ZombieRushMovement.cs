using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* GameObject: Any enemy that mindlessly tries to rush at the player
 * Movement type that moves left or right forever, initially trying to rush the player
 * Enemies with this movement type should be destroyed eventually after they pass the player
 * Movement is very basic and does not account for jumping over obstacles
 */

public class ZombieRushMovement : EnemyMovement
{
    float facingDirection;

    private void Start()
    {
        FindPlayer();
        DetermineMoveDirection();
    }

    //Setup a direction to go to based on where the player is at
    private void DetermineMoveDirection()
    {
        if (player.transform.position.x < transform.position.x) { facingDirection = -1; }
        else if (player.transform.position.x > transform.position.x) { facingDirection = 1; }
    }

    // Update is called once per frame - call methods only
    void Update()
    {
        Rush();
    }

    //Move towards the move direction
    private void Rush()
    {
        this.transform.position = new Vector2(
            transform.position.x + movementSpeed * facingDirection,
            transform.position.y
            );
    }
}
