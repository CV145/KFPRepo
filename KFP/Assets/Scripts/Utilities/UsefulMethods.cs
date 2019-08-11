using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A collection of useful methods that can be reused
namespace useful
{
    public class UsefulMethods : MonoBehaviour
    {
        //Finds the angle between the game object and some other position in 2D world space
        public static float FindAngleBetweenPositions2D(Vector2 currentObject, Vector2 otherObject)
        {
            Vector2 hypotenuse = otherObject - currentObject;
            return Mathf.Atan2(hypotenuse.y, hypotenuse.x) * Mathf.Rad2Deg;
        }
    }
}
