using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//makes an object jump automatically when in front of an obstacle
public class AutoJump : MonoBehaviour
{
    bool inAir;

    //Method called to make object jump
    public void jump()
    {
        //jumpPress = true;

        if (!inAir)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 3000);
        }
    }


    //Method checks if object is in midair by testing y velocity speeds
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

}
