using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachines.States
{

    /// <summary>
    /// An Animator state with behavior for rushing towards the player's direction horiontally. 
    /// Direction to move is determined as soon as the state begins.
    /// </summary>
    public class RushToPlayerDirectionState : NPCState
    {
        //There needs to be another way to get move speed because here the same variables are used for all the
        //game objects using the animator this state is in
        //[Header("How fast this object will move.")]
        //[SerializeField] float moveSpeed;
        int direction;

        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            if (playerPos.position.x < self.transform.position.x)
            {
                direction = -1;
            }
            else if (playerPos.transform.position.x > self.transform.position.x)
            {
                direction = 1;
            }
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!debugDisableState)
            {
                //if (direction == -1) MovementBehaviors.MoveLeft(self.transform, moveSpeed);
                //else if (direction == 1) MovementBehaviors.MoveRight(self.transform, moveSpeed);
            }
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
}