using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component class with a Flip() method for flipping a game object. Contains a bool
/// for checking whether the game object is facing right or not. 
/// </summary>
public class Flipper : MonoBehaviour
{
    [Header("Set the default facing right here")]
    [SerializeField] bool facingRight;
    /// <summary>
    /// Whether the object is currently facing right or not.
    /// </summary>
    public bool FacingRight { get => facingRight; set => facingRight = value; }
 

    [Header("If not null, object will flip to face this.")]
    [SerializeField] Transform objToFace = null;
    /// <summary>
    /// If set to something, the object will flip to face the given transform.
    /// </summary>
    public Transform ObjToFace { get => objToFace; set => objToFace = value; }

    [Header("Breathing space before flipping relative to objToFace")]
    [SerializeField] float offsetForObjToFace;

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

    private void Update()
    {
        if (ObjToFace != null)
        {
            FaceObject();
        }
    }

    private void FaceObject()
    {
        if (ObjToFace.position.x - offsetForObjToFace < transform.position.x)
        {
            if (FacingRight)
            {
                Flip();
            }
        }
        else if (ObjToFace.transform.position.x + offsetForObjToFace > transform.position.x)
        {
            if (!FacingRight)
            {
                Flip();
            }
        }
    }
}
