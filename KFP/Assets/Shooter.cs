using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shooters inherit from this class.
/// </summary>
public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected int currentAmmo = 0;
    [SerializeField] protected int maxAmmo;
    [SerializeField] protected bool hasInfiniteAmmo;

    /// <summary>
    /// How much ammo is left before having to reload.
    /// </summary>
    public int CurrentAmmo { get => currentAmmo; set => currentAmmo = value; }
    /// <summary>
    /// Current ammo can't go higher than this. Initialized as size of projectiles array.
    /// </summary>
    public int MaxAmmo { get => maxAmmo; }
    /// <summary>
    /// Retrieve whether this shooter has infinite current ammo or not.
    /// </summary>
    public bool HasInfiniteAmmo { get => hasInfiniteAmmo; }

    /// <summary>
    /// Resets the current ammo count to the max ammo count, or size of preLoadedProjectiles array.
    /// </summary>
    public void Reload()
    {
        CurrentAmmo = MaxAmmo;
        //print("reloaded");
    }
}
