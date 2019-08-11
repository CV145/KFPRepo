using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A unique Brain is given to anything that has AI behaviors. Brains are in charge of
/// communicating with an Animator to determine what state it should currently be playing.
/// All Brain objects have an Animator reference. The Animator functions as a state machine.
/// </summary>
public abstract class Brain : MonoBehaviour
{
    [SerializeField] Animator stateMachine;
    /// <summary>
    /// An Animator reference that functions as a state machine.
    /// </summary>
    public Animator StateMachine { get => stateMachine; }
}
