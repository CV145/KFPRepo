using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script follows a specified object unless told not to
public class ObjectFocuser : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offset;
    [SerializeField] private bool focusOnTarget;
    public bool FocusOnObject { get; set; }

    private void LateUpdate()
    {
        moveToTarget();
    }

    //allows target to be changed
    public void SetTarget(GameObject newTarget)
    {
        target = newTarget.transform;
    }

    //temporarily set a target
    public void TemporarySetTarget(GameObject newTarget, float secs)
    {
        StartCoroutine(TemporarySetTargetCoroutine(newTarget, secs));
    }
    IEnumerator TemporarySetTargetCoroutine(GameObject newTarget, float secs)
    {
        Transform oldTarget = target;
        target = newTarget.transform;
        yield return new WaitForSeconds(secs);
        target = oldTarget;
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
