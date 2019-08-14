using Assets.Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Game object: Firepoint
//Works to rotate the fire point to look at where the mouse is 

public class FirePointRotator : MonoBehaviour
{
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame - calls other methods
    void Update()
    {
        //UpdateFirePointRotation();
    }

    //Used to update the rotation of the firepoint to look at the current mouse position in world space
    public void UpdateFirePointRotation()
    {
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            //print("mouse position (world): " + mousePos);
            float angle = MathMethods.FindAngleBetweenPositions2D(this.transform.position, mousePos);
            //print("angle: " + angle);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

   
}
