using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains reuseable static behaviors related to movement, moving, jumping, etc. 
/// </summary>
public class MovementBehaviors : MonoBehaviour
{
    /// <summary>
    /// Moves a given object to the left by a move speed amount.
    /// </summary>
    /// <param name="objToMove"></param>
    /// <param name="moveSpeed"></param>
    public static void MoveLeft(Transform objToMove, float moveSpeed)
    {
        objToMove.position = new Vector2(
                    objToMove.position.x + moveSpeed * -1,
                    objToMove.position.y
                    );
    }

    /// <summary>
    /// Moves a given object to the right by a move speed amount.
    /// </summary>
    /// <param name="objToMove"></param>
    /// <param name="moveSpeed"></param>
    public static void MoveRight (Transform objToMove, float moveSpeed)
    {
        objToMove.position = new Vector2(
                    objToMove.position.x + moveSpeed,
                    objToMove.position.y
                    );
    }

    /// <summary>
    /// Moves a given object towards a target object on the x-axis by a move speed amount. 
    /// </summary>
    /// <param name="objToMove"></param>
    /// <param name="targetObj"></param>
    /// <param name="moveSpeed"></param>
    public static void HorizontalRushTowards(Transform objToMove, Transform targetObj, float moveSpeed)
    {
        int facingDirection = 0;

        if (targetObj.position.x < objToMove.position.x)
        {
            facingDirection = -1;
        }
        else if (targetObj.transform.position.x > objToMove.position.x)
        {
            facingDirection = 1;
        }

        objToMove.position = new Vector2(
                    objToMove.position.x + moveSpeed * facingDirection,
                    objToMove.position.y
                    );
    }

    /// <summary>
    /// Moves a given object towards a target object on the x-axis by a move speed amount. 
    /// If the object to move has a Flipper component, it can be passed in to flip the object.
    /// </summary>
    /// <param name="objToMove"></param>
    /// <param name="targetObj"></param>
    /// <param name="moveSpeed"></param>
    /// <param name="flipper"></param>
    public static void HorizontalRushTowards(Transform objToMove, Transform targetObj, float moveSpeed, Flipper flipper)
    {
        int facingDirection = 0;
        
        if (targetObj.position.x < objToMove.position.x)
        {
            facingDirection = -1;
            if (flipper.FacingRight)
            {
                flipper.Flip();
            }
        }
        else if (targetObj.transform.position.x > objToMove.position.x)
        {
            facingDirection = 1;
            if (!flipper.FacingRight)
            {
                flipper.Flip();
            }
        }

        objToMove.position = new Vector2(
                    objToMove.position.x + moveSpeed * facingDirection,
                    objToMove.position.y
                    );
    }


}
