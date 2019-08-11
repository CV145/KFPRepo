using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Movement
{

    /// <summary>
    /// Abstract class representing all enemy movement.
    /// </summary>
    public abstract class EnemyMovementBehavior : CharacterMovementState
    {
        protected GameObject player;

        /// <summary>
        /// Finds the player using a tag.
        /// </summary>
        protected void FindPlayer()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
}