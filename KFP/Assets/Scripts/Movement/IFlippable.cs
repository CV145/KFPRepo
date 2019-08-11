using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Whatever implements this interface is guaranteed to have a facingRight bool property. This is needed
/// by some movement behaviors, notably MovementBehaviors.Flip(). The object to flip needs to be a GameObject which is 
/// why the Self property needs to be implemented.
/// </summary>
public interface IFlippable 
{
    /// <summary>
    /// A bool that checks whether an object is facing right or not.
    /// </summary>
     bool FacingRight
    {
        get; set;
    }

    /// <summary>
    /// A reference to IFlippable's self, which is the game object that will be flipped by MovementBehaviors.Flip().
    /// </summary>
    GameObject Self
    {
        get;
    }
}
