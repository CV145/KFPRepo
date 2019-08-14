using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.StateMachines.States
{

    /// <summary>
    /// Abstract state for all NPC characters. 
    /// NPC states have references to the player and its position, as well as an optional Flipper.
    /// This information is initialized as soon as the state starts.
    /// </summary>
    public abstract class NPCState : State
    {
        protected GameObject player;
        protected Transform playerPos;
        protected Flipper flipper;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, animatorStateInfo, layerIndex);
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
    }
}