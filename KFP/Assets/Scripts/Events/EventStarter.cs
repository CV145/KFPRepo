using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//script shows event responses in the inspector and has methods for invoking them
public class EventStarter : MonoBehaviour
{
    [SerializeField] protected UnityEvent eventResponses;

    protected void InvokeResponses()
    {
        eventResponses.Invoke();
    }
}
