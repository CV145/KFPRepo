using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extension of Health component. PlayerHealth plays a camera glitch when reduced.
/// </summary>
/// 
[RequireComponent(typeof(GlitchEffectMaker))]
public class PlayerHealth : Health
{
    GlitchEffectMaker glitchEffectMaker;

    private void Start()
    {
        glitchEffectMaker = GetComponent<GlitchEffectMaker>();
    }

    /// <summary>
    /// Increase max health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
    }

    /// <summary>
    /// Lower health by a given amount. For players, causes a glitch effect.
    /// </summary>
    /// <param name="amount"></param>
    public override void DecreaseHealth(int amount)
    {
        if (currentHealth > 0)
        {
            glitchEffectMaker.MakeGlitch();
            currentHealth -= amount;
        }
        else
        currentHealth = 0;
    }

    /// <summary>
    /// Increase health by a given amount.
    /// </summary>
    /// <param name="amount"></param>
    public override void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
}
