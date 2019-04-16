using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is in charge of shooting a raycast starting at the player's position and going towards the direction of where mouse was clicked/screen tapped

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float range;


    // Update is called once per frame
    void Update()
    {
        ShootCheck();
    }

    //When the mouse is down, shoot a raycast
    private void ShootCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print("click");
            SpawnRaycast();
        }
    }

   //This method spawns a raycast from the player's position to the point mouse was in when clicked
    private void SpawnRaycast()
    {
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 10f);
        print("mouse position in world: " + mousePos);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, mousePos, out hit, range))
        {
            Debug.DrawRay(transform.position, mousePos, Color.white, 1f, false);
            print(hit.transform.name);
        }
    }
}
