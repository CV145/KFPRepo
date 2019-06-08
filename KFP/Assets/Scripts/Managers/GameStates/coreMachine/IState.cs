using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState 
{
    void Enter(); //What the intial state wants to do

    void Execute(); //What the state does during the update

    void Exit(); // what the state does when it exits

}
