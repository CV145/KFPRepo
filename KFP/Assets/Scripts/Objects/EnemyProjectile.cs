using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : ZombieRushMovement
{
    //The ZombieRushMovement script also works for projectiles.
    private void OnEnable()
    {
        //print("on enable called");
        FindPlayer();
        DetermineMoveDirection();
    }

    new void Update()
    {
        base.Update();
        Rush(TheManager.Game.GameActive);
    }
        
}