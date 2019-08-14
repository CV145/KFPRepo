using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All enemies have animator controller and health references.
/// </summary>
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] Animator animator;
    /// <summary>
    /// An Animator reference that functions as a state machine.
    /// </summary>
    public Animator AnimController { get => animator; }
    [SerializeField] Health health;
    /// <summary>
    /// The Health script attached to the enemy.
    /// </summary>
    public Health Health { get => health; }
}
