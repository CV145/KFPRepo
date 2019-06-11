using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//moves an object in a circular path
public class EllipticalMovement : AIMovement
{
    [SerializeField] Vector2 center;
    public Vector2 Center
    {
        get => center; set => center = value;
    }

    [SerializeField] float width;
    [SerializeField] float height;
    [Range(0f, 1f)]
    [SerializeField] float progress = 0f;
    [SerializeField] int numberOfCycles;
    [SerializeField] bool infiniteCycles;
    public UnityEvent onCyclesFinished;

    private void Start()
    {
        center = transform.position;
        StartCoroutine(MoveThroughPoints());
    }

    //makes a new point on ellipse based off progress value
    private void SetPosition()
    {
            float angle = progress * 360 * Mathf.Deg2Rad;
            float x = width * Mathf.Sin(angle);
            float y = height * Mathf.Cos(angle);
            Vector2 point = new Vector2(x + center.x, y + center.y);
        this.transform.position = point;
    }

    IEnumerator MoveThroughPoints()
    {
        while (AllowMovement)
        {
            if (numberOfCycles > 0 || infiniteCycles)
            {
                progress += movementSpeed * Time.deltaTime;
                //progress %= 1f;
                if (progress >= 1f)
                {
                    progress = 0f;
                    if (!infiniteCycles)
                    numberOfCycles--;
                }
                SetPosition();
                yield return null;
            }
            if (numberOfCycles <= 0 && !infiniteCycles)
            {
                onCyclesFinished.Invoke();
            }
        }
    }
}
