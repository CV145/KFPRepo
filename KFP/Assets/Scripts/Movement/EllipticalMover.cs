using Assets.Scripts.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Movement for moving an object in an elliptical shape.
/// </summary>
public class EllipticalMover : MonoBehaviour
{
    [SerializeField] Vector2 center;
    public Vector2 Center
    {
        get => center; set => center = value;
    }
    public bool AllowMovement { get => allowMovement; set => allowMovement = value; }
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }

    [SerializeField] bool allowMovement;
    [SerializeField] float movementSpeed;


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
                progress += MovementSpeed * Time.deltaTime;
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
