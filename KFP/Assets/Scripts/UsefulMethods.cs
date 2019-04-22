using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A collection of useful methods that can be reused
//Maybe script can be used in other projects too
//Useful for math experimenting/making utilities and tools - maybe from stuff learned from math classes
namespace carlos_methods
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
