using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlayerStates
{
    RUN,
    SHOOT,
    IDLE
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
    public Flipper flipper;
    public PlayerShooter shooter;
    Vector2 mousePos;
    bool isReloading;

    bool CanJump = true;

    public float JumpForce = 11;
    bool allowEnemySpawning;

    float StartY;

    public static GameObject PlayerObject;

    /// <summary>
    /// The current state of the player. Either RUN or SHOOT.
    /// </summary>
    public PlayerStates CurrentState { get => currentState; set => currentState = value; }

    public void SetState(string stateName)
    {
        switch (stateName)
        {
            case "RUN":
                currentState = PlayerStates.RUN;
                break;
            case "SHOOT":
                currentState = PlayerStates.SHOOT;
                break;
            case "IDLE":
                currentState = PlayerStates.IDLE;
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = gameObject;
        mover = GetComponent<Mover>();
        flipper = GetComponent<Flipper>();
        shooter = GetComponent<PlayerShooter>();
        SpawnSystem.SpawnEnemies(LevelSystem.LevelDifficulty,transform.position);
        SetState("SHOOT");

        StartY = transform.position.y;

        //Jump();
    }

    public void Jump()
    {
        if (!CanJump)
            return;

        CanJump = false;
        this.GetComponent<Rigidbody2D>().velocity += new Vector2(0,JumpForce);
        StartCoroutine(JumpTimeout());
    }

    public IEnumerator JumpTimeout()
    {
        yield return new WaitForSeconds(5);
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case PlayerStates.RUN:
                animator.SetBool("shootStateActive", false);
                animator.SetBool("idleStateActive", false);
                Run();
                break;
            case PlayerStates.SHOOT:
                animator.SetBool("shootStateActive", true);
                animator.SetBool("idleStateActive", false);
                CheckShot();
                break;
            case PlayerStates.IDLE:
                animator.SetBool("idleStateActive", true);
                animator.SetBool("idleStateActive", true);
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

    public void Flip()
    {
        flipper.Flip();
    }

    private void CheckShot()
    {
        if (PlayerShotBlocker.stopShooting)
            return;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && !isReloading)
        {
            if (shooter.CurrentAmmo > 0)
                animator.SetTrigger("fireTrigger");

            if (mousePos.x < transform.position.x && flipper.FacingRight)
            {
                flipper.Flip();
            }
            else if (mousePos.x > transform.position.x && !flipper.FacingRight)
            {
                flipper.Flip();
            }

            shooter.Shoot(mousePos); //dont call when clicking on a UI button...
        }
        else
        {
            isReloading = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Peso>() != null)
        {
            PesoSystem.Pesos += 1;
        }
    }

    private void OnMouseDown()
    {
        isReloading = true;
        shooter.Reload();
    }
}
