using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

/// <summary>
/// Enemy health. Enemies flash when they take damage. Requires a Flasher.
/// </summary>
/// 
[RequireComponent(typeof(RedFlasher))]
public class EnemyHealth : Health
{
    RedFlasher flasher; //serialize do not force
    [SerializeField] UnityEvent reactionWhenHealthIsZero;
    [SerializeField] bool flashWhenHurt = true;

    private void Start()
    {
        flasher = GetComponent<RedFlasher>();
    }

    /// <summary>
    /// Increase enemy health by a certain amount.
    /// </summary>
    /// <param name="increaseAmount"></param>
    public override void IncreaseHealth(int increaseAmount)
    {
        currentHealth += increaseAmount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// Decrease enemy health and flash using Flasher.
    /// </summary>
    /// <param name="decreaseAmount"></param>
    public override void DecreaseHealth (int decreaseAmount)
    {
        currentHealth -= decreaseAmount;
        flasher.FlashColor();
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            reactionWhenHealthIsZero.Invoke();
        }
    }
}
