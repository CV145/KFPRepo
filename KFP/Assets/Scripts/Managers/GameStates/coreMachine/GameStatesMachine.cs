using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine
{
    private IState CurrentState;
    private IState PreviousState;


    public void ChangeState(IState newState)
    {
        if (CurrentState != null) // null check if make sure there is a previous state to exit from
        {
            this.CurrentState.Exit(); //Exits the current state
        }



        this.PreviousState = this.CurrentState; //Sets the previous state

        this.CurrentState = newState; //sets the current state 

        this.CurrentState.Enter(); // Enter the new state
    }

    public void ExecuteStateUpdate()
    {
        var activeState = this.CurrentState;

        if (activeState != null)
        {
            activeState.Execute();
        }


    }

    public void SwitchToPreviousState()
    {
        this.CurrentState.Exit();
        this.CurrentState = this.PreviousState;
        this.CurrentState.Enter();
    }
}