using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    /// <summary>
    /// Abstract class for all character-related movement states. 
    /// </summary>
    public abstract class CharacterMovementState : MovementState
    {
        [SerializeField] protected bool facingRight;

        /// <summary>
        /// Flips the right to face the opposite direction.
        /// </summary>
        protected void Flip()
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}