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
    [SerializeField] float quickSetTargetTime = 1f;
    GameObject player;
    public bool FollowTarget { set { followTarget = value; } }
    public float QuickSetTargetTime { set { quickSetTargetTime = value; } }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //not good if more than one player may need to change
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

    //temporarily set a target for quickSetTargetTime, then back to player
    public void QuickSetTarget(GameObject newTarget)
    {
        StartCoroutine(QuickSetTargetCoroutine(newTarget));
    }
    IEnumerator QuickSetTargetCoroutine(GameObject newTarget)
    {
        target = newTarget.transform;
        yield return new WaitForSeconds(quickSetTargetTime);
        target = player.transform;
    }

    //always follow the target
    private void moveToTarget()
    {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //smoothSpeed: 0 is transform.position, 1 is desiredPosition
            transform.position = smoothedPosition;
    }
}
