using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//script shows event responses in the inspector and has methods for invoking them
//[System.Serializable] public class UnityEventFloat : UnityEvent<float> { }
public abstract class EventStarter : MonoBehaviour
{
    [SerializeField] private UnityEvent eventResponses;

    public void InvokeResponses()
    {
        eventResponses.Invoke();
    }
}
