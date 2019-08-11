using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component class with a Flip() method for flipping a game object. Also contains a bool
/// for checking whether the game object is facing right or not.
/// </summary>
public class Flipper : MonoBehaviour
{
    [Header("Set the default facing right here")]
    [SerializeField] bool facingRight;
    public bool FacingRight { get => facingRight; set => facingRight = value; }

    /// <summary>
    /// Call this method to flip the game object facing direction.
    /// </summary>
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
