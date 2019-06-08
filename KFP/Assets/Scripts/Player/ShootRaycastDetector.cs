using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when a raycast from a player bullet hits something, this detector script determines what happens next

public class ShootRaycastDetector : MonoBehaviour
{
    //checks information retrieved by the raycast hit and calls methods accordingly
    public GameObject DetectRaycastHit(RaycastHit2D hit)
    {
        string tag = hit.transform.gameObject.tag;
        GameObject collidedObject = hit.transform.gameObject;
        GameObject collidedObjectParent = collidedObject.transform.parent.gameObject;

        switch (tag)
        {
            case "Enemy":
                //if (collidedObject.GetComponent<DestructibleObject>())
                //{
                    collidedObject.GetComponent<DestructibleObject>().TakeDamage();
                //}
                break;
            case "BreakableObject":
                collidedObject.GetComponent<DestructibleObject>().TakeDamage();
                break;
        }

        return collidedObjectParent;
    }
}
