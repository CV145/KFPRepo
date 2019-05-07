using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 GameObject: Player
Works with and requires: ShootRaycastDetector
- Creates a raycast when mouse is clicked/screen touched from the fire point and towards its forward vector direction (which should be where the mouse/finger is) for a fixed, variable length from inspector. If the raycast hits something it returns a RaycastHit, which is then passed to ShootRaycastDetector. A line is also drawn and created to represent the raycast in-game*/

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
    PlayerStats stats;
    ShootRaycastDetector detector;

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

    //Checks if mouse clicked or not to call ShootRaycast()
    private void ShootCheck()
    {
        if (Input.GetMouseButtonDown(0) && stats.ammoCount > 0)
        {
            stats.ammoCount -= 1;
            firePointRotation.UpdateFirePointRotation();
            StartCoroutine(ShootRaycast());
        }

        if (Input.GetMouseButtonUp(0))
        {

            stats.ammoCount = 12;

        }
    }

    //creates a raycast starting at the firePoint's position, going in the direction of its forward vector, and for a distance of rayLength. If that raycast hits something, a RaycastHit is sent to ShootRaycastDetector
    IEnumerator ShootRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.transform.position, firePoint.transform.right, rayLength, shootRaycastMask); 
        if (hit)
        {
            line.SetPosition(0, firePoint.transform.position);
            line.SetPosition(1, hit.point);
            detector.DetectRaycastHit(hit);
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
}
