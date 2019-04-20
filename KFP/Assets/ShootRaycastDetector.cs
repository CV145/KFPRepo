using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* GameObject: Player
- Has methods that take in a RaycastHit and can be called to trigger events on objects that were hit, for example reducing hits on an object or triggering a switch */

public class ShootRaycastDetector : MonoBehaviour
{
    //checks information retrieved by the raycast hit and calls methods accordingly
    public void DetectRaycastHit(RaycastHit2D hit)
    {
        string tag = hit.transform.gameObject.tag;
        GameObject collidedObject = hit.transform.gameObject;
        GameObject collidedObjectParent = collidedObject.transform.parent.gameObject;

        switch (tag)
        {
            case "Enemy":
                if (collidedObjectParent.GetComponent<DestructibleObject>())
                {
                    collidedObjectParent.GetComponent<DestructibleObject>().TakeDamage();
                }
                break;
        }
    }
}
