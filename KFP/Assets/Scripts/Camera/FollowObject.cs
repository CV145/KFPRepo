using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script follows a specified object unless told not to
public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offset;
    [SerializeField] private bool focusOnTarget;
    public bool FocusOnObject { get; set; }
    CameraTimelines cameraTimelines;

    private void Start()
    {
        cameraTimelines = GetComponent<CameraTimelines>();
    }

    private void LateUpdate()
    {
        moveToTarget();
    }

    //allows target to be changed
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    //always follow the target
    private void moveToTarget()
    {
        if (focusOnTarget)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //smoothSpeed: 0 is transform.position, 1 is desiredPosition
            transform.position = smoothedPosition;
        }
    }
}
