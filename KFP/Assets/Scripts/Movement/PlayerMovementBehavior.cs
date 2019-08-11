using Assets.Scripts.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the player if movement is allowed. MovementSpeed checks whether to move left or right, if the value is 
/// negative or positive. The player can be set to flip directions depending on where the camera is.
/// </summary>
public class PlayerMovementBehavior : CharacterMovementState
{
    [SerializeField] bool flipWithCamera;
    /// <summary>
    /// Bool for whether the player can flip according to camera position or not.
    /// </summary>
    public bool FlipWithCamera { set => flipWithCamera = value; }

    private void Update()
    {
        MoveHorizontally();
        FlipWithCameraCheck();
    }

    private void MoveHorizontally()
    {
        if (AllowMovement && TheManager.Game.GameActive)
        {
            transform.position = new Vector2(this.transform.position.x + movementSpeed, transform.position.y);
        }
    }

    private void FlipWithCameraCheck()
    {
        Transform cameraTransform = FindObjectOfType<Camera>().transform;
        if (!flipWithCamera)
        {
            if (cameraTransform.position.x > transform.position.x)
            {
                if (!facingRight)
                {
                    Flip();
                }
            }
            else if (cameraTransform.position.x < transform.position.x)
            {
                if (facingRight)
                {
                    Flip();
                }
            }
        }
    }
}
