using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player states include:
/// RUNNING
/// SHOOTING
/// </summary>
public enum PlayerStates
{
    RUNNING,
    SHOOTING
}

/// <summary>
/// This class gives the player character a collection of states that control animations and gameplay. For
/// example, the SHOOTING state puts the player character in its shooting animation and unlocks 
/// the ability to shoot. 
/// </summary>-
public class PlayerStateMachine : IStateMachine <PlayerStates>
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerShoot playerShoot;
    [SerializeField] PlayerStates currentState;

    /// <summary>
    /// The player's current state. Can be changed by calling setState.
    /// </summary>
    public PlayerStates CurrentState
    {
        get => currentState;
    }

    /// <summary>
    /// Set and change the current player state.
    /// </summary>
    /// <param name="stateToChangeTo"></param>
    public void setState(PlayerStates stateToChangeTo)
    {
        switch (stateToChangeTo)
        {
            case PlayerStates.RUNNING:
                currentState = PlayerStates.RUNNING;
                break;
            case PlayerStates.SHOOTING:
                currentState = PlayerStates.SHOOTING;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ActOnCurrentState();
    }

    private void ActOnCurrentState()
    {
        switch (currentState)
        {
            case PlayerStates.RUNNING:
                animator.SetBool("shotIdle", false);
                animator.SetBool("Shooting", false);
                animator.SetBool("Running", true);
                playerMovement.AllowMovement = true;
                playerShoot.AllowShooting = false;
                break;
            case PlayerStates.SHOOTING:
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
