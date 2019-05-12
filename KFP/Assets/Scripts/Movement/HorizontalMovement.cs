using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moves an object horizontally when a move bool is true

public class HorizontalMovement : AIMovement
{
    bool facingRight;
    float horizontalMove;

    private void Update()
    {
        moveHorizontally();
    }

    //increases x position by move speed whenever called
    private void moveHorizontally()
    {
        if (move)
        {
            horizontalMove = movementSpeed;
            transform.position = new Vector2(this.transform.position.x + movementSpeed, transform.position.y);
        }
    }

    // Switch the direction the player is facing
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
