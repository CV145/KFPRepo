using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class UtilityMethods : object
    {
        /// <summary>
        /// Gets the absolute distance between obj1 and obj2.
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static float GetAbsoluteDistance(Transform obj1, Transform obj2)
        {
            return Mathf.Abs(Vector2.Distance(obj1.position, obj2.position));
        }
    }
}