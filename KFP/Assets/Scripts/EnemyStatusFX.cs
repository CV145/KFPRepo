using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event triggers for whenever an enemy is affected by a certain 
/// powerup effect. Since each enemy behaves differently this gives
/// the freedom to customize effects for different enemy types
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Enemy))]
public class EnemyStatusFX : MonoBehaviour
{
    [SerializeField] UnityEvent OnFrozen;
    [SerializeField] UnityEvent OnSlowed;
    [SerializeField] UnityEvent OnPushed;
    [SerializeField] UnityEvent OnNoStatus;
    Mover mover;
    Enemy enemyScript;
    Push push;
    Animator animator;

    private class Push
    {
        float pushPower;
        public enum Direction
        {
            LEFT, RIGHT
        }
        Direction pushDirection;
        public Direction PushDirection { get => pushDirection; }
        public float PushPower { get => pushPower; }

        public Push(float pushPower, Vector2 enemyPos)
        {
            this.pushPower = pushPower;
            Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (playerPos.x > enemyPos.x)
                pushDirection = Direction.LEFT;
            else if (playerPos.x < enemyPos.x)
                pushDirection = Direction.RIGHT;
        }
    }

    private void Start()
    {
        mover = GetComponent<Mover>();
        enemyScript = GetComponent<Enemy>();
    }

    private void DisableEnemyScript()
    {
        enemyScript.enabled = false;
    }

    private void EnableEnemyScript()
    {
        enemyScript.enabled = true;
    }

    private void DisableAnimator()
    {
        try
        {
            animator = GetComponent<Animator>();
            animator.enabled = false;
        }
        catch (System.NullReferenceException)
        {
            //no animator
        }
    }

    private void EnableAnimator()
    {
        try
        {
            animator = GetComponent<Animator>();
            animator.enabled = true;
        }
        catch (System.NullReferenceException)
        {
            //no animator
        }
    }

    public void TriggerFreezeEffect(float secondsToLast)
    {
        mover.StatusFXMultiplier = 0;
        OnFrozen.Invoke();
        DisableEnemyScript();
        DisableAnimator();
        currentStatus = Statuses.FROZEN;
        statusTimer = secondsToLast;
    }

    public void TriggerSlowdownEffect(float speedMultiplier, float secondsToLast)
    {
        speedMultiplier = Mathf.Clamp(speedMultiplier, 0, 1);
        mover.StatusFXMultiplier = speedMultiplier;
        OnSlowed.Invoke();
        currentStatus = Statuses.SLOWED;
        statusTimer = secondsToLast;
    }

    public void TriggerPushEffect(float pushStrength, float secondsToLast)
    {
        push = new Push(pushStrength, this.transform.position);
        float timer = secondsToLast;
        OnPushed.Invoke();
        DisableEnemyScript();
        DisableAnimator();
        currentStatus = Statuses.PUSHED;
        statusTimer = secondsToLast;
    }

    enum Statuses
    {
        FROZEN,
        SLOWED,
        PUSHED,
        NONE
    }
    [SerializeField] Statuses currentStatus;

    float statusTimer;
    private void Update()
    {
        switch(currentStatus)
        {
            case Statuses.NONE:
                break;
            case Statuses.SLOWED:
                break;
            case Statuses.PUSHED:
               switch (push.PushDirection)
                {
                    // tilt away from player here 45 degrees?
                    case Push.Direction.LEFT:
                        mover.MoveLeft(push.PushPower);
                        break;
                    case Push.Direction.RIGHT:
                        mover.MoveRight(push.PushPower);
                        break;
                }
                break;
            case Statuses.FROZEN:
                break;
        } 
        
        if (statusTimer <= 0)
        {
            currentStatus = Statuses.NONE;
            mover.StatusFXMultiplier = 1;
            OnNoStatus.Invoke();
            EnableEnemyScript();
            EnableAnimator();
            push = null;
        }
        else
        {
            statusTimer -= Time.deltaTime;
            //print(statusTimer);
        }
    }
}
