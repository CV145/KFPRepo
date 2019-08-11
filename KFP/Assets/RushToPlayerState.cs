using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Animator state with behavior for rushing towards the player's direction horiontally. 
/// The player is found using a tag. 
/// </summary>
public class RushToPlayerState : State
{
    GameObject player;
    Transform playerPos;
    Flipper flipper;
    [Header("How fast this object will move.")]
    [SerializeField] float moveSpeed;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform;
        if (self.GetComponent<Flipper>() != null)
        {
            flipper = self.GetComponent<Flipper>();
        }
        else
        {
            flipper = null;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (flipper != null)
            MovementBehaviors.HorizontalRushTowards(self.transform, playerPos, moveSpeed, flipper);
        else
            MovementBehaviors.HorizontalRushTowards(self.transform, playerPos, moveSpeed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
