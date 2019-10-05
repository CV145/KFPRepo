using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script follows a specified object unless told not to
public class CameraFocuser : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offset;
    [SerializeField] private bool followTarget;
    [SerializeField] private bool applyOffset;
    GameObject player;
    public bool ApplyOffset { set { applyOffset = value; } }
    public static bool FollowTarget;

    public void SetApplyOffset(bool value)
    {
        applyOffset = value;
    }
    public void SetFollowTarget(bool value)
    {
        followTarget = value;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void LateUpdate()
    {
        if (followTarget)
        {
            moveToTarget();
        }
    }

    //allows target to be changed
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    //set player as target
    public void SetPlayerAsTarget()
    {
        applyOffset = true;
        target = player.transform;
    }

    //temporarily set a target for a specified time before invoking CameraLookEvent's onCameraFinishLooking event
    public void QuickSetTargetEvent(GameObject newTarget, float secs, CameraLookEvent caller)
    {
        StartCoroutine(QuickSetTargetCoroutine(newTarget, secs, caller));
    }
    IEnumerator QuickSetTargetCoroutine(GameObject newTarget, float secs, CameraLookEvent caller)
    {
        Transform oldTarget = target;
        target = newTarget.transform;
        yield return new WaitForSeconds(secs);
        caller.onCameraFinishLooking.Invoke();
    }

    //always follow the target
    private void moveToTarget()
    {
        Vector3 desiredPosition;
        if (applyOffset)
        {
             desiredPosition = target.position + offset;
        }
        else
        {
            desiredPosition = target.position;
        }
            Vector3 smoothedPosition = Vector3.Lerp(transform.position,
                desiredPosition, smoothSpeed * Time.deltaTime); //smoothSpeed: 0 is transform.position, 1 is desiredPosition
            transform.position = smoothedPosition;
    }
}
