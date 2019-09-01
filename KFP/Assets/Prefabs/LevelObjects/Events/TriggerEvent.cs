using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Prefabs.LevelObjects.Events
{
    /// <summary>
    /// Script for a trigger event, triggered whenever anything tagged in the collision tags enters the
    /// box collider.
    /// </summary>
    [RequireComponent(typeof(BoxCollider2D))]
    public class TriggerEvent : MonoBehaviour
    {
        [SerializeField] UnityEvent onTriggerEnter;
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
                    //print("collide");
                    onTriggerEnter.Invoke();
                }
            }
        }
    }
}