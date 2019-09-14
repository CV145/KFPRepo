using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component for objects that shoot game object projectiles. It comes packed with a max/current ammo count and a reference477// as to what to shoot. Requires a firePoint transform
/// to know where to shoot projectiles from.
/// </summary>
public class ProjectileShooter : Shooter
{
    [Header("Where projectiles spawn")]
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject projectile;
    [SerializeField] bool randomizeStartingAmmo;

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
    /// Shoots a projectile if current ammo > 0. Every call reduces current ammo count by 1, if ammo is not infinite.
    /// </summary>
    public void Fire()
    {
        if (CurrentAmmo > 0 || hasInfiniteAmmo)
        {
            GameObject projectileRef = Instantiate(projectile);
            projectileRef.transform.position = firePoint.position;
            if (!hasInfiniteAmmo)
            CurrentAmmo--;
        }
    }
}
