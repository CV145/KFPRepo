using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Prefabs.LevelObjects.Events
{
    /// <summary>
    /// Event that triggers when clicking on the object's box collider.
    /// </summary>
    public class ClickEvent : MonoBehaviour
    {
        [SerializeField] UnityEvent onClick;
        [SerializeField] UnityEvent onClickRelease;

        private void OnMouseDown()
        {
            onClick.Invoke();
        }

        private void OnMouseUp()
        {
            onClickRelease.Invoke();
        }
    }
}