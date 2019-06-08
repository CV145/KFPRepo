using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingState : IState
{
    public void Enter()
    {
        Debug.Log("Starting State");

        TheManager.Game.GameTime(true);
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}
