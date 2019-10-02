using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that has methods for moving the game object it's attached to.
/// </summary>
public class Mover : MonoBehaviour
{
    float statusFXMultiplier = 1;
    public static bool gameIsPaused;

    /// <summary>
    /// A multiplier that affects move speed
    /// </summary>
    public float StatusFXMultiplier { set => statusFXMultiplier = value; }

    /// <summary>
    /// Moves self to the left by a move speed amount.
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void MoveLeft(float moveSpeed)
    {
        if (gameIsPaused)
        {
            moveSpeed *= 0;
        }
        moveSpeed *= statusFXMultiplier;

        this.transform.position = new Vector2(
                    transform.position.x + moveSpeed * -1,
                    transform.position.y
                    );
    }

    /// <summary>
    /// Moves self to the right by a move speed amount.
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void MoveRight(float moveSpeed)
    {
        if (gameIsPaused)
        {
            moveSpeed *= 0;
        }
        moveSpeed *= statusFXMultiplier;

        this.transform.position = new Vector2(
                    transform.position.x + moveSpeed,
                    transform.position.y
                    );
    }

    /// <summary>
    /// Moves self up by a move speed amount.
    /// </summary>
    public void MoveUp(float moveSpeed)
    {
        if (gameIsPaused)
        {
            moveSpeed *= 0;
        }
        moveSpeed *= statusFXMultiplier;

        this.transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y + moveSpeed
                    );
    }

    /// <summary>
    /// Moves self down by a move speed amount.
    /// </summary>
    /// <param name="moveSpeed"></param>
    public void MoveDown(float moveSpeed)
    {
        if (gameIsPaused)
        {
            moveSpeed *= 0;
        }
        moveSpeed *= statusFXMultiplier;

        this.transform.position = new Vector2(
                    transform.position.x,
                    transform.position.y - moveSpeed
                    );
    }

    /// <summary>
    /// Moves self towards a target position by a move speed amount.
    /// </summary>
    /// <param name="targetPos"></param>
    public void MoveTo(Transform targetPos, float moveSpeed)
    {
        if (!targetPos)
            return;

        if (gameIsPaused)
        {
            moveSpeed *= 0;
        }
        moveSpeed *= statusFXMultiplier;

        this.transform.position = Vector2.MoveTowards(transform.position, targetPos.position, moveSpeed * Time.deltaTime);
    }
}
