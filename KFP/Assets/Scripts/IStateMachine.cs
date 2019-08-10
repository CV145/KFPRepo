using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All state machines need to have states and methods for setting states.
/// The states can be any generic type, but should be implemented as an enum.
/// </summary>
public interface IStateMachine <StatesEnum> 
{
    /// <summary>
    /// The current state needs to exist and be retrieveable.
    /// </summary>
    StatesEnum CurrentState
    {
        get;
    }

    /// <summary>
    /// A method that sets the current state.
    /// </summary>
    /// <param name="stateToChangeTo"></param>
    void setState(StatesEnum stateToChangeTo);
}
