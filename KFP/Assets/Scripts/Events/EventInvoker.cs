using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//guarantees all events have an InvokeResponses() method
public abstract class EventInvoker : MonoBehaviour
{
    public abstract void InvokeResponses();
}
