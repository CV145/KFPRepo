using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component for objects that shoot game object projectiles. It comes packed with a max/current ammo count and a reference
/// as to what to shoot. Requires a firePoint transform
/// to know where to shoot projectiles from.
/// </summary>
public class ProjectileShooter : MonoBehaviour
{
    [Header("Where projectiles spawn")]
    [SerializeField] Transform firePoint;
    [SerializeField] int currentAmmo = 0;
    [SerializeField] int maxAmmo;
    [SerializeField] bool hasInfiniteAmmo;
    [SerializeField] GameObject projectile;
    [SerializeField] bool randomizeStartingAmmo;

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

    private void Start()
    {

        if (hasInfiniteAmmo)
        {
            currentAmmo = 999;
            randomizeStartingAmmo = false;
        }
        else if (randomizeStartingAmmo)
        {
            currentAmmo = Random.Range(0, maxAmmo);
            hasInfiniteAmmo = false;
        }
        

        if (CurrentAmmo > MaxAmmo) CurrentAmmo = MaxAmmo;
    }

    /// <summary>
    /// Enables a projectile if current ammo > 0. Every call reduces current ammo count by 1.
    /// </summary>
    public void Fire()
    {
        if (CurrentAmmo > 0)
        {
            GameObject projectileRef = Instantiate(projectile);
            projectileRef.transform.position = firePoint.position;
            if (!hasInfiniteAmmo)
            CurrentAmmo--;
        }
    }

    /// <summary>
    /// Resets the current ammo count to the max ammo count, or size of preLoadedProjectiles array.
    /// </summary>
    public void Reload()
    {
        CurrentAmmo = MaxAmmo;
    }
}
