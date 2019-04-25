using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] Text ammoCountText;
    [SerializeField] PlayerShoot pS;
    void Start()
    {
        ammoCountText.text = "Ammo : 12/12";

    }

    void Update()
    {
        //Display the current ammo count every frame.
        ammoCountText.text = "Ammo :" + " " + pS.ammoCount + "/12";

    }
}
