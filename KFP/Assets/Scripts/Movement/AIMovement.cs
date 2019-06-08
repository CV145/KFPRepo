using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Holds information and abstract methods that will be used for all AI movement, such as
//a movement speed
public abstract class AIMovement : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected bool allowMovement;
    [SerializeField] protected bool facingRight;
    protected Transform selfTransform;
    protected Vector3 selfPosition;
    public bool AllowMovement
    {
        get => allowMovement;
        set => allowMovement = value; 
    }

    protected void Update()
    {
        selfTransform = this.gameObject.transform;
        selfPosition = selfTransform.position;
        
    }

    //switch the direction the object is facing
    protected void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    protected void Movement(bool activeState)
    {
        allowMovement = activeState;

       
    }
}
