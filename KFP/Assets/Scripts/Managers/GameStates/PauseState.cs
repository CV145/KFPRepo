using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState
{
    public void Enter()
    {
        Debug.Log("Pause state");
       
        //turns on the ui for pause menu
        TheManager.Ui.setPanelOnOff(TheManager.Ui.PausePanel, true);

        //stops game time
        TheManager.Game.GameTime(false);

    }
    public void Execute()
    {
        
    }

    public void Exit()
    {
        TheManager.Ui.setPanelOnOff(TheManager.Ui.PausePanel, false);
        
    }

   
    
}
