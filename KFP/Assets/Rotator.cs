using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to rotate the object it's attached to.
/// </summary>
public class Rotator : MonoBehaviour
{
    [Header("Default variables")]
    [SerializeField] float rotationSpeed;
    Quaternion defaultRotation;

    public Quaternion DefaultRotation { get => defaultRotation; }

    private void Start()
    {
        defaultRotation = this.transform.localRotation;
    }

    /// <summary>
    /// Rotate the object using the default properties.
    /// </summary>
    public void Rotate()
    {
        this.transform.Rotate(0, 0, rotationSpeed);
    }

    /// <summary>
    /// Rotate the object using given properties.
    /// </summary>
    /// <param name="rotateClockwise"></param>
    /// <param name="rotationSpeed"></param>
    public void Rotate(bool rotateClockwise, float rotationSpeed)
    {
        this.transform.Rotate(0, 0, rotationSpeed);
    }

    /// <summary>
    /// Reset back to the initial rotation.
    /// </summary>
    public void Reset()
    {
        this.transform.localRotation = defaultRotation;
    }
}
