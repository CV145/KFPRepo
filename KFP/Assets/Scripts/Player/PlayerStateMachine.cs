using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//controls animation and AI states for player such as running and shooting
public class PlayerStateMachine : StateMachine
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShoot playerShoot;

    [SerializeField]
    public enum playerStates
    {
        RUNNING,
        SHOOTING
    }
    [SerializeField] playerStates currentState;
    public playerStates CurrentState
    {
        get => currentState;
    }
    
    

    
    public void SetState(string stateName)
    {
        switch (stateName)
        {
            case "RUNNING":
                currentState = playerStates.RUNNING;
                break;
            case "SHOOTING":
                currentState = playerStates.SHOOTING;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case playerStates.RUNNING:
                
                animator.SetBool("shotIdle", false);
                animator.SetBool("Shooting", false);
                animator.SetBool("Running", true);
                playerMovement.AllowMovement = true;
                playerShoot.AllowShooting = false;
                break;
            case playerStates.SHOOTING:
                animator.SetBool("Running", false);
                animator.SetBool("shotIdle", true);
                playerMovement.AllowMovement = false;
                playerShoot.AllowShooting = true;
                playerShoot.ActiveShots = AnimatorActiveShot(playerShoot.ActiveShots);
                break;
        }
    }
    private bool AnimatorActiveShot(bool ActiveShot)
    {
       
        if (ActiveShot == true)
        {
            animator.SetBool("shotIdle", false);
            animator.SetBool("Shooting", true);
            return false;
        }
        else
        {
            animator.SetBool("shotIdle", true);
            animator.SetBool("Shooting", false);
            return false;
        }

       
    }
}
