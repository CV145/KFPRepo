using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//in charge of player movement 
public class PlayerMovement : CharacterMovement
{
    Transform cameraTransform;
    [SerializeField] bool disableCameraFlipping;
    public bool DisableCameraFlipping { set => disableCameraFlipping = value; }

    private void Start()
    {
       cameraTransform = FindObjectOfType<Camera>().transform;
    }

    private new void Update()
    {
        base.Update();
        moveHorizontally();
        CheckCameraPosition();
    }

    //increases x position by move speed whenever called
    private void moveHorizontally()
    {
        if (AllowMovement && TheManager.Game.GameActive)
        {
            transform.position = new Vector2(this.transform.position.x + movementSpeed, transform.position.y);
        }
    }

    //check whether camera is greater than or less than x position to flip self
    private void CheckCameraPosition()
    {
        if (!disableCameraFlipping)
        {
            if (cameraTransform.position.x > selfPosition.x)
            {
                if (!facingRight)
                {
                    Flip();
                }
            }
            else if (cameraTransform.position.x < selfPosition.x)
            {
                if (facingRight)
                {
                    Flip();
                }
            }
        }
    }
}
