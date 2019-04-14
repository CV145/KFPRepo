using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script in charge of moving and jumping the player
/* Player moves automatically forward unless told not to
 * */

public class PlayerMovement : MonoBehaviour
{
    bool facingRight;
    bool movingForward;
    bool inAir;
    [SerializeField] private float moveSpeed;
    float horizontalMove;


    private void Update()
    {
        moveHorizontally();
    }

    //increases x position of player by move speed whenever called
    private void moveHorizontally()
    {
        horizontalMove = moveSpeed;
        transform.position = new Vector2(this.transform.position.x + moveSpeed, transform.position.y);
    }



    //Method called to make the player jump
    public void jump()
    {
        //jumpPress = true;

        if (!inAir)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);
        }
    }


    //Method checks if the player is in midair by testing y velocity speeds
    void MidairCheck()
    {
        if (!inAir && Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.y) > 0.05f)
        {
            inAir = true;
        }
        else if (inAir && this.GetComponent<Rigidbody2D>().velocity.y == 0.0f)
        {
            inAir = false;
            //if (jumpPress) jump();
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
