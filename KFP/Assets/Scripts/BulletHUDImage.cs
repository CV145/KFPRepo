using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet UI images fly off the screen after being used and have a method that can be called to trigger
/// that. They store their initial position as soon as the game begins, and can be reset to that position 
/// using a method too.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Rotator))]
public class BulletHUDImage : MonoBehaviour
{
    [SerializeField] Vector2 initialPosition;
    Mover mover;
    Rotator rotator;
    [SerializeField] float flySpeed;
    [SerializeField] float timeBeforeDisabling;
    bool isFlying;

    /// <summary>
    /// Set bullet isFlying to true.
    /// </summary>
    public void SetIsFlying()
    {
        isFlying = true;
        //StartCoroutine(Deactivate());
    }

    /// <summary>
    /// Stop the deactivation coroutine.
    /// </summary>
    public void DeactivateCountdown()
    {
        StopCoroutine(Deactivate());
    }

    private void Start()
    {
        //initialPosition = this.transform.localPosition;
        //initialPosition = this.transform.position; //world space
        mover = GetComponent<Mover>();
        rotator = GetComponent<Rotator>();
    }

    private void Update()
    {
        if (isFlying)
        {
            FlyAway();
        }
    }

    private void FlyAway()
    {
        mover.MoveDown(flySpeed);
        mover.MoveLeft(flySpeed);
        rotator.Rotate();
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(timeBeforeDisabling);
        this.transform.gameObject.SetActive(false);
    }

    /// <summary>
    /// Resets back to its default position.
    /// </summary>
    public void Reset()
    {
        StopCoroutine(Deactivate());
        isFlying = false;
        this.transform.localPosition = initialPosition;

        if (rotator != null)
        {
            rotator.Reset();
        } else
        {
            //Debug.LogError("Rotator was null!");
        }
    }
}
