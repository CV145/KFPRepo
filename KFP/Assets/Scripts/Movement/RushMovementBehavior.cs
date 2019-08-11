using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    /// <summary>
    /// A kind of enemy movement where the enemy looks for the player's position and rushes toward it. Used by enemies
    /// such as the Crackhead.
    /// </summary>
    public class RushMovementBehavior : EnemyMovementBehavior
    {
        float facingDirection;
        /// <summary>
        /// This is the direction the enemy is facing. This depends on where the player is located. 
        /// It's either 1 for right or -1 for left.
        /// </summary>
        public float FacingDirection { get => facingDirection; }

        private void OnEnable()
        {
            //print("on enable called");
            FindPlayer();
            DetermineMoveDirection();
        }

        private void DetermineMoveDirection()
        {
            if (player.transform.position.x < transform.position.x)
            {
                facingDirection = -1;
                if (facingRight)
                {
                    Flip();
                }
            }
            else if (player.transform.position.x > transform.position.x)
            {
                facingDirection = 1;
                if (!facingRight)
                {
                    Flip();
                }
            }
        }

        void Update()
        {
            Rush();
        }

        public void Rush()
        {
            if (TheManager.Game.GameActive)
            {
                //print("rush called");
                transform.position = new Vector2(
                    transform.position.x + movementSpeed * facingDirection,
                    transform.position.y
                    );
            }
            else
            {
                print("The game isn't active. Cannot rush.");
            }
        }
    }
}