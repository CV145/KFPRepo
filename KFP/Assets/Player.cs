using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlayerStates
{
    RUN,
    SHOOT
}

/// <summary>
/// The main script for the player behavior.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(PlayerShooter))]
public class Player : MonoBehaviour
{
    [SerializeField] PlayerStates currentState;
    [SerializeField] float moveSpeed;
    [SerializeField] Animator animator;
    Mover mover;
    Flipper flipper;
    PlayerShooter shooter;

    /// <summary>
    /// The current state of the player. Either RUN or SHOOT.
    /// </summary>
    public PlayerStates CurrentState { get => currentState; set => currentState = value; }


    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        flipper = GetComponent<Flipper>();
        shooter = GetComponent<PlayerShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case PlayerStates.RUN:
                animator.SetBool("shootStateActive", false);
                Run();
                break;
            case PlayerStates.SHOOT:
                animator.SetBool("shootStateActive", true);
                CheckShot();
                break;
        }
    }

    private void Run()
    {
        if (flipper.FacingRight)
        {
            mover.MoveRight(moveSpeed);
        }
        else
        {
            mover.MoveLeft(moveSpeed);
        }
    }

    private void CheckShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("fireTrigger");
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x < transform.position.x && flipper.FacingRight)
            {
                flipper.Flip();
            }
            else if (mousePos.x > transform.position.x && !flipper.FacingRight)
            {
                flipper.Flip();
            }
            shooter.Shoot(mousePos);
        }
    }
}
