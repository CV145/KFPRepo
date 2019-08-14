using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that keeps track of health.
/// </summary>
public class Health : MonoBehaviour
{
    [SerializeField] int currentHealth;
    [SerializeField] int maxHealth;

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

    /// <summary>
    /// Increase health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }

    /// <summary>
    /// Lower health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    /// <summary>
    /// Increase max health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public void IncreaseMaxHealth (int amount)
    {
        maxHealth += amount;
    }
}
