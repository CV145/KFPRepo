using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Brain for all Crackhead enemies. The Crackhead runs towards the player. If it collides with the player it'll
/// rob pesos.
/// </summary>
/// 
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Mover))]
public class Crackhead : Enemy
{
    public enum States
    {
        RUN
    }

    Transform player;
    Flipper flipper;
    Mover mover;
    [SerializeField] States currentState;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        flipper = GetComponent<Flipper>();
        mover = GetComponent<Mover>();
    }

    private void Update()
    {
            switch (currentState)
            {
                case States.RUN:
                    Run();
                    break;
            }
    }

    private void Run()
    {
        if (!flipper.FacingRight)
        {
            mover.MoveLeft(moveSpeed);
        }
        else if (flipper.FacingRight)
        {
            mover.MoveRight(moveSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                //rob pesos and damage player here
                print("crackhead robbed player");
                break;
        }
    }
}
