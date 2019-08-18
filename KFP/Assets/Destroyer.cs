using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Component capable of destroying or disabling the game object it's attached to. 
/// </summary>
public class Destroyer : MonoBehaviour
{
    [SerializeField] UnityEvent onDestroy;

    /// <summary>
    /// Destroy the game object the Destroyer is attached to right after invoking a special event.
    /// </summary>
    public void DestroySelf()
    {
        onDestroy.Invoke();
        GameObject.Destroy(this.gameObject);
    }

    /// <summary>
    /// Destroy after a given time.
    /// </summary>
    /// <param name="time"></param>
    public void DestroySelf(float time)
    {
        onDestroy.Invoke();
        GameObject.Destroy(this.gameObject, time);
    }
}
