using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//type of enemy movement where the enemy spots the player position on awakening and tries to rush toward it
public class ZombieRushMovement : EnemyMovement
{
    float facingDirection;

    private void OnEnable()
    {
        print("on enable called");
        FindPlayer();
        DetermineMoveDirection();
    }

    //Setup a direction to go to based on where the player is at
    private void DetermineMoveDirection()
    {
        if (player.transform.position.x < transform.position.x)
        {
            facingDirection = -1;
            if (facingRight)
            {
                Flip();
            }
        }
        else if (player.transform.position.x > transform.position.x)
        {
            facingDirection = 1;
            if (!facingRight)
            {
                Flip();
            }
        }
    }

    // Update is called once per frame - call methods only
    new void Update()
    {
        base.Update();
        Rush();
    }

    //Move towards the move direction
    private void Rush()
    {
        print("rush called");
        this.transform.position = new Vector2(
            transform.position.x + movementSpeed * facingDirection,
            transform.position.y
            );
    }
}
