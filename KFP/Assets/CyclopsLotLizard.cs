using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for third eye lot lizards. These rush at the player and, if shot, will perform a back flip. They are only
/// vulnerable when in a back flip state. At a certain distance they begin shooting at the player.
/// </summary>
/// 
[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(ProjectileShooter))]
public class CyclopsLotLizard : Enemy
{
    public enum States
    {
        RUN,
        SHOOT,
        BACKFLIP
    }
    [SerializeField] States currentState;
    Transform player;
    Flipper flipper;
    Mover mover;
    ProjectileShooter shooter;
    [SerializeField] float moveSpeed;
    [SerializeField] float backflipSpeed;
    [SerializeField] float rangeToShootPlayer;
    [SerializeField] float intervalBetweenFiring;
    [SerializeField] float backflipRiseTime;
    float backflipTimeLeft;
    float absoluteDistanceFromPlayer;
    float startingYPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        flipper = GetComponent<Flipper>();
        mover = GetComponent<Mover>();
        shooter = GetComponent<ProjectileShooter>();
        //flipper.ObjToFace = player;
        backflipTimeLeft = backflipRiseTime;

        //currentState = States.RUN;
    }

    // Update is called once per frame
    void Update()
    {
        absoluteDistanceFromPlayer = UtilityMethods.GetAbsoluteDistance(transform, player);

        if (absoluteDistanceFromPlayer <= rangeToShootPlayer && currentState == States.RUN)
        {
            currentState = States.SHOOT;
            //print("within shooting range and has ammo");
        }

        switch (currentState)
        {
            case States.SHOOT:
                Shoot();
                break;
            case States.RUN:
                Run();
                break;
            case States.BACKFLIP:
                Backflip();
                break;
        }
    }

    private void Shoot()
    {
        if (backflipTimeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            AnimController.SetTrigger("fireTrigger");
            shooter.Fire();
            backflipTimeLeft = intervalBetweenFiring;
            StartCoroutine("LoseTime");
        }
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
            StartCoroutine("LoseTime");
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
            StopCoroutine("LoseTime");
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

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            backflipTimeLeft--;
        }
    }
}
