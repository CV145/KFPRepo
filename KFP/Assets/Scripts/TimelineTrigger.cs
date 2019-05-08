using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//triggers a timeline in CameraTimelines when any chosen tag enters object's trigger collider
[RequireComponent(typeof(BoxCollider2D))]
public class TimelineTrigger : MonoBehaviour
{
    CameraTimelines cameraTimelines;
    [Header("Objects with these tags activate trigger")]
    [SerializeField] string[] tags;
    [SerializeField] string timelineToActivate;

    private void Start()
    {
        cameraTimelines = FindObjectOfType<CameraTimelines>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(string otherTag in tags)
        {
            if (collision.gameObject.CompareTag(otherTag))
            {
                cameraTimelines.PlayTimeline(timelineToActivate);
            }
        }
    }
}
