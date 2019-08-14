using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains reuseable static behaviors related to movement, moving, jumping, etc. 
/// </summary>
public static class MovementBehaviors : object
{
    

    /// <summary>
    /// Moves a given object towards a target object on the x-axis by a move speed amount. 
    /// </summary>
    /// <param name="objToMove"></param>
    /// <param name="targetObj"></param>
    /// <param name="moveSpeed"></param>
    public static void HorizontalMoveTowards(Transform objToMove, Transform targetObj, float moveSpeed)
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


}
