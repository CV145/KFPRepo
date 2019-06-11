using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PlayerShoot deals with everything shooting related

[RequireComponent(typeof(ShootRaycastDetector))]
[RequireComponent(typeof(PlayerStats))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] float rayLength;
    [SerializeField] LineRenderer line;
    [SerializeField] float bulletLineDisplayTime;
    [SerializeField] FirePointRotation firePointRotation;
    [SerializeField] LayerMask shootRaycastMask;
    [SerializeField] RaycastHit2D hit;
    [SerializeField] GameObject bullet;
    [SerializeField] protected bool allowShooting;
    [SerializeField] protected bool activeShot;
    [SerializeField] bool reloadAttempt;
    PlayerStats stats;
    ShootRaycastDetector detector;

    public bool ActiveShots
    {
        get => activeShot;
        set => activeShot = value;

    }

    public bool AllowShooting
    {
        get => allowShooting;
        set => allowShooting = value;
    }

    private void Start()
    {
        detector = GetComponent<ShootRaycastDetector>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame - only calls methods
    void Update()
    {
        ShootCheck();
    }

    private void OnMouseDown()
    {
        reloadAttempt = true;

        //It's 13 because when player clicks on KFP they will shoot one bullet as they reload and would start with 11 instead of 12.
        if (TheManager.Game.GameActive && allowShooting)
        {
            stats.ammoCount = 12;
        }
    }

    //Checks if mouse clicked or not to call ShootRaycast()
    private void ShootCheck()
    {
        if(TheManager.Game.GameActive && Input.GetMouseButtonDown(0) && stats.ammoCount > 0 && allowShooting)
        {
           
            if (reloadAttempt == false)
            {
                activeShot = true;
                stats.ammoCount -= 1;
                firePointRotation.UpdateFirePointRotation();
                StartCoroutine(ShootRaycast());
                SpawnBullet(5);

                
            } else
            {
                reloadAttempt = false;
            }
         
        }
    }

   

    //creates a raycast starting at the firePoint's position, going in the direction of its forward vector, and for a distance of rayLength. If that raycast hits something, a RaycastHit is sent to ShootRaycastDetector
    IEnumerator ShootRaycast()
    {
        Ray2D bulletRay = new Ray2D(firePoint.transform.position, firePoint.transform.right);
        hit = Physics2D.Raycast(bulletRay.origin, bulletRay.direction, rayLength, shootRaycastMask); 
        if (hit)
        {
            
            line.SetPosition(0, firePoint.transform.position);
            line.SetPosition(1, hit.point);
           var hitobject =  detector.DetectRaycastHit(hit);
            
            
        }
        else
        {
            line.SetPosition(0, firePoint.transform.position);
            line.SetPosition(1, firePoint.position + firePoint.right * rayLength);
        }

        line.enabled = true;
        yield return new WaitForSeconds(bulletLineDisplayTime);
        line.enabled = false;

    }

    private void SpawnBullet(float speed)
    {

            GameObject bulletTrailObject = Instantiate(bullet, firePoint.position + firePoint.right, firePointRotation.transform.rotation);
            Destroy(bulletTrailObject, 1.5f);


    }
}
