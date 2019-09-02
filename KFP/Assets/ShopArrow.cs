using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The shop arrow is an arrow that moves back and forth from the starting point to a target point. Needs a 
/// Mover to work. Horizontal movement only.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
public class ShopArrow : MonoBehaviour
{
    [SerializeField] float horizontalMoveDistance;
    [SerializeField] bool moveRight;
    [SerializeField] float moveToTargetTime;
    [SerializeField] float moveToStartTime;
    [SerializeField] float timeBetweenMoves;
    Vector2 startPos;
    [SerializeField] Vector2 targetPos;
    Mover mover;
    float moveToTargetSpeed;
    float moveToStartSpeed;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        mover = GetComponent<Mover>();
        targetPos = FindTargetPos();
        moveToTargetSpeed = CalculateMoveSpeed(startPos, targetPos, moveToTargetTime);
        moveToStartSpeed = CalculateMoveSpeed(targetPos, startPos, moveToStartTime);
        StartCoroutine(MovementLoop());
    }

    bool movingBack;
    IEnumerator MovementLoop()
    {
        while (true)
        {
            while (!movingBack)
            {
                print("moving to target");
                if (targetPos.x < startPos.x)
                {
                    mover.MoveLeft(moveToTargetSpeed);
                    if (transform.position.x <= targetPos.x)
                    {
                        movingBack = true;
                    }
                }
                else
                {
                    mover.MoveRight(moveToTargetSpeed);
                    if (transform.position.x >= targetPos.x)
                    {
                        movingBack = true;
                    }
                }
            }
            while (movingBack)
            {
                print("moving back to start");
                if (startPos.x < targetPos.x)
                {
                    mover.MoveLeft(moveToStartSpeed);
                    if (transform.position.x <= startPos.x)
                    {
                        movingBack = false;
                    }
                }
                else
                {
                    mover.MoveRight(moveToStartSpeed);
                    if (transform.position.x >= startPos.x)
                    {
                        movingBack = false;
                    }
                }
            }

            yield return new WaitForSeconds(timeBetweenMoves);
        }
    }

    private float CalculateMoveSpeed(Vector2 start, Vector2 end, float totalTimeToMove)
    {
        float totalDistance = Mathf.Abs(Vector2.Distance(start, end));
        int numOfTimesToMove = (int) (totalTimeToMove / timeBetweenMoves);
        return totalDistance / numOfTimesToMove;
    }

    private Vector2 FindTargetPos()
    {
        if (moveRight)
        {
            return new Vector2(startPos.x + horizontalMoveDistance, startPos.y);
        }
       else
        {
            return new Vector2(startPos.x - horizontalMoveDistance, startPos.y);
        }
    }
}
