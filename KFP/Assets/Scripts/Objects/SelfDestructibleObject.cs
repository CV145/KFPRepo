using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object that destroys itself when hitting aany of the objects with the tag in collisionObjectTags
public class SelfDestructibleObject : DestructibleObject
{
    [SerializeField] string[] collisionObjectTags;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in collisionObjectTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {

                // //if the object is colliding withthe player it will play a glitch
                // if (collision.gameObject.tag == "Player")
                // {
                //     /* I normally would hard sode something like this but the use of tags
                //     Makes things like this almost unaviodable. This will deffinately need to be refactored */

                //     TheManager.Camera.glitch();                   
                // }


                DisableObject();
            }
        }
    }
}
