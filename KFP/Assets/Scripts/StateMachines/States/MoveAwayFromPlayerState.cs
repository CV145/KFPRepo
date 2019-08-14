using Assets.Scripts.StateMachines.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection
{
    MOVE_RIGHT, MOVE_LEFT
}
/// <summary>
/// This state will move the game object away from the player in a chosen or passed-in direction. 
/// </summary>
public class MoveAwayFromPlayerState : NPCState
{
    [Header("How fast this object will move.")]
    [SerializeField] float moveSpeed;
    [Header("Direction to move to.")]
    [SerializeField] MoveDirection moveDirection;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //switch (moveDirection)
        //{
        //    case MoveDirection.MOVE_RIGHT:
        //        if (flipper != null && !flipper.FacingRight) flipper.Flip();
        //        MovementBehaviors.MoveRight(self.transform, moveSpeed);
        //        break;
        //    case MoveDirection.MOVE_LEFT:
        //        if (flipper != null && flipper.FacingRight) flipper.Flip();
        //        MovementBehaviors.MoveLeft(self.transform, moveSpeed);
        //        break;
        //}
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
