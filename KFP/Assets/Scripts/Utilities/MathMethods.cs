using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A collection of useful math methods.
/// </summary>
namespace Assets.Scripts.Utilities
{
    public static class MathMethods : object
    {
        //Finds the angle between the game object and some other position in 2D world space
        public static float FindAngleBetweenPositions2D(Vector2 currentObject, Vector2 otherObject)
        {
            Vector2 hypotenuse = otherObject - currentObject;
            return Mathf.Atan2(hypotenuse.y, hypotenuse.x) * Mathf.Rad2Deg;
        }
    }
}
