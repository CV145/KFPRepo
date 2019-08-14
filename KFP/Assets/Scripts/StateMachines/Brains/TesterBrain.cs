using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States
{
    RUNTOPLAYER,
    RUNFROMPLAYER
}
public class TesterBrain : Enemy
{
    float distanceFromPlayer;
    Transform player;
    [SerializeField] States currentState;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //StateMachine.SetFloat("DistanceFromPlayer", GetAbsoluteDistanceFromPlayer());

        switch (currentState)
        {
            case States.RUNTOPLAYER:
                RunToPlayer();
                break;
            case States.RUNFROMPLAYER:
                RunFromPlayer();
                break;
        }
    }

    private void RunToPlayer()
    {

    }

    private void RunFromPlayer()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                AnimController.SetTrigger("CollideWithPlayer");
                break;
        }
    }
}
