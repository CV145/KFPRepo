using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object that destroys itself when hitting a specified tagged object
[RequireComponent(typeof(BoxCollider2D))]
public class SelfDestructibleObject : DestructibleObject
{
    [SerializeField] string[] collisionObjectTags;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (string tag in collisionObjectTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                DisableObject();
            }
        }
    }
}
