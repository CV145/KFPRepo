using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract class for all computer based movement
//Holds information and abstract methods that will be used for all AI movement, such as
//a movement speed
//AI movement can be used on enemies, projectiles, the player, NPCs... etc
public abstract class AIMovement : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected bool move;
    public bool Move
    {
        get { return move; } set { move = value; }
    }
}
