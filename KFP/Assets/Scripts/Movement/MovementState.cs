using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Movement
{

    /// <summary>
    /// Abstract class representing all states that handle movement.
    /// </summary>
    public abstract class MovementState : MonoBehaviour
    {
        [SerializeField] protected float movementSpeed;
        bool allowMovement;
        /// <summary>
        /// Property for whether the object can move or not.
        /// </summary>
        public bool AllowMovement
        {
            get => allowMovement;
            set => allowMovement = value;
        }
    }
}