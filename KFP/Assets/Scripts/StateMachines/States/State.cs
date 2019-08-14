using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A generic AI state that all other states should inherit from. This stores a reference
/// to the game object that the states will act on, which is retrieved from the animator using 
/// these states.
/// Generally it's in these states where most of the actual behaviors will be run, which are called
/// from static behavior methods from classes such as MovementBehaviors.
/// </summary>
public abstract class State : StateMachineBehaviour
{
    protected GameObject self;
    [Header("Disable state update calls")]
    [SerializeField] protected bool debugDisableState;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (self ==  null)
        self = animator.gameObject;
        // Call behavior methods here in children classes
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    // Call behavior methods here in children classes
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Call behavior methods here in children classes
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
