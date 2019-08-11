using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterBrain : Brain
{
    float distanceFromPlayer;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        StateMachine.SetFloat("DistanceFromPlayer", GetAbsoluteDistanceFromPlayer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                StateMachine.SetTrigger("CollideWithPlayer");
                break;
        }
    }

    //could be static utility method
    private float GetAbsoluteDistanceFromPlayer()
    {
        return Mathf.Abs(Vector2.Distance(this.transform.position, player.position));
    }

    

}
