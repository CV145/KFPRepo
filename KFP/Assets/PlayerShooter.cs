﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component that handles player shooting. 
/// </summary>
/// 
public class PlayerShooter : Shooter
{
    [SerializeField] GameObject shotEffect;
    [SerializeField] LayerMask shootRaycastMask;
    [SerializeField] int attackPower = 1;
    [SerializeField] AudioSource shotSound;
    [SerializeField] AudioSource emptySound;
    [SerializeField] AudioSource reloadSound;
    AmmoUI ammoUI;
    ParticleSystem particles;

    private void Start()
    {
        particles = shotEffect.GetComponent<ParticleSystem>();
        ammoUI = FindObjectOfType<AmmoUI>(); //should only be one ammo UI
    }

    /// <summary>
    /// Shoot a raycast in the given position. Whatever's caught in there is what got shot.
    /// </summary>
    /// <param name="targetShotPos"></param>
    public void Shoot(Vector2 targetShotPos)
    {
        if (currentAmmo > 0)
        {
            shotEffect.transform.position = targetShotPos;
            particles.Play();
            Ray2D shootRay = new Ray2D(targetShotPos, targetShotPos);
            RaycastHit2D hitInfo = Physics2D.Raycast(shootRay.origin, shootRay.direction, 0.1f, shootRaycastMask);

            shotSound.Play();

            if (hitInfo.transform != null)
            {
                GameObject shotObject = hitInfo.transform.gameObject;
                shotObject.GetComponent<ShotReceiver>().ReceiveShot();

                try
                {
                    shotObject.GetComponent<EnemyShotReceiver>().CauseDamage(attackPower, targetShotPos);
                }
                catch (System.NullReferenceException)
                {
                    //object that was shot doesn't have an enemy shot receiver
                }
            }
            else
            {
                print("missed");
            }

            currentAmmo--;
            ammoUI.ReleaseBullet();
        }
        else
        {
            emptySound.Play();
            print("No ammo!");
        }
    }

    public void Reload()
    {
        base.Reload();
        reloadSound.Play();
        ammoUI.InitializeStack();
    }
}
