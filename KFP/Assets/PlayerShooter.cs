using System.Collections;
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
    ParticleSystem particles;

    private void Start()
    {
        particles = shotEffect.GetComponent<ParticleSystem>();
    }

    /// <summary>
    /// Shoot a raycast in the given position. Whatever's caught in there is what got shot.
    /// </summary>
    /// <param name="shootPos"></param>
    public void Shoot(Vector2 shootPos)
    {
        shotEffect.transform.position = shootPos;
        //spawn particle effect in shootPos
        particles.Play();

        //if an object is shootable it takes damage when shot and flashes red
        Ray2D shootRay = new Ray2D(shootPos, shootPos);
        RaycastHit2D hitInfo = Physics2D.Raycast(shootRay.origin, shootRay.direction, 0.1f, shootRaycastMask);

        if (hitInfo.transform != null)
        {
            GameObject shotObject = hitInfo.transform.gameObject;

            switch (shotObject.tag)
            {
                case "Enemy":
                    shotObject.GetComponent<EnemyHealth>().DecreaseHealth(1);
                    break;
            }
        }
        else
        {
            print("missed");
        }
    }
}
