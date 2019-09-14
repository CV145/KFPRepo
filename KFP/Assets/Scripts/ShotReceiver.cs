using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Component used on anything that receives player shots and reacts to them.
/// </summary>
public class ShotReceiver : MonoBehaviour
{
    [Header("Used for changes in behavior")]
    [SerializeField] protected UnityEvent reactionWhenShot;

    /// <summary>
    /// Plays an event when called.
    /// </summary>
    public void ReceiveShot()
    {
        reactionWhenShot.Invoke();
    }
}
