using System.Collections;
using UnityEngine;

/// <summary>
/// Script for third eye lot lizards. These rush at the player and, if shot, will perform a back flip. They are only
/// vulnerable when in a back flip state. At a certain distance they begin shooting at the player.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(EnemyShotReceiver))]
public class CyclopsLotLizard : Enemy
{
    public enum States
    {
        RUN,
        KICK,
        BACKFLIP
    }
    [SerializeField] States currentState;
    Transform player;
    Flipper flipper;
    Mover mover;
    EnemyShotReceiver shotReceiver;
    [SerializeField] float moveSpeed;
    [SerializeField] float backflipSpeed;
    [SerializeField] float backflipRiseTime;
    float backflipTimeLeft = 0;
    float startingYPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        flipper = GetComponent<Flipper>();
        mover = GetComponent<Mover>();
        shotReceiver = GetComponent<EnemyShotReceiver>();
        backflipTimeLeft = backflipRiseTime;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case States.KICK:
                shotReceiver.ReduceHealthWhenShot = true;
                shotReceiver.EmitParticlesWhenShot = true;
                Kick();
                break;
            case States.RUN:
                shotReceiver.ReduceHealthWhenShot = false;
                shotReceiver.EmitParticlesWhenShot = false;
                Run();
                break;
            case States.BACKFLIP:
                shotReceiver.ReduceHealthWhenShot = true;
                shotReceiver.EmitParticlesWhenShot = true;
                Backflip();
                break;
        }
    }

    int kicks;

    private void Kick()
    {
        kicks++;
        if (kicks >= 420)
        {
            DialogHandler.PlayEnemyDialog(gameObject, "Dialog/Lot Lizard/Third Eye/lot lizard third eye attacking 1");
            kicks = 0;
        }
        if (!AnimController.GetBool("doingBackflip"))
        {
            AnimController.SetBool("doingMelee", true);
        }
        mover.MoveTo(player, moveSpeed);
    }

    private void Run()
    {
        if (flipper.FacingRight) mover.MoveRight(moveSpeed);
        else mover.MoveLeft(moveSpeed);
    }

    private void Backflip()
    {
        if (!AnimController.GetBool("doingBackflip"))
        {
            AnimController.SetBool("doingBackflip", true);
            StartCoroutine("LoseBackflipTime");
            startingYPos = transform.position.y;
        }

       
        //TODO add speed variables for each different movement
        if (backflipTimeLeft >= 0)
        {
            if (flipper.FacingRight)
            {
                mover.MoveLeft(backflipSpeed);
                mover.MoveUp(backflipSpeed);
            }
            else
            {
                mover.MoveRight(backflipSpeed);
                mover.MoveUp(backflipSpeed);
            }
        }
        else 
        {
            // print("going down");
            // print("starting Y pos: " + startingYPos);
            StopCoroutine("LoseBackflipTime");
            if (flipper.FacingRight)
            {
                mover.MoveLeft(backflipSpeed);
                mover.MoveDown(backflipSpeed);
            }
            else
            {
                mover.MoveRight(backflipSpeed);
                mover.MoveDown(backflipSpeed);
            }

            if (transform.position.y <= startingYPos)
            {
                //print("switching state back. current y pos: " + transform.position.y);
                transform.position = new Vector2(transform.position.x, startingYPos);
                backflipTimeLeft = backflipRiseTime;
                AnimController.SetBool("doingBackflip", false);
                currentState = States.RUN;
            }
        }

        
    }

    IEnumerator LoseBackflipTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            backflipTimeLeft--;
        }
    }

    /// <summary>
    /// Override current state by passing in a string with the name of the state to change to, case sensitive.
    /// </summary>
    /// <param name="stateName"></param>
    public void SetState(string stateName)
    {
        switch (stateName)
        {
            case "BACKFLIP":
                currentState = States.BACKFLIP;
                break;
            case "RUN":
                currentState = States.RUN;
                break;
            case "KICK":
                currentState = States.KICK;
                break;
        }
    }
}
