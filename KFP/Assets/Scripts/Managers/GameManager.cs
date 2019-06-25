using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateMachine GameState = new GameStateMachine();
    public bool GameActive;

    // Start is called before the first frame update
    void Start()
    {
        this.GameState.ChangeState(new StartingState());
    }

    // Update is called once per frame
    void Update()
    {
        this.GameState.ExecuteStateUpdate();
    }




    //------------Collection of Functions for setting the GameState---------//
    //sets the Game to a paused state
    public void SetPausedState()
    {

        this.GameState.ChangeState(new PauseState());

    }
    //sets the Game to a un-paused state
    public void SetGameStateUnpaused()
    {
        
        
            this.GameState.SwitchToPreviousState();
        
    }

    //Quits the game
    public void Quit()
    {
        // Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false; had to remove because it caused errors when building 
    }
    //sets the timeScale at 1.0 or 0.0
    public void GameTime(bool time)
    {
        var timeFloat = time ? 1.0f : 0.0f;
        Time.timeScale = timeFloat;
        GameActive = time;
    }
}
