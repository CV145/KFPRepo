using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : AIMovement
{
    [SerializeField] protected bool facingRight;

    //switch the direction the object is facing
    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
