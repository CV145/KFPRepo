using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that keeps track of health.
/// </summary>
public abstract class Health : MonoBehaviour
{
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int maxHealth;

    /// <summary>
    /// The current health. Can't go above max health or below zero.
    /// </summary>
    public int CurrentHealth { get => currentHealth; }
    /// <summary>
    /// The max capacity for current health.
    /// </summary>
    public int MaxHealth { get => maxHealth; }

    private void Start()
    {
        if (CurrentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }

    public abstract void IncreaseHealth(int amount);

    
    public abstract void DecreaseHealth(int amount);

    
}
