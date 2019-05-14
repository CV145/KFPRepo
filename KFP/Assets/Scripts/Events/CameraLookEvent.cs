using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//invokes events that make a camera look at something
//can be invoked from either a public call or trigger collision
[Serializable]
public class LookAtEvent : UnityEvent<GameObject, float, CameraLookEvent> { } 

public class CameraLookEvent : TriggerEvent
{
    CameraFocuser focuser;
    [SerializeField] GameObject objectToLookAt;
    [SerializeField] float secondsToLook;
    [Header("What to do beside moving camera")]
    [SerializeField] LookAtEvent cameraLookResponse; 
    public UnityEvent onCameraFinishLooking;

    public GameObject ObjectToLookAt { get { return objectToLookAt; } set { objectToLookAt = value; } }
    public float SecondsToLook { get { return secondsToLook; } set { secondsToLook = value; } }

    private new void Start()
    {
        base.Start();
        focuser = FindObjectOfType<CameraFocuser>();
        cameraLookResponse.AddListener(focuser.QuickSetTargetEvent);
    }

    override
    public void InvokeResponses()
    {
        cameraLookResponse.Invoke(objectToLookAt, secondsToLook, this);
    }
}
