using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//allows events to be invoked when an object with a specified tag from the array collides in a trigger box collider
[RequireComponent(typeof(BoxCollider2D))]
public abstract class TriggerEvent : EventInvoker
{
    [Header("The types of objects that collide with trigger:")]
    [SerializeField] string[] triggerTags = { "Player" };
    BoxCollider2D collider;

    protected void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string tag in triggerTags)
        {
            if (collision.CompareTag(tag))
            {
                InvokeResponses();
            }
        }
    }
}
